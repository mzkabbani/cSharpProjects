/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/23/2012
 * Time: 9:34 AM
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Automation.Common.Classes.TPKBuilder {
    /// <summary>
    /// Description of BuildTargetObject.
    /// </summary>
    public class BuildTargetObject {
        public string Name, Text;
        public List<BuildTask> BuildTasks = new List<BuildTask>();        

        public override string ToString() {
        	
            return string.Format("Target - {0}", this.Name);
        }

        public BuildTargetObject() {
        }

        public BuildTargetObject(string name) {
            this.Name = name;
        }

        public BuildTargetObject(string name, List<BuildTask> targetBuildTasks) {
            this.Name = name;
            this.BuildTasks = targetBuildTasks;
        }

        public void AddBuildTask(BuildTask buildTask) {
            if ((this.BuildTasks != null)) {
                this.BuildTasks.Add(buildTask);
            } else {
                this.BuildTasks = new List<BuildTask>();
                this.BuildTasks.Add(buildTask);
            }
        }

        public string GetTextRepresentation(out List<BuildTask> usedMacrodefs) {
        	usedMacrodefs = new List<BuildTask>();
            string textRepresentation = "\n\t<target name=\""+this.Name+"\" >\r\n";
            foreach (BuildTask buildTask in BuildTasks) {
            	if (buildTask.CategoryId == (int)AppEnum.BuildTaskCat.Macrodef ||
            	   buildTask.CategoryId == (int)AppEnum.BuildTaskCat.MacrodefParallel) {
            	   usedMacrodefs.Add(buildTask);
                }
            	textRepresentation = string.Concat(textRepresentation,"\n<!-- "+buildTask.SuppliedComment+" -->\n"+buildTask.GetTextRepresentation());
            }
            textRepresentation = string.Concat(textRepresentation,"\r\n\t</target>");
            return textRepresentation;
        }

    }
}
