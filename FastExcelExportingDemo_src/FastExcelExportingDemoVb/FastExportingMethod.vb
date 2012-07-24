Imports Microsoft.Office.Interop.Excel

Module FastExportingMethod

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

            ' Copy the DataTable to an object array
            Dim rawData(dt.Rows.Count, dt.Columns.Count - 1) As Object

            ' Copy the column names to the first row of the object array
            For col = 0 To dt.Columns.Count - 1
                rawData(0, col) = dt.Columns(col).ColumnName
            Next

            ' Copy the values to the object array
            For col = 0 To dt.Columns.Count - 1
                For row = 0 To dt.Rows.Count - 1
                    rawData(row + 1, col) = dt.Rows(row).ItemArray(col)
                Next
            Next

            ' Calculate the final column letter
            Dim finalColLetter As String = String.Empty
            Dim colCharset As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
            Dim colCharsetLen As Integer = colCharset.Length

            If dt.Columns.Count > colCharsetLen Then
                finalColLetter = colCharset.Substring( _
                 (dt.Columns.Count - 1) \ colCharsetLen - 1, 1)
            End If

            finalColLetter += colCharset.Substring( _
              (dt.Columns.Count - 1) Mod colCharsetLen, 1)

            ' Create a new Sheet
            excelSheet = CType( _
                excelWorkbook.Sheets.Add(excelWorkbook.Sheets(sheetIndex), _
                Type.Missing, 1, XlSheetType.xlWorksheet), Worksheet)

            excelSheet.Name = dt.TableName

            ' Fast data export to Excel
            Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, dt.Rows.Count + 1)
            excelSheet.Range(excelRange, Type.Missing).Value2 = rawData

            ' Mark the first row as BOLD
            CType(excelSheet.Rows(1, Type.Missing), Range).Font.Bold = True

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