Imports System.Data.OleDb

Imports Microsoft.Office.Interop


Public Class Form_ConfigColums

    Dim Table_Excel As New ExclObj


    Public Sub New()
        InitializeComponent()
        NumericUpDown_RowN.Value = 3
        Dim sql As String = "SELECT * FROM [Sheet1$]"

        'Using connection As New OleDbConnection(StData.connectionString)
        '    connection.Open()

        '    Using command As New OleDbCommand(sql, connection)
        '        Using reader As OleDbDataReader = command.ExecuteReader()
        '            While reader.Read()
        '                Dim row As New List(Of String) From {
        '                reader.GetString(0),
        '                reader.GetString(1),
        '                reader.GetString(2),
        '                reader.GetString(3)
        '            }



        '                'TextBox_Row.Text = row
        '                Console.WriteLine(row)
        '            End While
        '        End Using
        '    End Using
        'End Using


        'Dim exl As New Excel.Application
        'Dim exlSheet As Excel.Worksheet

        'exl.Workbooks.Open(Application.StartupPath & StData.FileName)
        ''exl.Workbooks.Add()
        'exl.Visible = True

        'exlSheet = exl.Workbooks(1).Worksheets(1) 'Переходим к первому листу

        'Dim exl As New Excel.Application
        'Dim exlSheet As Excel.Worksheet

        'exl.Workbooks.Open(Application.StartupPath & StData.FileName)
        ''exl.Workbooks.Add()
        'exl.Visible = True

        'exlSheet = exl.Workbooks(1).Worksheets(1) 'Переходим к первому листу

        'exl.Quit()
        'exlSheet = Nothing
        'exl = Nothing

        Dim list As New List(Of String)


        list.AddRange(GetListFromExcelRow(Table_Excel.exlSheet, NumericUpDown_RowN.Value))

        ListBox_Columns.Items.AddRange(list.GetRange(0, list.Count - 20).ToArray())
    End Sub

    Private Sub NumericUpDown_RowN_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown_RowN.ValueChanged
        If (NumericUpDown_RowN.Value < 3) Then
            NumericUpDown_RowN.Value = 3
        End If

        'Using table As New ExclObj()
        '    TextBox_Row.Text = table.exlSheet.Range($"D{NumericUpDown_RowN.Value}").Value

        'End Using

        'TextBox_Row.Text = Table_Excel.exlSheet.Range($"E{NumericUpDown_RowN.Value}").Value
        Dim row20(,) As Object
        row20 = Table_Excel.exlSheet.Range($"A{NumericUpDown_RowN.Value}", $"T{NumericUpDown_RowN.Value}").Value

        'For Each i As Object In row20
        '    Console.Write("{0} ", i)
        'Next
        'TextBox_Row.Text = String.Join("|", row20)
        'Determine the dimensions of the array.
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

        'Dim iRows As Long
        'Dim iCols As Long
        'iRows = row20.GetUpperBound(0)
        'iCols = row20.GetUpperBound(1)

        ''Build a string that contains the data of the array.
        'Dim valueString As String
        'valueString = "Array Data" + vbCrLf

        'Dim rowCounter As Long
        'Dim colCounter As Long
        'For rowCounter = 1 To iRows
        '    For colCounter = 1 To iCols

        '        'Write the next value into the string.
        '        valueString = String.Concat(valueString,
        '            row20(rowCounter, colCounter).ToString() + ", ")

        '    Next colCounter
        '    'Write in a new line.
        '    valueString = String.Concat(valueString, vbCrLf)
        'Next rowCounter

    End Sub

    'Private Sub Form_ConfigColums_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
    '    'Table_Excel.Dispose()

    'End Sub

    Private Sub Form_ConfigColums_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Table_Excel.Dispose()
    End Sub

    Private Sub Button_Exit_Click(sender As Object, e As EventArgs) Handles Button_Exit.Click
        Me.Close()
    End Sub


    Private Function GetListFromExcelRow(ByVal worksheet As Excel.Worksheet, ByVal rowIndex As Integer) As List(Of String)
        Dim emptyCellsCount As Integer = 0
        Dim columnIndex As Integer = 1
        Dim list As New List(Of String)

        'worksheet.Application.Interactive = False
        While emptyCellsCount < 20
            'Dim cellValueObj As Object = CType(worksheet.Cells(rowIndex, columnIndex), Excel.Range).Value.ToString()
            Dim cellValue As String
            If CType(worksheet.Cells(rowIndex, columnIndex), Excel.Range).Value Is Nothing Then
                cellValue = ""
            Else
                cellValue = CType(worksheet.Cells(rowIndex, columnIndex), Excel.Range).Value.ToString()
            End If
            'Dim cellValue As String = CType(worksheet.Cells(rowIndex, columnIndex), Excel.Range).Value.ToString()
            If String.IsNullOrEmpty(cellValue) Then
                emptyCellsCount += 1
                'стоит ли добавлять
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
        'worksheet.Application.Interactive = True

        Return list
    End Function

    Private Sub Button_Right_Click(sender As Object, e As EventArgs) Handles Button_Right.Click
        ' Получить индекс выделенной строки в ListBox
        Dim selectedIndex As Integer = ListBox_Columns.SelectedIndex

        ' Получить соответствующую строку из ListBox
        Dim selectedString As String = ListBox_Columns.Items(selectedIndex).ToString()

        '' Добавить строку в DataGridView
        'Dim row As String() = New String() {selectedIndex.ToString(), selectedString}

        '' Добавить строку в DataGridView
        'DataGridView1.Rows.Add(row)

        ' Проверить, есть ли строка с таким же индексом в DataGridView
        Dim rowExists As Boolean = False
        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(0).Value IsNot Nothing AndAlso row.Cells(0).Value.ToString() = String.Format($"{StData.GetExcelColumnName(selectedIndex + 1)}{NumericUpDown_RowN.Value}") Then
                'If row.Cells(0).Value IsNot Nothing AndAlso row.Cells(0).Value.ToString() = selectedIndex.ToString() Then
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
            'Dim row As String() = New String() {selectedIndex.ToString(), selectedString}
            'Dim row As String() = New String() {String.Format($"{StData.GetExcelColumnName(selectedIndex + 1)}{NumericUpDown_RowN.Value}"), selectedString}
            Dim row As String() = New String() {String.Format($"{StData.GetExcelColumnName(selectedIndex + 1)}{NumericUpDown_RowN.Value}"), selectedString, selectedCell}
            DataGridView1.Rows.Add(row)
        End If
    End Sub

    Private Sub Button_Left_Click(sender As Object, e As EventArgs) Handles Button_Left.Click
        ' Проверить, выделена ли строка в DataGridView
        If DataGridView1.SelectedRows.Count > 0 Then
            ' Получить индекс выделенной строки в DataGridView
            Dim selectedIndex As Integer = DataGridView1.SelectedRows(0).Index

            ' Удалить строку из DataGridView
            DataGridView1.Rows.RemoveAt(selectedIndex)
        End If
    End Sub

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
                If row.Cells(2).Value Is Nothing AndAlso Not OldCell = "" Then
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

    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        DataGridView1.Rows.Clear()
    End Sub
End Class