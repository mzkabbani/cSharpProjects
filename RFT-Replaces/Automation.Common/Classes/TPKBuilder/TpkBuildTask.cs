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

namespace Automation.Common
{
	/// <summary>
	/// Description of TpkBuildTask.
	/// </summary>
	public class TpkBuildTask
	{
		public int Id, CategoryId, AddedByUserId, ModifiedByUserId;
		public string Name, DetailsLink;
		public DateTime DateAdded, DateModified;
		public List<BuildTaskProperty> TaskProperties = new List<BuildTaskProperty>();
		
		public TpkBuildTask(int id, string name, string detailsLink, int categoryId, int addedByUserId, DateTime dateAdded, int modifiedByUserId, DateTime dateModified)
		{
			Id =  id;
			CategoryId = categoryId;
			AddedByUserId = addedByUserId;
			ModifiedByUserId = modifiedByUserId ;
			Name = name;
			DetailsLink = detailsLink;
			DateAdded = dateAdded;
			DateModified = dateModified;
		}
		
		public TpkBuildTask(string name, string detailsLink, int categoryId, int addedByUserId, DateTime dateAdded)
		{
			Name = name;
			DetailsLink = detailsLink;
			CategoryId = categoryId;
			AddedByUserId = addedByUserId;
			DateAdded = dateAdded;
		}
		
		public TpkBuildTask(string name, string detailsLink, int categoryId, int addedByUserId, DateTime dateAdded, List<BuildTaskProperty> properties)
		{
			Name = name;
			DetailsLink = detailsLink;
			CategoryId = categoryId;
			AddedByUserId = addedByUserId;
			DateAdded = dateAdded;
			TaskProperties = properties;
		}		
		
	}
}
