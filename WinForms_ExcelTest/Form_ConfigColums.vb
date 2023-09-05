Imports System.Data.OleDb

Imports Microsoft.Office.Interop


Public Class Form_ConfigColums

    Dim Table_Excel As New ExclObj


    Public Sub New()
        InitializeComponent()
        NumericUpDown_RowN.Value = 4

        Dim list As New List(Of String)


        'list.AddRange(GetListFromExcelRow(Table_Excel.exlSheet, NumericUpDown_RowN.Value))
        list.AddRange(GetListFromExcelRow(Table_Excel.exlSheet, 3))

        'Очистка от не нужных пустых колонок в конце
        ListBox_Columns.Items.AddRange(list.GetRange(0, list.Count - 20).ToArray())
    End Sub

    ''' <summary>
    ''' Переключение строки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub NumericUpDown_RowN_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_RowN.ValueChanged
        If (NumericUpDown_RowN.Value < 4) Then
            NumericUpDown_RowN.Value = 4
        End If

        Dim row20(,) As Object
        row20 = Table_Excel.exlSheet.Range($"A{NumericUpDown_RowN.Value}", $"T{NumericUpDown_RowN.Value}").Value


        Dim i As Integer
        Dim valueStr As String = ""
        For i = 1 To row20.Length
            If row20(1, i) IsNot Nothing Then
                valueStr += String.Format("[" + row20(1, i).ToString() + "]")
            Else
                valueStr += String.Format("[]")
            End If


        Next
        TextBox_Row.Text = valueStr


        'Очистка списка в GridView
        DataGridView1.Rows.Clear()

    End Sub


    ''' <summary>
    ''' Событие при закрытии формы
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form_ConfigColums_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Table_Excel.Dispose()
    End Sub

    ''' <summary>
    ''' Выход из формы
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_Exit_Click(sender As Object, e As EventArgs) Handles Button_Exit.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Возвращает строку с данными из Excel по указанному индексу rowIndex
    ''' </summary>
    ''' <param name="worksheet"></param>
    ''' <param name="rowIndex"></param>
    ''' <returns></returns>
    Private Function GetListFromExcelRow(ByVal worksheet As Excel.Worksheet, ByVal rowIndex As Integer) As List(Of String)
        Dim emptyCellsCount As Integer = 0
        Dim columnIndex As Integer = 1
        Dim list As New List(Of String)

        While emptyCellsCount < 20
            Dim cellValue As String
            If CType(worksheet.Cells(rowIndex, columnIndex), Excel.Range).Value Is Nothing Then
                cellValue = ""
            Else
                cellValue = CType(worksheet.Cells(rowIndex, columnIndex), Excel.Range).Value.ToString()
            End If
            If String.IsNullOrEmpty(cellValue) Then
                emptyCellsCount += 1
                list.Add(cellValue)
            Else
                emptyCellsCount = 0
                list.Add(cellValue)
            End If

            columnIndex += 1

            If columnIndex > worksheet.UsedRange.Columns.Count Then
                Exit While
            End If
        End While

        Return list
    End Function

    ''' <summary>
    ''' Добавление в GridView Ячейки для редактирования
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_Right_Click(sender As Object, e As EventArgs) Handles Button_Right.Click
        If ListBox_Columns.SelectedItems.Count < 1 Then
            Exit Sub
        End If
        ' Получить индекс выделенной строки в ListBox
        Dim selectedIndex As Integer = ListBox_Columns.SelectedIndex

        ' Получить соответствующую строку из ListBox
        Dim selectedString As String = ListBox_Columns.Items(selectedIndex).ToString()

        ' Проверить, есть ли строка с таким же индексом в DataGridView
        Dim rowExists As Boolean = False
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value IsNot Nothing AndAlso row.Cells(0).Value.ToString() = String.Format($"{StData.GetExcelColumnName(selectedIndex + 1)}{NumericUpDown_RowN.Value}") Then

                rowExists = True
                Exit For
            End If
        Next

        ' Если строка с таким же индексом не существует, добавить строку в DataGridView
        If Not rowExists Then
            Dim selectedCell As String
            If Table_Excel.exlSheet.Range(String.Format($"{StData.GetExcelColumnName(selectedIndex + 1)}{NumericUpDown_RowN.Value}")).Value Is Nothing Then
                selectedCell = ""
            Else
                selectedCell = Table_Excel.exlSheet.Range(String.Format($"{StData.GetExcelColumnName(selectedIndex + 1)}{NumericUpDown_RowN.Value}")).Value.ToString()
            End If

            Dim row As String() = New String() {String.Format($"{StData.GetExcelColumnName(selectedIndex + 1)}{NumericUpDown_RowN.Value}"), selectedString, selectedCell}
            DataGridView1.Rows.Add(row)
        End If
    End Sub

    ''' <summary>
    ''' Удаление из GridView Ячейки
    ''' Для удаления выделяется целая строка в GridWiew
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_Left_Click(sender As Object, e As EventArgs) Handles Button_Left.Click
        ' Проверить, выделена ли строка в DataGridView
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Получить индекс выделенной строки в DataGridView
            Dim selectedIndex As Integer = DataGridView1.SelectedRows(0).Index

            ' Удалить строку из DataGridView
            DataGridView1.Rows.RemoveAt(selectedIndex)
        End If
    End Sub

    ''' <summary>
    ''' Сохраняет прогресс редактирования ячейки
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_Save_Click(sender As Object, e As EventArgs) Handles Button_Save.Click
        ' Проверить, есть ли строка с таким же индексом в DataGridView
        Dim newDataCell_Exists As Boolean = False

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value IsNot Nothing Then

                Dim OldCell As String
                'Старая запись из содержимой ячейки
                If Table_Excel.exlSheet.Range(row.Cells(0).Value.ToString()).Value IsNot Nothing Then
                    OldCell = Table_Excel.exlSheet.Range(row.Cells(0).Value.ToString()).Value.ToString()
                Else
                    OldCell = ""
                End If
                'Запись новых данных
                If row.Cells(2).Value Is Nothing AndAlso Not OldCell = row.Cells(2).Value Then
                    Table_Excel.exlSheet.Range(row.Cells(0).Value.ToString()).Value = ""
                    newDataCell_Exists = True
                ElseIf row.Cells(2).Value IsNot Nothing AndAlso Not row.Cells(2).Value.ToString() = OldCell Then
                    Table_Excel.exlSheet.Range(row.Cells(0).Value.ToString()).Value = row.Cells(2).Value.ToString()
                    newDataCell_Exists = True
                End If
            End If
        Next

        'Сохраняет прогресс если были изменения
        If newDataCell_Exists = True Then
            Table_Excel.exl.ActiveWorkbook.Save()
        End If
    End Sub

    ''' <summary>
    ''' Отмена прогресса изменения ячеек
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        DataGridView1.Rows.Clear()
    End Sub
End Class