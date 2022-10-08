'2011/12/24 �V�K�쐬(VB2005�ɂ��)
'2013/08/17 �S�ʓI�ɍX�V
'2013/09/16 �J�����_�[��ʒǉ�
'2014/03/25 �e�L�X�g������ʒǉ�
'2014/04/11 �J�����_�[�ݒ莞�ɗj�����X�V����Ȃ��o�O���C��
'2014/08/09 VB2013�Ɉڍs
'2015/07/26 �u�����ցv�{�^���ǉ�
'2016/01/02 �J�����_�[�����\���������̓��t�ł͂Ȃ���ʕ\�������Őݒ肷��悤�ɍX�V
'2018/07/11 ������ʂŌ�����ɊY��������\���ł���悤�ɍX�V
'2018/09/18 �t�@���N�V�����L�[�̊��蓖��
'2019/08/26 �V���O���N�H�[�e�[�V�������܂܂�Ă���ƈُ�I�����Ă��܂��o�O���C��
'2019/12/05 �f�[�^�X�V���Ɋm�F���b�Z�[�W��\������悤�ɍX�V
'2020/12/16 �e�L�X�g�G���A���L����
'2021/04/28 �t�H�[������ʂ̃Z���^�[�ɕ\������悤�ɍX�V
'           Git�ɃA�b�v���[�h
'2022/10/07 INI�t�@�C���Ǎ������Ɠ�d�N���`�F�b�N������ǉ�
Public Class frmMain

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Ini�t�@�C�����ݒ�
        gsIniPath = My.Application.Info.DirectoryPath & "\" & INIFILENAME

        'IniFile�ǂݍ���
        If FnGetIniFileInfo() = False Then
            '�ُ�I��
            End
        End If

        'DB�t�@�C�����݊m�F
        If FnFileget(gDBName) = False Then
            MsgBox("MDB�t�@�C�������݂��܂���B", vbCritical, TITLE)
            '�ُ�I��
            End
        End If

        ' ��d�N���`�F�b�N
        If FnUpcheck() = False Then
            '�ُ�I��
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

        '���L�f�[�^�ݒ�
        Me.SetDiary()

    End Sub

    '2018/09/18 ADD
    '�t�@���N�V�����L�[�̊��蓖��
    'http://blog.livedoor.jp/akf0/archives/51318094.html
    'KeyPreview�v���p�e�B��True�ɕύX����B
    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                '�u�{���v�{�^��
                cmdToday.PerformClick()
            Case Keys.F2
                '�u����ցv�{�^��
                cmdYesterday.PerformClick()
            Case Keys.F3
                '�u�����ցv�{�^��
                cmdtomorrow.PerformClick()
            Case Keys.F5
                '�u�X�V�v�{�^��
                cmdUpdate.PerformClick()
            Case Keys.F9
                '�u�J�����_�[�v�{�^��
                cmdCalendar.PerformClick()
            Case Keys.F11
                '�u�����v�{�^��
                cmdSearch.PerformClick()
            Case Keys.F12
                '�u�I���v�{�^��
                cmdEnd.PerformClick()
        End Select
    End Sub

    '�u�{���v�{�^��
    Private Sub cmdToday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdToday.Click

        txtDate.Text = CStr(Today)
        txtWeek.Text = WeekdayName(Weekday(Now)).Substring(0, 1)

        '���L�f�[�^�ݒ�
        Me.SetDiary()

    End Sub

    '�u����ցv�{�^��
    Private Sub cmdYesterday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdYesterday.Click

        txtDate.Text = CStr(CDate(txtDate.Text).AddDays(-1))

        '���L�f�[�^�ݒ�
        Me.SetDiary()

    End Sub

    '�u�����ցv�{�^��
    Private Sub cmdtomorrow_Click(sender As Object, e As EventArgs) Handles cmdtomorrow.Click

        txtDate.Text = CStr(CDate(txtDate.Text).AddDays(+1))

        '���L�f�[�^�ݒ�
        Me.SetDiary()

    End Sub

    '�u�X�V�v�{�^��
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click

        Dim strSQL As String
        Dim reader As OleDb.OleDbDataReader = Nothing
        Dim cn As New OleDb.OleDbConnection

        Try
            If String.IsNullOrEmpty(txtSchedule.Text) AndAlso String.IsNullOrEmpty(txtDiary.Text) Then
                MsgBox("���͂��Ă��������B", vbExclamation, TITLE)
                txtSchedule.Focus()
                Exit Sub
            End If

            If Me.DataCheck(reader) = False Then
                '�V�K�ǉ�
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
                Dim msgResult As DialogResult = MessageBox.Show("�X�V���܂����H", "�X�V�m�F",
                                                                MessageBoxButtons.YesNo,
                                                                MessageBoxIcon.Question,
                                                                MessageBoxDefaultButton.Button2)

                If Not msgResult = MsgBoxResult.Yes Then
                    Exit Sub
                End If
                '2019/12/05 ADD END

                '�������R�[�h�X�V
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
            'SQL���s
            SQLCm.ExecuteNonQuery()
            cn.Close()

            MsgBox("�X�V���܂����B", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    '�u�J�����_�[�v�{�^��
    Private Sub cmdCalendar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalendar.Click
        frmCalendar.ShowDialog()

    End Sub

    '�u�����v�{�^��
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        frmTextSearch.ShowDialog()

    End Sub

    '�u�I���v�{�^��
    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        End

    End Sub

    Private Sub txtSchedule_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSchedule.GotFocus
        txtSchedule.SelectAll()
    End Sub

    Private Sub txtDiary_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiary.GotFocus
        txtDiary.SelectAll()
    End Sub

    '���L�f�[�^�ݒ�
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
            '2014/04/11 ADD START �J�����_�[�ݒ莞�ɗj�����X�V����Ȃ��o�O���C��
            txtWeek.Text = Mid(WeekdayName(Weekday(CDate(txtDate.Text), vbSunday)), 1, 1)
            '2014/04/11 ADD END
            txtSchedule.Text = ""
            txtDiary.Text = ""
        End If

        dr.Close() : dr = Nothing
        cn.Close() : cn = Nothing

    End Sub

    '2018/09/15 Try�`Catch��ǉ� dr.Close,cn.Close���폜(���݃o�O)
    '���L�f�[�^���݊m�F
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
