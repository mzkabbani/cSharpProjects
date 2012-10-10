/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/9/2012
 * Time: 6:02 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Automation.Common.Utils;
using Sybase.Data.AseClient;

namespace XmlParsersAndUi.Forms.Pac_TPKS {
    /// <summary>
    /// Description of PackReferenceForm.
    /// </summary>
    public partial class PackReferenceForm : Form {
        public PackReferenceForm() {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        List<string> GetSuppliedTEs (string inputText) {
            List<string> teList = new List<string>();
            string[] inputSplit = inputText.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < inputSplit.Length; i++) {
                teList.Add(inputSplit[i].Trim());
            }
            return teList;

        }

        DataTable GetTestDataTableFromDB(string testID, AseConnection conn) {
            DataTable table = new DataTable(testID);
            using (AseDataAdapter adapter = new AseDataAdapter("select * from QA_PAC_TIMING where TE_REF like '"+testID+"'" ,conn)) {
                adapter.Fill(table);
            }
			return table;
        }

    	
    	object[] GetAverageCPUFromRowsAndClosestTE(string executionCtx, DataSet workingSet){
    		object[] result = new object[5];
    		
    		DataTable tempSameExecutionCTX = workingSet.Tables[0].Clone();
    		tempSameExecutionCTX.Rows.Clear();
    		
    		foreach(DataTable table in workingSet.Tables) {
    			
    			DataRow[] filteredRows =  table.Select("EXECUTION_TYPE = '"+executionCtx+"'");
    			foreach (DataRow row in filteredRows) {
    				tempSameExecutionCTX.Rows.Add(row.ItemArray);
    			}
    			
    		}
    		
    		object averageCPU = tempSameExecutionCTX.Compute("Avg(CPU)","CPU > 0");
    		
    		DataTable tableWithAllCPUs =  tempSameExecutionCTX.DefaultView.ToTable(false,"CPU","TE_REF"); ;
    		
    		double closestCPUDiffValue = 99999;
    		string closestCPUTENumber = "";
    		double closestCPUValue = 0;
    		
    		
    		foreach (DataRow row in tableWithAllCPUs.Rows) {
    			double cpu= Convert.ToDouble(row.ItemArray[0]);
    			double cpuDiff = Math.Abs((cpu - Convert.ToDouble(averageCPU)));
    			if ( cpuDiff < closestCPUDiffValue) {
    				closestCPUTENumber = row.ItemArray[1].ToString();
    				closestCPUDiffValue = cpuDiff;
    				closestCPUValue = cpu;
    			}
    		}
    		
    		result = new object[]{executionCtx,closestCPUTENumber,closestCPUValue,averageCPU};
    		
    		return result;
    		
    	}
    	
        void BtnGetResultsClick(object sender, EventArgs e) {
			
            string connectionString = "Data Source='daisy';Port='4100';UID='INSTAL';PWD='INSTALL';Database='GLOBALQA_UDT';";
            try {
                List<string> suppliedTEs = GetSuppliedTEs(txtInputTes.Text.Trim());

                DataSet set = new DataSet("TE Collection");
                AseConnection conn = new AseConnection(connectionString);
                
                try {
                    conn.Open();

                    for (int i = 0; i < suppliedTEs.Count; i++) {
                        set.Tables.Add(GetTestDataTableFromDB(suppliedTEs[i],conn));
                    }
                    // work with set now
                    DataTable resultTable = set.Tables[0].Clone();
                    resultTable.Rows.Clear();
                    
                    DataTable firstTable = set.Tables[0];
					if ((firstTable.Rows != null)) {
					 //executionCtx,closestCPUTENumber,closestCPUValue,averageCPU
                    	dgvResults.Columns.Add("executionCtx","Execution Context");
                    	
                    	DataGridViewComboBoxColumn closestTEColumn = new DataGridViewComboBoxColumn();
                    	closestTEColumn.Name = "ClosestTe";
                    	closestTEColumn.HeaderText = "Closest TE";
                    	closestTEColumn.DataSource = suppliedTEs.ToArray();
                    	dgvResults.Columns.Add(closestTEColumn);
                    	
                   // 	dgvResults.Columns.Add("closestCPUTENumber","Closest TE");
                    	dgvResults.Columns.Add("closestCPUValue","Closest CPU Value");
                    	dgvResults.Columns.Add("averageCPU","Average CPU");
                    	
                    
                    foreach (DataRow row in firstTable.Rows) {
                    		//resultTable.Rows.Add(GetAverageCPUFromRowsAndClosestTE(row["EXECUTION_TYPE"].ToString(),set));
                    		dgvResults.Rows.Add(GetAverageCPUFromRowsAndClosestTE(row["EXECUTION_TYPE"].ToString(),set));
                    		
                    }	
                    	
                    }
                   

                } catch (Exception ex) {
                    FrontendUtils.ShowError(ex.Message,ex);
                } finally {
                    conn.Close();
                }
                btnGetResults.Enabled = false;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message,ex);
            }
        }    	
		
		void BtnResetClick(object sender, EventArgs e)
		{
			dgvResults.Rows.Clear();
			dgvResults.Columns.Clear();
			txtInputTes.Clear();
			btnGetResults.Enabled = true;
		}
    }
}
