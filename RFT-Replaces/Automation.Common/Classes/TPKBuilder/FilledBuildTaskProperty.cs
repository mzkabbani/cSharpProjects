/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/17/2012
 * Time: 2:03 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Automation.Common.Classes.TPKBuilder {
    /// <summary>
    /// Description of FilledBuildTaskProperty.
    /// </summary>
    public class FilledBuildTaskProperty {

        public string PropertyName, PropertyValue, PropertyConfigFileValue, PropertyConfigFilePath;
        public int PropertyType;
        public bool HasConfigFile;
        
        public FilledBuildTaskProperty(string pname, string pvalue, int ptype) {
            PropertyName = pname;
            PropertyValue = pvalue;
            PropertyType = ptype;
        }
        
        public FilledBuildTaskProperty(string pname, bool hasConfigFile,string configFilePath ,string configFileValue,int ptype) {
            PropertyName = pname;
            HasConfigFile = hasConfigFile;
            PropertyConfigFilePath = configFilePath;
            PropertyConfigFileValue = configFileValue;
            PropertyType = ptype;
        }
        
    }
}
