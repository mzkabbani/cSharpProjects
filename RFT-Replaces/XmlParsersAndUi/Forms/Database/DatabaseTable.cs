/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 11/15/2012
 * Time: 3:33 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Manifest.Forms.Database
{
	/// <summary>
	/// Description of DatabaseTable.
	/// </summary>
	public class DatabaseTable
	{
		string Name;
		List<string> ColumnNames;
		string KeyColumn, ForeignKeyColumn, ForeignKeyTable;
		
		public DatabaseTable()
		{
		}
	}
}
