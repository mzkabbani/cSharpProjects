using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Automation.Backend{
    public class Advanced_Recommendation_Categories {


        public static DataTable GetAllCaptureCategoriesAsDataTable(bool isForTextConv) {
            DataTable dataTable = new DataTable();
            SqlConnection conn = BackEndUtils.GetSqlConnection();
            
            SqlCommand command = 
            	new SqlCommand( (isForTextConv ? Advanced_Recommendation_Categories_TextConv_SQL.commandGetAllCaptureCategoriesTextConv : Advanced_Recommendation_Categories_SQL.commandGetAllCaptureCategories) , conn);
            
            
            using (SqlDataAdapter adapter2 = new SqlDataAdapter(command)) {
                adapter2.Fill(dataTable);
            }
            return dataTable;
        }

		
		 
        public static DataSet GetAllAdvancedRecCategoriesAsDataset() {
            SqlConnection conn = BackEndUtils.GetSqlConnection();
            DataSet dataSet = new DataSet();
            try {
                SqlDataAdapter da = new SqlDataAdapter(Advanced_Recommendation_Categories_SQL.commandGetAllCaptureCategories, conn);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Fill(dataSet);
            } finally {
                conn.Close();
            }
            return dataSet;
        }

       

    }
}
