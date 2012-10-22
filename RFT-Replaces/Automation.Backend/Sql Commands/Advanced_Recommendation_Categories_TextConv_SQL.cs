/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/10/2012
 * Time: 3:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Automation.Backend{
    public static class Advanced_Recommendation_Categories_TextConv_SQL {

        public static string commandGetAllCaptureCategoriesTextConv = "SELECT     id, enumerationName " +
                                                    "FROM      ApplicationEnums "+
        											"Where type='SDDGen'";

    }
}