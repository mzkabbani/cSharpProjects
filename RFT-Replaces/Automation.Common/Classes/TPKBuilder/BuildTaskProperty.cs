/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/15/2012
 * Time: 4:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Automation.Common
{
	/// <summary>
	/// Description of BuildTaskProperty.
	/// </summary>
	public class BuildTaskProperty
	{
		public int Id, BuildTaskId, AddedByUserId, ModifiedByUserId, PropertyTypeId;
		public DateTime DateAdded, DateModified;
		public string Name, DefaultValue, ConfigFileTemplate,SuppliedValue, SuppliedConfigFile, SuppliedConfigFilePath;
		public bool IsMandatory;
		
		public override string ToString()
		{
			return this.Name;
		}
		
		
		public BuildTaskProperty(int id, string name,string defaultValue,int propertyTypeId,bool isMandatory,string configFileTemplate,int buildTaskId, int addedByUserId,DateTime dateAdded, int modifiedByUserId,DateTime dateModified)
		{
			Id = id;
			Name = name;
			DefaultValue = defaultValue;
			PropertyTypeId = propertyTypeId;
			IsMandatory = isMandatory;
			ConfigFileTemplate = configFileTemplate;
			BuildTaskId = buildTaskId;
			AddedByUserId = addedByUserId;
			DateAdded = dateAdded;
			ModifiedByUserId = modifiedByUserId;
			DateModified = dateModified;			
		}
		
		public BuildTaskProperty(string name,string defaultValue,int propertyTypeId,bool isMandatory, int addedByUserId,DateTime dateAdded)
		{		
			Name = name;
			DefaultValue = defaultValue;
			PropertyTypeId = propertyTypeId;
			IsMandatory = isMandatory;
			AddedByUserId = addedByUserId;
			DateAdded = dateAdded;
		}
		
	}
}
