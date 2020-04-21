Imports System.IO

<Serializable>
Public Class SignalSettings
    Public Shared Property SettingsFilename As String = Path.Combine(My.Application.Info.DirectoryPath, "Settings.a2t")

    'Stock Selection
    Public Property MinimumStockPrice As Decimal
    Public Property MaximumStockPrice As Decimal
    Public Property MinimumATRPercentage As Decimal
    Public Property MinimumBlankCandlePercentage As Decimal
    Public Property NumberOfStock As Integer
    Public Property FetchBannedStock As Boolean

    'Others
    Public Property MainStockParallelHit As Integer
    Public Property Week_1 As Boolean
    Public Property Day_1 As Boolean
    Public Property Hour_1 As Boolean
    Public Property Minutes_15 As Boolean
    Public Property Minutes_5 As Boolean

    'Indicator
    Public Property EMAPeriod As Integer
    Public Property AroonPeriod As Integer
    Public Property SupertrendPeriod As Integer
    Public Property SupertrendMultiplier As Integer
End Class
