using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Automation.Backend{
    public class Replacement_Events_Categories {

        public static DataTable GetAllReplacementCategoriesAsDataTable() {
            DataTable dataTable = new DataTable();
            SqlConnection conn = BackEndUtils.GetSqlConnection();
            SqlCommand command = new SqlCommand(Replacement_Events_Categories_SQL.commandGetAllReplacementCategories, conn);
            using (SqlDataAdapter adapter2 = new SqlDataAdapter(command)) {
                adapter2.Fill(dataTable);
            }
            return dataTable;
        }
       

    }
}
