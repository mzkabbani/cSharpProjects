﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Automation.Common;
using Automation.Common.Utils;

namespace Automation.Backend{
    public class Advanced_Recommendations {

        public static DataSet GetAllAdvancedRecsAsDataSet() {
            SqlConnection conn = BackEndUtils.GetSqlConnection();
            DataSet dataSet = new DataSet();
            try {
                SqlDataAdapter da = new SqlDataAdapter(Advanced_Recommendations_SQL.commandGetAllrecommendations, conn);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Fill(dataSet);
            } finally {
                conn.Close();
            }
            return dataSet;
        }


        public static DataTable GetAllAdvancedRecs() {
            SqlConnection conn = BackEndUtils.GetSqlConnection();
            DataTable dataTable = new DataTable();
            try {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Advanced_Recommendations", conn)) {
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

  public static void DisableAdvanceRecById(int advanceRecId) {
            SqlConnection conn = BackEndUtils.GetSqlConnection();
            try {
                conn.Open();
                SqlCommand command = new SqlCommand(Advanced_Recommendations_SQL.commandDisableAdvancedRec, conn);
                command.Parameters.Add("@id", advanceRecId);
                command.Parameters.Add("@isEnabled", "0");
                command.ExecuteNonQuery();
            } finally {
                conn.Close();
            }
        }
		
		
        public static void SaveAdvancedRecomendationById(int captureEventId, AdvancedRecomendation advancedRecomendation) {
            SqlTransaction transaction;
            SqlConnection conn = BackEndUtils.GetSqlConnection();
            try {
                conn.Open();
                transaction = conn.BeginTransaction();
                try {
                    UpdateRecommendationById(captureEventId, advancedRecomendation, conn, transaction);
                    Rec_CapturePoints.DeletAllRespectiveCapturePoints(captureEventId, conn, transaction);
                    Rec_CapturePoints.InsertCapturePointsAsTransaction(captureEventId, advancedRecomendation.CaptureEventCapturePointsList, conn, transaction);
                    transaction.Commit();
                } catch (Exception ex) {
                    FrontendUtils.LogError(ex.Message, ex);
                    transaction.Rollback();
                }
            } finally {
                conn.Close();
            }
        }

        private static void UpdateRecommendationById(int captureEventId, AdvancedRecomendation advancedRecomendation, SqlConnection conn, SqlTransaction transaction) {
            int value = 0;
            SqlCommand command = new SqlCommand(Advanced_Recommendations_SQL.commandUpdateRecommendationById, conn);
            command.Transaction = transaction;
            command.Parameters.Add("@name", advancedRecomendation.CaptureEventName);
            command.Parameters.Add("@description", advancedRecomendation.CaptureEventDescription);
            command.Parameters.Add("@event_text", advancedRecomendation.CaptureEventEventText);
            command.Parameters.Add("@id", captureEventId);
            command.Parameters.Add("@categoryId", advancedRecomendation.captureEventCategory);
            command.Parameters.Add("@usageCount", advancedRecomendation.captureEventUsageCount);
            command.Parameters.Add("@userId", FrontendUtils.LoggedInUserId);
            value = Convert.ToInt32(command.ExecuteNonQuery());
        }

        public static int InsertCaptureEvent(AdvancedRecomendation advancedRecomendation) {
            int returnCode = -1;
            int RecommendationId = InsertRecommendation(advancedRecomendation);
            int CapturePointId = Rec_CapturePoints.InsertCapturePoints(RecommendationId, advancedRecomendation.CaptureEventCapturePointsList);
            return returnCode;
        }

        private static int InsertRecommendation(AdvancedRecomendation advancedRecomendation) {
            SqlConnection conn = BackEndUtils.GetSqlConnection();
            int value = 0;
            try {
                conn.Open();
                SqlCommand command = new SqlCommand(Advanced_Recommendations_SQL.commandInsertRecommendation, conn);
                command.Parameters.Add("@name", advancedRecomendation.CaptureEventName);
                command.Parameters.Add("@description", advancedRecomendation.CaptureEventDescription);
                command.Parameters.Add("@eventText", advancedRecomendation.CaptureEventEventText);
                // @categoryId, @usageCount
                command.Parameters.Add("@categoryId", advancedRecomendation.captureEventCategory);
                command.Parameters.Add("@usageCount", advancedRecomendation.captureEventUsageCount);
                command.Parameters.Add("@userId", FrontendUtils.LoggedInUserId);
                value = Convert.ToInt32(command.ExecuteNonQuery());
                SqlCommand commandMaxId = new SqlCommand(Advanced_Recommendations_SQL.commandMaxRecommendationId, conn);
                value = Convert.ToInt32(commandMaxId.ExecuteScalar());
            }catch (Exception ex){
            	FrontendUtils.LogError(ex.Message,ex);
            }
            finally {
                conn.Close();
            }
            return value;
        }

        private static int GetARCount() {
            int arCount = -1;
            SqlConnection conn = BackEndUtils.GetSqlConnection();
            SqlCommand command = new SqlCommand(Advanced_Recommendations_SQL.commandCountRecommendations, conn);
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
            SqlConnection conn = BackEndUtils.GetSqlConnection();
            SqlCommand command = new SqlCommand(Advanced_Recommendations_SQL.commandSelectSumOfAllAdvancedRecUsage, conn);
            try {
                conn.Open();
                total = Convert.ToInt32(command.ExecuteScalar());
            } finally {
                conn.Close();
            }
            return total;
        }


     

        public static AdvancedRecomendation SelectAdvancedRecByIdAndIncrementUsage(object RecId, int currentUsageCount) {
            SqlConnection conn = BackEndUtils.GetSqlConnection();
            AdvancedRecomendation advancedRecomendation;
            DataTable dataTable = new DataTable();
            try {
                conn.Open();
                DataTable capturePointsTable = Rec_CapturePoints.GetRespectiveCapturePoints(RecId, conn);
                SqlCommand command = new SqlCommand(Advanced_Recommendations_SQL.commandSelectAdvancedRecById);
                command.Parameters.Add("@id", RecId);
                command.Connection = conn;
                using (SqlDataAdapter adapter = new SqlDataAdapter(command)) {
                    adapter.Fill(dataTable);
                }
                advancedRecomendation = GetAdvancedRecommendationItem(dataTable.Rows[0], capturePointsTable, conn);
                SqlCommand incrementUsageCount = new SqlCommand(Advanced_Recommendations_SQL.commandUpdateRecommendationUsageCountById);
                incrementUsageCount.Parameters.Add("@usageCount", currentUsageCount + 1);
                incrementUsageCount.Parameters.Add("@id", (int)RecId);
                incrementUsageCount.Connection = conn;
                object resutlt = incrementUsageCount.ExecuteNonQuery();
            } finally {
                conn.Close();
            }
            return advancedRecomendation;
        }

        public static AdvancedRecomendation SelectAdvancedRecById(object RecId) {
            SqlConnection conn = BackEndUtils.GetSqlConnection();
            AdvancedRecomendation advancedRecomendation;
            DataTable dataTable = new DataTable();
            try {
                conn.Open();
                DataTable capturePointsTable = Rec_CapturePoints.GetRespectiveCapturePoints(RecId, conn);
                SqlCommand command = new SqlCommand(Advanced_Recommendations_SQL.commandSelectAdvancedRecById);
                command.Parameters.Add("@id", RecId);
                command.Connection = conn;
                using (SqlDataAdapter adapter = new SqlDataAdapter(command)) {
                    adapter.Fill(dataTable);
                }
                advancedRecomendation = GetAdvancedRecommendationItem(dataTable.Rows[0], capturePointsTable, conn);
            } finally {
                conn.Close();
            }
            return advancedRecomendation;
        }

        private static AdvancedRecomendation GetAdvancedRecommendationItem(DataRow advancedRecRow, DataTable capturePointsTable, SqlConnection conn) {
            List<CustomTreeNode> customCapturePointList = BackEndUtils.GetCustomCapturePointListFromTable(capturePointsTable);
            AdvancedRecomendation capture = new AdvancedRecomendation(Convert.ToInt32(advancedRecRow["id"]), advancedRecRow["name"].ToString(), advancedRecRow["description"].ToString(), advancedRecRow["event_text"].ToString(), Convert.ToInt32(advancedRecRow["categoryId"]), Convert.ToInt32(advancedRecRow["usageCount"]), customCapturePointList, FrontendUtils.LoggedInUserId);
            capture.Replacement = Advanced_Replacements.GetReplacementEventByCaptureEventId(capture.CaptureEventId, conn);
            return capture;
        }


        public static List<AdvancedRecomendation> GetAllAdvancedRecsAsList() {
            List<AdvancedRecomendation> allCaptureEvens = new List<AdvancedRecomendation>();
            DataTable advancedRexTable = new DataTable();
            SqlConnection conn = BackEndUtils.GetSqlConnection();
            SqlCommand getAllRecsCommand = new SqlCommand(Advanced_Recommendations_SQL.commandGetAllrecommendations, conn);
            DataTable dataTable = new DataTable();
            try {
                conn.Open();
                using (SqlDataAdapter adapter = new SqlDataAdapter(Advanced_Recommendations_SQL.commandGetAllrecommendations, conn)) {
                    adapter.Fill(dataTable);
                }
                for (int i = 0; i < dataTable.Rows.Count; i++) {
                    DataTable capturePointsTable = Rec_CapturePoints.GetRespectiveCapturePoints(dataTable.Rows[i].ItemArray[0], conn);
                    allCaptureEvens.Add(GetAdvancedRecommendationItem(dataTable.Rows[i], capturePointsTable, conn));
                }
            } finally {
                conn.Close();
            }
            return allCaptureEvens;
        }
    }


}
