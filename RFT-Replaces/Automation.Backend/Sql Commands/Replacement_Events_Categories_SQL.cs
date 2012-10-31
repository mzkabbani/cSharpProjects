using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Backend{
    public static class Replacement_Events_Categories_SQL {
        
        public static string commandGetAllReplacementCategories = "SELECT     id, enumerationName " +
                                                                  "FROM       ApplicationEnums "+
        														  "Where type='ReplacementCategory' "+
        														  "order by [index] asc";

      

    }
}
