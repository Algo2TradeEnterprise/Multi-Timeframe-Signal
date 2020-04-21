Imports System.Threading
Imports Utilities.Network
Imports System.Net
Imports System.Net.Http

Public Class DataFetcher

#Region "Events/Event handlers"
    Public Event DocumentDownloadComplete()
    Public Event DocumentRetryStatus(ByVal currentTry As Integer, ByVal totalTries As Integer)
    Public Event Heartbeat(ByVal msg As String)
    Public Event WaitingFor(ByVal elapsedSecs As Integer, ByVal totalSecs As Integer, ByVal msg As String)
    'The below functions are needed to allow the derived classes to raise the above two events
    Protected Overridable Sub OnDocumentDownloadComplete()
        RaiseEvent DocumentDownloadComplete()
    End Sub
    Protected Overridable Sub OnDocumentRetryStatus(ByVal currentTry As Integer, ByVal totalTries As Integer)
        RaiseEvent DocumentRetryStatus(currentTry, totalTries)
    End Sub
    Protected Overridable Sub OnHeartbeat(ByVal msg As String)
        RaiseEvent Heartbeat(msg)
    End Sub
    Protected Overridable Sub OnWaitingFor(ByVal elapsedSecs As Integer, ByVal totalSecs As Integer, ByVal msg As String)
        RaiseEvent WaitingFor(elapsedSecs, totalSecs, msg)
    End Sub
#End Region

#Region "Enum"
    Enum DataType
        EOD = 1
        Intraday
    End Enum
#End Region

    Private ReadOnly _cts As CancellationTokenSource
    Private ReadOnly _instrument As InstrumentDetails
    Private ReadOnly _fetchDataWithAPI As Boolean
    Private ReadOnly _fetchDataWithoutAPI As Boolean
    Private ReadOnly _tradingDate As Date
    Private ReadOnly _settings As SignalSettings
    Public Sub New(ByVal canceller As CancellationTokenSource,
                   ByVal processInstrument As InstrumentDetails,
                   ByVal fetchDataWithAPI As Boolean,
                   ByVal fetchDataWithoutAPI As Boolean,
                   ByVal tradingDate As Date,
                   ByVal settings As SignalSettings)
        _cts = canceller
        _instrument = processInstrument
        _fetchDataWithAPI = fetchDataWithAPI
        _fetchDataWithoutAPI = fetchDataWithoutAPI
        _tradingDate = tradingDate
        _settings = settings
    End Sub

#Region "Historical Fetch"
    Private Async Function GetHistoricalDataAsync(ByVal instrumentToken As String, ByVal tradingSymbol As String,
                                                  ByVal startDate As Date, ByVal endDate As Date,
                                                  ByVal typeOfData As DataType, ByVal zerodhaDetails As ZerodhaLogin,
                                                  ByVal fetchDataWithAPI As Boolean, ByVal fetchDataWithoutAPI As Boolean,
                                                  ByVal canceller As CancellationTokenSource) As Task(Of Dictionary(Of Date, Payload))
        canceller.Token.ThrowIfCancellationRequested()
        Dim ret As Dictionary(Of Date, Payload) = Nothing
        Dim AWSZerodhaEODHistoricalURL As String = "https://kitecharts-aws.zerodha.com/api/chart/{0}/day?oi=1&api_key=kitefront&access_token=K&from={1}&to={2}"
        Dim AWSZerodhaIntradayHistoricalURL As String = "https://kitecharts-aws.zerodha.com/api/chart/{0}/minute?oi=1&api_key=kitefront&access_token=K&from={1}&to={2}"
        Dim ZerodhaEODHistoricalURL As String = "https://kite.zerodha.com/oms/instruments/historical/{0}/day?&oi=1&from={1}&to={2}"
        Dim ZerodhaIntradayHistoricalURL As String = "https://kite.zerodha.com/oms/instruments/historical/{0}/minute?oi=1&from={1}&to={2}"
        Dim ZerodhaHistoricalURL As String = Nothing
        Select Case typeOfData
            Case DataType.EOD
                If fetchDataWithAPI Then
                    ZerodhaHistoricalURL = ZerodhaEODHistoricalURL
                ElseIf fetchDataWithoutAPI Then
                    ZerodhaHistoricalURL = AWSZerodhaEODHistoricalURL
                End If
            Case DataType.Intraday
                If fetchDataWithAPI Then
                    ZerodhaHistoricalURL = ZerodhaIntradayHistoricalURL
                ElseIf fetchDataWithoutAPI Then
                    ZerodhaHistoricalURL = AWSZerodhaIntradayHistoricalURL
                End If
        End Select
        canceller.Token.ThrowIfCancellationRequested()
        If ZerodhaHistoricalURL IsNot Nothing AndAlso instrumentToken IsNot Nothing AndAlso instrumentToken <> "" Then
            Dim historicalDataURL As String = String.Format(ZerodhaHistoricalURL, instrumentToken, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"))
            'OnHeartbeat(String.Format("Fetching historical Data: {0}", historicalDataURL))
            Dim historicalCandlesJSONDict As Dictionary(Of String, Object) = Nothing

            ServicePointManager.Expect100Continue = False
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            ServicePointManager.ServerCertificateValidationCallback = Function(s, Ca, CaC, sslPE)
                                                                          Return True
                                                                      End Function

            If fetchDataWithAPI Then
                Dim proxyToBeUsed As HttpProxy = Nothing
                Using browser As New HttpBrowser(proxyToBeUsed, Net.DecompressionMethods.GZip Or DecompressionMethods.Deflate Or DecompressionMethods.None, New TimeSpan(0, 1, 0), canceller)
                    'AddHandler browser.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                    'AddHandler browser.Heartbeat, AddressOf OnHeartbeat
                    'AddHandler browser.WaitingFor, AddressOf OnWaitingFor
                    'AddHandler browser.DocumentRetryStatus, AddressOf OnDocumentRetryStatus

                    Dim headers As New Dictionary(Of String, String)
                    headers.Add("Host", "kite.zerodha.com")
                    headers.Add("Accept", "*/*")
                    headers.Add("Accept-Encoding", "gzip, deflate")
                    headers.Add("Accept-Language", "en-US,en;q=0.9,hi;q=0.8,ko;q=0.7")
                    headers.Add("Authorization", String.Format("enctoken {0}", zerodhaDetails.ENCToken))
                    headers.Add("Referer", "https://kite.zerodha.com/static/build/chart.html?v=2.4.0")
                    headers.Add("sec-fetch-mode", "cors")
                    headers.Add("sec-fetch-site", "same-origin")
                    headers.Add("Connection", "keep-alive")

                    canceller.Token.ThrowIfCancellationRequested()
                    Dim l As Tuple(Of Uri, Object) = Await browser.NonPOSTRequestAsync(historicalDataURL,
                                                                                            HttpMethod.Get,
                                                                                            Nothing,
                                                                                            False,
                                                                                            headers,
                                                                                            True,
                                                                                            "application/json").ConfigureAwait(False)
                    canceller.Token.ThrowIfCancellationRequested()
                    If l IsNot Nothing AndAlso l.Item2 IsNot Nothing Then
                        historicalCandlesJSONDict = l.Item2
                    End If

                    'RemoveHandler browser.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                    'RemoveHandler browser.Heartbeat, AddressOf OnHeartbeat
                    'RemoveHandler browser.WaitingFor, AddressOf OnWaitingFor
                    'RemoveHandler browser.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                End Using
            ElseIf fetchDataWithoutAPI Then
                Dim proxyToBeUsed As HttpProxy = Nothing
                Using browser As New HttpBrowser(proxyToBeUsed, Net.DecompressionMethods.GZip, New TimeSpan(0, 1, 0), canceller)
                    'AddHandler browser.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                    'AddHandler browser.Heartbeat, AddressOf OnHeartbeat
                    'AddHandler browser.WaitingFor, AddressOf OnWaitingFor
                    'AddHandler browser.DocumentRetryStatus, AddressOf OnDocumentRetryStatus

                    canceller.Token.ThrowIfCancellationRequested()
                    Dim l As Tuple(Of Uri, Object) = Await browser.NonPOSTRequestAsync(historicalDataURL,
                                                                                        HttpMethod.Get,
                                                                                        Nothing,
                                                                                        True,
                                                                                        Nothing,
                                                                                        True,
                                                                                        "application/json").ConfigureAwait(False)
                    canceller.Token.ThrowIfCancellationRequested()
                    If l IsNot Nothing AndAlso l.Item2 IsNot Nothing Then
                        historicalCandlesJSONDict = l.Item2
                    End If

                    'RemoveHandler browser.DocumentDownloadComplete, AddressOf OnDocumentDownloadComplete
                    'RemoveHandler browser.Heartbeat, AddressOf OnHeartbeat
                    'RemoveHandler browser.WaitingFor, AddressOf OnWaitingFor
                    'RemoveHandler browser.DocumentRetryStatus, AddressOf OnDocumentRetryStatus
                End Using
            End If

            If historicalCandlesJSONDict IsNot Nothing AndAlso historicalCandlesJSONDict.Count > 0 AndAlso
                historicalCandlesJSONDict.ContainsKey("data") Then
                Dim historicalCandlesDict As Dictionary(Of String, Object) = historicalCandlesJSONDict("data")
                If historicalCandlesDict.ContainsKey("candles") AndAlso historicalCandlesDict("candles").count > 0 Then
                    Dim historicalCandles As ArrayList = historicalCandlesDict("candles")
                    'OnHeartbeat(String.Format("Generating Payload for {0}", tradingSymbol))
                    Dim previousPayload As Payload = Nothing
                    For Each historicalCandle As ArrayList In historicalCandles
                        canceller.Token.ThrowIfCancellationRequested()
                        Dim runningSnapshotTime As Date = Utilities.Time.GetDateTimeTillMinutes(historicalCandle(0))

                        Dim runningPayload As Payload = New Payload
                        With runningPayload
                            .PayloadDate = Utilities.Time.GetDateTimeTillMinutes(historicalCandle(0))
                            .TradingSymbol = tradingSymbol
                            .Open = historicalCandle(1)
                            .High = historicalCandle(2)
                            .Low = historicalCandle(3)
                            .Close = historicalCandle(4)
                            .Volume = historicalCandle(5)
                            .OI = historicalCandle(6)
                            .PreviousPayload = previousPayload
                        End With
                        If ret Is Nothing Then ret = New Dictionary(Of Date, Payload)
                        ret.Add(runningSnapshotTime, runningPayload)
                        previousPayload = runningPayload
                    Next
                End If
            End If
        End If
        Return ret
    End Function
#End Region

    Public Async Function StartFetchingAsync() As Task
        Try
            Dim eodData As Dictionary(Of Date, Payload) = Await GetHistoricalDataAsync(_instrument.CashInstrumentToken, _instrument.CashTradingSymbol, _tradingDate.Date.AddDays(-1200), _tradingDate.Date, DataType.EOD, Nothing, _fetchDataWithAPI, _fetchDataWithoutAPI, _cts)
            _cts.Token.ThrowIfCancellationRequested()
            Dim intradayData As Dictionary(Of Date, Payload) = Await GetHistoricalDataAsync(_instrument.CashInstrumentToken, _instrument.CashTradingSymbol, _tradingDate.Date.AddDays(-30), _tradingDate.Date, DataType.Intraday, Nothing, _fetchDataWithAPI, _fetchDataWithoutAPI, _cts)
            _cts.Token.ThrowIfCancellationRequested()
            If intradayData IsNot Nothing AndAlso intradayData.Count > 0 AndAlso eodData IsNot Nothing AndAlso eodData.Count > 0 Then
                If (_instrument.PreviousDay = Date.MinValue OrElse _instrument.PreviousDay.Date = Now.Date) AndAlso
                    eodData.LastOrDefault.Value.PreviousPayload IsNot Nothing Then
                    If eodData.LastOrDefault.Value.PayloadDate < _tradingDate Then
                        _instrument.PreviousDay = eodData.LastOrDefault.Value.PayloadDate.Date
                        _instrument.PreviousClose = eodData.LastOrDefault.Value.Close
                        _instrument.NotifyPropertyChanged("PreviousClose")
                    Else
                        _instrument.PreviousDay = eodData.LastOrDefault.Value.PreviousPayload.PayloadDate
                        _instrument.PreviousClose = eodData.LastOrDefault.Value.PreviousPayload.Close
                        _instrument.NotifyPropertyChanged("PreviousClose")
                    End If
                End If

                Dim currentLTP As Decimal = intradayData.LastOrDefault.Value.Close
                If _instrument.LTP = Decimal.MinValue OrElse _instrument.LTP <> currentLTP Then
                    _instrument.LTP = currentLTP
                    _instrument.NotifyPropertyChanged("LTP")
                    _instrument.NotifyPropertyChanged("ChangePer")
                End If

                Dim emaSentiment As Color = Color.Black
                Dim aroonSentiment As Color = Color.Black
                Dim supertrendSentiment As Color = Color.Black
                Dim fractalSentiment As Color = Color.Black

                If _settings.Week_1 Then
                    Dim weeklyPayload As Dictionary(Of Date, Payload) = Common.ConvertDayPayloadsToWeek(eodData)
                    If weeklyPayload IsNot Nothing AndAlso weeklyPayload.Count > 0 Then
                        Dim lastWeekPayload As Payload = weeklyPayload.LastOrDefault.Value

                        Dim emaColor As Color = Color.White
                        Dim aroonColor As Color = Color.White
                        Dim supertrendColor As Color = Color.White
                        Dim fractalTrendlineColor As Color = Color.White
                        CalculateIndicators(weeklyPayload, lastWeekPayload, emaColor, aroonColor, supertrendColor, fractalTrendlineColor)
                        _instrument.EMA1Week = emaColor.Name
                        _instrument.NotifyPropertyChanged("EMA1Week")
                        _instrument.Aroon1Week = aroonColor.Name
                        _instrument.NotifyPropertyChanged("Aroon1Week")
                        _instrument.Supertrend1Week = supertrendColor.Name
                        _instrument.NotifyPropertyChanged("Supertrend1Week")
                        _instrument.Fractal1Week = fractalTrendlineColor.Name
                        _instrument.NotifyPropertyChanged("Fractal1Week")
                        SetOverallColors(emaColor, aroonColor, supertrendColor, fractalTrendlineColor, emaSentiment, aroonSentiment, supertrendSentiment, fractalSentiment)
                    End If
                End If

                If _settings.Day_1 Then
                    Dim lastDayPayload As Payload = eodData.LastOrDefault.Value

                    Dim emaColor As Color = Color.White
                    Dim aroonColor As Color = Color.White
                    Dim supertrendColor As Color = Color.White
                    Dim fractalTrendlineColor As Color = Color.White
                    CalculateIndicators(eodData, lastDayPayload, emaColor, aroonColor, supertrendColor, fractalTrendlineColor)
                    _instrument.EMA1Day = emaColor.Name
                    _instrument.NotifyPropertyChanged("EMA1Day")
                    _instrument.Aroon1Day = aroonColor.Name
                    _instrument.NotifyPropertyChanged("Aroon1Day")
                    _instrument.Supertrend1Day = supertrendColor.Name
                    _instrument.NotifyPropertyChanged("Supertrend1Day")
                    _instrument.Fractal1Day = fractalTrendlineColor.Name
                    _instrument.NotifyPropertyChanged("Fractal1Day")
                    SetOverallColors(emaColor, aroonColor, supertrendColor, fractalTrendlineColor, emaSentiment, aroonSentiment, supertrendSentiment, fractalSentiment)
                End If

                Dim exchangeStartTime As Date = New Date(Now.Year, Now.Month, Now.Day, 9, 15, 0)
                If _settings.Hour_1 Then
                    Dim timeframe As Integer = 60
                    Dim hourlyPayload As Dictionary(Of Date, Payload) = Common.ConvertPayloadsToXMinutes(intradayData, timeframe, exchangeStartTime)
                    If hourlyPayload IsNot Nothing AndAlso hourlyPayload.Count > 0 Then
                        Dim lastHourPayload As Payload = hourlyPayload.LastOrDefault.Value

                        Dim emaColor As Color = Color.White
                        Dim aroonColor As Color = Color.White
                        Dim supertrendColor As Color = Color.White
                        Dim fractalTrendlineColor As Color = Color.White
                        CalculateIndicators(hourlyPayload, lastHourPayload, emaColor, aroonColor, supertrendColor, fractalTrendlineColor)
                        _instrument.EMA1Hour = emaColor.Name
                        _instrument.NotifyPropertyChanged("EMA1Hour")
                        _instrument.Aroon1Hour = aroonColor.Name
                        _instrument.NotifyPropertyChanged("Aroon1Hour")
                        _instrument.Supertrend1Hour = supertrendColor.Name
                        _instrument.NotifyPropertyChanged("Supertrend1Hour")
                        _instrument.Fractal1Hour = fractalTrendlineColor.Name
                        _instrument.NotifyPropertyChanged("Fractal1Hour")
                        SetOverallColors(emaColor, aroonColor, supertrendColor, fractalTrendlineColor, emaSentiment, aroonSentiment, supertrendSentiment, fractalSentiment)
                    End If
                End If

                If _settings.Minutes_15 Then
                    Dim timeframe As Integer = 15
                    Dim xMinutePayload As Dictionary(Of Date, Payload) = Common.ConvertPayloadsToXMinutes(intradayData, timeframe, exchangeStartTime)
                    If xMinutePayload IsNot Nothing AndAlso xMinutePayload.Count > 0 Then
                        Dim lastXMinutePayload As Payload = xMinutePayload.LastOrDefault.Value

                        Dim emaColor As Color = Color.White
                        Dim aroonColor As Color = Color.White
                        Dim supertrendColor As Color = Color.White
                        Dim fractalTrendlineColor As Color = Color.White
                        CalculateIndicators(xMinutePayload, lastXMinutePayload, emaColor, aroonColor, supertrendColor, fractalTrendlineColor)
                        _instrument.EMA15Mins = emaColor.Name
                        _instrument.NotifyPropertyChanged("EMA15Mins")
                        _instrument.Aroon15Mins = aroonColor.Name
                        _instrument.NotifyPropertyChanged("Aroon15Mins")
                        _instrument.Supertrend15Mins = supertrendColor.Name
                        _instrument.NotifyPropertyChanged("Supertrend15Mins")
                        _instrument.Fractal15Mins = fractalTrendlineColor.Name
                        _instrument.NotifyPropertyChanged("Fractal15Mins")
                        SetOverallColors(emaColor, aroonColor, supertrendColor, fractalTrendlineColor, emaSentiment, aroonSentiment, supertrendSentiment, fractalSentiment)
                    End If
                End If

                Dim lastMinute As Date = Date.MinValue
                If _settings.Minutes_5 Then
                    Dim timeframe As Integer = 5
                    Dim xMinutePayload As Dictionary(Of Date, Payload) = Common.ConvertPayloadsToXMinutes(intradayData, timeframe, exchangeStartTime)
                    If xMinutePayload IsNot Nothing AndAlso xMinutePayload.Count > 0 Then
                        Dim lastXMinutePayload As Payload = xMinutePayload.LastOrDefault.Value
                        lastMinute = lastXMinutePayload.PayloadDate

                        Dim emaColor As Color = Color.White
                        Dim aroonColor As Color = Color.White
                        Dim supertrendColor As Color = Color.White
                        Dim fractalTrendlineColor As Color = Color.White
                        CalculateIndicators(xMinutePayload, lastXMinutePayload, emaColor, aroonColor, supertrendColor, fractalTrendlineColor)
                        _instrument.EMA5Mins = emaColor.Name
                        _instrument.NotifyPropertyChanged("EMA5Mins")
                        _instrument.Aroon5Mins = aroonColor.Name
                        _instrument.NotifyPropertyChanged("Aroon5Mins")
                        _instrument.Supertrend5Mins = supertrendColor.Name
                        _instrument.NotifyPropertyChanged("Supertrend5Mins")
                        _instrument.Fractal5Mins = fractalTrendlineColor.Name
                        _instrument.NotifyPropertyChanged("Fractal5Mins")
                        SetOverallColors(emaColor, aroonColor, supertrendColor, fractalTrendlineColor, emaSentiment, aroonSentiment, supertrendSentiment, fractalSentiment)
                    End If
                End If

                If _instrument.OverallEMA <> emaSentiment.Name Then
                    _instrument.OverallEMA = emaSentiment.Name
                    _instrument.NotifyPropertyChanged("OverallEMA")
                End If
                If _instrument.OverallAroon <> aroonSentiment.Name Then
                    _instrument.OverallAroon = aroonSentiment.Name
                    _instrument.NotifyPropertyChanged("OverallAroon")
                End If
                If _instrument.OverallSupertrend <> supertrendSentiment.Name Then
                    _instrument.OverallSupertrend = supertrendSentiment.Name
                    _instrument.NotifyPropertyChanged("OverallSupertrend")
                End If
                If _instrument.OverallFractal <> fractalSentiment.Name Then
                    _instrument.OverallFractal = fractalSentiment.Name
                    _instrument.NotifyPropertyChanged("OverallFractal")
                End If

                Dim candleNumber As Integer = GetCurrentCandleNumber(exchangeStartTime, lastMinute)
                If candleNumber <> Integer.MinValue Then
                    Dim colorCount As Integer = GetColorCount(emaSentiment, aroonSentiment, supertrendSentiment, fractalSentiment)
                    _instrument.SetNthMinuteColumn(candleNumber, colorCount)
                End If

                _instrument.LastUpdateTime = Now
                _instrument.NotifyPropertyChanged("LastUpdateTime")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub CalculateIndicators(ByVal inputPayload As Dictionary(Of Date, Payload), ByVal currentPayload As Payload,
                                    ByRef emaColor As Color, ByRef aroonColor As Color, ByRef supertrendColor As Color, ByRef fractalTrendlineColor As Color)
        If inputPayload IsNot Nothing AndAlso inputPayload.Count > 100 AndAlso currentPayload IsNot Nothing Then
            Dim emaPayload As Dictionary(Of Date, Decimal) = Nothing
            Indicator.EMA.CalculateEMA(_settings.EMAPeriod, inputPayload, emaPayload)
            If currentPayload.Close > emaPayload(currentPayload.PayloadDate) Then
                emaColor = Color.Green
            ElseIf currentPayload.Close < emaPayload(currentPayload.PayloadDate) Then
                emaColor = Color.Red
            End If

            Dim highDonchianPayload As Dictionary(Of Date, Decimal) = Nothing
            Dim lowDonchianPayload As Dictionary(Of Date, Decimal) = Nothing
            Indicator.DonchianChannel.CalculateDonchianChannel(_settings.AroonPeriod, _settings.AroonPeriod, inputPayload, highDonchianPayload, lowDonchianPayload, Nothing)
            For Each runningPayload In inputPayload.OrderByDescending(Function(x)
                                                                          Return x.Key
                                                                      End Function)
                If runningPayload.Key <= currentPayload.PayloadDate Then
                    If runningPayload.Value.High > highDonchianPayload(runningPayload.Value.PayloadDate) Then
                        aroonColor = Color.Green
                        Exit For
                    ElseIf runningPayload.Value.Low < lowDonchianPayload(runningPayload.Value.PayloadDate) Then
                        aroonColor = Color.Red
                        Exit For
                    End If
                End If
            Next

            Dim supertrendColorPayload As Dictionary(Of Date, Color) = Nothing
            Indicator.Supertrend.CalculateSupertrend(_settings.SupertrendPeriod, _settings.SupertrendMultiplier, inputPayload, Nothing, supertrendColorPayload)
            supertrendColor = supertrendColorPayload(currentPayload.PayloadDate)

            Dim highFractalTredlinePayload As Dictionary(Of Date, TrendLineVeriables) = Nothing
            Dim lowFractalTredlinePayload As Dictionary(Of Date, TrendLineVeriables) = Nothing
            Indicator.FractalUTrendLine.CalculateFractalUTrendLine(inputPayload, highFractalTredlinePayload, lowFractalTredlinePayload, Nothing, Nothing)
            If highFractalTredlinePayload(currentPayload.PayloadDate) IsNot Nothing AndAlso
                highFractalTredlinePayload(currentPayload.PayloadDate).CurrentValue <> Decimal.MinValue AndAlso
                currentPayload.Close > highFractalTredlinePayload(currentPayload.PayloadDate).CurrentValue Then
                fractalTrendlineColor = Color.Green
            End If
            If lowFractalTredlinePayload(currentPayload.PayloadDate) IsNot Nothing AndAlso
                lowFractalTredlinePayload(currentPayload.PayloadDate).CurrentValue <> Decimal.MinValue AndAlso
                currentPayload.Close < lowFractalTredlinePayload(currentPayload.PayloadDate).CurrentValue Then
                If fractalTrendlineColor = Color.Green Then
                    fractalTrendlineColor = Color.White
                Else
                    fractalTrendlineColor = Color.Red
                End If
            End If
        End If
    End Sub

    Private Function GetCurrentBlockTime(ByVal exchangeStartTime As Date, ByVal timeframe As Integer) As Date
        Dim ret As Date = Date.MinValue
        If exchangeStartTime.Minute Mod timeframe = 0 Then
            ret = New Date(Now.Year, Now.Month, Now.Day, Now.Hour, Math.Floor(Now.Minute / timeframe) * timeframe, 0)
        Else
            Dim exchangeTime As Date = New Date(Now.Year, Now.Month, Now.Day, exchangeStartTime.Hour, exchangeStartTime.Minute, 0)
            Dim currentTime As Date = New Date(Now.Year, Now.Month, Now.Day, Now.Hour, Now.Minute, 0)
            Dim timeDifference As Double = currentTime.Subtract(exchangeTime).TotalMinutes
            Dim adjustedTimeDifference As Integer = Math.Floor(timeDifference / timeframe) * timeframe
            Dim currentMinute As Date = exchangeTime.AddMinutes(adjustedTimeDifference)
            ret = New Date(Now.Year, Now.Month, Now.Day, currentMinute.Hour, currentMinute.Minute, 0)
        End If
        Return ret
    End Function

    Private Sub SetOverallColors(ByVal emaColor As Color, ByVal aroonColor As Color, ByVal supertrendColor As Color, ByVal fractalTrendlineColor As Color,
                                 ByRef emaSentiment As Color, ByRef aroonSentiment As Color, ByRef supertrendSentiment As Color, ByRef fractalTrendlineSentiment As Color)
        If emaSentiment = Color.Black Then
            emaSentiment = emaColor
        Else
            If emaSentiment <> emaColor Then
                emaSentiment = Color.White
            End If
        End If
        If aroonSentiment = Color.Black Then
            aroonSentiment = aroonColor
        Else
            If aroonSentiment <> aroonColor Then
                aroonSentiment = Color.White
            End If
        End If
        If supertrendSentiment = Color.Black Then
            supertrendSentiment = supertrendColor
        Else
            If supertrendSentiment <> supertrendColor Then
                supertrendSentiment = Color.White
            End If
        End If
        If fractalTrendlineSentiment = Color.Black Then
            fractalTrendlineSentiment = fractalTrendlineColor
        Else
            If fractalTrendlineSentiment <> fractalTrendlineColor Then
                fractalTrendlineSentiment = Color.White
            End If
        End If
    End Sub

    Private Function GetColorCount(ByVal emaColor As Color, ByVal aroonColor As Color, ByVal supertrendColor As Color, ByVal fractalTrendlineColor As Color) As Integer
        Dim ret As Integer = 0
        If emaColor = Color.Green Then
            ret += 1
        ElseIf emaColor = Color.Red Then
            ret -= 1
        End If
        If aroonColor = Color.Green Then
            ret += 1
        ElseIf aroonColor = Color.Red Then
            ret -= 1
        End If
        If supertrendColor = Color.Green Then
            ret += 1
        ElseIf supertrendColor = Color.Red Then
            ret -= 1
        End If
        If fractalTrendlineColor = Color.Green Then
            ret += 1
        ElseIf fractalTrendlineColor = Color.Red Then
            ret -= 1
        End If
        Return ret
    End Function

    Private Function GetCurrentCandleNumber(ByVal exchangeStartTime As Date, ByVal currentMinute As Date) As Integer
        Dim ret As Integer = Integer.MinValue
        If currentMinute <> Date.MinValue Then
            Dim exchangeTime As Date = New Date(Now.Year, Now.Month, Now.Day, exchangeStartTime.Hour, exchangeStartTime.Minute, 0)
            Dim currentTime As Date = New Date(Now.Year, Now.Month, Now.Day, currentMinute.Hour, currentMinute.Minute, 0)
            Dim timeDifference As Double = currentTime.Subtract(exchangeTime).TotalMinutes
            ret = (timeDifference / 5) + 1
        End If
        Return ret
    End Function
End Class
