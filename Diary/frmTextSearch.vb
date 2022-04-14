'2014/03/25 新規作成
'2018/07/11 検索件数を表示できるように更新
'2018/07/13 検索した言葉を表示できるように更新
'2019/08/13 ファンクションキーの割り当て
'           検索ボタン押下時の入力チェック追加
'           クリアボタン追加
'2019/08/23 設定ボタン押下時に日付以外のセルを選択した場合、異常終了するバグを修正
'2019/08/26 シングルクォーテーションが含まれていると異常終了してしまうバグを修正
'http://homepage1.nifty.com/rucio/main/VBdotNet/Database/Database5.htm
Imports System.Data.OleDb

Public Class frmTextSearch

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With txtWords
            .Clear()
            .Focus()
        End With

    End Sub

    '2019/08/13 ADD
    'ファンクションキーの割り当て
    'KeyPreviewプロパティをTrueに変更する。
    Private Sub frmTextSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                '「クリア」ボタン
                cmdClear.PerformClick()
            Case Keys.F3
                '「検索」ボタン
                cmdSearch.PerformClick()
            Case Keys.F5
                '「設定」ボタン
                cmdSet.PerformClick()
            Case Keys.F12
                '「閉じる」ボタン
                cmdClose.PerformClick()
        End Select
    End Sub

    Private Sub txtWords_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWords.GotFocus
        txtWords.SelectAll()

    End Sub

    '「閉じる」ボタン
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()

    End Sub

    '「検索」ボタン
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        '2019/08/13 UPDATE START
        '入力チェック
        If String.IsNullOrEmpty(txtWords.Text) AndAlso String.IsNullOrEmpty(txtWords.Text) Then
            MsgBox("入力してください。", vbExclamation, TITLE)
            txtWords.Focus()
            Exit Sub
        End If
        '2019/08/13 UPDATE END

        Me.openForm()

        Dim Table As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
        Dim View As DataView = Table.DefaultView

        '2018/07/13 UPDATE START
        Dim strWords As String = txtWords.Text
        View.RowFilter = "DIARYTEXT LIKE '*" & SanitizeSQL(strWords) & "*'" '2019/08/26 UPDATE
        'View.RowFilter = "DIARYTEXT LIKE '*" & strWords & "*'" '2019/08/26 DELETE
        'View.RowFilter = "DIARYTEXT LIKE '*" & txtWords.Text & "*'"
        '2018/07/13 UPDATE END
        Me.Text = "該当件数：" & View.Count.ToString & Space(3) &
                    "検索：" & strWords '2018/07/11 検索件数を表示 2018/07/13 UPDATE

        '2019/08/13 UPDATE START
        If Not View.Count = 0 Then
            Me.cmdSet.Enabled = True
        End If
        Me.cmdClear.Enabled = True
        '2019/08/13 UPDATE END
    End Sub

    '「設定」ボタン
    Private Sub cmdSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSet.Click
        '2019/08/23 UPDATE 設定ボタン押下時に日付以外のセルを選択した場合、異常終了するバグを修正
        Try
            Dim searchGrid As DataGridView = Me.DataGridView1

            '日付設定
            frmMain.txtDate.Text = searchGrid.Item(0, searchGrid.CurrentRow.Index).Value.ToString
            'frmMain.txtDate.Text = DataGridView1.CurrentCell.Value.ToString

            '日記データ設定
            frmMain.SetDiary()

            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message, vbExclamation, TITLE)
        End Try

    End Sub

    '2019/08/13 ADD
    '「クリア」ボタン
    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        '初期化処理
        Me.Initial()

    End Sub

    Private Sub openForm()
        'データ取得
        Dim Cn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DBNAME & "")
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable

        SQLCm.CommandText = "SELECT * FROM Diary ORDER BY DATE"
        Adapter.Fill(Table)

        '値の表示
        DataGridView1.DataSource = Table

    End Sub

    '2019/08/13 ADD
    '初期化処理
    Private Sub Initial()
        Me.Text = "検索"
        Me.cmdClear.Enabled = False
        Me.cmdSet.Enabled = False
        Me.txtWords.Clear()
        'DataSourceでバインドしている時の初期化
        Me.DataGridView1.DataSource = Nothing

    End Sub
End Class