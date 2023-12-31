﻿Public Class StData
    Public Shared FileName As String
    Public Shared connectionString As String

    'Генерация ссылки на колонку в Excel, например 27 = "AA"
    Public Shared Function GetExcelColumnName(columnNumber As Integer) As String
        Dim dividend As Integer = columnNumber
        Dim columnName As String = String.Empty
        Dim modulo As Integer

        While dividend > 0
            modulo = (dividend - 1) Mod 26
            columnName = Convert.ToChar(65 + modulo).ToString() & columnName
            dividend = CInt((dividend - modulo) / 26)
        End While

        Return columnName
    End Function
End Class
