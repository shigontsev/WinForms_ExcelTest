Imports Microsoft.Office.Interop


Public Class Form1
    Public Sub New()
        InitializeComponent()
        'TextBox1.Text = "C:\Users\Yurii_S\Desktop\TaskByVBA\Pechi.xlsx"
        'StData.FileName = TextBox1.Text

    End Sub

    ''' <summary>
    ''' Выбор Excel файла через диалоговое окно
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OpenDialog As New OpenFileDialog, FileName As String = ""



        With OpenDialog

            .Title = "Открыть документ Excel"

            .Filter = "Документы Excel|*.xls;*.xlsx"



            If .ShowDialog = Windows.Forms.DialogResult.OK Then

                FileName = .FileName : Application.DoEvents()

            Else

                Return

            End If

        End With
        StData.FileName = FileName
        StData.connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={FileName};Extended Properties=Excel 12.0 Macro;ReadOnly=False"



        TextBox1.Text = StData.FileName
    End Sub

    ''' <summary>
    ''' Переход к Форме ConfigColums
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_OpenConfigColums_Click(sender As Object, e As EventArgs) Handles Button_OpenConfigColums.Click
        If TextBox1.Text IsNot Nothing AndAlso Not TextBox1.Text = "" Then

            Dim newForm As New Form_ConfigColums
            newForm.Show()
        End If
    End Sub


    ''' <summary>
    ''' Переход к Форме редактирования ячейки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_Edit_Click(sender As Object, e As EventArgs) Handles Button_Edit.Click
        If TextBox1.Text IsNot Nothing AndAlso Not TextBox1.Text = "" Then

            Dim newForm As New Form_EditCell

            newForm.Show()
        End If
    End Sub
End Class
