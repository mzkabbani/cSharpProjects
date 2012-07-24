Public Class MainForm

    Private Function getDemoDataSet() As DataSet
        Dim cnn As New SqlClient.SqlConnection("server=.;database=Northwind;integrated security=sspi;")
        Dim da As New SqlClient.SqlDataAdapter("select * from Customers", cnn)
        Dim i As Integer

        Dim ds As New DataSet()
        da.Fill(ds)
        ds.Tables(0).TableName = "Customers0"

        For i = 1 To 24
            Dim dt As DataTable = ds.Tables(0).Copy()
            dt.TableName = "Customers" + i.ToString()
            ds.Tables.Add(dt)
        Next

        Return ds
    End Function

    Private Sub startDemoButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles startDemoButton.Click
        ' Prepare the output filenames
        Dim timeMark As String = DateTime.Now.ToString("yyyyMMdd HHmmss")
        Dim cellByCellFilePath As String = "C:\ExcelExportCellByCell_" + timeMark + ".xls"
        Dim fastExportFilePath As String = "C:\ExcelExportFastExport_" + timeMark + ".xls"

        Me.demoResultListBox.Items.Clear()

        ' Object to mark the times for each process
        Dim stopwatch As New Stopwatch()
        Me.UseWaitCursor = True

        Try
	        ' Get the demo DataSet
            stopwatch.Start()
            Dim demoDataSet As DataSet = Me.getDemoDataSet()
            stopwatch.Stop()

            Me.demoResultListBox.Items.Add("* Generate DEMO DataSet: " + stopwatch.Elapsed.ToString())
            stopwatch.Reset()

            ' Use the "Copy-cell-by-cell" method
            stopwatch.Start()
            ExportingCellByCellMethod.ExportToExcel(demoDataSet, cellByCellFilePath)
            stopwatch.Stop()

            Me.demoResultListBox.Items.Add("* COPY CELL-BY-CELL method: " + stopwatch.Elapsed.ToString())
            stopwatch.Reset()

            ' Use the "fast export" method
            stopwatch.Start()
            FastExportingMethod.ExportToExcel(demoDataSet, fastExportFilePath)
            stopwatch.Stop()

            Me.demoResultListBox.Items.Add("* FAST EXPORT method: " + stopwatch.Elapsed.ToString())
            stopwatch.Reset()

        Finally
            Me.UseWaitCursor = False
        End Try

    End Sub

End Class
