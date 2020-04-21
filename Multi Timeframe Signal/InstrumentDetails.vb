Imports NLog
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Public Class InstrumentDetails
    Implements INotifyPropertyChanged

#Region "Logging and Status Progress"
    Public Shared logger As Logger = LogManager.GetCurrentClassLogger
#End Region

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Public Sub NotifyPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Private ReadOnly _settings As SignalSettings
    Public Sub New(ByVal settings As SignalSettings)
        _settings = settings
    End Sub

    <Display(Name:="Instrument Name", Order:=0, AutoGenerateField:=True)>
    Public Property OriginatingInstrument As String

    Private _LastUpdateTime As Date
    <Display(Name:="Last Update Time", Order:=1, AutoGenerateField:=True)>
    Public Property LastUpdateTime As Date
        Get
            Return _LastUpdateTime
        End Get
        Set(value As Date)
            If _LastUpdateTime <> value Then
                _LastUpdateTime = value
            End If
        End Set
    End Property

    <Display(Name:="ATR %", Order:=2, AutoGenerateField:=True)>
    Public Property ATR As Decimal

    <Display(Name:="Slab", Order:=3, AutoGenerateField:=True)>
    Public Property Slab As Decimal

    <Display(Name:="Overall EMA", Order:=4, AutoGenerateField:=True)>
    Public Property OverallEMA As String

    <Display(Name:="Overall Aroon", Order:=5, AutoGenerateField:=True)>
    Public Property OverallAroon As String

    <Display(Name:="Overall Supertrend", Order:=6, AutoGenerateField:=True)>
    Public Property OverallSupertrend As String

    <Display(Name:="Overall Fractal", Order:=7, AutoGenerateField:=True)>
    Public Property OverallFractal As String



#Region "5 Minute Slab"
    <Display(Name:="", Order:=20, AutoGenerateField:=True)>
    Public Property Minute1 As Integer
    <Display(Name:="", Order:=21, AutoGenerateField:=True)>
    Public Property Minute2 As Integer
    <Display(Name:="", Order:=22, AutoGenerateField:=True)>
    Public Property Minute3 As Integer
    <Display(Name:="", Order:=23, AutoGenerateField:=True)>
    Public Property Minute4 As Integer
    <Display(Name:="", Order:=24, AutoGenerateField:=True)>
    Public Property Minute5 As Integer
    <Display(Name:="", Order:=25, AutoGenerateField:=True)>
    Public Property Minute6 As Integer
    <Display(Name:="", Order:=26, AutoGenerateField:=True)>
    Public Property Minute7 As Integer
    <Display(Name:="", Order:=27, AutoGenerateField:=True)>
    Public Property Minute8 As Integer
    <Display(Name:="", Order:=28, AutoGenerateField:=True)>
    Public Property Minute9 As Integer
    <Display(Name:="", Order:=29, AutoGenerateField:=True)>
    Public Property Minute10 As Integer
    <Display(Name:="", Order:=30, AutoGenerateField:=True)>
    Public Property Minute11 As Integer
    <Display(Name:="", Order:=31, AutoGenerateField:=True)>
    Public Property Minute12 As Integer
    <Display(Name:="", Order:=32, AutoGenerateField:=True)>
    Public Property Minute13 As Integer
    <Display(Name:="", Order:=33, AutoGenerateField:=True)>
    Public Property Minute14 As Integer
    <Display(Name:="", Order:=34, AutoGenerateField:=True)>
    Public Property Minute15 As Integer
    <Display(Name:="", Order:=35, AutoGenerateField:=True)>
    Public Property Minute16 As Integer
    <Display(Name:="", Order:=36, AutoGenerateField:=True)>
    Public Property Minute17 As Integer
    <Display(Name:="", Order:=37, AutoGenerateField:=True)>
    Public Property Minute18 As Integer
    <Display(Name:="", Order:=38, AutoGenerateField:=True)>
    Public Property Minute19 As Integer
    <Display(Name:="", Order:=39, AutoGenerateField:=True)>
    Public Property Minute20 As Integer
    <Display(Name:="", Order:=40, AutoGenerateField:=True)>
    Public Property Minute21 As Integer
    <Display(Name:="", Order:=41, AutoGenerateField:=True)>
    Public Property Minute22 As Integer
    <Display(Name:="", Order:=42, AutoGenerateField:=True)>
    Public Property Minute23 As Integer
    <Display(Name:="", Order:=43, AutoGenerateField:=True)>
    Public Property Minute24 As Integer
    <Display(Name:="", Order:=44, AutoGenerateField:=True)>
    Public Property Minute25 As Integer
    <Display(Name:="", Order:=45, AutoGenerateField:=True)>
    Public Property Minute26 As Integer
    <Display(Name:="", Order:=46, AutoGenerateField:=True)>
    Public Property Minute27 As Integer
    <Display(Name:="", Order:=47, AutoGenerateField:=True)>
    Public Property Minute28 As Integer
    <Display(Name:="", Order:=48, AutoGenerateField:=True)>
    Public Property Minute29 As Integer
    <Display(Name:="", Order:=49, AutoGenerateField:=True)>
    Public Property Minute30 As Integer
    <Display(Name:="", Order:=50, AutoGenerateField:=True)>
    Public Property Minute31 As Integer
    <Display(Name:="", Order:=51, AutoGenerateField:=True)>
    Public Property Minute32 As Integer
    <Display(Name:="", Order:=52, AutoGenerateField:=True)>
    Public Property Minute33 As Integer
    <Display(Name:="", Order:=53, AutoGenerateField:=True)>
    Public Property Minute34 As Integer
    <Display(Name:="", Order:=54, AutoGenerateField:=True)>
    Public Property Minute35 As Integer
    <Display(Name:="", Order:=55, AutoGenerateField:=True)>
    Public Property Minute36 As Integer
    <Display(Name:="", Order:=56, AutoGenerateField:=True)>
    Public Property Minute37 As Integer
    <Display(Name:="", Order:=57, AutoGenerateField:=True)>
    Public Property Minute38 As Integer
    <Display(Name:="", Order:=58, AutoGenerateField:=True)>
    Public Property Minute39 As Integer
    <Display(Name:="", Order:=59, AutoGenerateField:=True)>
    Public Property Minute40 As Integer
    <Display(Name:="", Order:=60, AutoGenerateField:=True)>
    Public Property Minute41 As Integer
    <Display(Name:="", Order:=61, AutoGenerateField:=True)>
    Public Property Minute42 As Integer
    <Display(Name:="", Order:=62, AutoGenerateField:=True)>
    Public Property Minute43 As Integer
    <Display(Name:="", Order:=63, AutoGenerateField:=True)>
    Public Property Minute44 As Integer
    <Display(Name:="", Order:=64, AutoGenerateField:=True)>
    Public Property Minute45 As Integer
    <Display(Name:="", Order:=65, AutoGenerateField:=True)>
    Public Property Minute46 As Integer
    <Display(Name:="", Order:=66, AutoGenerateField:=True)>
    Public Property Minute47 As Integer
    <Display(Name:="", Order:=67, AutoGenerateField:=True)>
    Public Property Minute48 As Integer
    <Display(Name:="", Order:=68, AutoGenerateField:=True)>
    Public Property Minute49 As Integer
    <Display(Name:="", Order:=69, AutoGenerateField:=True)>
    Public Property Minute50 As Integer
    <Display(Name:="", Order:=70, AutoGenerateField:=True)>
    Public Property Minute51 As Integer
    <Display(Name:="", Order:=71, AutoGenerateField:=True)>
    Public Property Minute52 As Integer
    <Display(Name:="", Order:=72, AutoGenerateField:=True)>
    Public Property Minute53 As Integer
    <Display(Name:="", Order:=73, AutoGenerateField:=True)>
    Public Property Minute54 As Integer
    <Display(Name:="", Order:=74, AutoGenerateField:=True)>
    Public Property Minute55 As Integer
    <Display(Name:="", Order:=75, AutoGenerateField:=True)>
    Public Property Minute56 As Integer
    <Display(Name:="", Order:=76, AutoGenerateField:=True)>
    Public Property Minute57 As Integer
    <Display(Name:="", Order:=77, AutoGenerateField:=True)>
    Public Property Minute58 As Integer
    <Display(Name:="", Order:=78, AutoGenerateField:=True)>
    Public Property Minute59 As Integer
    <Display(Name:="", Order:=79, AutoGenerateField:=True)>
    Public Property Minute60 As Integer
    <Display(Name:="", Order:=80, AutoGenerateField:=True)>
    Public Property Minute61 As Integer
    <Display(Name:="", Order:=81, AutoGenerateField:=True)>
    Public Property Minute62 As Integer
    <Display(Name:="", Order:=82, AutoGenerateField:=True)>
    Public Property Minute63 As Integer
    <Display(Name:="", Order:=83, AutoGenerateField:=True)>
    Public Property Minute64 As Integer
    <Display(Name:="", Order:=84, AutoGenerateField:=True)>
    Public Property Minute65 As Integer
    <Display(Name:="", Order:=85, AutoGenerateField:=True)>
    Public Property Minute66 As Integer
    <Display(Name:="", Order:=86, AutoGenerateField:=True)>
    Public Property Minute67 As Integer
    <Display(Name:="", Order:=87, AutoGenerateField:=True)>
    Public Property Minute68 As Integer
    <Display(Name:="", Order:=88, AutoGenerateField:=True)>
    Public Property Minute69 As Integer
    <Display(Name:="", Order:=89, AutoGenerateField:=True)>
    Public Property Minute70 As Integer
    <Display(Name:="", Order:=90, AutoGenerateField:=True)>
    Public Property Minute71 As Integer
    <Display(Name:="", Order:=91, AutoGenerateField:=True)>
    Public Property Minute72 As Integer
    <Display(Name:="", Order:=92, AutoGenerateField:=True)>
    Public Property Minute73 As Integer
    <Display(Name:="", Order:=93, AutoGenerateField:=True)>
    Public Property Minute74 As Integer
    <Display(Name:="", Order:=94, AutoGenerateField:=True)>
    Public Property Minute75 As Integer
#End Region

#Region "Timeframe indicator values"
    <Display(Name:="", Order:=100, AutoGenerateField:=True)>
    Public Property Seperator50 As String

    <Display(Name:="5 Mins EMA", Order:=101, AutoGenerateField:=True)>
    Public Property EMA5Mins As String

    <Display(Name:="5 Mins Aroon", Order:=102, AutoGenerateField:=True)>
    Public Property Aroon5Mins As String

    <Display(Name:="5 Mins Supertrend", Order:=103, AutoGenerateField:=True)>
    Public Property Supertrend5Mins As String

    <Display(Name:="5 Mins Fractal", Order:=104, AutoGenerateField:=True)>
    Public Property Fractal5Mins As String


    <Display(Name:="", Order:=105, AutoGenerateField:=True)>
    Public Property Seperator51 As String

    <Display(Name:="15 Mins EMA", Order:=106, AutoGenerateField:=True)>
    Public Property EMA15Mins As String

    <Display(Name:="15 Mins Aroon", Order:=107, AutoGenerateField:=True)>
    Public Property Aroon15Mins As String

    <Display(Name:="15 Mins Supertrend", Order:=108, AutoGenerateField:=True)>
    Public Property Supertrend15Mins As String

    <Display(Name:="15 Mins Fractal", Order:=109, AutoGenerateField:=True)>
    Public Property Fractal15Mins As String


    <Display(Name:="", Order:=110, AutoGenerateField:=True)>
    Public Property Seperator52 As String

    <Display(Name:="1 Hour EMA", Order:=111, AutoGenerateField:=True)>
    Public Property EMA1Hour As String

    <Display(Name:="1 Hour Aroon", Order:=112, AutoGenerateField:=True)>
    Public Property Aroon1Hour As String

    <Display(Name:="1 Hour Supertrend", Order:=113, AutoGenerateField:=True)>
    Public Property Supertrend1Hour As String

    <Display(Name:="1 Hour Fractal", Order:=114, AutoGenerateField:=True)>
    Public Property Fractal1Hour As String


    <Display(Name:="", Order:=115, AutoGenerateField:=True)>
    Public Property Seperator53 As String

    <Display(Name:="1 Day EMA", Order:=116, AutoGenerateField:=True)>
    Public Property EMA1Day As String

    <Display(Name:="1 Day Aroon", Order:=117, AutoGenerateField:=True)>
    Public Property Aroon1Day As String

    <Display(Name:="1 Day Supertrend", Order:=118, AutoGenerateField:=True)>
    Public Property Supertrend1Day As String

    <Display(Name:="1 Day Fractal", Order:=119, AutoGenerateField:=True)>
    Public Property Fractal1Day As String


    <Display(Name:="", Order:=120, AutoGenerateField:=True)>
    Public Property Seperator54 As String

    <Display(Name:="1 Week EMA", Order:=121, AutoGenerateField:=True)>
    Public Property EMA1Week As String

    <Display(Name:="1 Week Aroon", Order:=122, AutoGenerateField:=True)>
    Public Property Aroon1Week As String

    <Display(Name:="1 Week Supertrend", Order:=123, AutoGenerateField:=True)>
    Public Property Supertrend1Week As String

    <Display(Name:="1 Week Fractal", Order:=124, AutoGenerateField:=True)>
    Public Property Fractal1Week As String
#End Region

#Region "Non Relevant"
    <Display(Name:="", Order:=125, AutoGenerateField:=True)>
    Public Property Seperator100 As String

    <Display(Name:="LTP", Order:=126, AutoGenerateField:=True)>
    Public Property LTP As Decimal

    <Display(Name:="Change %", Order:=127, AutoGenerateField:=True)>
    Public ReadOnly Property ChangePer As Decimal
        Get
            If LTP <> Decimal.MinValue AndAlso PreviousClose <> Decimal.MinValue AndAlso LTP <> 0 Then
                Return Math.Round(((PreviousClose / LTP) - 1) * 100, 2)
            Else
                Return 0
            End If
        End Get
    End Property
#End Region

#Region "Non Browsable"
    <Display(Name:="Previous Close", Order:=200, AutoGenerateField:=False)>
    Public Property PreviousClose As Decimal

    <Display(Name:="Previous Day", Order:=200, AutoGenerateField:=False)>
    Public Property PreviousDay As Date

    <Display(Name:="Cash Trading Symbol", Order:=200, AutoGenerateField:=False)>
    Public Property CashTradingSymbol As String

    <Display(Name:="Instrument Token", Order:=200, AutoGenerateField:=False)>
    Public Property CashInstrumentToken As String
#End Region

#Region "Set Function"
    Public Sub SetNthMinuteColumn(ByVal minuteNumber As Integer, ByVal value As Integer)
        Select Case minuteNumber
            Case 1
                Me.Minute1 = value
                NotifyPropertyChanged("Minute1")
            Case 2
                Me.Minute2 = value
                NotifyPropertyChanged("Minute2")
            Case 3
                Me.Minute3 = value
                NotifyPropertyChanged("Minute3")
            Case 4
                Me.Minute4 = value
                NotifyPropertyChanged("Minute4")
            Case 5
                Me.Minute5 = value
                NotifyPropertyChanged("Minute5")
            Case 6
                Me.Minute6 = value
                NotifyPropertyChanged("Minute6")
            Case 7
                Me.Minute7 = value
                NotifyPropertyChanged("Minute7")
            Case 8
                Me.Minute8 = value
                NotifyPropertyChanged("Minute8")
            Case 9
                Me.Minute9 = value
                NotifyPropertyChanged("Minute9")
            Case 10
                Me.Minute10 = value
                NotifyPropertyChanged("Minute10")
            Case 11
                Me.Minute11 = value
                NotifyPropertyChanged("Minute11")
            Case 12
                Me.Minute12 = value
                NotifyPropertyChanged("Minute12")
            Case 13
                Me.Minute13 = value
                NotifyPropertyChanged("Minute13")
            Case 14
                Me.Minute14 = value
                NotifyPropertyChanged("Minute14")
            Case 15
                Me.Minute15 = value
                NotifyPropertyChanged("Minute15")
            Case 16
                Me.Minute16 = value
                NotifyPropertyChanged("Minute16")
            Case 17
                Me.Minute17 = value
                NotifyPropertyChanged("Minute17")
            Case 18
                Me.Minute18 = value
                NotifyPropertyChanged("Minute18")
            Case 19
                Me.Minute19 = value
                NotifyPropertyChanged("Minute19")
            Case 20
                Me.Minute20 = value
                NotifyPropertyChanged("Minute20")
            Case 21
                Me.Minute21 = value
                NotifyPropertyChanged("Minute21")
            Case 22
                Me.Minute22 = value
                NotifyPropertyChanged("Minute22")
            Case 23
                Me.Minute23 = value
                NotifyPropertyChanged("Minute23")
            Case 24
                Me.Minute24 = value
                NotifyPropertyChanged("Minute24")
            Case 25
                Me.Minute25 = value
                NotifyPropertyChanged("Minute25")
            Case 26
                Me.Minute26 = value
                NotifyPropertyChanged("Minute26")
            Case 27
                Me.Minute27 = value
                NotifyPropertyChanged("Minute27")
            Case 28
                Me.Minute28 = value
                NotifyPropertyChanged("Minute28")
            Case 29
                Me.Minute29 = value
                NotifyPropertyChanged("Minute29")
            Case 30
                Me.Minute30 = value
                NotifyPropertyChanged("Minute30")
            Case 31
                Me.Minute31 = value
                NotifyPropertyChanged("Minute31")
            Case 32
                Me.Minute32 = value
                NotifyPropertyChanged("Minute32")
            Case 33
                Me.Minute33 = value
                NotifyPropertyChanged("Minute33")
            Case 34
                Me.Minute34 = value
                NotifyPropertyChanged("Minute34")
            Case 35
                Me.Minute35 = value
                NotifyPropertyChanged("Minute35")
            Case 36
                Me.Minute36 = value
                NotifyPropertyChanged("Minute36")
            Case 37
                Me.Minute37 = value
                NotifyPropertyChanged("Minute37")
            Case 38
                Me.Minute38 = value
                NotifyPropertyChanged("Minute38")
            Case 39
                Me.Minute39 = value
                NotifyPropertyChanged("Minute39")
            Case 40
                Me.Minute40 = value
                NotifyPropertyChanged("Minute40")
            Case 41
                Me.Minute41 = value
                NotifyPropertyChanged("Minute41")
            Case 42
                Me.Minute42 = value
                NotifyPropertyChanged("Minute42")
            Case 43
                Me.Minute43 = value
                NotifyPropertyChanged("Minute43")
            Case 44
                Me.Minute44 = value
                NotifyPropertyChanged("Minute44")
            Case 45
                Me.Minute45 = value
                NotifyPropertyChanged("Minute45")
            Case 46
                Me.Minute46 = value
                NotifyPropertyChanged("Minute46")
            Case 47
                Me.Minute47 = value
                NotifyPropertyChanged("Minute47")
            Case 48
                Me.Minute48 = value
                NotifyPropertyChanged("Minute48")
            Case 49
                Me.Minute49 = value
                NotifyPropertyChanged("Minute49")
            Case 50
                Me.Minute50 = value
                NotifyPropertyChanged("Minute50")
            Case 51
                Me.Minute51 = value
                NotifyPropertyChanged("Minute51")
            Case 52
                Me.Minute52 = value
                NotifyPropertyChanged("Minute52")
            Case 53
                Me.Minute53 = value
                NotifyPropertyChanged("Minute53")
            Case 54
                Me.Minute54 = value
                NotifyPropertyChanged("Minute54")
            Case 55
                Me.Minute55 = value
                NotifyPropertyChanged("Minute55")
            Case 56
                Me.Minute56 = value
                NotifyPropertyChanged("Minute56")
            Case 57
                Me.Minute57 = value
                NotifyPropertyChanged("Minute57")
            Case 58
                Me.Minute58 = value
                NotifyPropertyChanged("Minute58")
            Case 59
                Me.Minute59 = value
                NotifyPropertyChanged("Minute59")
            Case 60
                Me.Minute60 = value
                NotifyPropertyChanged("Minute60")
            Case 61
                Me.Minute61 = value
                NotifyPropertyChanged("Minute61")
            Case 62
                Me.Minute62 = value
                NotifyPropertyChanged("Minute62")
            Case 63
                Me.Minute63 = value
                NotifyPropertyChanged("Minute63")
            Case 64
                Me.Minute64 = value
                NotifyPropertyChanged("Minute64")
            Case 65
                Me.Minute65 = value
                NotifyPropertyChanged("Minute65")
            Case 66
                Me.Minute66 = value
                NotifyPropertyChanged("Minute66")
            Case 67
                Me.Minute67 = value
                NotifyPropertyChanged("Minute67")
            Case 68
                Me.Minute68 = value
                NotifyPropertyChanged("Minute68")
            Case 69
                Me.Minute69 = value
                NotifyPropertyChanged("Minute69")
            Case 70
                Me.Minute70 = value
                NotifyPropertyChanged("Minute70")
            Case 71
                Me.Minute71 = value
                NotifyPropertyChanged("Minute71")
            Case 72
                Me.Minute72 = value
                NotifyPropertyChanged("Minute72")
            Case 73
                Me.Minute73 = value
                NotifyPropertyChanged("Minute73")
            Case 74
                Me.Minute74 = value
                NotifyPropertyChanged("Minute74")
            Case 75
                Me.Minute75 = value
                NotifyPropertyChanged("Minute75")
        End Select
    End Sub
#End Region
End Class
