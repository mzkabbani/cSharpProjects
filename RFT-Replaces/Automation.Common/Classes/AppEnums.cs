/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/22/2012
 * Time: 4:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Automation.Common.Classes
{
	/// <summary>
	/// Description of AppEnums.
	/// </summary>
	public static class AppEnums
	{
			
		public enum BuildTaskCat{		
			Default = 8,
			Macrodef =9,
			MacrodefParallel=16	
		}
		
		public enum PropertyType{
			ConfigFile=10,
			Default=11,
			DefaultNested=12,
			ConfigFileNested=13,
			Common=14,
			CommonNested=15				
		}
		
	}
}
