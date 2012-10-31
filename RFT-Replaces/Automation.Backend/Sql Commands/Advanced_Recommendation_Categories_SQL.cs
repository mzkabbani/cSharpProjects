using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Backend{
    public static class Advanced_Recommendation_Categories_SQL {

        public static string commandGetAllCaptureCategories = "SELECT     id, enumerationName " +
                                                    "FROM      ApplicationEnums "+
        											"Where type='Regular' "+
        											"order by [index] asc";
    }
}
