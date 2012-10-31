/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/31/2012
 * Time: 4:26 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using Automation.Backend.Sql_Commands;

namespace Automation.Backend.Classes
{
	/// <summary>
	/// Description of ApplicationEnums.
	/// </summary>
	public static class ApplicationEnumsBackend
	{
		public ApplicationEnumsBackend()
		{
		}
		
		public static DataTable GetAllAppEnums(){
		
           SqlCeConnection conn = BackEndUtils.GetSqlConnection();
           SqlCeCommand Command = new SqlCeCommand(ApplicationEnums_SQL.commandGetAllApplicationEnums, conn);
           DataSet dataSet = new DataSet();
           try {
               SqlCeDataAdapter da = new SqlCeDataAdapter(Command);
               SqlCeCommandBuilder cb = new SqlCeCommandBuilder(da);
               da.Fill(dataSet);
           } finally {
               conn.Close();
           }
           return dataSet.Tables[0];
		
		}
		
	}
}
