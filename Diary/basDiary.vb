'2013/08/17 �V�K�쐬
Imports System.Runtime.InteropServices

Module basDiary
    'Public Const DBNAME As String = "D:\Ishizaki\Diary\DiaryDB.mdb"
    'Public Const DBNAME As String = "D:\MIRO\My Document\DIARY\DiaryDB.mdb"
    Public Const TITLE As String = "���L����"
    Public Const INIFILENAME As String = "\Diary.ini" 'Ini�t�@�C����
    Public gsIniPath As String ' Ini�t�@�C���t���p�X
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

    'DB�ڑ�
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
        FIELD(1) = "���t"
        FIELD(2) = "�j��"
        FIELD(3) = "���L"
        FIELD(4) = "�\��"

    End Sub

    '2019/08/26 ADD
    'SQL���T�j�^�C�W���O����B
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

    '2022/10/07 �ȉ�ADD
    Public Function FnGetIniFileInfo() As Boolean

        '--------------------------------------------------
        ' INI�t�@�C�����݃`�F�b�N
        '--------------------------------------------------
        If (False = FnFileget(gsIniPath)) Then
            MsgBox("INI�t�@�C�������݂��܂���B", vbCritical, TITLE)
            Return False
        End If

        '--------------------------------------------------
        ' Oracle�ڑ����̎擾
        '--------------------------------------------------
        'gtyOracle.sOraUserId = FnGetIniFile(gsIniPath, "oracle", "userid")
        'gtyOracle.sOraPasswd = FnGetIniFile(gsIniPath, "oracle", "passwd")
        'gtyOracle.sOraSid = FnGetIniFile(gsIniPath, "oracle", "sid")

        '--------------------------------------------------
        ' DB�t�@�C���p�X�̎擾
        '--------------------------------------------------
        gDBName = FnGetIniFile(gsIniPath, "app", "dbfile")

        Return True

    End Function

    'INI�t�@�C�����e�擾����
    Public Function FnGetIniFile(ByVal asFileName As String, ByVal asSection As String, ByVal asKey As String) As String

        Dim lsGetStr As New System.Text.StringBuilder(255) ' �擾������
        liStrLen = GetPrivateProfileString(asSection, asKey, "", lsGetStr, 255, asFileName)
        FnGetIniFile = lsGetStr.ToString

    End Function

    '�t�@�C���̗L���`�F�b�N
    Public Function FnFileget(ByVal asDic As String) As Boolean

        On Error Resume Next

        '--------------------------------------------------
        ' �t�@�C���̗L���`�F�b�N
        '--------------------------------------------------
        If String.IsNullOrEmpty(Dir(asDic)) Then
            Return False
        Else
            Return True
        End If

    End Function

    '���s�t�@�C���̓�d�N���`�F�b�N
    Public Function FnUpcheck() As Boolean

        '--------------------------------------------------
        ' ��d�N���`�F�b�N
        '--------------------------------------------------
        If (Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName).Length > 1) Then
            MsgBox("��d�N���ׁ̈A�����𒆒f���܂����B", vbCritical, TITLE)
            Return False
        Else
            Return True
        End If

    End Function

End Module
