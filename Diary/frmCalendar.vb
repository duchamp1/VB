'2013/09/16 �V�K�쐬
'2016/01/02 �J�����_�[�����\���������̓��t�ł͂Ȃ���ʕ\�������Őݒ肷��悤�ɍX�V
'2019/08/13 �t�@���N�V�����L�[�̊��蓖��
Public Class frmCalendar

    Private Sub frmCalendar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '2016/01/02��ʕ\�����Ă�����t��ݒ�
        Dim dispDate As Date = CDate(frmMain.txtDate.Text)

        Calendar1.SetDate(dispDate)
        '�����̓��t��ݒ�
        'Calendar1.SetDate(Today)

    End Sub

    '2019/08/13 ADD
    '�t�@���N�V�����L�[�̊��蓖��
    'KeyPreview�v���p�e�B��True�ɕύX����B
    Private Sub frmCalendar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F5
                '�u�ݒ�v�{�^��
                cmdSet.PerformClick()
            Case Keys.F12
                '�u����v�{�^��
                cmdClose.PerformClick()
        End Select
    End Sub

    '�u�ݒ�v�{�^��
    Private Sub cmdSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSet.Click

        '���t�ݒ�
        frmMain.txtDate.Text = CStr(Calendar1.SelectionRange.Start)

        '���L�f�[�^�ݒ�
        frmMain.SetDiary()

        Me.Close()

    End Sub

    '�u����v�{�^��
    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()

    End Sub
End Class