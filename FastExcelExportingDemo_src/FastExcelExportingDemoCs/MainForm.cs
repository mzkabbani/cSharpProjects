
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace FastExcelExportingDemoCs
{

	internal partial class MainForm : Form
	{

		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}

		public MainForm()
		{
			InitializeComponent();
		}

		private DataSet getDemoDataSet()
		{
			SqlConnection cnn = new SqlConnection("server=.;database=Northwind;integrated security=sspi;");
			SqlDataAdapter da = new SqlDataAdapter("select * from Customers", cnn);

			DataSet ds = new DataSet();
			da.Fill(ds);
			ds.Tables[0].TableName = "Customers0";

			for (int i = 1; i < 25; i++)
			{
				DataTable dt = ds.Tables[0].Copy();
				dt.TableName = "Customers" + i.ToString();
				ds.Tables.Add(dt);
			}

			return ds;
		}

		private void startDemoButton_Click(object sender, EventArgs e)
		{
			// Prepare the output filenames
			string timeMark = DateTime.Now.ToString("yyyyMMdd HHmmss");
			string cellByCellFilePath = "C:\\ExcelExportCellByCell_" + timeMark + ".xls";
			string fastExportFilePath = "C:\\ExcelExportFastExport_" + timeMark + ".xls";

			this.demoResultListBox.Items.Clear();

			// Object to mark the times for each process
			Stopwatch stopwatch = new Stopwatch();
			this.UseWaitCursor = true;

			try
			{
				// Get the demo DataSet
				stopwatch.Start();
				DataSet demoDataSet = this.getDemoDataSet();
				stopwatch.Stop();

				this.demoResultListBox.Items.Add("* Generate DEMO DataSet: " + stopwatch.Elapsed.ToString());
				stopwatch.Reset();

				// Use the "Copy-cell-by-cell" method
				stopwatch.Start();
				ExportingCellByCellMethod.ExportToExcel(demoDataSet, cellByCellFilePath);
				stopwatch.Stop();

				this.demoResultListBox.Items.Add("* COPY CELL-BY-CELL method: " + stopwatch.Elapsed.ToString());
				stopwatch.Reset();

				// Use the "fast export" method
				stopwatch.Start();
				FastExportingMethod.ExportToExcel(demoDataSet, fastExportFilePath);
				stopwatch.Stop();

				this.demoResultListBox.Items.Add("* FAST EXPORT method: " + stopwatch.Elapsed.ToString());
				stopwatch.Reset();

			}
			finally
			{
				this.UseWaitCursor = false;
			}

		}
	}
}