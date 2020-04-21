Imports System.IO
Public Class frmSettings
    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If File.Exists(SignalSettings.SettingsFilename) Then
            Dim settings As SignalSettings = Utilities.Strings.DeserializeToCollection(Of SignalSettings)(SignalSettings.SettingsFilename)

            txtMinPrice.Text = settings.MinimumStockPrice
            txtMaxPrice.Text = settings.MaximumStockPrice
            txtATRPercentage.Text = settings.MinimumATRPercentage
            txtBlankCandlePercentage.Text = settings.MinimumBlankCandlePercentage
            txtNumberOfStock.Text = settings.NumberOfStock
            chkbFetchBannedStocks.Checked = settings.FetchBannedStock

            txtMainStockParallelHit.Text = settings.MainStockParallelHit
            chkb1Week.Checked = settings.Week_1
            chkb1Day.Checked = settings.Day_1
            chkb1Hour.Checked = settings.Hour_1
            chkb15Minutes.Checked = settings.Minutes_15
            chkb5Minutes.Checked = settings.Minutes_5

            txtEMAPeriod.Text = settings.EMAPeriod
            txtAroonPeriod.Text = settings.AroonPeriod
            txtSupertrendPeriod.Text = settings.SupertrendPeriod
            txtSupertrendMultiplier.Text = settings.SupertrendMultiplier
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            ValidateInputs()
            SaveSettings()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(String.Format("The following error occurred: {0}", ex.Message), "Settings", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveSettings()
        Dim settings As SignalSettings = New SignalSettings

        settings.MinimumStockPrice = txtMinPrice.Text
        settings.MaximumStockPrice = txtMaxPrice.Text
        settings.MinimumATRPercentage = txtATRPercentage.Text
        settings.MinimumBlankCandlePercentage = txtBlankCandlePercentage.Text
        settings.NumberOfStock = txtNumberOfStock.Text
        settings.FetchBannedStock = chkbFetchBannedStocks.Checked

        settings.MainStockParallelHit = txtMainStockParallelHit.Text
        settings.Week_1 = chkb1Week.Checked
        settings.Day_1 = chkb1Day.Checked
        settings.Hour_1 = chkb1Hour.Checked
        settings.Minutes_15 = chkb15Minutes.Checked
        settings.Minutes_5 = chkb5Minutes.Checked

        settings.EMAPeriod = txtEMAPeriod.Text
        settings.AroonPeriod = txtAroonPeriod.Text
        settings.SupertrendPeriod = txtSupertrendPeriod.Text
        settings.SupertrendMultiplier = txtSupertrendMultiplier.Text

        Utilities.Strings.SerializeFromCollection(Of SignalSettings)(SignalSettings.SettingsFilename, settings)
    End Sub

    Private Function ValidateNumbers(ByVal startNumber As Decimal, ByVal endNumber As Decimal, ByVal inputTB As TextBox, Optional ByVal validateInteger As Boolean = False) As Boolean
        Dim ret As Boolean = False
        If IsNumeric(inputTB.Text) Then
            If validateInteger Then
                If Val(inputTB.Text) <> Math.Round(Val(inputTB.Text), 0) Then
                    Throw New ApplicationException(String.Format("{0} should be of type Integer", inputTB.Tag))
                End If
            End If
            If Val(inputTB.Text) >= startNumber And Val(inputTB.Text) <= endNumber Then
                ret = True
            End If
        End If
        If Not ret Then Throw New ApplicationException(String.Format("{0} cannot have a value < {1} or > {2}", inputTB.Tag, startNumber, endNumber))
        Return ret
    End Function

    Private Sub ValidateInputs()
        If chkb1Week.Checked AndAlso chkb1Day.Checked AndAlso chkb1Hour.Checked AndAlso chkb15Minutes.Checked AndAlso chkb5Minutes.Checked Then
            Throw New ApplicationException("Can't run with more than 4 timeframe")
        ElseIf Not (chkb1Week.Checked OrElse chkb1Day.Checked OrElse chkb1Hour.Checked OrElse chkb15Minutes.Checked OrElse chkb5Minutes.Checked) Then
            Throw New ApplicationException("Can't run without any timeframe")
        End If

        ValidateNumbers(0, Decimal.MaxValue, txtMinPrice)
        ValidateNumbers(0, Decimal.MaxValue, txtMaxPrice)
        ValidateNumbers(0, 100, txtATRPercentage)
        ValidateNumbers(0, 100, txtBlankCandlePercentage)
        ValidateNumbers(0, Integer.MaxValue, txtNumberOfStock, True)

        ValidateNumbers(0, Integer.MaxValue, txtMainStockParallelHit, True)

        ValidateNumbers(0, Integer.MaxValue, txtEMAPeriod, True)
        ValidateNumbers(0, Integer.MaxValue, txtAroonPeriod, True)
        ValidateNumbers(0, Integer.MaxValue, txtSupertrendPeriod, True)
        ValidateNumbers(0, Decimal.MaxValue, txtSupertrendMultiplier)
    End Sub

End Class