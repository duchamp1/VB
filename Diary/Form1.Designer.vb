<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows フォーム デザイナで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナで必要です。
    'Windows フォーム デザイナを使用して変更できます。  
    'コード エディタを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.txtWeek = New System.Windows.Forms.TextBox()
        Me.txtSchedule = New System.Windows.Forms.TextBox()
        Me.txtDiary = New System.Windows.Forms.TextBox()
        Me.cmdToday = New System.Windows.Forms.Button()
        Me.cmdYesterday = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmdEnd = New System.Windows.Forms.Button()
        Me.cmdCalendar = New System.Windows.Forms.Button()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.cmdtomorrow = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtDate
        '
        Me.txtDate.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.txtDate.Location = New System.Drawing.Point(21, 34)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.Size = New System.Drawing.Size(76, 19)
        Me.txtDate.TabIndex = 0
        Me.txtDate.TabStop = False
        Me.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWeek
        '
        Me.txtWeek.Location = New System.Drawing.Point(103, 34)
        Me.txtWeek.Name = "txtWeek"
        Me.txtWeek.Size = New System.Drawing.Size(29, 19)
        Me.txtWeek.TabIndex = 1
        Me.txtWeek.TabStop = False
        Me.txtWeek.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSchedule
        '
        Me.txtSchedule.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtSchedule.Location = New System.Drawing.Point(21, 73)
        Me.txtSchedule.Multiline = True
        Me.txtSchedule.Name = "txtSchedule"
        Me.txtSchedule.Size = New System.Drawing.Size(622, 33)
        Me.txtSchedule.TabIndex = 0
        '
        'txtDiary
        '
        Me.txtDiary.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.txtDiary.Location = New System.Drawing.Point(21, 122)
        Me.txtDiary.Multiline = True
        Me.txtDiary.Name = "txtDiary"
        Me.txtDiary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDiary.Size = New System.Drawing.Size(622, 420)
        Me.txtDiary.TabIndex = 1
        '
        'cmdToday
        '
        Me.cmdToday.Location = New System.Drawing.Point(137, 31)
        Me.cmdToday.Name = "cmdToday"
        Me.cmdToday.Size = New System.Drawing.Size(70, 25)
        Me.cmdToday.TabIndex = 2
        Me.cmdToday.Text = "本日"
        Me.cmdToday.UseVisualStyleBackColor = True
        '
        'cmdYesterday
        '
        Me.cmdYesterday.Location = New System.Drawing.Point(209, 31)
        Me.cmdYesterday.Name = "cmdYesterday"
        Me.cmdYesterday.Size = New System.Drawing.Size(70, 25)
        Me.cmdYesterday.TabIndex = 3
        Me.cmdYesterday.Text = "昨日へ"
        Me.cmdYesterday.UseVisualStyleBackColor = True
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Location = New System.Drawing.Point(353, 31)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(70, 25)
        Me.cmdUpdate.TabIndex = 5
        Me.cmdUpdate.Text = "更新"
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'cmdEnd
        '
        Me.cmdEnd.Location = New System.Drawing.Point(569, 31)
        Me.cmdEnd.Name = "cmdEnd"
        Me.cmdEnd.Size = New System.Drawing.Size(70, 25)
        Me.cmdEnd.TabIndex = 8
        Me.cmdEnd.Text = "終了"
        Me.cmdEnd.UseVisualStyleBackColor = True
        '
        'cmdCalendar
        '
        Me.cmdCalendar.Location = New System.Drawing.Point(425, 31)
        Me.cmdCalendar.Name = "cmdCalendar"
        Me.cmdCalendar.Size = New System.Drawing.Size(70, 25)
        Me.cmdCalendar.TabIndex = 6
        Me.cmdCalendar.Text = "カレンダー"
        Me.cmdCalendar.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(497, 31)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(70, 25)
        Me.cmdSearch.TabIndex = 7
        Me.cmdSearch.Text = "検索"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'cmdtomorrow
        '
        Me.cmdtomorrow.Location = New System.Drawing.Point(281, 31)
        Me.cmdtomorrow.Name = "cmdtomorrow"
        Me.cmdtomorrow.Size = New System.Drawing.Size(70, 25)
        Me.cmdtomorrow.TabIndex = 4
        Me.cmdtomorrow.Text = "明日へ"
        Me.cmdtomorrow.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(161, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 12)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "F1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(231, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 12)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "F2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(305, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 12)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "F3"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(378, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 12)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "F5"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(449, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 12)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "F9"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(518, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 12)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "F11"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(589, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 12)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "F12"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(659, 561)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdtomorrow)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.cmdCalendar)
        Me.Controls.Add(Me.cmdEnd)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.cmdYesterday)
        Me.Controls.Add(Me.cmdToday)
        Me.Controls.Add(Me.txtDiary)
        Me.Controls.Add(Me.txtSchedule)
        Me.Controls.Add(Me.txtWeek)
        Me.Controls.Add(Me.txtDate)
        Me.KeyPreview = True
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "日記入力"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents txtWeek As System.Windows.Forms.TextBox
    Friend WithEvents txtSchedule As System.Windows.Forms.TextBox
    Friend WithEvents txtDiary As System.Windows.Forms.TextBox
    Friend WithEvents cmdToday As System.Windows.Forms.Button
    Friend WithEvents cmdYesterday As System.Windows.Forms.Button
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdEnd As System.Windows.Forms.Button
    Friend WithEvents cmdCalendar As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents cmdtomorrow As System.Windows.Forms.Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
End Class
