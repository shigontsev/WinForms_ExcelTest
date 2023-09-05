Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel

Public Class ExclObj
    Implements IDisposable
    Public exl As New Excel.Application
    Public exlSheet As Excel.Worksheet

    Public Sub New(FileName As String)
        Me.exl.Workbooks.Open(FileName)
        'exl.Visible = True

        exlSheet = exl.Workbooks(1).Worksheets(1) 'Переходим к первому листу
    End Sub

    Public Sub New()
        Me.exl.Workbooks.Open(StData.FileName)
        exl.Visible = True

        exlSheet = exl.Workbooks(1).Worksheets(1) 'Переходим к первому листу
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        exl.Quit()
        exlSheet = Nothing
        exl = Nothing
    End Sub
End Class
