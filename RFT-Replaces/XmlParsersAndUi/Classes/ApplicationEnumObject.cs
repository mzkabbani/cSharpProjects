/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/31/2012
 * Time: 6:46 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using Automation.Backend.Classes;

namespace XmlParsersAndUi.Classes
{
	/// <summary>
	/// Description of ApplicationEnumObject.
	/// </summary>
	public class ApplicationEnumObject
	{
		public string EnumerationName, Description, Type ;
        public int AddedByUserId, ModifiedByUserId, Index;
        public DateTime DateAdded, DateModified;


        public static DataTable SelectAllEnumsAsDataTable() {
            return ApplicationEnumsBackend.GetAllAppEnums();
        }
        
        public  ApplicationEnumObject(string enumerationName, string description,int addedByUserId, DateTime dateAdded, int modifiedByUserId, DateTime dateModified, string type, int index) {
            EnumerationName= enumerationName;
            Description = description;
            Type = type ;
            AddedByUserId = addedByUserId ;
            ModifiedByUserId = modifiedByUserId;
            Index = index ;
            DateAdded = dateAdded;
            DateModified = dateModified;
        }

        public  ApplicationEnumObject(string enumerationName, string description,int addedByUserId, DateTime dateAdded, string type, int index) {
            EnumerationName= enumerationName;
            Description = description;
            Type = type ;
            AddedByUserId = addedByUserId ;
            
            Index = index ;
            DateAdded = dateAdded;
            
        }
	}
}
