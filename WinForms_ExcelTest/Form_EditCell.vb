﻿Imports Microsoft.Office.Interop
Public Class Form_EditCell

    Dim Table_Excel As New ExclObj

    Dim colCounter As New Integer

    Dim current_Cell As String

    Public Sub New()

        colCounter = 1
        InitializeComponent()
        NumericUpDown_RowN.Value = 3

        TextBox_Column.Text = Table_Excel.exlSheet.Range(String.Format($"{StData.GetExcelColumnName(colCounter)}3")).Value
        current_Cell = Table_Excel.exlSheet.Range(String.Format($"{StData.GetExcelColumnName(colCounter)}{Integer.Parse(NumericUpDown_RowN.Value)}")).Value
        RichTextBox_Value.Text = current_Cell

        TextBox_Row.Text = String.Format($"Column: {StData.GetExcelColumnName(colCounter)} Row {NumericUpDown_RowN.Value}")
    End Sub

    ''' <summary>
    ''' Перемещение выделенной Ячейки по строке влево
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_Left_Click(sender As Object, e As EventArgs) Handles Button_Left.Click
        If colCounter > 1 Then
            colCounter -= 1

            TextBox_Column.Text = Table_Excel.exlSheet.Range(String.Format($"{StData.GetExcelColumnName(colCounter)}3")).Value
            current_Cell = Table_Excel.exlSheet.Range(String.Format($"{StData.GetExcelColumnName(colCounter)}{Integer.Parse(NumericUpDown_RowN.Value)}")).Value
            RichTextBox_Value.Text = current_Cell

            TextBox_Row.Text = String.Format($"Column: {StData.GetExcelColumnName(colCounter)} Row {NumericUpDown_RowN.Value}")
        End If
    End Sub

    ''' <summary>
    ''' Перемещение выделенной Ячейки по строке вправо
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_Right_Click(sender As Object, e As EventArgs) Handles Button_Right.Click
        colCounter += 1

        TextBox_Column.Text = Table_Excel.exlSheet.Range(String.Format($"{StData.GetExcelColumnName(colCounter)}3")).Value
        current_Cell = Table_Excel.exlSheet.Range(String.Format($"{StData.GetExcelColumnName(colCounter)}{Integer.Parse(NumericUpDown_RowN.Value)}")).Value
        RichTextBox_Value.Text = current_Cell

        TextBox_Row.Text = String.Format($"Column: {StData.GetExcelColumnName(colCounter)} Row {NumericUpDown_RowN.Value}")
    End Sub

    ''' <summary>
    ''' Перемещение выделенной Ячейки по колонке влево и вправо
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub NumericUpDown_RowN_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_RowN.ValueChanged

        current_Cell = Table_Excel.exlSheet.Range(String.Format($"{StData.GetExcelColumnName(colCounter)}{Integer.Parse(NumericUpDown_RowN.Value)}")).Value
        RichTextBox_Value.Text = current_Cell

        TextBox_Row.Text = String.Format($"Column: {StData.GetExcelColumnName(colCounter)} Row {NumericUpDown_RowN.Value}")
    End Sub

    ''' <summary>
    ''' Закрытие формы
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form_EditCell_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Table_Excel.Dispose()
    End Sub

    ''' <summary>
    ''' Сохраняет прогресс изменения Ячейки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_Save_Click(sender As Object, e As EventArgs) Handles Button_Save.Click
        TextBox_Row.Text = String.Format($"Column: {StData.GetExcelColumnName(colCounter)} Row {NumericUpDown_RowN.Value} CS '{current_Cell}' SS '{RichTextBox_Value.Text}'")
        If Not RichTextBox_Value.Text = current_Cell Then
            Table_Excel.exlSheet.Range(String.Format($"{StData.GetExcelColumnName(colCounter)}{Integer.Parse(NumericUpDown_RowN.Value)}")).Value = RichTextBox_Value.Text
            Table_Excel.exl.ActiveWorkbook.Save()
            current_Cell = RichTextBox_Value.Text
        End If
    End Sub

    ''' <summary>
    ''' Отмена прогресса изменения ячейки, возвращает старые данные
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        RichTextBox_Value.Text = current_Cell
    End Sub

    ''' <summary>
    ''' Выход из формы
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_Exit_Click(sender As Object, e As EventArgs) Handles Button_Exit.Click
        Me.Close()
    End Sub
End Class