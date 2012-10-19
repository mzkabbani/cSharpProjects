/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/11/2012
 * Time: 4:49 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace XmlParsersAndUi.Forms.Pac_TPKS
{
	/// <summary>
	/// Description of PAC_TimingObject.
	/// </summary>
	public class PAC_TimingObject
	{
		public Dictionary<string,object> paramtersWithValues = new Dictionary<string, object>();
		
		public List<string> parameterNames = new List<string>(){"EXECUTION_TYPE","TE_REF","JOB_ID",
			"TEST_PACKAGE","VERSION","BUILD_ID","PAC_STATUS","FUNC_STATUS","BZIP_FILE_PATH","REMOTE_HOST",
			"PID","NPID","ELAPSED","MIN_ELAPSED","MAX_ELAPSED","AVERAGE_ELAPSED","ELAPSED_CUMUL","CPU",
			"MAX_CPU","MIN_CPU","AVERAGE_CPU","CPU_CUMUL","RDB_COM","RDB_COM_CUMUL","RDB","RDB_CUMUL",
			"LOGICAL_IO","PHYSICAL_IO","CREATE_N","USE_N","SELECT_N","TOTAL_TRC_TIME","MEMORY","HEAP_MEMORY",
			"FILE_NAME","COMMENT","REFERENCE_TYPE","TPK_NICKNAME","TPK_SVN_BRANCH","ALTER_N","UPDATE_N",
			"INSERT_N","DELETE_N","OPERATING_SYSTEM","S_PROC_N","IDNTTY","TOTAL_NBR_QUERIES","SUM_CPU",
			"SUM_ELAPSED","LOGICAL_TE","SELECTED_TE","TE_GROUP"};
		
		
		public PAC_TimingObject()
		{
			for (int i = 0; i < parameterNames.Count; i++) {
				paramtersWithValues.Add(parameterNames[i],null);
			}
			
			
			
		}
	}
}
