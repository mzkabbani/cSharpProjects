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

        String commandText = "INSERT INTO QA_PAC_REFERENCES_INT  (ID,EXECUTION_TYPE,TE_REF,JOB_ID,TEST_PACKAGE,VERSION,BUILD_ID,PAC_STATUS,FUNC_STATUS,BZIP_FILE_PATH,REMOTE_HOST,PID,NPID,ELAPSED,MIN_ELAPSED,MAX_ELAPSED,AVERAGE_ELAPSED,ELAPSED_CUMUL,CPU,MAX_CPU,MIN_CPU,AVERAGE_CPU,CPU_CUMUL,RDB_COM,RDB_COM_CUMUL,RDB,RDB_CUMUL,LOGICAL_IO,PHYSICAL_IO,CREATE_N,USE_N,SELECT_N,TOTAL_TRC_TIME,MEMORY,HEAP_MEMORY,FILE_NAME,COMMENT,REFERENCE_TYPE,TPK_NICKNAME,TPK_SVN_BRANCH,ALTER_N,UPDATE_N,INSERT_N,DELETE_N,OPERATING_SYSTEM,S_PROC_N,IDNTTY,TOTAL_NBR_QUERIES,SUM_CPU,SUM_ELAPSED,LOGICAL_TE,SELECTED_TE,TE_GROUP) VALUES (@ID,@EXECUTION_TYPE,@TE_REF,@JOB_ID,@TEST_PACKAGE,@VERSION,@BUILD_ID,@PAC_STATUS,@FUNC_STATUS,@BZIP_FILE_PATH,@REMOTE_HOST,@PID,@NPID,@ELAPSED,@MIN_ELAPSED,@MAX_ELAPSED,@AVERAGE_ELAPSED,@ELAPSED_CUMUL,@CPU,@MAX_CPU,@MIN_CPU,@AVERAGE_CPU,@CPU_CUMUL,@RDB_COM,@RDB_COM_CUMUL,@RDB,@RDB_CUMUL,@LOGICAL_IO,@PHYSICAL_IO,@CREATE_N,@USE_N,@SELECT_N,@TOTAL_TRC_TIME,@MEMORY,@HEAP_MEMORY,@FILE_NAME,@COMMENT,@REFERENCE_TYPE,@TPK_NICKNAME,@TPK_SVN_BRANCH,@ALTER_N,@UPDATE_N,@INSERT_N,@DELETE_N,@OPERATING_SYSTEM,@S_PROC_N,@IDNTTY,@TOTAL_NBR_QUERIES,@SUM_CPU,@SUM_ELAPSED,@LOGICAL_TE,@SELECTED_TE,@TE_GROUP)";


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


        object[] GetAverageCPUFromRowsAndClosestTE(string executionCtx, DataSet workingSet) {
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

            result = new object[] {executionCtx,closestCPUTENumber,closestCPUValue,averageCPU};

            return result;

        }

        public string connectionString = "Data Source='daisy';Port='4100';UID='INSTAL';PWD='INSTALL';Database='GLOBALQA_UDT';";

        void BtnGetResultsClick(object sender, EventArgs e) {

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

                        //   dgvResults.Columns.Add("closestCPUTENumber","Closest TE");
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

        void BtnResetClick(object sender, EventArgs e) {
            dgvResults.Rows.Clear();
            dgvResults.Columns.Clear();
            txtInputTes.Clear();
            btnGetResults.Enabled = true;
        }


        private DataTable CopyDataGridToDataTable(DataGridView dgvResults) {
            //  result = new object[]{executionCtx,closestCPUTENumber,closestCPUValue,averageCPU};
            DataTable gridValues = new DataTable("Result");
            gridValues.Columns.Add("executionCtx");
            gridValues.Columns.Add("closestCPUTENumber");
            gridValues.Columns.Add("closestCPUValue");
            gridValues.Columns.Add("averageCPU");

            foreach (DataGridViewRow row in dgvResults.Rows) {
                //# Operation filePath
                object[] values = new object[] { row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value };
                gridValues.Rows.Add(values);
            }
            return gridValues;
        }

        void FillLocalUDTTable(DataTable gridValues) {
            AseConnection conn = new AseConnection(connectionString);
            PAC_TimingObject timingObject = new PAC_TimingObject();
            string maxLogicalTeNumber =  "PAR.TE.";
            try {
                conn.Open();
                DataTable table = new DataTable("TempTable");
                foreach (DataRow row in gridValues.Rows) {
                    string selectedTe = row["closestCPUTENumber"].ToString();
                    string executionContext = row["executionCtx"].ToString();

                    using (AseDataAdapter adapter = new AseDataAdapter("Select * from QA_PAC_TIMING where TE_REF='"+selectedTe+"' and EXECUTION_TYPE='"+executionContext+"'" ,conn)) {
                        int rowsNumber =   adapter.Fill(table);
                        if (rowsNumber >1) {
                            rowsNumber = 0;
                        }
                    }
                }

                AseCommand commandMaxTE = new AseCommand("select LOGICAL_TE from QA_PAC_REFERENCES_INT where ID in (Select max(ID) from QA_PAC_REFERENCES_INT)",conn);
                object returnedValue = commandMaxTE.ExecuteScalar();
                if (returnedValue !=null) {
                    string[] teValueSplit = returnedValue.ToString().Split(new char[] {'.'},StringSplitOptions.RemoveEmptyEntries);
                    Decimal teNumber = Convert.ToDecimal(teValueSplit[2]);
                    teNumber = teNumber +1;
                    maxLogicalTeNumber = maxLogicalTeNumber+teNumber.ToString("0000000");
                } else {
                    maxLogicalTeNumber= maxLogicalTeNumber+"0000000";
                }
                DataTable table2 = table.Copy();
                table2.Columns.Add("SELECTED_TE");
                table2.Columns.Add("TE_GROUP");
                table2.Columns.Add("LOGICAL_TE");

                foreach (DataRow row in table2.Rows) {

                    row["SELECTED_TE"]= row["TE_REF"].ToString();
                    row["TE_GROUP"] = txtInputTes.Text.Trim();
                    row["LOGICAL_TE"] = maxLogicalTeNumber;
                }
                dgvIntermediate.DataSource = table2;

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message,ex);
            } finally {
                conn.Close();
            }
        }

        void BtnInsertToDBClick(object sender, EventArgs e) {
            try {

                DataTable gridValues = CopyDataGridToDataTable(dgvResults);
                FillLocalUDTTable(gridValues);

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message,ex);
            }
        }

        void BtnInsertToPacClick(object sender, EventArgs e) {
            AseConnection conn = new AseConnection(connectionString);

            try {
                conn.Open();
                foreach (DataGridViewRow gridRow in dgvIntermediate.Rows) {
                    //insert to  QA_PAC_REFERENCES_INT
                    //update QA_PAC_TIMING TE_REF and
                    string idInPacTiming = gridRow.Cells["ID"].Value.ToString();
                    string teLogical = gridRow.Cells["LOGICAL_TE"].Value.ToString();
                    string referenceType = gridRow.Cells["REFERENCE_TYPE"].Value.ToString().Replace("REACHED","EXPECTED");

                    AseCommand commandUpdateValuesInPacTiming = new AseCommand(" UPDATE QA_PAC_TIMING "+
                            " SET TE_REF='"+teLogical+"' "+
                            " REFERENCE_TYPE='"+referenceType+"' "+
                            " WHERE ID="+idInPacTiming,conn);


                    AseCommand commandInsertToIntermediate = new AseCommand(commandText,conn);

                    AseCommand commandSelectMaxIdFromInter = new AseCommand("Select max(ID) from QA_PAC_REFERENCES_INT",conn);


                    object maxIdInIntermediate = commandSelectMaxIdFromInter.ExecuteScalar();

                    if (string.IsNullOrEmpty(maxIdInIntermediate.ToString())) {
                        maxIdInIntermediate = 1;
                    }

                    decimal maxIdIntermediate = Convert.ToDecimal(maxIdInIntermediate) + 1;


                    PAC_TimingObject timingObject = new PAC_TimingObject();

                    string[] keyArray = new string[timingObject.paramtersWithValues.Keys.Count];
                    timingObject.paramtersWithValues.Keys.CopyTo(keyArray,0);

                    int counter = 0;
                    commandInsertToIntermediate.Parameters.Add("@ID",maxIdIntermediate);

                    for (int i = 0; i < keyArray.Length; i++) {
                        //set value
                        counter = i;
                        timingObject.paramtersWithValues[keyArray[i]] = gridRow.Cells[keyArray[i]].Value;

                        if (string.Equals(keyArray[i],"EXECUTION_TYPE")||string.Equals(keyArray[i],"TE_REF")||string.Equals(keyArray[i],"TEST_PACKAGE")||string.Equals(keyArray[i],"VERSION")||string.Equals(keyArray[i],"BUILD_ID")||string.Equals(keyArray[i],"PAC_STATUS")||string.Equals(keyArray[i],"FUNC_STATUS")||string.Equals(keyArray[i],"BZIP_FILE_PATH")||string.Equals(keyArray[i],"REMOTE_HOST")||string.Equals(keyArray[i],"FILE_NAME")||string.Equals(keyArray[i],"COMMENT")||string.Equals(keyArray[i],"REFERENCE_TYPE")||string.Equals(keyArray[i],"TPK_NICKNAME")||string.Equals(keyArray[i],"TPK_SVN_BRANCH")||string.Equals(keyArray[i],"LOGICAL_TE")||string.Equals(keyArray[i],"SELECTED_TE")||string.Equals(keyArray[i],"TE_GROUP")) {
                            commandInsertToIntermediate.Parameters.Add("@"+keyArray[i],timingObject.paramtersWithValues[keyArray[i]].ToString());
                        } else {
                            commandInsertToIntermediate.Parameters.Add("@"+keyArray[i],string.IsNullOrEmpty(timingObject.paramtersWithValues[keyArray[i]].ToString())? 0:timingObject.paramtersWithValues[keyArray[i]]);
                        }
                    }
                    
                    commandInsertToIntermediate.ExecuteNonQuery();
                    
                    
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message,ex);
            } finally {
                conn.Close();
            }

        }
    }
}
