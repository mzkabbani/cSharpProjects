/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/15/2012
 * Time: 4:54 PM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Automation.Common.Classes;
using Automation.Common.Classes.TPKBuilder;

namespace Automation.Common {
    /// <summary>
    /// Description of TpkBuildTask.
    /// </summary>
    public class BuildTask {
        public int Id, CategoryId, AddedByUserId, ModifiedByUserId;
        public string Name, DetailsLink, GeneratedText, SuppliedComment;
        public DateTime DateAdded, DateModified;
        public List<BuildTaskProperty> TaskProperties = new List<BuildTaskProperty>();
        public BuildTargetObject OwnedByTarget;
        public BuildTask OwnedByMacrodef;

        public override string ToString() {
            if (this.CategoryId == (int)AppEnum.BuildTaskCat.Default) {
                return string.Format(this.Name);
            } else {
                return string.Format("Macrodef - {0}",this.Name);
            }

        }

        public BuildTask(){}
        
        public BuildTask(int id, string name, string detailsLink, int categoryId, int addedByUserId, DateTime dateAdded, int modifiedByUserId, DateTime dateModified) {
            Id =  id;
            CategoryId = categoryId;
            AddedByUserId = addedByUserId;
            ModifiedByUserId = modifiedByUserId ;
            Name = name;
            DetailsLink = detailsLink;
            DateAdded = dateAdded;
            DateModified = dateModified;
        }

        public BuildTask(string name, string detailsLink, int categoryId, int addedByUserId, DateTime dateAdded) {
            Name = name;
            DetailsLink = detailsLink;
            CategoryId = categoryId;
            AddedByUserId = addedByUserId;
            DateAdded = dateAdded;
        }

        public BuildTask(string name, string detailsLink, int categoryId, int addedByUserId, DateTime dateAdded, List<BuildTaskProperty> properties) {
            Name = name;
            DetailsLink = detailsLink;
            CategoryId = categoryId;
            AddedByUserId = addedByUserId;
            DateAdded = dateAdded;
            TaskProperties = properties;
        }

        public string GetMacroDefTextRepresentation() {
            string macrodefTextRep = "<macrodef name=\""+this.Name+"\">\r\n\t";
            foreach (BuildTaskProperty prop in this.TaskProperties) {
                if (string.IsNullOrEmpty(prop.DefaultValue)) {
                    macrodefTextRep = string.Concat(macrodefTextRep,"<var name=\""+prop.Name+"\" />\r\n\t");
                } else {
                    macrodefTextRep = string.Concat(macrodefTextRep,"<var name=\""+prop.Name+"\" default=\""+prop.DefaultValue+"\" />\r\n\t");
                }
            }
            if (this.CategoryId == (int)AppEnum.BuildTaskCat.Macrodef) {
                macrodefTextRep = string.Concat(macrodefTextRep,"\t<sequential>\r\n\t\t</sequential>\r\n");
            } else if (this.CategoryId == (int)AppEnum.BuildTaskCat.MacrodefParallel) {
                macrodefTextRep = string.Concat(macrodefTextRep,"\t<parallel>\r\n\t\t</parallel>\r\n");
            }
            macrodefTextRep = string.Concat(macrodefTextRep,"\t</macrodef>");
            return macrodefTextRep;
        }

        public string GetTextRepresentation() {
            string taskTextRepresentation = "<"+this.Name+" >" ;
            string nestedProperties = string.Empty;
            string taskClose = "</"+this.Name+">";
            foreach (BuildTaskProperty property in this.TaskProperties) {
                if (property.PropertyTypeId == (int)AppEnum.PropertyType.CommonNested ||
                        property.PropertyTypeId == (int)AppEnum.PropertyType.ConfigFileNested ||
                        property.PropertyTypeId == (int)AppEnum.PropertyType.DefaultNested) {
                    //add nested property
                    if (!string.IsNullOrEmpty(nestedProperties)) {
                        nestedProperties = nestedProperties +"\n";
                    }
                    if (property.PropertyTypeId == (int)AppEnum.PropertyType.ConfigFileNested && !string.IsNullOrEmpty(property.SuppliedConfigFile)) {
                        nestedProperties = string.Concat(nestedProperties,"<property "+property.Name+"=\""+property.SuppliedConfigFilePath+"\" />");
                    } else if(!string.IsNullOrEmpty(property.SuppliedValue)) {
                        nestedProperties = string.Concat(nestedProperties,"<property "+property.Name+"=\""+property.SuppliedValue+"\" />");
                    }
                } else {
                    //add normal property
                    if (property.PropertyTypeId == (int)AppEnum.PropertyType.ConfigFile && !string.IsNullOrEmpty(property.SuppliedConfigFile)) {
                        taskTextRepresentation= taskTextRepresentation.Replace(">", property.Name+"=\""+property.SuppliedConfigFilePath+"\" >");
                    } else if(!string.IsNullOrEmpty(property.SuppliedValue)) {
                        taskTextRepresentation= taskTextRepresentation.Replace(">", property.Name+"=\""+property.SuppliedValue+"\" >");
                    }
                }
            }

            if (string.IsNullOrEmpty(nestedProperties)) {
                return taskTextRepresentation+taskClose;
            } else {
                return taskTextRepresentation +"\r\n\t\t"+nestedProperties+"\r\n\t"+taskClose;
            }
        }
    }
}
