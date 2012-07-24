Imports Microsoft.Office.Interop.Excel

Module ExportingCellByCellMethod

    Public Sub ExportToExcel(ByVal dataSet As DataSet, ByVal outputPath As String)
        ' Create the Excel Application object
        Dim excelApp As New ApplicationClass()

        ' Create a new Excel Workbook
        Dim excelWorkbook As Workbook = excelApp.Workbooks.Add(Type.Missing)

        Dim sheetIndex As Integer = 0
        Dim col, row As Integer
        Dim excelSheet As Worksheet

        ' Copy each DataTable as a new Sheet
        For Each dt As System.Data.DataTable In dataSet.Tables

            sheetIndex += 1

            ' Create a new Sheet
            excelSheet = CType( _
                excelWorkbook.Sheets.Add(excelWorkbook.Sheets(sheetIndex), _
                Type.Missing, 1, XlSheetType.xlWorksheet), Worksheet)

            excelSheet.Name = dt.TableName

            ' Copy the column names (cell-by-cell)
            For col = 0 To dt.Columns.Count - 1
                excelSheet.Cells(1, col + 1) = dt.Columns(col).ColumnName
            Next

            CType(excelSheet.Rows(1, Type.Missing), Range).Font.Bold = True

            ' Copy the values (cell-by-cell)
            For col = 0 To dt.Columns.Count - 1
                For row = 0 To dt.Rows.Count - 1
                    excelSheet.Cells(row + 2, col + 1) = dt.Rows(row).ItemArray(col)
                Next
            Next

            excelSheet = Nothing
        Next

        ' Save and Close the Workbook
        excelWorkbook.SaveAs(outputPath, XlFileFormat.xlWorkbookNormal, Type.Missing, _
         Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, _
         Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)

        excelWorkbook.Close(True, Type.Missing, Type.Missing)

        excelWorkbook = Nothing

        ' Release the Application object
        excelApp.Quit()
        excelApp = Nothing

        ' Collect the unreferenced objects
        GC.Collect()
        GC.WaitForPendingFinalizers()

    End Sub

End Module