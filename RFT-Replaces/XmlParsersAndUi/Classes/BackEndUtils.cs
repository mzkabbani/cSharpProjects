using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using XmlParsersAndUi.Classes;
using System.Windows.Forms;

namespace XmlParsersAndUi {
    public class BackEndUtils {

        public static string ConnectionParamter = string.Empty;

        public static string ConnectionParamterPrimary = string.Empty;

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

        private static SqlCeConnection GetSqlConnection() {
            SqlCeConnection sqlConnection1 = new SqlCeConnection();
            //sqlConnection1.ConnectionString = @"Data Source=C:\Documents and Settings\mkabbani\My Documents\Visual Studio 2008\Projects\RFT-Replaces\XmlParsersAndUi\Database.sdf";

            #region May use this for parallel databases running at same time
            //try {
            //    sqlConnection1.ConnectionString = "Data Source=" + ConnectionParamterPrimary;
            //    try {
            //        sqlConnection1.Open();
            //    } finally {
            //        sqlConnection1.Close();
            //    }
            //} catch (Exception ex) {
            //    sqlConnection1.ConnectionString = "Data Source=" + ConnectionParamter;                
            //} 
            #endregion

            sqlConnection1.ConnectionString = "Data Source=" + ConnectionParamter;
            return sqlConnection1;
        }

        public static void UpdateUserStatusById(int userId, bool isLoginEvent) {
            int loginCount = BackEndUtils.GetLoginCountByUserId(userId);
            //onlineStatus =@onlineStatus, loginCount =@loginCount, lastLogin =@lastLogin"+
            //"WHERE id=@id"
            SqlCeConnection conn = GetSqlConnection();
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

        private static int GetMaxId(string TableName, SqlCeConnection conn) {
            int maxId = -1;
            SqlCeCommand command = new SqlCeCommand("Select MAX(id) From " + TableName, conn);
            maxId = Convert.ToInt32(command.ExecuteScalar());
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


        public static DataSet GetAllAdvancedRecsAsDataSet() {
            SqlCeConnection conn = GetSqlConnection();
            DataSet dataSet = new DataSet();
            try {
                SqlCeDataAdapter da = new SqlCeDataAdapter("SELECT * FROM Advanced_Recommendations", conn);
                SqlCeCommandBuilder cb = new SqlCeCommandBuilder(da);
                da.Fill(dataSet);
            } finally {
                conn.Close();
            }
            return dataSet;
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

        #region Text conversion


        internal static void DisableAdvanceRecById(int advanceRecId) {
            SqlCeConnection conn = GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandDisableAdvancedRecTextConv, conn);                
                command.Parameters.Add("@id", advanceRecId);
                command.Parameters.Add("@isEnabled", "0");
                command.ExecuteNonQuery();
            } finally {
                conn.Close();
            }
        }

        internal static void SaveCaptureEventByIdForTextConversion(int captureEventId, CaptureEvent captureEvent, ReplacementEvent replacementEvent) {
            SqlCeTransaction transaction;
            SqlCeConnection conn = GetSqlConnection();
            try {
                conn.Open();
                transaction = conn.BeginTransaction();
                try {
                    UpdateRecommendationByIdForTextConversion(captureEventId, captureEvent, conn, transaction);
                    DeletAllRespectiveCapturePointsForTextConversion(captureEventId, conn, transaction);
                    InsertCapturePointsAsTransactionForTextConversion(captureEventId, captureEvent.CaptureEventCapturePointsList, conn, transaction);
                    replacementEvent.capturePointId = captureEventId;
                    SaveReplacementEventForTextConversion(replacementEvent, conn, transaction);
                    transaction.Commit();
                } catch (Exception ex) {
                    FrontendUtils.LogError(ex.Message, ex);
                    transaction.Rollback();
                }
            } finally {
                conn.Close();
            }
        }

        private static int InsertCapturePointsAsTransactionForTextConversion(int RecommendationId, List<CustomTreeNode> customNodesList, SqlCeConnection conn, SqlCeTransaction transaction) {
            int returnCode = -1;
            List<int> capturePointsIds = new List<int>();
            for (int i = 0; i < customNodesList.Count; i++) {
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandInsertCapturePointTextConv, conn);
                command.Transaction = transaction;
                //@pointText, @pointUsedAttributes, @pointParentNode, @pointUsedAttribValues, @pointRecId
                command.Parameters.Add("@pointText", customNodesList[i].Text);
                command.Parameters.Add("@pointUsedAttributes", GetUsedAttributes(customNodesList[i].customizedAttributeCollection));
                command.Parameters.Add("@pointParentNode", (customNodesList[i].Parent == null ? "" : customNodesList[i].Parent.Text));
                command.Parameters.Add("@pointUsedAttribValues", GetUsedAttributesValues(customNodesList[i].customizedAttributeCollection));
                command.Parameters.Add("@pointRecId", RecommendationId);
                command.Parameters.Add("@Level", customNodesList[i].Level);
                command.Parameters.Add("@ItemIndex", customNodesList[i].Index);
                command.Parameters.Add("@parentLevel", customNodesList[i].Parent == null ? -1 : customNodesList[i].Parent.Level);
                command.Parameters.Add("@parentIndex", customNodesList[i].Parent == null ? -1 : customNodesList[i].Parent.Index);

                returnCode = Convert.ToInt32(command.ExecuteNonQuery());
                SqlCeCommand commandMaxId = new SqlCeCommand(SqlCommands.commandMaxCapturePointIdTextConv, conn);
                capturePointsIds.Add(Convert.ToInt32(commandMaxId.ExecuteScalar()));
            }
            return returnCode;
        }

        private static void DeletAllRespectiveCapturePointsForTextConversion(int captureEventId, SqlCeConnection conn, SqlCeTransaction transaction) {
            //pointRecId
            int value = 0;
            SqlCeCommand command = new SqlCeCommand(SqlCommands.commandRemoveAllCapturePointsByRecIdTextConv, conn);
            command.Transaction = transaction;
            command.Parameters.Add("@pointRecId", captureEventId);
            value = Convert.ToInt32(command.ExecuteNonQuery());
        }

        private static void UpdateRecommendationByIdForTextConversion(int captureEventId, CaptureEvent captureEvent, SqlCeConnection conn, SqlCeTransaction transaction) {
            int value = 0;
            SqlCeCommand command = new SqlCeCommand(SqlCommands.commandUpdateRecommendationByIdTextConv, conn);
            command.Transaction = transaction;
            command.Parameters.Add("@name", captureEvent.CaptureEventName);
            command.Parameters.Add("@description", captureEvent.CaptureEventDescription);
            command.Parameters.Add("@event_text", captureEvent.CaptureEventEventText);
            command.Parameters.Add("@id", captureEventId);
            command.Parameters.Add("@categoryId", captureEvent.captureEventCategory);
            command.Parameters.Add("@usageCount", captureEvent.captureEventUsageCount);
            command.Parameters.Add("@userId", FrontendUtils.LoggedInUserId);
            value = Convert.ToInt32(command.ExecuteNonQuery());
        }


        #endregion


        internal static void SaveCaptureEventById(int captureEventId, CaptureEvent captureEvent) {
            SqlCeTransaction transaction;
            SqlCeConnection conn = GetSqlConnection();
            try {
                conn.Open();
                transaction = conn.BeginTransaction();
                try {
                    UpdateRecommendationById(captureEventId, captureEvent, conn, transaction);
                    DeletAllRespectiveCapturePoints(captureEventId, conn, transaction);
                    InsertCapturePointsAsTransaction(captureEventId, captureEvent.CaptureEventCapturePointsList, conn, transaction);
                    transaction.Commit();
                } catch (Exception ex) {
                    FrontendUtils.LogError(ex.Message, ex);
                    transaction.Rollback();
                }
            } finally {
                conn.Close();
            }
        }

        private static int InsertCapturePointsAsTransaction(int RecommendationId, List<CustomTreeNode> customNodesList, SqlCeConnection conn, SqlCeTransaction transaction) {
            int returnCode = -1;
            List<int> capturePointsIds = new List<int>();
            for (int i = 0; i < customNodesList.Count; i++) {
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandInsertCapturePoint, conn);
                command.Transaction = transaction;
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
            return returnCode;
        }

        private static void DeletAllRespectiveCapturePoints(int captureEventId, SqlCeConnection conn, SqlCeTransaction transaction) {
            //pointRecId
            int value = 0;
            SqlCeCommand command = new SqlCeCommand(SqlCommands.commandRemoveAllCapturePointsByRecId, conn);
            command.Transaction = transaction;
            command.Parameters.Add("@pointRecId", captureEventId);
            value = Convert.ToInt32(command.ExecuteNonQuery());
        }

        private static void UpdateRecommendationById(int captureEventId, CaptureEvent captureEvent, SqlCeConnection conn, SqlCeTransaction transaction) {
            int value = 0;
            SqlCeCommand command = new SqlCeCommand(SqlCommands.commandUpdateRecommendationById, conn);
            command.Transaction = transaction;
            command.Parameters.Add("@name", captureEvent.CaptureEventName);
            command.Parameters.Add("@description", captureEvent.CaptureEventDescription);
            command.Parameters.Add("@event_text", captureEvent.CaptureEventEventText);
            command.Parameters.Add("@id", captureEventId);
            command.Parameters.Add("@categoryId", captureEvent.captureEventCategory);
            command.Parameters.Add("@usageCount", captureEvent.captureEventUsageCount);
            command.Parameters.Add("@userId", FrontendUtils.LoggedInUserId);
            value = Convert.ToInt32(command.ExecuteNonQuery());
        }

        internal static int InsertCaptureEvent(CaptureEvent captureEvent) {
            int returnCode = -1;
            int RecommendationId = BackEndUtils.InsertRecommendation(captureEvent);
            int CapturePointId = BackEndUtils.InsertCapturePoints(RecommendationId, captureEvent.CaptureEventCapturePointsList);
            return returnCode;
        }

        internal static int InsertCaptureEventForTextConversion(CaptureEvent captureEvent, ReplacementEvent replacementEvent) {
            int returnCode = -1;
            int RecommendationId = BackEndUtils.InsertRecommendationForTextConversion(captureEvent);
            int CapturePointId = BackEndUtils.InsertCapturePointsForTextConversion(RecommendationId, captureEvent.CaptureEventCapturePointsList);
            replacementEvent.capturePointId = RecommendationId;
            InsertNewReplacementForTextConversion(replacementEvent);
            return returnCode;
        }

        private static int InsertCapturePointsForTextConversion(int RecommendationId, List<CustomTreeNode> customNodesList) {
            int returnCode = -1;
            List<int> capturePointsIds = new List<int>();
            SqlCeConnection conn = GetSqlConnection();
            try {
                conn.Open();
                for (int i = 0; i < customNodesList.Count; i++) {
                    SqlCeCommand command = new SqlCeCommand(SqlCommands.commandInsertCapturePointTextConv, conn);
                    //@pointText, @pointUsedAttributes, @pointParentNode, @pointUsedAttribValues, @pointRecId
                    command.Parameters.Add("@pointText", customNodesList[i].Text);
                    command.Parameters.Add("@pointUsedAttributes", GetUsedAttributes(customNodesList[i].customizedAttributeCollection));
                    command.Parameters.Add("@pointParentNode", (customNodesList[i].Parent == null ? "" : customNodesList[i].Parent.Text));
                    command.Parameters.Add("@pointUsedAttribValues", GetUsedAttributesValues(customNodesList[i].customizedAttributeCollection));
                    command.Parameters.Add("@pointRecId", RecommendationId);
                    command.Parameters.Add("@Level", customNodesList[i].Level);
                    command.Parameters.Add("@ItemIndex", customNodesList[i].Index);
                    command.Parameters.Add("@parentLevel", customNodesList[i].Parent == null ? -1 : customNodesList[i].Parent.Level);
                    command.Parameters.Add("@parentIndex", customNodesList[i].Parent == null ? -1 : customNodesList[i].Parent.Index);

                    returnCode = Convert.ToInt32(command.ExecuteNonQuery());
                    SqlCeCommand commandMaxId = new SqlCeCommand(SqlCommands.commandMaxCapturePointIdTextConv, conn);
                    capturePointsIds.Add(Convert.ToInt32(commandMaxId.ExecuteScalar()));
                }
            } finally {
                conn.Close();
            }
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
                    if (list[i].attribute == null) {
                        usedAttributesValues = usedAttributesValues + (string.IsNullOrEmpty(usedAttributesValues) ? "" : ",") + list[i].attrValue;
                    } else {
                        usedAttributesValues = usedAttributesValues + (string.IsNullOrEmpty(usedAttributesValues) ? "" : ",") + list[i].attribute.Value;
                    }
                }
            }
            return usedAttributesValues;
        }

        private static string GetUsedAttributes(List<CustomizedAttribute> list) {
            string usedAttributes = string.Empty;
            for (int i = 0; i < list.Count; i++) {
                if (list[i].isUsed) {
                    if (list[i].attribute == null) {
                        usedAttributes = usedAttributes + (string.IsNullOrEmpty(usedAttributes) ? "" : ",") + list[i].attrName;
                    } else {
                        usedAttributes = usedAttributes + (string.IsNullOrEmpty(usedAttributes) ? "" : ",") + list[i].attribute.Name;
                    }
                }
            }
            return usedAttributes;
        }


        private static int InsertRecommendationForTextConversion(CaptureEvent captureEvent) {
            SqlCeConnection conn = GetSqlConnection();
            int value = 0;
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandInsertRecommendationTextConv, conn);
                command.Parameters.Add("@name", captureEvent.CaptureEventName);
                command.Parameters.Add("@description", captureEvent.CaptureEventDescription);
                command.Parameters.Add("@eventText", captureEvent.CaptureEventEventText);
                // @categoryId, @usageCount
                command.Parameters.Add("@categoryId", captureEvent.captureEventCategory);
                command.Parameters.Add("@usageCount", captureEvent.captureEventUsageCount);
                command.Parameters.Add("@userId", FrontendUtils.LoggedInUserId);
                value = Convert.ToInt32(command.ExecuteNonQuery());
                SqlCeCommand commandMaxId = new SqlCeCommand(SqlCommands.commandMaxRecommendationIdTextConv, conn);
                value = Convert.ToInt32(commandMaxId.ExecuteScalar());
            } finally {
                conn.Close();
            }
            return value;
        }

        private static int InsertRecommendation(CaptureEvent captureEvent) {
            SqlCeConnection conn = GetSqlConnection();
            int value = 0;
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandInsertRecommendation, conn);
                command.Parameters.Add("@name", captureEvent.CaptureEventName);
                command.Parameters.Add("@description", captureEvent.CaptureEventDescription);
                command.Parameters.Add("@eventText", captureEvent.CaptureEventEventText);
                // @categoryId, @usageCount
                command.Parameters.Add("@categoryId", captureEvent.captureEventCategory);
                command.Parameters.Add("@usageCount", captureEvent.captureEventUsageCount);
                command.Parameters.Add("@userId", FrontendUtils.LoggedInUserId);
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

        internal static List<CaptureEvent> GetAllAdvancedRecsAsListTextConv() {
            List<CaptureEvent> allCaptureEvens = new List<CaptureEvent>();
            DataTable advancedRexTable = new DataTable();
            SqlCeConnection conn = GetSqlConnection();
            SqlCeCommand getAllRecsCommand = new SqlCeCommand(SqlCommands.commandGetAllrecommendationsTextConv, conn);
            DataTable dataTable = new DataTable();
            try {
                conn.Open();
                using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(SqlCommands.commandGetAllrecommendationsTextConv, conn)) {
                    adapter.Fill(dataTable);
                }
                for (int i = 0; i < dataTable.Rows.Count; i++) {
                    DataTable capturePointsTable = GetRespectiveCapturePointsForTextConversion(dataTable.Rows[i].ItemArray[6], conn);
                    allCaptureEvens.Add(GetCaptureEventItem(dataTable.Rows[i], capturePointsTable, conn));
                }
            } finally {
                conn.Close();
            }
            return allCaptureEvens;
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
                    allCaptureEvens.Add(GetCaptureEventItem(dataTable.Rows[i], capturePointsTable, conn));
                }
            } finally {
                conn.Close();
            }
            return allCaptureEvens;
        }

        private static CaptureEvent GetCaptureEventItem(DataRow advancedRecRow, DataTable capturePointsTable, SqlCeConnection conn) {
            List<CustomTreeNode> customCapturePointList = GetCustomCapturePointListFromTable(capturePointsTable);
            CaptureEvent capture = new CaptureEvent(Convert.ToInt32(advancedRecRow["id"]), advancedRecRow["name"].ToString(), advancedRecRow["description"].ToString(), advancedRecRow["event_text"].ToString(), Convert.ToInt32(advancedRecRow["categoryId"]), Convert.ToInt32(advancedRecRow["usageCount"]), customCapturePointList, FrontendUtils.LoggedInUserId);
            capture.Replacement = GetReplacementEventByCaptureEventId(capture.CaptureEventId, conn);
            return capture;
        }

        private static ReplacementEvent GetReplacementEventByCaptureEventId(int captureEventId, SqlCeConnection conn) {
            List<ReplacementEvent> replacements = GetAvailableReplacementsByCaptureIdForTextConversion(captureEventId, conn);
            return replacements[0];
        }

        private static List<CustomTreeNode> GetCustomCapturePointListFromTable(DataTable capturePointsTable) {
            List<CustomTreeNode> capturePointList = new List<CustomTreeNode>();
            for (int i = 0; i < capturePointsTable.Rows.Count; i++) {
                object obj = new object();
                XmlAttributeCollection attrCol = null;
                CustomTreeNode treeNode = new CustomTreeNode(capturePointsTable.Rows[i].ItemArray[0].ToString(), attrCol);
                treeNode.nodeLevel = Convert.ToInt32(capturePointsTable.Rows[i].ItemArray[4]);
                treeNode.nodeIndex = Convert.ToInt32(capturePointsTable.Rows[i].ItemArray[5]);
                treeNode.parentLevel=Convert.ToInt32(capturePointsTable.Rows[i].ItemArray[6]);
                treeNode.parentIndex = Convert.ToInt32(capturePointsTable.Rows[i].ItemArray[7]);
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

        private static DataTable GetRespectiveCapturePointsForTextConversion(object advancedRecId, SqlCeConnection conn) {
            DataTable dataTable = new DataTable();//pointRecId
            SqlCeCommand command = new SqlCeCommand(SqlCommands.commandGetAllRespectiveCapturePointsTextConv, conn);
            command.Parameters.Add("@pointRecId", Convert.ToInt32(advancedRecId));
            using (SqlCeDataAdapter adapter2 = new SqlCeDataAdapter(command)) {
                adapter2.Fill(dataTable);
            }
            return dataTable;
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


        public static int GetTotalAdvanceRecUsageCount() {
            int total = 0;
            SqlCeConnection conn = GetSqlConnection();
            SqlCeCommand command = new SqlCeCommand(SqlCommands.commandSelectSumOfAllAdvancedRecUsage, conn);
            try {
                conn.Open();
                total = Convert.ToInt32(command.ExecuteScalar());
            } finally {
                conn.Close();
            }
            return total;
        }

        public static int GetTotalAdvanceReplacementUsageCount() {
            int total = 0;
            SqlCeConnection conn = GetSqlConnection();
            SqlCeCommand command = new SqlCeCommand(SqlCommands.commandSelectSumOfAllReplacementUsage, conn);
            try {
                conn.Open();
                total = Convert.ToInt32(command.ExecuteScalar());
            } finally {
                conn.Close();
            }
            return total;
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
                    simpleRec.isRegex = string.Equals((itemArray[2] as string), "True");
                    simpleRec.description = itemArray[3] as string;
                    simpleRec.pattern = itemArray[4] as string;
                    simpleRec.replacement = itemArray[5] as string;
                    simpleRec.fileName = itemArray[6] as string;
                    simpleRecommendationObjects.Add(simpleRec);
                }
            } finally {
                conn.Close();
            }
            return simpleRecommendationObjects;
        }

        internal static void UpdateSimpleRecByName(SimpleRecommendationObject newRecObj, string newName) {
            int simpleRecId = GetSimpleRecIdByName(newRecObj.optionName);
            UpdateSimpleRecById(simpleRecId, newRecObj, newName);
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
                    ApplicationConfigObject applicationConfigObject = new ApplicationConfigObject(Convert.ToInt32(itemArray[0]), itemArray[1] as string, itemArray[2] as string);
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
                command.Parameters.Add("@id", ApplicationConfigKeys.PrivelegedUsers);
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


        internal static DataSet GetAllFolderNamesAsDataset() {
            SqlCeConnection conn = GetSqlConnection();
            DataSet dataSet = new DataSet();
            try {
                SqlCeDataAdapter da = new SqlCeDataAdapter(SqlCommands.commandGetAllFolderNamesTable, conn);
                SqlCeCommandBuilder cb = new SqlCeCommandBuilder(da);
                da.Fill(dataSet);
            } finally {
                conn.Close();
            }
            return dataSet;
        }

        internal static void DeleteAllFileNames(SqlCeTransaction transaction, SqlCeConnection conn) {
            SqlCeCommand command = new SqlCeCommand(SqlCommands.commandDeleteAllFolderNames, conn);
            command.Transaction = transaction;
            command.Connection = conn;
            command.ExecuteNonQuery();
        }

        internal static void InsertFolderName(int index, string folderName, object parentId, SqlCeTransaction transaction, SqlCeConnection conn) {
            SqlCeCommand command = new SqlCeCommand(SqlCommands.commandInsertFolderName, conn);
            command.Parameters.Add("@id", index);
            command.Parameters.Add("@folderName", folderName);
            command.Parameters.Add("@parentId", parentId);
            command.Transaction = transaction;
            command.Connection = conn;
            command.ExecuteNonQuery();
        }

        internal static void InsertUpdatedFileNames(List<TreeNode> treeNodes, SqlCeTransaction transaction, SqlCeConnection conn) {
            for (int i = 0; i < treeNodes.Count; i++) {
                int parentId = treeNodes[i].Parent == null ? -1 : treeNodes.IndexOf(treeNodes[i].Parent);
                if (parentId != -1) {
                    BackEndUtils.InsertFolderName(i, treeNodes[i].Text, parentId, transaction, conn);
                } else {
                    BackEndUtils.InsertFolderName(i, treeNodes[i].Text, DBNull.Value, transaction, conn);
                }
            }
        }

        internal static void UpdateTreeNodesTransaction(List<TreeNode> treeNodes) {
            SqlCeTransaction transaction;
            SqlCeConnection conn = GetSqlConnection();
            try {
                conn.Open();
                transaction = conn.BeginTransaction();
                try {
                    DeleteAllFileNames(transaction, conn);
                    InsertUpdatedFileNames(treeNodes, transaction, conn);
                    transaction.Commit();
                } catch (Exception ex) {
                    FrontendUtils.LogError(ex.Message, ex);
                    transaction.Rollback();
                }
            } finally {
                conn.Close();
            }
        }


        internal static void UpdateEnvComparisonCategoriesTransaction(List<ComparisonCategoryTreeNode> treeNodes) {
            SqlCeTransaction transaction;
            SqlCeConnection conn = GetSqlConnection();
            try {
                conn.Open();
                transaction = conn.BeginTransaction();
                try {
                    DeleteEnvResultsCategories(transaction, conn);
                    InsertUpdatedCategories(treeNodes, transaction, conn);
                    transaction.Commit();
                } catch (Exception ex) {
                    FrontendUtils.LogError(ex.Message, ex);
                    transaction.Rollback();
                }
            } finally {
                conn.Close();
            }
        }

        private static void InsertUpdatedCategories(List<ComparisonCategoryTreeNode> treeNodes, SqlCeTransaction transaction, SqlCeConnection conn) {
            for (int i = 0; i < treeNodes.Count; i++) {
                int parentId = treeNodes[i].Parent == null ? -1 : treeNodes.IndexOf(treeNodes[i].Parent as ComparisonCategoryTreeNode);
                if (parentId != -1) {
                    ComparisonCategory comparisonCategory = treeNodes[i].comparisonCategory;
                    comparisonCategory.categoryParentId = parentId;
                    comparisonCategory.categoryId = i;
                    BackEndUtils.InserNewCategory(comparisonCategory, transaction, conn);
                    //  BackEndUtils.InsertFolderName(i, treeNodes[i].Text, parentId, transaction, conn);
                } else {
                    ComparisonCategory comparisonCategory = treeNodes[i].comparisonCategory;
                    comparisonCategory.categoryParentId = parentId;
                    comparisonCategory.categoryId = i;
                    BackEndUtils.InserNewCategory(comparisonCategory, transaction, conn);
                }
            }
        }

        private static void DeleteEnvResultsCategories(SqlCeTransaction transaction, SqlCeConnection conn) {
            SqlCeCommand command = new SqlCeCommand(SqlCommands.commandDeleteAllEnvCategories, conn);
            command.Transaction = transaction;
            command.Connection = conn;
            command.ExecuteNonQuery();
        }

        internal static DataSet GetAllAdvancedRecCategoriesAsDataset() {
            SqlCeConnection conn = GetSqlConnection();
            DataSet dataSet = new DataSet();
            try {
                SqlCeDataAdapter da = new SqlCeDataAdapter(SqlCommands.commandGetAllCaptureCategories, conn);
                SqlCeCommandBuilder cb = new SqlCeCommandBuilder(da);
                da.Fill(dataSet);
            } finally {
                conn.Close();
            }
            return dataSet;
        }

        internal static CaptureEvent SelectAdvancedRecByIdAndIncrementUsage(object RecId, int currentUsageCount) {
            SqlCeConnection conn = GetSqlConnection();
            CaptureEvent captureEvent;
            DataTable dataTable = new DataTable();
            try {
                conn.Open();
                DataTable capturePointsTable = GetRespectiveCapturePoints(RecId, conn);
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandSelectAdvancedRecById);
                command.Parameters.Add("@id", RecId);
                command.Connection = conn;
                using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(command)) {
                    adapter.Fill(dataTable);
                }
                captureEvent = GetCaptureEventItem(dataTable.Rows[0], capturePointsTable,conn);
                SqlCeCommand incrementUsageCount = new SqlCeCommand(SqlCommands.commandUpdateRecommendationUsageCountById);
                incrementUsageCount.Parameters.Add("@usageCount", currentUsageCount + 1);
                incrementUsageCount.Parameters.Add("@id", (int)RecId);
                incrementUsageCount.Connection = conn;
                object resutlt = incrementUsageCount.ExecuteNonQuery();
            } finally {
                conn.Close();
            }
            return captureEvent;
        }


        internal static CaptureEvent SelectAdvancedRecById(object RecId) {
            SqlCeConnection conn = GetSqlConnection();
            CaptureEvent captureEvent;
            DataTable dataTable = new DataTable();
            try {
                conn.Open();
                DataTable capturePointsTable = GetRespectiveCapturePoints(RecId, conn);
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandSelectAdvancedRecById);
                command.Parameters.Add("@id", RecId);
                command.Connection = conn;
                using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(command)) {
                    adapter.Fill(dataTable);
                }
                captureEvent = GetCaptureEventItem(dataTable.Rows[0], capturePointsTable, conn);
            } finally {
                conn.Close();
            }
            return captureEvent;
        }


        public static DataTable GetAllReplacementCategoriesAsDataTable() {
            DataTable dataTable = new DataTable();
            SqlCeConnection conn = GetSqlConnection();
            SqlCeCommand command = new SqlCeCommand(SqlCommands.commandGetAllReplacementCategories, conn);
            using (SqlCeDataAdapter adapter2 = new SqlCeDataAdapter(command)) {
                adapter2.Fill(dataTable);
            }
            return dataTable;
        }


        public static int InsertNewReplacementForTextConversion(ReplacementEvent replacementEvent) {
            int replacementId = 0;
            int numberAffectedRows = 0;
            SqlCeConnection conn = GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandInsertReplacementTextConv, conn);
                command.Parameters.Add("@name", replacementEvent.name);
                command.Parameters.Add("@description", replacementEvent.description);
                command.Parameters.Add("@value", replacementEvent.Value);
                command.Parameters.Add("@typeId", replacementEvent.typeId);
                command.Parameters.Add("@capturePointId", replacementEvent.capturePointId);
                command.Parameters.Add("@userId", replacementEvent.userId);
                command.Parameters.Add("@usageCount", replacementEvent.usageCount);
                numberAffectedRows = Convert.ToInt32(command.ExecuteNonQuery());
                SqlCeCommand commandMaxId = new SqlCeCommand(SqlCommands.commandMaxReplacementIdTextConv, conn);
                replacementId = Convert.ToInt32(commandMaxId.ExecuteScalar());
            } finally {
                conn.Close();
            }
            return replacementId;
        }

        public static int InsertNewReplacement(ReplacementEvent replacementEvent) {
            int replacementId = 0;
            int numberAffectedRows = 0;
            SqlCeConnection conn = GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandInsertReplacement, conn);
                command.Parameters.Add("@name", replacementEvent.name);
                command.Parameters.Add("@description", replacementEvent.description);
                command.Parameters.Add("@value", replacementEvent.Value);
                command.Parameters.Add("@typeId", replacementEvent.typeId);
                command.Parameters.Add("@capturePointId", replacementEvent.capturePointId);
                command.Parameters.Add("@userId", replacementEvent.userId);
                command.Parameters.Add("@usageCount", replacementEvent.usageCount);
                numberAffectedRows = Convert.ToInt32(command.ExecuteNonQuery());
                SqlCeCommand commandMaxId = new SqlCeCommand(SqlCommands.commandMaxReplacementId, conn);
                replacementId = Convert.ToInt32(commandMaxId.ExecuteScalar());
            } finally {
                conn.Close();
            }
            return replacementId;
        }

        public static List<ReplacementEvent> GetAvailableReplacementsByCaptureIdForTextConversion(int captureEventId, SqlCeConnection conn) {
            //commandGetCapturePointReplacements
            List<ReplacementEvent> replacementEvents = new List<ReplacementEvent>();
            DataSet availableReplacementsAsDataset = GetAvailableReplacementsAsDatasetForTextConversion(captureEventId, conn);
            foreach (DataRow row in availableReplacementsAsDataset.Tables[0].Rows) {
                ReplacementEvent repEvent = new ReplacementEvent(Convert.ToInt32(row["id"]),
                                                                 Convert.ToInt32(row["userId"]),
                                                                 row["name"].ToString(),
                                                                 row["description"].ToString(),
                                                                 row["value"].ToString(),
                                                                 Convert.ToInt32(row["typeId"]),
                                                                 Convert.ToInt32(row["capturePointId"]),
                                                                 Convert.ToInt32(row["usageCount"]));
                replacementEvents.Add(repEvent);
            }
            return replacementEvents;
        }

        public static List<ReplacementEvent> GetAvailableReplacementsByCaptureId(int captureEventId) {
            //commandGetCapturePointReplacements
            List<ReplacementEvent> replacementEvents = new List<ReplacementEvent>();
            DataSet availableReplacementsAsDataset = GetAvailableReplacementsAsDataset(captureEventId);
            foreach (DataRow row in availableReplacementsAsDataset.Tables[0].Rows) {
                ReplacementEvent repEvent = new ReplacementEvent(Convert.ToInt32(row["id"]),
                                                                 Convert.ToInt32(row["userId"]),
                                                                 row["name"].ToString(),
                                                                 row["description"].ToString(),
                                                                 row["value"].ToString(),
                                                                 Convert.ToInt32(row["typeId"]),
                                                                 Convert.ToInt32(row["capturePointId"]),
                                                                 Convert.ToInt32(row["usageCount"]));
                replacementEvents.Add(repEvent);
            }
            return replacementEvents;
        }


        //ForTextConversion

        private static DataSet GetAvailableReplacementsAsDatasetForTextConversion(int captureEventId, SqlCeConnection conn) {
            SqlCeCommand getAllReplacementsByCaptureIDCommand = new SqlCeCommand(SqlCommands.commandGetCapturePointReplacementsTextConv, conn);
            getAllReplacementsByCaptureIDCommand.Parameters.Add("@capturePointId", captureEventId);
            DataSet dataSet = new DataSet();
            SqlCeDataAdapter da = new SqlCeDataAdapter(getAllReplacementsByCaptureIDCommand);
            SqlCeCommandBuilder cb = new SqlCeCommandBuilder(da);
            da.Fill(dataSet);
            return dataSet;
        }



        private static DataSet GetAvailableReplacementsAsDataset(int captureEventId) {
            SqlCeConnection conn = GetSqlConnection();
            SqlCeCommand getAllReplacementsByCaptureIDCommand = new SqlCeCommand(SqlCommands.commandGetCapturePointReplacements, conn);
            getAllReplacementsByCaptureIDCommand.Parameters.Add("@capturePointId", captureEventId);
            DataSet dataSet = new DataSet();
            try {
                SqlCeDataAdapter da = new SqlCeDataAdapter(getAllReplacementsByCaptureIDCommand);
                SqlCeCommandBuilder cb = new SqlCeCommandBuilder(da);
                da.Fill(dataSet);
            } finally {
                conn.Close();
            }
            return dataSet;
        }

        internal static void SaveReplacementEventForTextConversion(ReplacementEvent replacementEvent, SqlCeConnection conn, SqlCeTransaction transaction) {

            SqlCeCommand command = new SqlCeCommand(SqlCommands.commandUpdateReplacementByIdTextConv, conn);
            command.Transaction = transaction;
            command.Parameters.Add("@name", replacementEvent.name);
            command.Parameters.Add("@description", replacementEvent.description);
            command.Parameters.Add("@value", replacementEvent.Value);
            command.Parameters.Add("@typeId", replacementEvent.typeId);
            command.Parameters.Add("@capturePointId", replacementEvent.capturePointId);
            command.Parameters.Add("@userId", replacementEvent.userId);
            command.Parameters.Add("@usageCount", replacementEvent.usageCount);
            command.Parameters.Add("@id", replacementEvent.id);
            command.ExecuteNonQuery();

        }

        internal static void SaveReplacementEvent(ReplacementEvent replacementEvent) {
            SqlCeConnection conn = GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandUpdateReplacementById, conn);
                command.Parameters.Add("@name", replacementEvent.name);
                command.Parameters.Add("@description", replacementEvent.description);
                command.Parameters.Add("@value", replacementEvent.Value);
                command.Parameters.Add("@typeId", replacementEvent.typeId);
                command.Parameters.Add("@capturePointId", replacementEvent.capturePointId);
                command.Parameters.Add("@userId", replacementEvent.userId);
                command.Parameters.Add("@usageCount", replacementEvent.usageCount);
                command.Parameters.Add("@id", replacementEvent.id);
                command.ExecuteNonQuery();
            } finally {
                conn.Close();
            }
        }

        internal static DataTable GetAllCaptureCategoriesAsDataTable() {
            DataTable dataTable = new DataTable();
            SqlCeConnection conn = GetSqlConnection();
            SqlCeCommand command = new SqlCeCommand(SqlCommands.commandGetAllCaptureCategories, conn);
            using (SqlCeDataAdapter adapter2 = new SqlCeDataAdapter(command)) {
                adapter2.Fill(dataTable);
            }
            return dataTable;
        }


        public static int InsertFormInfoCheckForFirstUse(string formName) {
            FormInfo formInfo = new FormInfo(formName, (int)FormInfo.formStatus.Active, "True");
            SqlCeConnection conn = GetSqlConnection();
            int returnedFormStatus = -1;
            try {
                conn.Open();
                int foundRows = GetFoundRowsForExistingForm(formName, conn);
                if (foundRows > 0) {
                    returnedFormStatus = GetFormStatus(formName, conn);
                } else {
                    InsertNewFormInfo(formInfo);
                }
            } finally {
                conn.Close();
            }
            return returnedFormStatus;
        }

        private static int GetFormStatus(string formName, SqlCeConnection conn) {
            int returnCode = -1;
            try {
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandGetFormStatus, conn);
                command.Parameters.Add("@formName", formName);
                returnCode = Convert.ToInt32(command.ExecuteScalar());
            } catch (Exception ex) {
            }
            return returnCode;
        }

        private static int GetFoundRowsForExistingForm(string formName, SqlCeConnection conn) {
            int returnCode = -1;
            try {
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandGetFormCount, conn);
                command.Parameters.Add("@formName", formName);
                returnCode = Convert.ToInt32(command.ExecuteScalar());
            } catch (Exception ex) {
            }
            return returnCode;
        }

        public static int InsertNewFormInfo(FormInfo formInfo) {
            int numberAffectedRows = 0;
            SqlCeConnection conn = GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandInsertIntoFormInfo, conn);
                command.Parameters.Add("@formName", formInfo.localFormName);
                command.Parameters.Add("@formStatus", XmlParsersAndUi.Classes.FormInfo.formStatus.Active);
                command.Parameters.Add("@formUpdated", "True");
                numberAffectedRows = Convert.ToInt32(command.ExecuteNonQuery());

            } finally {
                conn.Close();
            }
            return numberAffectedRows;
        }

        public static int InserNewFilter(EnvComparisonFilter envComparisonFilter) {
            int returnedId = -1;
            SqlCeConnection conn = GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandInsertNewComparisonFilter, conn);
                command.Parameters.Add("@name", envComparisonFilter.localName);
                command.Parameters.Add("@description", envComparisonFilter.localDescription);
                command.Parameters.Add("@filter", envComparisonFilter.localFilterPattern);
                command.Parameters.Add("@userid", envComparisonFilter.localUserId);
                command.Parameters.Add("@filterType", envComparisonFilter.localFilterType);
                int numberAffectedRows = Convert.ToInt32(command.ExecuteNonQuery());
                returnedId = GetMaxId("Env_Comparison_Filters", conn);
            } finally {
                conn.Close();
            }
            return returnedId;
        }

        internal static DataSet GetAllAvailableFiltersAsDataset() {
            SqlCeConnection conn = GetSqlConnection();
            SqlCeCommand Command = new SqlCeCommand(SqlCommands.commandSelectAllComparisonFilters, conn);
            DataSet dataSet = new DataSet();
            try {
                SqlCeDataAdapter da = new SqlCeDataAdapter(Command);
                SqlCeCommandBuilder cb = new SqlCeCommandBuilder(da);
                da.Fill(dataSet);
            } finally {
                conn.Close();
            }
            return dataSet;
        }

        internal static void UpdatedFilterById(EnvComparisonFilter filter) {
            SqlCeConnection conn = GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandUpdateComparisonFilterById, conn);
                command.Parameters.Add("@name", filter.localName);
                command.Parameters.Add("@description", filter.localDescription);
                command.Parameters.Add("@filter", filter.localFilterPattern);
                command.Parameters.Add("@userid", filter.localUserId);
                command.Parameters.Add("@filterType", filter.localFilterType);
                command.Parameters.Add("@id", filter.filterId);
                command.ExecuteNonQuery();
            } finally {
                conn.Close();
            }
        }

        internal static DataSet GetAllAvailableEnvCompCategsAsDataset() {
            SqlCeConnection conn = GetSqlConnection();
            SqlCeCommand Command = new SqlCeCommand(SqlCommands.commandSelectAllEnvComparisonCategory, conn);
            DataSet dataSet = new DataSet();
            try {
                SqlCeDataAdapter da = new SqlCeDataAdapter(Command);
                SqlCeCommandBuilder cb = new SqlCeCommandBuilder(da);
                da.Fill(dataSet);
            } finally {
                conn.Close();
            }
            return dataSet;
        }


        internal static void UpdatedCategoryById(ComparisonCategory comparisonCategory) {
            SqlCeConnection conn = GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandUpdateEnvComparisonCategoryById, conn);
                command.Parameters.Add("@name", comparisonCategory.categoryName);
                command.Parameters.Add("@description", comparisonCategory.categoryDescription);
                command.Parameters.Add("@path", comparisonCategory.categoryPath);
                command.Parameters.Add("@parentId", comparisonCategory.categoryParentId);
                command.Parameters.Add("@id", comparisonCategory.categoryId);
                command.ExecuteNonQuery();
            } finally {
                conn.Close();
            }
        }

        public static int DeleteEnvComparisonCategoryById(int categoryId) {
            int returnedId = -1;
            SqlCeConnection conn = GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(SqlCommands.commandDeleteEnvCategoryById, conn);
                command.Parameters.Add("@id", categoryId);
                int numberAffectedRows = Convert.ToInt32(command.ExecuteNonQuery());
            } finally {
                conn.Close();
            }
            return returnedId;
        }

        public static int InserNewCategory(ComparisonCategory comparisonCategory, SqlCeTransaction transaction, SqlCeConnection conn) {
            SqlCeCommand command = new SqlCeCommand(SqlCommands.commandInsertNewEnvComparisonCategory, conn);
            command.Transaction = transaction;
            command.Parameters.Add("@id", comparisonCategory.categoryId);
            command.Parameters.Add("@name", comparisonCategory.categoryName);
            command.Parameters.Add("@description", comparisonCategory.categoryDescription);
            command.Parameters.Add("@path", comparisonCategory.categoryPath);
            if (comparisonCategory.categoryParentId == -1) {
                //DBNull.Value
                command.Parameters.Add("@parentId", DBNull.Value);
            } else {
                command.Parameters.Add("@parentId", comparisonCategory.categoryParentId);
            }
            int numberAffectedRows = Convert.ToInt32(command.ExecuteNonQuery());
            return numberAffectedRows;
        }

        internal static DataSet GetAllTableNamesAsDataSet() {
            //select table_name from information_schema.tables where TABLE_TYPE <> 'VIEW'
            SqlCeConnection conn = GetSqlConnection();
            SqlCeCommand Command = new SqlCeCommand("select table_name from information_schema.tables where TABLE_TYPE <> 'VIEW'", conn);
            DataSet dataSet = new DataSet();
            try {
                SqlCeDataAdapter da = new SqlCeDataAdapter(Command);
                SqlCeCommandBuilder cb = new SqlCeCommandBuilder(da);
                da.Fill(dataSet);
            } finally {
                conn.Close();
            }
            return dataSet;
        }
    }

}