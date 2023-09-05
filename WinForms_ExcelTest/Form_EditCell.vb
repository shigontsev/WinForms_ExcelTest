Imports Microsoft.Office.Interop
Public Class Form_EditCell

    Dim Table_Excel As New ExclObj

    Dim colCounter As New Integer

    Dim current_Cell As String

    Public Sub New()

        colCounter = 1
        InitializeComponent()
        NumericUpDown_RowN.Value = 3
        'TextBox_Column.Text = Table_Excel.exlSheet.Cells(3, colCounter).ToString()
        'RichTextBox_Value.Text = Table_Excel.exlSheet.Cells(Integer.Parse(NumericUpDown_RowN.Value), colCounter).ToString()

        'TextBox_Row.Text = Table_Excel.exlSheet.UsedRange.Cells(3, 3).ToString()

        TextBox_Column.Text = Table_Excel.exlSheet.Range(String.Format($"{StData.GetExcelColumnName(colCounter)}3")).Value
        current_Cell = Table_Excel.exlSheet.Range(String.Format($"{StData.GetExcelColumnName(colCounter)}{Integer.Parse(NumericUpDown_RowN.Value)}")).Value
        RichTextBox_Value.Text = current_Cell

        TextBox_Row.Text = String.Format($"Column: {StData.GetExcelColumnName(colCounter)} Row {NumericUpDown_RowN.Value}")
    End Sub

    Private Sub Button_Left_Click(sender As Object, e As EventArgs) Handles Button_Left.Click
        If colCounter > 1 Then
            colCounter -= 1
            'TextBox_Column.Text = Table_Excel.exl.Cells(3, colCounter).ToString()
            'RichTextBox_Value.Text = Table_Excel.exl.Cells(Integer.Parse(NumericUpDown_RowN.Value), colCounter).ToString()
            TextBox_Column.Text = Table_Excel.exlSheet.Range(String.Format($"{StData.GetExcelColumnName(colCounter)}3")).Value
            current_Cell = Table_Excel.exlSheet.Range(String.Format($"{StData.GetExcelColumnName(colCounter)}{Integer.Parse(NumericUpDown_RowN.Value)}")).Value
            RichTextBox_Value.Text = current_Cell

            TextBox_Row.Text = String.Format($"Column: {StData.GetExcelColumnName(colCounter)} Row {NumericUpDown_RowN.Value}")
        End If
    End Sub

    Private Sub Button_Right_Click(sender As Object, e As EventArgs) Handles Button_Right.Click
        colCounter += 1
        'TextBox_Column.Text = Table_Excel.exl.Cells(3, colCounter).ToString()
        'RichTextBox_Value.Text = Table_Excel.exl.Cells(Integer.Parse(NumericUpDown_RowN.Value), colCounter).ToString()
        TextBox_Column.Text = Table_Excel.exlSheet.Range(String.Format($"{StData.GetExcelColumnName(colCounter)}3")).Value
        current_Cell = Table_Excel.exlSheet.Range(String.Format($"{StData.GetExcelColumnName(colCounter)}{Integer.Parse(NumericUpDown_RowN.Value)}")).Value
        RichTextBox_Value.Text = current_Cell

        TextBox_Row.Text = String.Format($"Column: {StData.GetExcelColumnName(colCounter)} Row {NumericUpDown_RowN.Value}")
    End Sub

    Private Sub NumericUpDown_RowN_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_RowN.ValueChanged
        'Table_Excel.exlSheet.Range($"A{NumericUpDown_RowN.Value}", $"T{NumericUpDown_RowN.Value}").Value

        'RichTextBox_Value.Text = Table_Excel.exlSheet.Cells(Integer.Parse(NumericUpDown_RowN.Value), colCounter).ToString()
        current_Cell = Table_Excel.exlSheet.Range(String.Format($"{StData.GetExcelColumnName(colCounter)}{Integer.Parse(NumericUpDown_RowN.Value)}")).Value
        RichTextBox_Value.Text = current_Cell

        TextBox_Row.Text = String.Format($"Column: {StData.GetExcelColumnName(colCounter)} Row {NumericUpDown_RowN.Value}")
    End Sub

    Private Sub Form_EditCell_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Table_Excel.Dispose()
    End Sub
    Private Sub Button_Save_Click(sender As Object, e As EventArgs) Handles Button_Save.Click
        TextBox_Row.Text = String.Format($"Column: {StData.GetExcelColumnName(colCounter)} Row {NumericUpDown_RowN.Value} CS '{current_Cell}' SS '{RichTextBox_Value.Text}'")
        If Not RichTextBox_Value.Text = current_Cell Then
            Table_Excel.exlSheet.Range(String.Format($"{StData.GetExcelColumnName(colCounter)}{Integer.Parse(NumericUpDown_RowN.Value)}")).Value = RichTextBox_Value.Text
            Table_Excel.exl.ActiveWorkbook.Save()
            'Table_Excel.exl.save
            current_Cell = RichTextBox_Value.Text
        End If
    End Sub

    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        RichTextBox_Value.Text = current_Cell
    End Sub

    Private Sub Button_Exit_Click(sender As Object, e As EventArgs) Handles Button_Exit.Click
        'Table_Excel.Dispose()
        Me.Close()
    End Sub
End Class