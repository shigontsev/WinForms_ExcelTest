Imports Microsoft.Office.Interop


Public Class Form1
    Public Sub New()
        InitializeComponent()
        TextBox1.Text = "C:\Users\Yurii_S\Desktop\TaskByVBA\Pechi.xlsx"
        StData.FileName = TextBox1.Text

    End Sub

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

        'Dim exl As New Excel.Application
        'Dim exlSheet As Excel.Worksheet

        'exl.Workbooks.Open(Application.StartupPath & StData.FileName)
        ''exl.Workbooks.Add()
        'exl.Visible = True

        'exlSheet = exl.Workbooks(1).Worksheets(1) 'Переходим к первому листу

        'exl.Quit()
        'exlSheet = Nothing
        'exl = Nothing
    End Sub

    Private Sub Button_OpenConfigColums_Click(sender As Object, e As EventArgs) Handles Button_OpenConfigColums.Click

        Dim newForm As New Form_ConfigColums
        newForm.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim exl As New Excel.Application
        Dim exlSheet As Excel.Worksheet

        exl.Workbooks.Open(StData.FileName)
        'exl.Workbooks.Add()
        exl.Visible = True

        exlSheet = exl.Workbooks(1).Worksheets(1) 'Переходим к первому листу
        Dim str As String = exlSheet.Range("D3").Value
        exl.Quit()
        exlSheet = Nothing
        exl = Nothing

        'Dim Exc As Object
        'Exc = CreateObject("Excel.Application")
        'Exc.Workbooks.Open(StData.FileName).Activate()
        ''Exc.Cells(1, 1) = "ПРИВЕТ!"
        ''Exc.Rows(7).Insert(Shift:=-4121)
        'Exc.ActiveWorkbook.Save()
        'Exc.ActiveWorkbook.Close()
        'Exc.Quit()
        'Exc = Nothing

        'Dim excelApp As New Excel.Application()
        'excelApp.Visible = True

        'Dim workbook As Excel.Workbook = excelApp.Workbooks.Open(StData.FileName)
        'Dim worksheet As Excel.Worksheet = workbook.Sheets("Печи")

        ''Чтение данных из Excel файла
        'Dim range As Excel.Range = worksheet.Range("A1:B5")
        'For Each cell In range
        '    'Console.WriteLine(cell.Value)
        '    TextBox1.Text += cell.Value

        'Next

        'workbook.Close()

        'excelApp.Quit()
    End Sub

    Private Sub Button_Edit_Click(sender As Object, e As EventArgs) Handles Button_Edit.Click
        Dim newForm As New Form_EditCell

        newForm.Show()
    End Sub
End Class
