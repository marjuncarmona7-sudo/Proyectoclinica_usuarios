Imports Microsoft.Office.Interop.Excel
Imports System.IO

Public Class FormReporte
    Private consultaDAO As New ConsultaDAO()

    Private Sub FormReporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Carga los datos de las consultas en el DataGridView
        DgvReporteCitas.DataSource = consultaDAO.ObtenerConsultas()
    End Sub

    ' Método para exportar un DataGridView a Excel
    Private Sub ExportarAExcel(dgv As DataGridView)
        ' Asegúrate de que la referencia a Microsoft.Office.Interop.Excel esté agregada
        Dim excelApp As New Microsoft.Office.Interop.Excel.Application()
        Dim excelWorkbook As Workbook = excelApp.Workbooks.Add()
        Dim excelSheet As Worksheet = excelWorkbook.Sheets("Sheet1")

        ' Escribe los encabezados de las columnas
        For i As Integer = 1 To dgv.ColumnCount
            excelSheet.Cells(1, i) = dgv.Columns(i - 1).HeaderText
        Next

        ' Escribe los datos de cada fila
        For i As Integer = 0 To dgv.RowCount - 1
            For j As Integer = 0 To dgv.ColumnCount - 1
                excelSheet.Cells(i + 2, j + 1) = dgv.Rows(i).Cells(j).Value
            Next
        Next

        excelApp.Visible = True
        MessageBox.Show("Reporte generado en Excel.")
    End Sub

    ' Evento del botón para exportar
    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        ExportarAExcel(DgvReporteCitas)
    End Sub

    ' Evento para volver al dashboard
    Private Sub BtnVolver_Click(sender As Object, e As EventArgs) Handles BtnVolver.Click
        Dim formBienvenido As New FormBienvenido()
        formBienvenido.Show()
        Me.Close()
    End Sub
End Class