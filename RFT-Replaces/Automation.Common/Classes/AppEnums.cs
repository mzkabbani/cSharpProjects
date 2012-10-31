/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/22/2012
 * Time: 4:02 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Automation.Common.Classes {
    /// <summary>
    /// Description of AppEnums.
    /// </summary>
    public static class AppEnum {

        public enum BuildTaskCat {
            Default = 8,
            Macrodef =9,
            MacrodefParallel=16
        }

        public enum PropertyType {
            ConfigFile=10,
            Default=11,
            DefaultNested=12,
            ConfigFileNested=13,
            Common=14,
            CommonNested=15
        }


        public string EnumerationName, Description, Type ;
        public int AddedByUserId, ModifiedByUserId, Index;
        public DateTime DateAdded, DateModified;


        public static DataTable SelectAllEnumsAsDataTable() {
            return ApplicationEnumsBackend.GetAllAppEnums();
        }
        
        public  AppEnum(string enumerationName, string description,int addedByUserId, DateTime dateAdded, int modifiedByUserId, DateTime dateModified, string type, int index) {
            EnumerationName= enumerationName;
            Description = description;
            Type = type ;
            AddedByUserId = addedByUserId ;
            ModifiedByUserId = modifiedByUserId;
            Index = index ;
            DateAdded = dateAdded;
            DateModified = dateModified;
        }

        public  AppEnum(string enumerationName, string description,int addedByUserId, DateTime dateAdded, string type, int index) {
            EnumerationName= enumerationName;
            Description = description;
            Type = type ;
            AddedByUserId = addedByUserId ;
            ModifiedByUserId = modifiedByUserId;
            Index = index ;
            DateAdded = dateAdded;
            DateModified = dateModified;
        }


    }
}
