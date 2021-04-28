<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalendar
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
        Me.Calendar1 = New System.Windows.Forms.MonthCalendar()
        Me.cmdSet = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Calendar1
        '
        Me.Calendar1.Location = New System.Drawing.Point(52, 31)
        Me.Calendar1.Name = "Calendar1"
        Me.Calendar1.TabIndex = 0
        '
        'cmdSet
        '
        Me.cmdSet.Location = New System.Drawing.Point(77, 232)
        Me.cmdSet.Name = "cmdSet"
        Me.cmdSet.Size = New System.Drawing.Size(80, 25)
        Me.cmdSet.TabIndex = 8
        Me.cmdSet.Text = "設定"
        Me.cmdSet.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(167, 232)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(80, 25)
        Me.cmdClose.TabIndex = 9
        Me.cmdClose.Text = "閉じる"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(109, 217)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 12)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "F5"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(193, 217)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 12)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "F12"
        '
        'frmCalendar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(324, 282)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdSet)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.Calendar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "frmCalendar"
        Me.ShowInTaskbar = False
        Me.Text = "frmCalendar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Calendar1 As System.Windows.Forms.MonthCalendar
    Friend WithEvents cmdSet As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
End Class
