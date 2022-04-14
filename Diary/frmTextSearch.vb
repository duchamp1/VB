'2014/03/25 �V�K�쐬
'2018/07/11 ����������\���ł���悤�ɍX�V
'2018/07/13 �����������t��\���ł���悤�ɍX�V
'2019/08/13 �t�@���N�V�����L�[�̊��蓖��
'           �����{�^���������̓��̓`�F�b�N�ǉ�
'           �N���A�{�^���ǉ�
'2019/08/23 �ݒ�{�^���������ɓ��t�ȊO�̃Z����I�������ꍇ�A�ُ�I������o�O���C��
'2019/08/26 �V���O���N�H�[�e�[�V�������܂܂�Ă���ƈُ�I�����Ă��܂��o�O���C��
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
    '�t�@���N�V�����L�[�̊��蓖��
    'KeyPreview�v���p�e�B��True�ɕύX����B
    Private Sub frmTextSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                '�u�N���A�v�{�^��
                cmdClear.PerformClick()
            Case Keys.F3
                '�u�����v�{�^��
                cmdSearch.PerformClick()
            Case Keys.F5
                '�u�ݒ�v�{�^��
                cmdSet.PerformClick()
            Case Keys.F12
                '�u����v�{�^��
                cmdClose.PerformClick()
        End Select
    End Sub

    Private Sub txtWords_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWords.GotFocus
        txtWords.SelectAll()

    End Sub

    '�u����v�{�^��
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()

    End Sub

    '�u�����v�{�^��
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        '2019/08/13 UPDATE START
        '���̓`�F�b�N
        If String.IsNullOrEmpty(txtWords.Text) AndAlso String.IsNullOrEmpty(txtWords.Text) Then
            MsgBox("���͂��Ă��������B", vbExclamation, TITLE)
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
        Me.Text = "�Y�������F" & View.Count.ToString & Space(3) &
                    "�����F" & strWords '2018/07/11 ����������\�� 2018/07/13 UPDATE

        '2019/08/13 UPDATE START
        If Not View.Count = 0 Then
            Me.cmdSet.Enabled = True
        End If
        Me.cmdClear.Enabled = True
        '2019/08/13 UPDATE END
    End Sub

    '�u�ݒ�v�{�^��
    Private Sub cmdSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSet.Click
        '2019/08/23 UPDATE �ݒ�{�^���������ɓ��t�ȊO�̃Z����I�������ꍇ�A�ُ�I������o�O���C��
        Try
            Dim searchGrid As DataGridView = Me.DataGridView1

            '���t�ݒ�
            frmMain.txtDate.Text = searchGrid.Item(0, searchGrid.CurrentRow.Index).Value.ToString
            'frmMain.txtDate.Text = DataGridView1.CurrentCell.Value.ToString

            '���L�f�[�^�ݒ�
            frmMain.SetDiary()

            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message, vbExclamation, TITLE)
        End Try

    End Sub

    '2019/08/13 ADD
    '�u�N���A�v�{�^��
    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        '����������
        Me.Initial()

    End Sub

    Private Sub openForm()
        '�f�[�^�擾
        Dim Cn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DBNAME & "")
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable

        SQLCm.CommandText = "SELECT * FROM Diary ORDER BY DATE"
        Adapter.Fill(Table)

        '�l�̕\��
        DataGridView1.DataSource = Table

    End Sub

    '2019/08/13 ADD
    '����������
    Private Sub Initial()
        Me.Text = "����"
        Me.cmdClear.Enabled = False
        Me.cmdSet.Enabled = False
        Me.txtWords.Clear()
        'DataSource�Ńo�C���h���Ă��鎞�̏�����
        Me.DataGridView1.DataSource = Nothing

    End Sub
End Class