'2013/08/17 新規作成
Imports System.Runtime.InteropServices

Module basDiary
    'Public Const DBNAME As String = "D:\Ishizaki\Diary\DiaryDB.mdb"
    'Public Const DBNAME As String = "D:\MIRO\My Document\DIARY\DiaryDB.mdb"
    Public Const TITLE As String = "日記入力"
    Public Const INIFILENAME As String = "\Diary.ini" 'Iniファイル名
    Public gsIniPath As String ' Iniファイルフルパス
    Public gDBName As String
    Public MaxRow As Long
    Public LIST(4) As String
    Public FIELD(4) As String
    Public Declare Auto Function GetPrivateProfileString Lib "kernel32" _
        Alias "GetPrivateProfileString" (
        <MarshalAs(UnmanagedType.LPTStr)> ByVal lpApplicationName As String,
        <MarshalAs(UnmanagedType.LPTStr)> ByVal lpKeyName As String,
        <MarshalAs(UnmanagedType.LPTStr)> ByVal lpDefault As String,
        <MarshalAs(UnmanagedType.LPTStr)> ByVal lpReturnedString As System.Text.StringBuilder,
        ByVal nSize As UInt32,
        <MarshalAs(UnmanagedType.LPTStr)> ByVal lpFileName As String) As UInt32

    Public liStrLen As UInt32
    Public Structure DiaryType
        Dim strDate As String
        Dim strDiary As String
        Dim strSchedule As String
    End Structure

    'DB接続
    Public Sub DB_OPEN(ByRef cn As OleDb.OleDbConnection)

        cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" _
            & "Data Source=" & gDBName

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

    '2022/10/07 以下ADD
    Public Function FnGetIniFileInfo() As Boolean

        '--------------------------------------------------
        ' INIファイル存在チェック
        '--------------------------------------------------
        If (False = FnFileget(gsIniPath)) Then
            MsgBox("INIファイルが存在しません。", vbCritical, TITLE)
            Return False
        End If

        '--------------------------------------------------
        ' Oracle接続情報の取得
        '--------------------------------------------------
        'gtyOracle.sOraUserId = FnGetIniFile(gsIniPath, "oracle", "userid")
        'gtyOracle.sOraPasswd = FnGetIniFile(gsIniPath, "oracle", "passwd")
        'gtyOracle.sOraSid = FnGetIniFile(gsIniPath, "oracle", "sid")

        '--------------------------------------------------
        ' DBファイルパスの取得
        '--------------------------------------------------
        gDBName = FnGetIniFile(gsIniPath, "app", "dbfile")

        Return True

    End Function

    'INIファイル内容取得処理
    Public Function FnGetIniFile(ByVal asFileName As String, ByVal asSection As String, ByVal asKey As String) As String

        Dim lsGetStr As New System.Text.StringBuilder(255) ' 取得文字列
        liStrLen = GetPrivateProfileString(asSection, asKey, "", lsGetStr, 255, asFileName)
        FnGetIniFile = lsGetStr.ToString

    End Function

    'ファイルの有無チェック
    Public Function FnFileget(ByVal asDic As String) As Boolean

        On Error Resume Next

        '--------------------------------------------------
        ' ファイルの有無チェック
        '--------------------------------------------------
        If String.IsNullOrEmpty(Dir(asDic)) Then
            Return False
        Else
            Return True
        End If

    End Function

    '実行ファイルの二重起動チェック
    Public Function FnUpcheck() As Boolean

        '--------------------------------------------------
        ' 二重起動チェック
        '--------------------------------------------------
        If (Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName).Length > 1) Then
            MsgBox("二重起動の為、処理を中断しました。", vbCritical, TITLE)
            Return False
        Else
            Return True
        End If

    End Function

End Module
