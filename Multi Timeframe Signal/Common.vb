Public Module Common
    Public Function ConvertPayloadsToXMinutes(ByVal inputPayloads As Dictionary(Of Date, Payload), ByVal timeframe As Integer, ByVal exchangeStartTime As Date) As Dictionary(Of Date, Payload)
        Dim ret As Dictionary(Of Date, Payload) = Nothing
        If inputPayloads IsNot Nothing AndAlso inputPayloads.Count > 0 Then
            Dim previousCandlePayload As Payload = Nothing
            For Each runningPayload In inputPayloads.Values
                Dim blockDateInThisTimeframe As Date = Date.MinValue
                If exchangeStartTime.Minute Mod timeframe = 0 Then
                    blockDateInThisTimeframe = New Date(runningPayload.PayloadDate.Year,
                                                        runningPayload.PayloadDate.Month,
                                                        runningPayload.PayloadDate.Day,
                                                        runningPayload.PayloadDate.Hour,
                                                        Math.Floor(runningPayload.PayloadDate.Minute / timeframe) * timeframe, 0)
                Else
                    Dim exchangeTime As Date = New Date(runningPayload.PayloadDate.Year, runningPayload.PayloadDate.Month, runningPayload.PayloadDate.Day, exchangeStartTime.Hour, exchangeStartTime.Minute, 0)
                    Dim currentTime As Date = New Date(runningPayload.PayloadDate.Year, runningPayload.PayloadDate.Month, runningPayload.PayloadDate.Day, runningPayload.PayloadDate.Hour, runningPayload.PayloadDate.Minute, 0)
                    Dim timeDifference As Double = currentTime.Subtract(exchangeTime).TotalMinutes
                    Dim adjustedTimeDifference As Integer = Math.Floor(timeDifference / timeframe) * timeframe
                    Dim currentMinute As Date = exchangeTime.AddMinutes(adjustedTimeDifference)
                    blockDateInThisTimeframe = New Date(runningPayload.PayloadDate.Year,
                                                        runningPayload.PayloadDate.Month,
                                                        runningPayload.PayloadDate.Day,
                                                        currentMinute.Hour,
                                                        currentMinute.Minute, 0)
                End If
                If blockDateInThisTimeframe <> Date.MinValue Then
                    If ret Is Nothing Then ret = New Dictionary(Of Date, Payload)
                    If Not ret.ContainsKey(blockDateInThisTimeframe) Then
                        Dim xMinutePayload As Payload = New Payload With {
                            .PayloadDate = blockDateInThisTimeframe,
                            .Open = runningPayload.Open,
                            .High = runningPayload.High,
                            .Low = runningPayload.Low,
                            .Close = runningPayload.Close,
                            .Volume = runningPayload.Volume,
                            .TradingSymbol = runningPayload.TradingSymbol,
                            .PreviousPayload = previousCandlePayload
                        }

                        ret.Add(blockDateInThisTimeframe, xMinutePayload)
                        previousCandlePayload = xMinutePayload
                    Else
                        Dim xMinutePayload As Payload = ret(blockDateInThisTimeframe)
                        xMinutePayload.High = Math.Max(xMinutePayload.High, runningPayload.High)
                        xMinutePayload.Low = Math.Min(xMinutePayload.Low, runningPayload.Low)
                        xMinutePayload.Close = runningPayload.Close
                        xMinutePayload.Volume = xMinutePayload.Volume + runningPayload.Volume
                    End If
                End If
            Next
        End If
        Return ret
    End Function

    Public Function ConvertDayPayloadsToMonth(ByVal payloads As Dictionary(Of Date, Payload)) As Dictionary(Of Date, Payload)
        Dim ret As Dictionary(Of Date, Payload) = Nothing
        If payloads IsNot Nothing AndAlso payloads.Count > 0 Then
            Dim newCandleStarted As Boolean = True
            Dim runningOutputPayload As Payload = Nothing
            For Each payload In payloads.Values
                If runningOutputPayload Is Nothing OrElse
                    payload.PayloadDate.Month <> runningOutputPayload.PayloadDate.Month OrElse
                    payload.PayloadDate.Year <> runningOutputPayload.PayloadDate.Year Then
                    newCandleStarted = True
                End If
                If newCandleStarted Then
                    newCandleStarted = False
                    Dim prevPayload As Payload = runningOutputPayload
                    runningOutputPayload = New Payload With {
                        .PayloadDate = New Date(payload.PayloadDate.Year, payload.PayloadDate.Month, 1),
                        .Open = payload.Open,
                        .High = payload.High,
                        .Low = payload.Low,
                        .Close = payload.Close,
                        .Volume = payload.Volume,
                        .TradingSymbol = payload.TradingSymbol,
                        .PreviousPayload = prevPayload
                    }

                    If ret Is Nothing Then ret = New Dictionary(Of Date, Payload)
                    ret.Add(runningOutputPayload.PayloadDate, runningOutputPayload)
                Else
                    runningOutputPayload.High = Math.Max(runningOutputPayload.High, payload.High)
                    runningOutputPayload.Low = Math.Min(runningOutputPayload.Low, payload.Low)
                    runningOutputPayload.Close = payload.Close
                    runningOutputPayload.Volume = runningOutputPayload.Volume + payload.Volume
                End If
            Next
        End If
        Return ret
    End Function

    Public Function ConvertDayPayloadsToWeek(ByVal payloads As Dictionary(Of Date, Payload)) As Dictionary(Of Date, Payload)
        Dim ret As Dictionary(Of Date, Payload) = Nothing
        If payloads IsNot Nothing AndAlso payloads.Count > 0 Then
            Dim newCandleStarted As Boolean = True
            Dim runningOutputPayload As Payload = Nothing
            For Each payload In payloads.Values
                If runningOutputPayload Is Nothing OrElse
                    GetStartDateOfTheWeek(payload.PayloadDate, DayOfWeek.Monday) <> runningOutputPayload.PayloadDate Then
                    newCandleStarted = True
                End If
                If newCandleStarted Then
                    newCandleStarted = False
                    Dim prevPayload As Payload = runningOutputPayload
                    runningOutputPayload = New Payload With {
                        .PayloadDate = GetStartDateOfTheWeek(payload.PayloadDate, DayOfWeek.Monday),
                        .Open = payload.Open,
                        .High = payload.High,
                        .Low = payload.Low,
                        .Close = payload.Close,
                        .Volume = payload.Volume,
                        .TradingSymbol = payload.TradingSymbol,
                        .PreviousPayload = prevPayload
                    }

                    If ret Is Nothing Then ret = New Dictionary(Of Date, Payload)
                    ret.Add(runningOutputPayload.PayloadDate, runningOutputPayload)
                Else
                    runningOutputPayload.High = Math.Max(runningOutputPayload.High, payload.High)
                    runningOutputPayload.Low = Math.Min(runningOutputPayload.Low, payload.Low)
                    runningOutputPayload.Close = payload.Close
                    runningOutputPayload.Volume = runningOutputPayload.Volume + payload.Volume
                End If
            Next
        End If
        Return ret
    End Function

    Public Function GetStartDateOfTheWeek(ByVal dt As Date, ByVal startOfWeek As DayOfWeek) As Date
        Dim diff As Integer = (7 + (dt.DayOfWeek - startOfWeek)) Mod 7
        Return dt.AddDays(-1 * diff).Date
    End Function

    Public Function GetSubPayload(ByVal inputPayload As Dictionary(Of Date, Payload),
                                  ByVal beforeThisTime As DateTime,
                                  ByVal numberOfItemsToRetrive As Integer,
                                  ByVal includeTimePassedAsOneOftheItems As Boolean) As List(Of KeyValuePair(Of DateTime, Payload))
        Dim ret As List(Of KeyValuePair(Of DateTime, Payload)) = Nothing
        If inputPayload IsNot Nothing Then
            'Find the index of the time passed
            Dim firstIndexOfKey As Integer = -1
            Dim loopTerminatedOnCondition As Boolean = False
            For Each item In inputPayload

                firstIndexOfKey += 1
                If item.Key >= beforeThisTime Then
                    loopTerminatedOnCondition = True
                    Exit For
                End If
            Next
            If loopTerminatedOnCondition Then 'Specially useful for only 1 count of item is there
                If Not includeTimePassedAsOneOftheItems Then
                    firstIndexOfKey -= 1
                End If
            End If
            If firstIndexOfKey >= 0 Then
                Dim startIndex As Integer = Math.Max((firstIndexOfKey - numberOfItemsToRetrive) + 1, 0)
                Dim revisedNumberOfItemsToRetrieve As Integer = Math.Min(numberOfItemsToRetrive, (firstIndexOfKey - startIndex) + 1)
                Dim referencePayLoadAsList = inputPayload.ToList
                ret = referencePayLoadAsList.GetRange(startIndex, revisedNumberOfItemsToRetrieve)
            End If
        End If
        Return ret
    End Function

    Public Function GetPayloadAtPositionOrPositionMinus1(ByVal beforeThisTime As DateTime, ByVal inputPayload As Dictionary(Of Date, Decimal)) As KeyValuePair(Of DateTime, Decimal)
        Dim ret As KeyValuePair(Of DateTime, Decimal) = Nothing
        If inputPayload IsNot Nothing Then
            Dim tempret = inputPayload.Where(Function(x)
                                                 Return x.Key < beforeThisTime
                                             End Function)
            If tempret IsNot Nothing Then
                ret = tempret.LastOrDefault
            End If
        End If
        Return ret
    End Function

    Public Function GetEquationOfTrendLine(ByVal x1 As Decimal, ByVal y1 As Decimal, ByVal x2 As Decimal, ByVal y2 As Decimal) As TrendLineVeriables
        Dim ret As TrendLineVeriables = Nothing
        If (x2 - x1) <> 0 Then
            ret = New TrendLineVeriables With {
                .M = (y2 - y1) / (x2 - x1),
                .C = y1 - (.M * x1),
                .X = x2
            }
        End If
        Return ret
    End Function
End Module
