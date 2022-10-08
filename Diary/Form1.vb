'2011/12/24 新規作成(VB2005による)
'2013/08/17 全面的に更新
'2013/09/16 カレンダー画面追加
'2014/03/25 テキスト検索画面追加
'2014/04/11 カレンダー設定時に曜日が更新されないバグを修正
'2014/08/09 VB2013に移行
'2015/07/26 「明日へ」ボタン追加
'2016/01/02 カレンダー初期表示を今日の日付ではなく画面表示日時で設定するように更新
'2018/07/11 検索画面で検索後に該当件数を表示できるように更新
'2018/09/18 ファンクションキーの割り当て
'2019/08/26 シングルクォーテーションが含まれていると異常終了してしまうバグを修正
'2019/12/05 データ更新時に確認メッセージを表示するように更新
'2020/12/16 テキストエリアを広げる
'2021/04/28 フォームを画面のセンターに表示するように更新
'           Gitにアップロード
'2022/10/07 INIファイル読込処理と二重起動チェック処理を追加
Public Class frmMain

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Iniファイル名設定
        gsIniPath = My.Application.Info.DirectoryPath & "\" & INIFILENAME

        'IniFile読み込み
        If FnGetIniFileInfo() = False Then
            '異常終了
            End
        End If

        'DBファイル存在確認
        If FnFileget(gDBName) = False Then
            MsgBox("MDBファイルが存在しません。", vbCritical, TITLE)
            '異常終了
            End
        End If

        ' 二重起動チェック
        If FnUpcheck() = False Then
            '異常終了
            End
        End If

        With txtDate
            .Text = CStr(Today)
            .ReadOnly = True
        End With

        With txtWeek
            .Text = WeekdayName(Weekday(Now)).Substring(0, 1)
            .ReadOnly = True
        End With

        '日記データ設定
        Me.SetDiary()

    End Sub

    '2018/09/18 ADD
    'ファンクションキーの割り当て
    'http://blog.livedoor.jp/akf0/archives/51318094.html
    'KeyPreviewプロパティをTrueに変更する。
    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                '「本日」ボタン
                cmdToday.PerformClick()
            Case Keys.F2
                '「昨日へ」ボタン
                cmdYesterday.PerformClick()
            Case Keys.F3
                '「明日へ」ボタン
                cmdtomorrow.PerformClick()
            Case Keys.F5
                '「更新」ボタン
                cmdUpdate.PerformClick()
            Case Keys.F9
                '「カレンダー」ボタン
                cmdCalendar.PerformClick()
            Case Keys.F11
                '「検索」ボタン
                cmdSearch.PerformClick()
            Case Keys.F12
                '「終了」ボタン
                cmdEnd.PerformClick()
        End Select
    End Sub

    '「本日」ボタン
    Private Sub cmdToday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToday.Click

        txtDate.Text = CStr(Today)
        txtWeek.Text = WeekdayName(Weekday(Now)).Substring(0, 1)

        '日記データ設定
        Me.SetDiary()

    End Sub

    '「昨日へ」ボタン
    Private Sub cmdYesterday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdYesterday.Click

        txtDate.Text = CStr(CDate(txtDate.Text).AddDays(-1))

        '日記データ設定
        Me.SetDiary()

    End Sub

    '「明日へ」ボタン
    Private Sub cmdtomorrow_Click(sender As Object, e As EventArgs) Handles cmdtomorrow.Click

        txtDate.Text = CStr(CDate(txtDate.Text).AddDays(+1))

        '日記データ設定
        Me.SetDiary()

    End Sub

    '「更新」ボタン
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click

        Dim strSQL As String
        Dim reader As OleDb.OleDbDataReader = Nothing
        Dim cn As New OleDb.OleDbConnection

        Try
            If String.IsNullOrEmpty(txtSchedule.Text) AndAlso String.IsNullOrEmpty(txtDiary.Text) Then
                MsgBox("入力してください。", vbExclamation, TITLE)
                txtSchedule.Focus()
                Exit Sub
            End If

            If Me.DataCheck(reader) = False Then
                '新規追加
                strSQL = ""
                strSQL = "INSERT INTO Diary([DATE],[WEEKDAY],[DIARYTEXT],[SCHEDULE],[ETC])" & vbCrLf
                strSQL = strSQL & " VALUES('" & txtDate.Text & "'" & vbCrLf
                strSQL = strSQL & ",'" & txtWeek.Text & "'" & vbCrLf
                '2019/08/26 UPDATE START
                strSQL = strSQL & ",'" & SanitizeSQL(txtDiary.Text) & "'" & vbCrLf
                strSQL = strSQL & ",'" & SanitizeSQL(txtSchedule.Text) & "'" & vbCrLf
                '2019/08/26 UPDATE END
                strSQL = strSQL & ",'');" & vbCrLf
            Else
                '2019/12/05 ADD START
                Dim msgResult As DialogResult = MessageBox.Show("更新しますか？", "更新確認",
                                                                MessageBoxButtons.YesNo,
                                                                MessageBoxIcon.Question,
                                                                MessageBoxDefaultButton.Button2)

                If Not msgResult = MsgBoxResult.Yes Then
                    Exit Sub
                End If
                '2019/12/05 ADD END

                '既存レコード更新
                strSQL = ""
                strSQL = "UPDATE Diary SET" & vbCrLf
                '2019/08/26 UPDATE START
                strSQL = strSQL & " DIARYTEXT = '" & SanitizeSQL(txtDiary.Text) & "'" & vbCrLf
                strSQL = strSQL & "," & " SCHEDULE = '" & SanitizeSQL(txtSchedule.Text) & "'" & vbCrLf
                '2019/08/26 UPDATE END
                strSQL = strSQL & " WHERE DATE = '" & txtDate.Text & "'" & vbCrLf

            End If

            DB_OPEN(cn)

            Dim SQLCm As OleDb.OleDbCommand = cn.CreateCommand
            SQLCm.CommandText = strSQL
            'SQL実行
            SQLCm.ExecuteNonQuery()
            cn.Close()

            MsgBox("更新しました。", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    '「カレンダー」ボタン
    Private Sub cmdCalendar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalendar.Click
        frmCalendar.ShowDialog()

    End Sub

    '「検索」ボタン
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        frmTextSearch.ShowDialog()

    End Sub

    '「終了」ボタン
    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        End

    End Sub

    Private Sub txtSchedule_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSchedule.GotFocus
        txtSchedule.SelectAll()
    End Sub

    Private Sub txtDiary_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiary.GotFocus
        txtDiary.SelectAll()
    End Sub

    '日記データ設定
    Public Sub SetDiary()

        Dim cn As New OleDb.OleDbConnection
        Dim cmd As New OleDb.OleDbCommand
        Dim strSQL As String
        Dim dr As OleDb.OleDbDataReader

        DB_OPEN(cn)

        strSQL = "select * from Diary where DATE = #" & txtDate.Text & "#"

        With cmd
            .Connection = cn
            .CommandText = strSQL
        End With

        dr = cmd.ExecuteReader

        If Me.DataCheck(dr) = True Then
            dr.Read()
            txtWeek.Text = dr("WEEKDAY").ToString
            txtSchedule.Text = dr("SCHEDULE").ToString
            txtDiary.Text = dr("DIARYTEXT").ToString
        Else
            '2014/04/11 ADD START カレンダー設定時に曜日が更新されないバグを修正
            txtWeek.Text = Mid(WeekdayName(Weekday(CDate(txtDate.Text), vbSunday)), 1, 1)
            '2014/04/11 ADD END
            txtSchedule.Text = ""
            txtDiary.Text = ""
        End If

        dr.Close() : dr = Nothing
        cn.Close() : cn = Nothing

    End Sub

    '2018/09/15 Try～Catchを追加 dr.Close,cn.Closeを削除(潜在バグ)
    '日記データ存在確認
    Public Function DataCheck(ByRef dr As OleDb.OleDbDataReader) As Boolean
        Dim cn As New OleDb.OleDbConnection

        Try

            Dim cmd As New OleDb.OleDbCommand
            Dim strSQL As String

            DB_OPEN(cn)

            strSQL = "select * from Diary where DATE = #" & txtDate.Text & "#"

            With cmd
                .Connection = cn
                .CommandText = strSQL
            End With

            dr = cmd.ExecuteReader

            If dr.HasRows = True Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Function

End Class
