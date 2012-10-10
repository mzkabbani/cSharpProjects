using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Automation.Common.Utils;
using System.Windows.Forms;

namespace Automation.Backend{
    public class Folder_Names {


        public static DataSet GetAllFolderNamesAsDataset() {
            SqlConnection conn = BackEndUtils.GetSqlConnection();
            DataSet dataSet = new DataSet();
            try {
                SqlDataAdapter da = new SqlDataAdapter(Folder_Names_SQL.commandGetAllFolderNamesTable, conn);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Fill(dataSet);
            } finally {
                conn.Close();
            }
            return dataSet;
        }

        public static void DeleteAllFileNames(SqlTransaction transaction, SqlConnection conn) {
            SqlCommand command = new SqlCommand(Folder_Names_SQL.commandDeleteAllFolderNames, conn);
            command.Transaction = transaction;
            command.Connection = conn;
            command.ExecuteNonQuery();
        }

        public static void InsertFolderName(int index, string folderName, object parentId, string generatedID, SqlTransaction transaction, SqlConnection conn) {
            try {
                SqlCommand command = new SqlCommand(Folder_Names_SQL.commandInsertFolderName, conn);
                command.Parameters.Add("@id", index);
                command.Parameters.Add("@folderName", folderName);
                command.Parameters.Add("@parentId", parentId);
                command.Parameters.Add("@generatedID", generatedID);
                command.Transaction = transaction;
                command.Connection = conn;
                command.ExecuteNonQuery();
            } catch (Exception ex) {
                FrontendUtils.LogError(ex.Message, ex);
            }
        }

        public static void InsertUpdatedFileNames(List<TreeNode> treeNodes, SqlTransaction transaction, SqlConnection conn) {
            try {
                for (int i = 0; i < treeNodes.Count; i++) {
                    int parentId = treeNodes[i].Parent == null ? -1 : treeNodes.IndexOf(treeNodes[i].Parent);
                    if (parentId != -1) {
                        InsertFolderName(i, treeNodes[i].Text, parentId, treeNodes[i].Tag.ToString(), transaction, conn);
                    } else {
                        InsertFolderName(i, treeNodes[i].Text, DBNull.Value, treeNodes[i].Tag.ToString(), transaction, conn);
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.LogError(ex.Message,ex);
            }
        }

        public static void UpdateTreeNodesTransaction(List<TreeNode> treeNodes) {
            SqlTransaction transaction;
            SqlConnection conn = BackEndUtils.GetSqlConnection();
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
        
       

      

    }
}
