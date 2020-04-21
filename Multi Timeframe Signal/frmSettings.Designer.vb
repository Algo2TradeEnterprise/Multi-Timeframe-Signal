<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnSave = New System.Windows.Forms.Button()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabOthers = New System.Windows.Forms.TabPage()
        Me.grpTimeframe = New System.Windows.Forms.GroupBox()
        Me.chkb5Minutes = New System.Windows.Forms.CheckBox()
        Me.chkb15Minutes = New System.Windows.Forms.CheckBox()
        Me.chkb1Hour = New System.Windows.Forms.CheckBox()
        Me.chkb1Day = New System.Windows.Forms.CheckBox()
        Me.chkb1Week = New System.Windows.Forms.CheckBox()
        Me.txtMainStockParallelHit = New System.Windows.Forms.TextBox()
        Me.lblMainStockParallelHit = New System.Windows.Forms.Label()
        Me.tabStockSelection = New System.Windows.Forms.TabPage()
        Me.lblFetchBannedStocks = New System.Windows.Forms.Label()
        Me.chkbFetchBannedStocks = New System.Windows.Forms.CheckBox()
        Me.txtBlankCandlePercentage = New System.Windows.Forms.TextBox()
        Me.lblBlankCandlePercentage = New System.Windows.Forms.Label()
        Me.txtNumberOfStock = New System.Windows.Forms.TextBox()
        Me.lblNumberOfStock = New System.Windows.Forms.Label()
        Me.txtATRPercentage = New System.Windows.Forms.TextBox()
        Me.lblATR = New System.Windows.Forms.Label()
        Me.txtMaxPrice = New System.Windows.Forms.TextBox()
        Me.lblMaxPrice = New System.Windows.Forms.Label()
        Me.txtMinPrice = New System.Windows.Forms.TextBox()
        Me.lblMinPrice = New System.Windows.Forms.Label()
        Me.tabIndicator = New System.Windows.Forms.TabPage()
        Me.txtSupertrendMultiplier = New System.Windows.Forms.TextBox()
        Me.lblSupertrendMultiplier = New System.Windows.Forms.Label()
        Me.txtSupertrendPeriod = New System.Windows.Forms.TextBox()
        Me.lblSupertrendPeriod = New System.Windows.Forms.Label()
        Me.txtAroonPeriod = New System.Windows.Forms.TextBox()
        Me.lblAroonPeriod = New System.Windows.Forms.Label()
        Me.txtEMAPeriod = New System.Windows.Forms.TextBox()
        Me.lblEMAPeriod = New System.Windows.Forms.Label()
        Me.tabMain.SuspendLayout()
        Me.tabOthers.SuspendLayout()
        Me.grpTimeframe.SuspendLayout()
        Me.tabStockSelection.SuspendLayout()
        Me.tabIndicator.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "save-icon-36533.png")
        '
        'btnSave
        '
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.ImageKey = "save-icon-36533.png"
        Me.btnSave.ImageList = Me.ImageList1
        Me.btnSave.Location = New System.Drawing.Point(478, 25)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(112, 58)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tabOthers)
        Me.tabMain.Controls.Add(Me.tabStockSelection)
        Me.tabMain.Controls.Add(Me.tabIndicator)
        Me.tabMain.Location = New System.Drawing.Point(1, 0)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(470, 228)
        Me.tabMain.TabIndex = 13
        '
        'tabOthers
        '
        Me.tabOthers.Controls.Add(Me.grpTimeframe)
        Me.tabOthers.Controls.Add(Me.txtMainStockParallelHit)
        Me.tabOthers.Controls.Add(Me.lblMainStockParallelHit)
        Me.tabOthers.Location = New System.Drawing.Point(4, 25)
        Me.tabOthers.Name = "tabOthers"
        Me.tabOthers.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOthers.Size = New System.Drawing.Size(462, 199)
        Me.tabOthers.TabIndex = 0
        Me.tabOthers.Text = "Others"
        Me.tabOthers.UseVisualStyleBackColor = True
        '
        'grpTimeframe
        '
        Me.grpTimeframe.Controls.Add(Me.chkb5Minutes)
        Me.grpTimeframe.Controls.Add(Me.chkb15Minutes)
        Me.grpTimeframe.Controls.Add(Me.chkb1Hour)
        Me.grpTimeframe.Controls.Add(Me.chkb1Day)
        Me.grpTimeframe.Controls.Add(Me.chkb1Week)
        Me.grpTimeframe.Location = New System.Drawing.Point(6, 45)
        Me.grpTimeframe.Name = "grpTimeframe"
        Me.grpTimeframe.Size = New System.Drawing.Size(192, 151)
        Me.grpTimeframe.TabIndex = 2
        Me.grpTimeframe.TabStop = False
        Me.grpTimeframe.Text = "Choose any 4 timeframe"
        '
        'chkb5Minutes
        '
        Me.chkb5Minutes.AutoSize = True
        Me.chkb5Minutes.Checked = True
        Me.chkb5Minutes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkb5Minutes.Enabled = False
        Me.chkb5Minutes.Location = New System.Drawing.Point(7, 122)
        Me.chkb5Minutes.Name = "chkb5Minutes"
        Me.chkb5Minutes.Size = New System.Drawing.Size(91, 21)
        Me.chkb5Minutes.TabIndex = 4
        Me.chkb5Minutes.Text = "5 Minutes"
        Me.chkb5Minutes.UseVisualStyleBackColor = True
        '
        'chkb15Minutes
        '
        Me.chkb15Minutes.AutoSize = True
        Me.chkb15Minutes.Location = New System.Drawing.Point(7, 97)
        Me.chkb15Minutes.Name = "chkb15Minutes"
        Me.chkb15Minutes.Size = New System.Drawing.Size(99, 21)
        Me.chkb15Minutes.TabIndex = 3
        Me.chkb15Minutes.Text = "15 Minutes"
        Me.chkb15Minutes.UseVisualStyleBackColor = True
        '
        'chkb1Hour
        '
        Me.chkb1Hour.AutoSize = True
        Me.chkb1Hour.Location = New System.Drawing.Point(7, 72)
        Me.chkb1Hour.Name = "chkb1Hour"
        Me.chkb1Hour.Size = New System.Drawing.Size(73, 21)
        Me.chkb1Hour.TabIndex = 2
        Me.chkb1Hour.Text = "1 Hour"
        Me.chkb1Hour.UseVisualStyleBackColor = True
        '
        'chkb1Day
        '
        Me.chkb1Day.AutoSize = True
        Me.chkb1Day.Location = New System.Drawing.Point(7, 47)
        Me.chkb1Day.Name = "chkb1Day"
        Me.chkb1Day.Size = New System.Drawing.Size(67, 21)
        Me.chkb1Day.TabIndex = 1
        Me.chkb1Day.Text = "1 Day"
        Me.chkb1Day.UseVisualStyleBackColor = True
        '
        'chkb1Week
        '
        Me.chkb1Week.AutoSize = True
        Me.chkb1Week.Location = New System.Drawing.Point(7, 22)
        Me.chkb1Week.Name = "chkb1Week"
        Me.chkb1Week.Size = New System.Drawing.Size(78, 21)
        Me.chkb1Week.TabIndex = 0
        Me.chkb1Week.Text = "1 Week"
        Me.chkb1Week.UseVisualStyleBackColor = True
        '
        'txtMainStockParallelHit
        '
        Me.txtMainStockParallelHit.Location = New System.Drawing.Point(192, 12)
        Me.txtMainStockParallelHit.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMainStockParallelHit.Name = "txtMainStockParallelHit"
        Me.txtMainStockParallelHit.Size = New System.Drawing.Size(201, 22)
        Me.txtMainStockParallelHit.TabIndex = 1
        Me.txtMainStockParallelHit.Tag = "Main Stock Parallel Hit"
        '
        'lblMainStockParallelHit
        '
        Me.lblMainStockParallelHit.AutoSize = True
        Me.lblMainStockParallelHit.Location = New System.Drawing.Point(10, 15)
        Me.lblMainStockParallelHit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMainStockParallelHit.Name = "lblMainStockParallelHit"
        Me.lblMainStockParallelHit.Size = New System.Drawing.Size(149, 17)
        Me.lblMainStockParallelHit.TabIndex = 62
        Me.lblMainStockParallelHit.Text = "Main Stock Parallel Hit"
        '
        'tabStockSelection
        '
        Me.tabStockSelection.Controls.Add(Me.lblFetchBannedStocks)
        Me.tabStockSelection.Controls.Add(Me.chkbFetchBannedStocks)
        Me.tabStockSelection.Controls.Add(Me.txtBlankCandlePercentage)
        Me.tabStockSelection.Controls.Add(Me.lblBlankCandlePercentage)
        Me.tabStockSelection.Controls.Add(Me.txtNumberOfStock)
        Me.tabStockSelection.Controls.Add(Me.lblNumberOfStock)
        Me.tabStockSelection.Controls.Add(Me.txtATRPercentage)
        Me.tabStockSelection.Controls.Add(Me.lblATR)
        Me.tabStockSelection.Controls.Add(Me.txtMaxPrice)
        Me.tabStockSelection.Controls.Add(Me.lblMaxPrice)
        Me.tabStockSelection.Controls.Add(Me.txtMinPrice)
        Me.tabStockSelection.Controls.Add(Me.lblMinPrice)
        Me.tabStockSelection.Location = New System.Drawing.Point(4, 25)
        Me.tabStockSelection.Name = "tabStockSelection"
        Me.tabStockSelection.Padding = New System.Windows.Forms.Padding(3)
        Me.tabStockSelection.Size = New System.Drawing.Size(462, 199)
        Me.tabStockSelection.TabIndex = 1
        Me.tabStockSelection.Text = "Stock Selection"
        Me.tabStockSelection.UseVisualStyleBackColor = True
        '
        'lblFetchBannedStocks
        '
        Me.lblFetchBannedStocks.AutoSize = True
        Me.lblFetchBannedStocks.Location = New System.Drawing.Point(10, 168)
        Me.lblFetchBannedStocks.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFetchBannedStocks.Name = "lblFetchBannedStocks"
        Me.lblFetchBannedStocks.Size = New System.Drawing.Size(142, 17)
        Me.lblFetchBannedStocks.TabIndex = 59
        Me.lblFetchBannedStocks.Text = "Fetch Banned Stocks"
        '
        'chkbFetchBannedStocks
        '
        Me.chkbFetchBannedStocks.AutoSize = True
        Me.chkbFetchBannedStocks.Location = New System.Drawing.Point(191, 168)
        Me.chkbFetchBannedStocks.Name = "chkbFetchBannedStocks"
        Me.chkbFetchBannedStocks.Size = New System.Drawing.Size(18, 17)
        Me.chkbFetchBannedStocks.TabIndex = 6
        Me.chkbFetchBannedStocks.UseVisualStyleBackColor = True
        '
        'txtBlankCandlePercentage
        '
        Me.txtBlankCandlePercentage.Location = New System.Drawing.Point(191, 103)
        Me.txtBlankCandlePercentage.Margin = New System.Windows.Forms.Padding(4)
        Me.txtBlankCandlePercentage.Name = "txtBlankCandlePercentage"
        Me.txtBlankCandlePercentage.Size = New System.Drawing.Size(201, 22)
        Me.txtBlankCandlePercentage.TabIndex = 4
        Me.txtBlankCandlePercentage.Tag = "Blank Candle %"
        '
        'lblBlankCandlePercentage
        '
        Me.lblBlankCandlePercentage.AutoSize = True
        Me.lblBlankCandlePercentage.Location = New System.Drawing.Point(10, 106)
        Me.lblBlankCandlePercentage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBlankCandlePercentage.Name = "lblBlankCandlePercentage"
        Me.lblBlankCandlePercentage.Size = New System.Drawing.Size(169, 17)
        Me.lblBlankCandlePercentage.TabIndex = 57
        Me.lblBlankCandlePercentage.Text = "Maximum Blank Candle %"
        '
        'txtNumberOfStock
        '
        Me.txtNumberOfStock.Location = New System.Drawing.Point(191, 134)
        Me.txtNumberOfStock.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumberOfStock.Name = "txtNumberOfStock"
        Me.txtNumberOfStock.Size = New System.Drawing.Size(201, 22)
        Me.txtNumberOfStock.TabIndex = 5
        Me.txtNumberOfStock.Tag = "Number Of Stock"
        '
        'lblNumberOfStock
        '
        Me.lblNumberOfStock.AutoSize = True
        Me.lblNumberOfStock.Location = New System.Drawing.Point(9, 137)
        Me.lblNumberOfStock.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNumberOfStock.Name = "lblNumberOfStock"
        Me.lblNumberOfStock.Size = New System.Drawing.Size(116, 17)
        Me.lblNumberOfStock.TabIndex = 56
        Me.lblNumberOfStock.Text = "Number Of Stock"
        '
        'txtATRPercentage
        '
        Me.txtATRPercentage.Location = New System.Drawing.Point(191, 73)
        Me.txtATRPercentage.Margin = New System.Windows.Forms.Padding(4)
        Me.txtATRPercentage.Name = "txtATRPercentage"
        Me.txtATRPercentage.Size = New System.Drawing.Size(201, 22)
        Me.txtATRPercentage.TabIndex = 3
        Me.txtATRPercentage.Tag = "ATR %"
        '
        'lblATR
        '
        Me.lblATR.AutoSize = True
        Me.lblATR.Location = New System.Drawing.Point(9, 76)
        Me.lblATR.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblATR.Name = "lblATR"
        Me.lblATR.Size = New System.Drawing.Size(111, 17)
        Me.lblATR.TabIndex = 54
        Me.lblATR.Text = "Minimum ATR %"
        '
        'txtMaxPrice
        '
        Me.txtMaxPrice.Location = New System.Drawing.Point(191, 43)
        Me.txtMaxPrice.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMaxPrice.Name = "txtMaxPrice"
        Me.txtMaxPrice.Size = New System.Drawing.Size(201, 22)
        Me.txtMaxPrice.TabIndex = 2
        Me.txtMaxPrice.Tag = "Max Price"
        '
        'lblMaxPrice
        '
        Me.lblMaxPrice.AutoSize = True
        Me.lblMaxPrice.Location = New System.Drawing.Point(9, 47)
        Me.lblMaxPrice.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMaxPrice.Name = "lblMaxPrice"
        Me.lblMaxPrice.Size = New System.Drawing.Size(102, 17)
        Me.lblMaxPrice.TabIndex = 53
        Me.lblMaxPrice.Text = "Maximum Price"
        '
        'txtMinPrice
        '
        Me.txtMinPrice.Location = New System.Drawing.Point(191, 13)
        Me.txtMinPrice.Margin = New System.Windows.Forms.Padding(4)
        Me.txtMinPrice.Name = "txtMinPrice"
        Me.txtMinPrice.Size = New System.Drawing.Size(201, 22)
        Me.txtMinPrice.TabIndex = 1
        Me.txtMinPrice.Tag = "Min Price"
        '
        'lblMinPrice
        '
        Me.lblMinPrice.AutoSize = True
        Me.lblMinPrice.Location = New System.Drawing.Point(9, 16)
        Me.lblMinPrice.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMinPrice.Name = "lblMinPrice"
        Me.lblMinPrice.Size = New System.Drawing.Size(99, 17)
        Me.lblMinPrice.TabIndex = 52
        Me.lblMinPrice.Text = "Minimum Price"
        '
        'tabIndicator
        '
        Me.tabIndicator.Controls.Add(Me.txtSupertrendMultiplier)
        Me.tabIndicator.Controls.Add(Me.lblSupertrendMultiplier)
        Me.tabIndicator.Controls.Add(Me.txtSupertrendPeriod)
        Me.tabIndicator.Controls.Add(Me.lblSupertrendPeriod)
        Me.tabIndicator.Controls.Add(Me.txtAroonPeriod)
        Me.tabIndicator.Controls.Add(Me.lblAroonPeriod)
        Me.tabIndicator.Controls.Add(Me.txtEMAPeriod)
        Me.tabIndicator.Controls.Add(Me.lblEMAPeriod)
        Me.tabIndicator.Location = New System.Drawing.Point(4, 25)
        Me.tabIndicator.Name = "tabIndicator"
        Me.tabIndicator.Size = New System.Drawing.Size(462, 199)
        Me.tabIndicator.TabIndex = 2
        Me.tabIndicator.Text = "Indicator"
        Me.tabIndicator.UseVisualStyleBackColor = True
        '
        'txtSupertrendMultiplier
        '
        Me.txtSupertrendMultiplier.Location = New System.Drawing.Point(192, 100)
        Me.txtSupertrendMultiplier.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSupertrendMultiplier.Name = "txtSupertrendMultiplier"
        Me.txtSupertrendMultiplier.Size = New System.Drawing.Size(201, 22)
        Me.txtSupertrendMultiplier.TabIndex = 4
        Me.txtSupertrendMultiplier.Tag = "Supertrend Multiplier"
        '
        'lblSupertrendMultiplier
        '
        Me.lblSupertrendMultiplier.AutoSize = True
        Me.lblSupertrendMultiplier.Location = New System.Drawing.Point(11, 103)
        Me.lblSupertrendMultiplier.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSupertrendMultiplier.Name = "lblSupertrendMultiplier"
        Me.lblSupertrendMultiplier.Size = New System.Drawing.Size(139, 17)
        Me.lblSupertrendMultiplier.TabIndex = 67
        Me.lblSupertrendMultiplier.Text = "Supertrend Multiplier"
        '
        'txtSupertrendPeriod
        '
        Me.txtSupertrendPeriod.Location = New System.Drawing.Point(192, 70)
        Me.txtSupertrendPeriod.Margin = New System.Windows.Forms.Padding(4)
        Me.txtSupertrendPeriod.Name = "txtSupertrendPeriod"
        Me.txtSupertrendPeriod.Size = New System.Drawing.Size(201, 22)
        Me.txtSupertrendPeriod.TabIndex = 3
        Me.txtSupertrendPeriod.Tag = "Supertrend Period"
        '
        'lblSupertrendPeriod
        '
        Me.lblSupertrendPeriod.AutoSize = True
        Me.lblSupertrendPeriod.Location = New System.Drawing.Point(10, 73)
        Me.lblSupertrendPeriod.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSupertrendPeriod.Name = "lblSupertrendPeriod"
        Me.lblSupertrendPeriod.Size = New System.Drawing.Size(124, 17)
        Me.lblSupertrendPeriod.TabIndex = 65
        Me.lblSupertrendPeriod.Text = "Supertrend Period"
        '
        'txtAroonPeriod
        '
        Me.txtAroonPeriod.Location = New System.Drawing.Point(192, 40)
        Me.txtAroonPeriod.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAroonPeriod.Name = "txtAroonPeriod"
        Me.txtAroonPeriod.Size = New System.Drawing.Size(201, 22)
        Me.txtAroonPeriod.TabIndex = 2
        Me.txtAroonPeriod.Tag = "Aroon Period"
        '
        'lblAroonPeriod
        '
        Me.lblAroonPeriod.AutoSize = True
        Me.lblAroonPeriod.Location = New System.Drawing.Point(10, 44)
        Me.lblAroonPeriod.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAroonPeriod.Name = "lblAroonPeriod"
        Me.lblAroonPeriod.Size = New System.Drawing.Size(91, 17)
        Me.lblAroonPeriod.TabIndex = 64
        Me.lblAroonPeriod.Text = "Aroon Period"
        '
        'txtEMAPeriod
        '
        Me.txtEMAPeriod.Location = New System.Drawing.Point(192, 10)
        Me.txtEMAPeriod.Margin = New System.Windows.Forms.Padding(4)
        Me.txtEMAPeriod.Name = "txtEMAPeriod"
        Me.txtEMAPeriod.Size = New System.Drawing.Size(201, 22)
        Me.txtEMAPeriod.TabIndex = 1
        Me.txtEMAPeriod.Tag = "EMA Period"
        '
        'lblEMAPeriod
        '
        Me.lblEMAPeriod.AutoSize = True
        Me.lblEMAPeriod.Location = New System.Drawing.Point(10, 13)
        Me.lblEMAPeriod.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEMAPeriod.Name = "lblEMAPeriod"
        Me.lblEMAPeriod.Size = New System.Drawing.Size(82, 17)
        Me.lblEMAPeriod.TabIndex = 63
        Me.lblEMAPeriod.Text = "EMA Period"
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 228)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.btnSave)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.tabMain.ResumeLayout(False)
        Me.tabOthers.ResumeLayout(False)
        Me.tabOthers.PerformLayout()
        Me.grpTimeframe.ResumeLayout(False)
        Me.grpTimeframe.PerformLayout()
        Me.tabStockSelection.ResumeLayout(False)
        Me.tabStockSelection.PerformLayout()
        Me.tabIndicator.ResumeLayout(False)
        Me.tabIndicator.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents btnSave As Button
    Friend WithEvents tabMain As TabControl
    Friend WithEvents tabOthers As TabPage
    Friend WithEvents tabStockSelection As TabPage
    Friend WithEvents txtMainStockParallelHit As TextBox
    Friend WithEvents lblMainStockParallelHit As Label
    Friend WithEvents txtBlankCandlePercentage As TextBox
    Friend WithEvents lblBlankCandlePercentage As Label
    Friend WithEvents txtNumberOfStock As TextBox
    Friend WithEvents lblNumberOfStock As Label
    Friend WithEvents txtATRPercentage As TextBox
    Friend WithEvents lblATR As Label
    Friend WithEvents txtMaxPrice As TextBox
    Friend WithEvents lblMaxPrice As Label
    Friend WithEvents txtMinPrice As TextBox
    Friend WithEvents lblMinPrice As Label
    Friend WithEvents lblFetchBannedStocks As Label
    Friend WithEvents chkbFetchBannedStocks As CheckBox
    Friend WithEvents tabIndicator As TabPage
    Friend WithEvents txtSupertrendMultiplier As TextBox
    Friend WithEvents lblSupertrendMultiplier As Label
    Friend WithEvents txtSupertrendPeriod As TextBox
    Friend WithEvents lblSupertrendPeriod As Label
    Friend WithEvents txtAroonPeriod As TextBox
    Friend WithEvents lblAroonPeriod As Label
    Friend WithEvents txtEMAPeriod As TextBox
    Friend WithEvents lblEMAPeriod As Label
    Friend WithEvents grpTimeframe As GroupBox
    Friend WithEvents chkb5Minutes As CheckBox
    Friend WithEvents chkb15Minutes As CheckBox
    Friend WithEvents chkb1Hour As CheckBox
    Friend WithEvents chkb1Day As CheckBox
    Friend WithEvents chkb1Week As CheckBox
End Class
