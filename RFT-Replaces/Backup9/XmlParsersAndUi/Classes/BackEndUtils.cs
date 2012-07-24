using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using XmlParsersAndUi.Classes;

namespace XmlParsersAndUi {
    public class BackEndUtils {

        public static string ConnectionParamter = string.Empty;   
        
        public enum ApplicationConfigKeys{
            DataSourceKey = 1,
            PriviligedUsersKey = 2,
            EnableTimerKey = 3,
            TimerDurationKey = 4,
            CleanUpEventsSearchPattern = 5

        }
      
        private static SqlCeConnection GetSqlConnection() {
            SqlCeConnection sqlConnection1 = new SqlCeConnection();
            //sqlConnection1.ConnectionString = @"Data Source=C:\Documents and Settings\mkabbani\My Documents\Visual Studio 2008\Projects\RFT-Replaces\XmlParsersAndUi\Database.sdf";
            sqlConnection1.ConnectionString = "Data Source=" + ConnectionParamter;
            return sqlConnection1;
        }

        public static void UpdateUserStatusById(int userId, bool isLoginEvent) {
            int loginCount = BackEndUtils.GetLoginCountByUserId(userId);
            //onlineStatus =@onlineStatus, loginCount =@loginCount, lastLogin =@lastLogin"+
            //"WHERE id=@id"
            SqlCeConnection conn =GetSqlConnection();
            SqlCeCommand command = new SqlCeCommand(SqlCommands.commandUpdateUserStatusWithId, conn);
            command.Parameters.Add("@onlineStatus", isLoginEvent ? "Online" : "Offline");
            command.Parameters.Add("@loginCount", isLoginEvent ? (loginCount + 1) : loginCount);
            command.Parameters.Add("@lastLogin", DateTime.Now);
            command.Parameters.Add("@id", userId);
            try {
                conn.Open();
                int returnCode = Convert.ToInt32(command.ExecuteNonQuery());

            } finally {
                conn.Close();
            }
        }

        public static DataTable GetAllUsersTable() {
            SqlCeConnection conn = GetSqlConnection();
            DataTable dataTable = new DataTable();
            try {
                conn.Open();
                using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(SqlCommands.commandGetAllUsersTable, conn)) {
                    // 3
                    // Use DataAdapter to fill DataTable

                    adapter.Fill(dataTable);

                    // 4
                    // Render data onto the screen
                    // dataGridView1.DataSource = t; // <-- From your designer
                }
            } finally {
                conn.Close();
            }
            return dataTable;
        }

        public static int InsertNewUser(string username) {
            int insertedUserId = -1;
            SqlCeConnection conn = GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandInsertNewUser, conn);
                // @username, @onlineStatus, @loginCount, @lastLogin, @firstLogin
                command.Parameters.Add("@username", username);
                command.Parameters.Add("@onlineStatus", "Offline");
                command.Parameters.Add("@loginCount", 1);
                command.Parameters.Add("@lastLogin", DateTime.Now);
                command.Parameters.Add("@firstLogin", DateTime.Now);
                Convert.ToInt32(command.ExecuteScalar());
                insertedUserId = GetMaxId("UserStatus", conn);
            } finally {
                conn.Close();
            }
            return insertedUserId;
        }

        private static int GetMaxId(string TableName,SqlCeConnection conn) {
            int maxId = -1;
            SqlCeCommand command = new SqlCeCommand("Select MAX(id) From " + TableName, conn);
            maxId =  Convert.ToInt32(command.ExecuteScalar());
            return maxId;
        }

        public static int GetLoginCountByUserId(int userId) {
            int selectedLoginCount = -1;

            SqlCeConnection conn = GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandGetLoginCountByUserId, conn);
                command.Parameters.Add("@id", userId);
                selectedLoginCount = Convert.ToInt32(command.ExecuteScalar());
            } finally {
                conn.Close();
            }

            return selectedLoginCount;
        }

        public static int GetUserIdByUsername(string username) {
            int selectedUserId = -1;

            SqlCeConnection conn = GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandGetUserIdByUserName, conn);
                command.Parameters.Add("@username", username);
                selectedUserId = Convert.ToInt32(command.ExecuteScalar());
            } finally {
                conn.Close();
            }
            return selectedUserId;
        }

        public static DataTable GetAllAdvancedRecs() {
            SqlCeConnection conn = GetSqlConnection();
            DataTable dataTable = new DataTable();
            try {
                conn.Open();
                using (SqlCeDataAdapter adapter = new SqlCeDataAdapter("SELECT * FROM Advanced_Recommendations", conn)) {
                    // 3
                    // Use DataAdapter to fill DataTable

                    adapter.Fill(dataTable);

                    // 4
                    // Render data onto the screen
                    // dataGridView1.DataSource = t; // <-- From your designer
                }
            } finally {
                conn.Close();
            }
            return dataTable;
        }

        public static int ExecuteRandomQuery(string query) {
            SqlCeConnection conn = GetSqlConnection();
            int value = 0;
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(query, conn);
                value = command.ExecuteNonQuery();
            } finally {
                conn.Close();
            }
            return value;
        }

        internal static int InsertCaptureEvent(CaptureEvent captureEvent) {
            int returnCode = -1;

            int RecommendationId = BackEndUtils.InsertRecommendation(captureEvent.CaptureEventName, captureEvent.CaptureEventDescription, captureEvent.CaptureEventEventText);
            int CapturePointId = BackEndUtils.InsertCapturePoints(RecommendationId, captureEvent.CaptureEventCapturePointsList);


            return returnCode;
        }

        private static int InsertCapturePoints(int RecommendationId, List<CustomTreeNode> customNodesList) {
            int returnCode = -1;
            List<int> capturePointsIds = new List<int>();
            SqlCeConnection conn = GetSqlConnection();
            try {
                conn.Open();
                for (int i = 0; i < customNodesList.Count; i++) {
                    SqlCeCommand command = new SqlCeCommand(SqlCommands.commandInsertCapturePoint, conn);
                    //@pointText, @pointUsedAttributes, @pointParentNode, @pointUsedAttribValues, @pointRecId
                    command.Parameters.Add("@pointText", customNodesList[i].Text);
                    command.Parameters.Add("@pointUsedAttributes", GetUsedAttributes(customNodesList[i].customizedAttributeCollection));
                    command.Parameters.Add("@pointParentNode", (customNodesList[i].Parent == null ? "" : customNodesList[i].Parent.Text));
                    command.Parameters.Add("@pointUsedAttribValues", GetUsedAttributesValues(customNodesList[i].customizedAttributeCollection));
                    command.Parameters.Add("@pointRecId", RecommendationId);
                    command.Parameters.Add("@Level", customNodesList[i].Level);
                    command.Parameters.Add("@ItemIndex", customNodesList[i].Index);
                    returnCode = Convert.ToInt32(command.ExecuteNonQuery());
                    SqlCeCommand commandMaxId = new SqlCeCommand(SqlCommands.commandMaxCapturePointId, conn);
                    capturePointsIds.Add(Convert.ToInt32(commandMaxId.ExecuteScalar()));
                }
            } finally {
                conn.Close();
            }
            return returnCode;
        }

        private static string GetUsedAttributesValues(List<CustomizedAttribute> list) {
            string usedAttributesValues = string.Empty;
            for (int i = 0; i < list.Count; i++) {
                if (list[i].isUsed) {
                    usedAttributesValues = usedAttributesValues + (string.IsNullOrEmpty(usedAttributesValues) ? "" : ",") + list[i].attribute.Value;
                }
            }
            return usedAttributesValues;
        }

        private static string GetUsedAttributes(List<CustomizedAttribute> list) {
            string usedAttributes = string.Empty;
            for (int i = 0; i < list.Count; i++) {
                if (list[i].isUsed) {
                    usedAttributes = usedAttributes + (string.IsNullOrEmpty(usedAttributes) ? "" : ",") + list[i].attribute.Name;
                }
            }
            return usedAttributes;
        }

        private static int InsertRecommendation(string name, string description, string eventText) {
            SqlCeConnection conn = GetSqlConnection();
            int value = 0;

            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandInsertRecommendation, conn);
                command.Parameters.Add("@name", name);
                command.Parameters.Add("@description", description);
                command.Parameters.Add("@eventText", eventText);
                value = Convert.ToInt32(command.ExecuteNonQuery());
                SqlCeCommand commandMaxId = new SqlCeCommand(SqlCommands.commandMaxRecommendationId, conn);
                value = Convert.ToInt32(commandMaxId.ExecuteScalar());
            } finally {
                conn.Close();
            }

            return value;
        }

        internal static object GetAllTableRowsAsDataTable(string tableName) {

            SqlCeConnection conn = GetSqlConnection();
            DataTable dataTable = new DataTable();
            try {
                conn.Open();

                using (SqlCeDataAdapter adapter = new SqlCeDataAdapter("SELECT * FROM " + tableName, conn)) {
                    // 3
                    // Use DataAdapter to fill DataTable

                    adapter.Fill(dataTable);

                    // 4
                    // Render data onto the screen
                    // dataGridView1.DataSource = t; // <-- From your designer
                }
            } finally {
                conn.Close();
            }

            return dataTable;

        }

        internal static List<CaptureEvent> GetAllAdvancedRecsAsList() {
            List<CaptureEvent> allCaptureEvens = new List<CaptureEvent>();
            DataTable advancedRexTable = new DataTable();
            SqlCeConnection conn = GetSqlConnection();
            SqlCeCommand getAllRecsCommand = new SqlCeCommand(SqlCommands.commandGetAllrecommendations, conn);
            DataTable dataTable = new DataTable();
            try {
                conn.Open();
                using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(SqlCommands.commandGetAllrecommendations, conn)) {
                    adapter.Fill(dataTable);
                }
                for (int i = 0; i < dataTable.Rows.Count; i++) {
                    DataTable capturePointsTable = GetRespectiveCapturePoints(dataTable.Rows[i].ItemArray[0], conn);
                    allCaptureEvens.Add(GetCaptureEventItem(dataTable.Rows[i], capturePointsTable));
                }
            } finally {
                conn.Close();
            }
            return allCaptureEvens;
        }

        private static CaptureEvent GetCaptureEventItem(DataRow advancedRecRow, DataTable capturePointsTable) {
            List<CustomTreeNode> customCapturePointList = GetCustomCapturePointListFromTable(capturePointsTable);
            return new CaptureEvent(advancedRecRow.ItemArray[1].ToString(), advancedRecRow.ItemArray[2].ToString(), advancedRecRow.ItemArray[3].ToString(), customCapturePointList);
        }
  
        private static List<CustomTreeNode> GetCustomCapturePointListFromTable(DataTable capturePointsTable) {
            List<CustomTreeNode> capturePointList = new List<CustomTreeNode>();
            for (int i = 0; i < capturePointsTable.Rows.Count; i++) {
                object obj = new object();
                XmlAttributeCollection attrCol = null;
                CustomTreeNode treeNode = new CustomTreeNode(capturePointsTable.Rows[i].ItemArray[0].ToString(), attrCol);
                treeNode.nodeLevel = Convert.ToInt32(capturePointsTable.Rows[i].ItemArray[4]);
                treeNode.nodeIndex = Convert.ToInt32(capturePointsTable.Rows[i].ItemArray[5]);
                treeNode.isNodeUsed = true;
                string[] usedAttributeNames = capturePointsTable.Rows[i].ItemArray[1].ToString().Split(',');
                string parentNode = capturePointsTable.Rows[i].ItemArray[2].ToString();
                string[] usedAttributeValues = capturePointsTable.Rows[i].ItemArray[3].ToString().Split(',');
                treeNode.parentNodeText = parentNode;
                treeNode.customizedAttributeCollection = new List<CustomizedAttribute>();
                for (int j = 0; j < usedAttributeNames.Length; j++) {
                    treeNode.customizedAttributeCollection.Add(new CustomizedAttribute(usedAttributeNames[j], usedAttributeValues[j], true));
                }
                capturePointList.Add(treeNode);
            }
            return capturePointList;
        }

        private static DataTable GetRespectiveCapturePoints(object advancedRecId, SqlCeConnection conn) {
            DataTable dataTable = new DataTable();//pointRecId
            SqlCeCommand command = new SqlCeCommand(SqlCommands.commandGetAllRespectiveCapturePoints, conn);
            command.Parameters.Add("@pointRecId", Convert.ToInt32(advancedRecId));
            using (SqlCeDataAdapter adapter2 = new SqlCeDataAdapter(command)) {
                adapter2.Fill(dataTable);
            }
            return dataTable;
        }

        private static int GetARCount() {
            int arCount = -1;
            SqlCeConnection conn = GetSqlConnection();
            SqlCeCommand command = new SqlCeCommand(SqlCommands.commandCountRecommendations, conn);
            try {
                conn.Open();
                arCount = Convert.ToInt32(command.ExecuteScalar());
            } finally {
                conn.Close();
            }
            return arCount;
        }

        internal static int InsertNewSimpleRecommendation(SimpleRecommendationObject newRecObj) {
            SqlCeConnection conn = GetSqlConnection();
            int value = 0;

            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandInsertNewSimpleRec, conn);
                command.Parameters.Add("@SR_name", newRecObj.optionName);
                command.Parameters.Add("@SR_isRegex", newRecObj.isRegex.ToString());
                command.Parameters.Add("@SR_description", newRecObj.description);
                command.Parameters.Add("@SR_pattern", newRecObj.pattern);
                command.Parameters.Add("@SR_replacement", newRecObj.replacement);
                command.Parameters.Add("@SR_fileName", newRecObj.fileName);
                value = Convert.ToInt32(command.ExecuteNonQuery());
                SqlCeCommand commandMaxId = new SqlCeCommand(SqlCommands.commandMaxSimpleRecommendationId, conn);
                value = Convert.ToInt32(commandMaxId.ExecuteScalar());
            } finally {
                conn.Close();
            }

            return value;
        }

        internal static List<SimpleRecommendationObject> GetAllSimpleRecsAsList() {
            List<SimpleRecommendationObject> simpleRecommendationObjects = new List<SimpleRecommendationObject>();
            DataTable advancedRexTable = new DataTable();
            SqlCeConnection conn = GetSqlConnection();
            SqlCeCommand getAllRecsCommand = new SqlCeCommand(SqlCommands.commandGetAllSimpleRecommendations, conn);
            DataTable dataTable = new DataTable();
            try {
                conn.Open();
                using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(SqlCommands.commandGetAllSimpleRecommendations, conn)) {
                    adapter.Fill(dataTable);
                }
                for (int i = 0; i < dataTable.Rows.Count; i++) {
                   // DataTable capturePointsTable = GetRespectiveCapturePoints(dataTable.Rows[i].ItemArray[0], conn);
                    object[] itemArray = dataTable.Rows[i].ItemArray;
                    SimpleRecommendationObject simpleRec = new SimpleRecommendationObject();
                    simpleRec.optionName = itemArray[1] as string;
                    simpleRec.isRegex = string.Equals((itemArray[2] as string),"True");
                    simpleRec.description = itemArray[3] as string;
                    simpleRec.pattern = itemArray[4] as string;
                    simpleRec.replacement = itemArray[5] as string;
                    simpleRec.fileName = itemArray[6] as string ;
                    simpleRecommendationObjects.Add(simpleRec);
                }
            } finally {
                conn.Close();
            }
            return simpleRecommendationObjects;
        }

        internal static void UpdateSimpleRecByName(SimpleRecommendationObject newRecObj, string newName) {
            int simpleRecId = GetSimpleRecIdByName(newRecObj.optionName);
            UpdateSimpleRecById(simpleRecId,newRecObj, newName);
        }

        private static void UpdateSimpleRecById(int simpleRecId, SimpleRecommendationObject newRecObj, string newName) {
            SqlCeConnection conn = GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandUpdateSimpleRecByName, conn);
                command.Parameters.Add("@SR_name", newName);
                command.Parameters.Add("@SR_isRegex", newRecObj.isRegex.ToString());
                command.Parameters.Add("@SR_description", newRecObj.description);
                command.Parameters.Add("@SR_pattern", newRecObj.pattern);
                command.Parameters.Add("@SR_replacement", newRecObj.replacement);
                command.Parameters.Add("@SR_fileName", newRecObj.fileName);
                command.Parameters.Add("@id", simpleRecId);
                command.ExecuteNonQuery();           
            } finally {
                conn.Close();
            }
        }

        private static int GetSimpleRecIdByName(string optionName) {
            SqlCeConnection conn = GetSqlConnection();
            int value = 0;
            try {
                conn.Open();
                SqlCeCommand commandRecIdByName = new SqlCeCommand(SqlCommands.commandGetSimpleRecIdByName, conn);
                commandRecIdByName.Parameters.Add("@SR_name", optionName); 
                value = Convert.ToInt32(commandRecIdByName.ExecuteScalar());
            } finally {
                conn.Close();
            }
            return value;
        }

        internal static List<ApplicationConfigObject> GetAllApplicationConfigAsList() {
            List<ApplicationConfigObject> applicationConfigObjectList = new List<ApplicationConfigObject>();
            DataTable advancedRexTable = new DataTable();
            SqlCeConnection conn = GetSqlConnection();
            SqlCeCommand getAllRecsCommand = new SqlCeCommand(SqlCommands.commandGetAllAppConfig, conn);
            DataTable dataTable = new DataTable();
            try {
                conn.Open();
                using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(SqlCommands.commandGetAllAppConfig, conn)) {
                    adapter.Fill(dataTable);
                }
                for (int i = 0; i < dataTable.Rows.Count; i++) {
                    // DataTable capturePointsTable = GetRespectiveCapturePoints(dataTable.Rows[i].ItemArray[0], conn);
                    object[] itemArray = dataTable.Rows[i].ItemArray;
                    ApplicationConfigObject applicationConfigObject = new ApplicationConfigObject(itemArray[1] as string, itemArray[2] as string);
                    applicationConfigObjectList.Add(applicationConfigObject);
                }
            } finally {
                conn.Close();
            }
            return applicationConfigObjectList;
        }

        internal static DataSet GetAppPrefsDataset() {
            SqlCeConnection conn = GetSqlConnection();
            DataSet dataSet = new DataSet();
            try {
                SqlCeDataAdapter da = new SqlCeDataAdapter(SqlCommands.commandGetAllAppConfig, conn);
                SqlCeCommandBuilder cb = new SqlCeCommandBuilder(da);                
                da.Fill(dataSet);
            } finally {
                conn.Close();
            }
            return dataSet;
        }

        internal static void UpdatePrefs(DataSet dataSet) {
            SqlCeConnection conn = GetSqlConnection();            
            try {
                SqlCeDataAdapter da = new SqlCeDataAdapter(SqlCommands.commandGetAllAppConfig, conn);
                SqlCeCommandBuilder cb = new SqlCeCommandBuilder(da);
                da.Update(dataSet);
            } finally {
                conn.Close();
            }
        }
        
        internal static List<string> GetPriviligedUsersAsList() {
            List<string> priviligedUsersList = new List<string>();
            SqlCeConnection conn = GetSqlConnection();
            SqlCeCommand command = new SqlCeCommand(SqlCommands.commandSelectFromAppConfigByKey, conn);
            try {
                conn.Open();
                command.Parameters.Add("@id", ApplicationConfigKeys.PriviligedUsersKey);
                priviligedUsersList = command.ExecuteScalar().ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            } finally {
                conn.Close();
            }
            return priviligedUsersList;
        }

        internal static object GetAppConfigValueByKey(ApplicationConfigKeys applicationConfigKeys) {
            SqlCeConnection conn = GetSqlConnection();
            SqlCeCommand command = new SqlCeCommand(SqlCommands.commandSelectFromAppConfigByKey, conn);
            try {
                conn.Open();
                command.Parameters.Add("@id", applicationConfigKeys);
               return command.ExecuteScalar();
            } finally {
                conn.Close();
            }
            return null;
        }

        internal static DataSet GetAllUsersTableAsDataSet() {
            SqlCeConnection conn = GetSqlConnection();
            DataSet dataSet = new DataSet();
            try {
                SqlCeDataAdapter da = new SqlCeDataAdapter(SqlCommands.commandGetAllUsersTable, conn);
                SqlCeCommandBuilder cb = new SqlCeCommandBuilder(da);
                da.Fill(dataSet);
            } finally {
                conn.Close();
            }
            return dataSet;
        }

    }
}