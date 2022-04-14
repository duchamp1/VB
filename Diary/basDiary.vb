'2013/08/17 新規作成
Module basDiary
    Public Const DBNAME As String = "D:\Ishizaki\Diary\DiaryDB.mdb"
    'Public Const DBNAME As String = "D:\MIRO\My Document\DIARY\DiaryDB.mdb"
    Public Const TITLE As String = "日記入力"
    Public Const INIFILENAME As String = "\Diary.ini"
    Public MaxRow As Long
    Public LIST(4) As String
    Public FIELD(4) As String

    Public Structure DiaryType
        Dim strDate As String
        Dim strDiary As String
        Dim strSchedule As String
    End Structure

    'DB接続
    Public Sub DB_OPEN(ByRef cn As OleDb.OleDbConnection)

        cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" _
            & "Data Source=" & DBNAME

        cn.Open()

    End Sub

    Public Sub ListField()
        LIST(0) = "NO"
        LIST(1) = "DATE"
        LIST(2) = "WEEKDAY"
        LIST(3) = "DIARYTEXT"
        LIST(4) = "SCHEDULE"

        FIELD(0) = "NO"
        FIELD(1) = "日付"
        FIELD(2) = "曜日"
        FIELD(3) = "日記"
        FIELD(4) = "予定"

    End Sub

    '2019/08/26 ADD
    'SQLをサニタイジングする。
    Public Function SanitizeSQL(ByVal value As String) As String

        If String.IsNullOrEmpty(value) Then
            Return String.Empty
        End If

        If Not value.Contains("'") Then
            Return value
        End If
        Dim ret As String = value.Replace("'", "''")

        Return ret
    End Function
End Module
