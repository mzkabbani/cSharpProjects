using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Common;
using System.Data;
using System.Data.SqlClient;

namespace Automation.Backend{
    public class Application_Settings {

        public enum ApplicationConfigKeys {
            Datasource = 50,
            PrivelegedUsers = 100,
            EnableTimerKey = 150,
            TimerDurationKey = 200,
            CleanUpEventsSearchPattern = 250,
            AdvancedRecoCategories = 300,
            ReplacementCategories = 350,
            ApplicationVersion = 400,
            EnvComparisonOnlyForEnv = 500
        }

        public static List<ApplicationConfigObject> GetAllApplicationConfigAsList() {
            List<ApplicationConfigObject> applicationConfigObjectList = new List<ApplicationConfigObject>();
            DataTable advancedRexTable = new DataTable();
            SqlConnection conn = BackEndUtils.GetSqlConnection();
            SqlCommand getAllRecsCommand = new SqlCommand(Application_Settings_SQL.commandGetAllAppConfig, conn);
            DataTable dataTable = new DataTable();
            try {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(Application_Settings_SQL.commandGetAllAppConfig, conn)) {
                    adapter.Fill(dataTable);
                }
                for (int i = 0; i < dataTable.Rows.Count; i++) {
                    // DataTable capturePointsTable = GetRespectiveCapturePoints(dataTable.Rows[i].ItemArray[0], conn);
                    object[] itemArray = dataTable.Rows[i].ItemArray;
                    ApplicationConfigObject applicationConfigObject = new ApplicationConfigObject(Convert.ToInt32(itemArray[0]), itemArray[1] as string, itemArray[2] as string);
                    applicationConfigObjectList.Add(applicationConfigObject);
                }
            } finally {
                conn.Close();
            }
            return applicationConfigObjectList;
        }

        public static DataSet GetAppPrefsDataset() {
            SqlConnection conn = BackEndUtils.GetSqlConnection();
            DataSet dataSet = new DataSet();
            try {
                SqlDataAdapter da = new SqlDataAdapter(Application_Settings_SQL.commandGetAllAppConfig, conn);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Fill(dataSet);
            } finally {
                conn.Close();
            }
            return dataSet;
        }

        public static void UpdatePrefs(DataSet dataSet) {
            SqlConnection conn = BackEndUtils.GetSqlConnection();
            try {
                SqlDataAdapter da = new SqlDataAdapter(Application_Settings_SQL.commandGetAllAppConfig, conn);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Update(dataSet);
            } finally {
                conn.Close();
            }
        }

        public static List<string> GetPriviligedUsersAsList() {
            List<string> priviligedUsersList = new List<string>();
            SqlConnection conn = BackEndUtils.GetSqlConnection();
            SqlCommand command = new SqlCommand(Application_Settings_SQL.commandSelectFromAppConfigByKey, conn);
            try {
                conn.Open();
                command.Parameters.Add("@id", ApplicationConfigKeys.PrivelegedUsers);
                priviligedUsersList = command.ExecuteScalar().ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            } finally {
                conn.Close();
            }
            return priviligedUsersList;
        }

        public static object GetAppConfigValueByKey(ApplicationConfigKeys applicationConfigKeys) {
            SqlConnection conn = BackEndUtils.GetSqlConnection();
            SqlCommand command = new SqlCommand(Application_Settings_SQL.commandSelectFromAppConfigByKey, conn);
            try {
                conn.Open();
                command.Parameters.Add("@id", applicationConfigKeys);
                return command.ExecuteScalar();
            } finally {
                conn.Close();
            }
            return null;
        }


    
    }
}
