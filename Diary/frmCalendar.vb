'2013/09/16 新規作成
'2016/01/02 カレンダー初期表示を今日の日付ではなく画面表示日時で設定するように更新
'2019/08/13 ファンクションキーの割り当て
Public Class frmCalendar

    Private Sub frmCalendar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '2016/01/02画面表示している日付を設定
        Dim dispDate As Date = CDate(frmMain.txtDate.Text)

        Calendar1.SetDate(dispDate)
        '今日の日付を設定
        'Calendar1.SetDate(Today)

    End Sub

    '2019/08/13 ADD
    'ファンクションキーの割り当て
    'KeyPreviewプロパティをTrueに変更する。
    Private Sub frmCalendar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                '「設定」ボタン
                cmdSet.PerformClick()
            Case Keys.F12
                '「閉じる」ボタン
                cmdClose.PerformClick()
        End Select
    End Sub

    '「設定」ボタン
    Private Sub cmdSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSet.Click

        '日付設定
        frmMain.txtDate.Text = CStr(Calendar1.SelectionRange.Start)

        '日記データ設定
        frmMain.SetDiary()

        Me.Close()

    End Sub

    '「閉じる」ボタン
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()

    End Sub
End Class