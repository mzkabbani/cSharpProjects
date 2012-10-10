using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Automation.Common;
using Automation.Common.Utils;

namespace Automation.Backend{

   public class Env_Comparison_Categories {

       public static int InserNewCategory(ComparisonCategory comparisonCategory, SqlTransaction transaction, SqlConnection conn) {
           SqlCommand command = new SqlCommand(Env_Comparison_Categories_SQL.commandInsertNewEnvComparisonCategory, conn);
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

       public static int DeleteEnvComparisonCategoryById(int categoryId) {
           int returnedId = -1;
           SqlConnection conn = BackEndUtils.GetSqlConnection();
           try {
               conn.Open();
               SqlCommand command = new SqlCommand(Env_Comparison_Categories_SQL.commandDeleteEnvCategoryById, conn);
               command.Parameters.Add("@id", categoryId);
               int numberAffectedRows = Convert.ToInt32(command.ExecuteNonQuery());
           } finally {
               conn.Close();
           }
           return returnedId;
       }

       public static void UpdatedCategoryById(ComparisonCategory comparisonCategory) {
           SqlConnection conn = BackEndUtils.GetSqlConnection();
           try {
               conn.Open();
               SqlCommand command = new SqlCommand(Env_Comparison_Categories_SQL.commandUpdateEnvComparisonCategoryById, conn);
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

       public static DataSet GetAllAvailableEnvCompCategsAsDataset() {
           SqlConnection conn = BackEndUtils.GetSqlConnection();
           SqlCommand Command = new SqlCommand(Env_Comparison_Categories_SQL.commandSelectAllEnvComparisonCategory, conn);
           DataSet dataSet = new DataSet();
           try {
               SqlDataAdapter da = new SqlDataAdapter(Command);
               SqlCommandBuilder cb = new SqlCommandBuilder(da);
               da.Fill(dataSet);
           } finally {
               conn.Close();
           }
           return dataSet;
       }

       public static void UpdateEnvComparisonCategoriesTransaction(List<ComparisonCategoryTreeNode> treeNodes) {
           SqlTransaction transaction;
           SqlConnection conn = BackEndUtils.GetSqlConnection();
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

       private static void InsertUpdatedCategories(List<ComparisonCategoryTreeNode> treeNodes, SqlTransaction transaction, SqlConnection conn) {
           for (int i = 0; i < treeNodes.Count; i++) {
               int parentId = treeNodes[i].Parent == null ? -1 : treeNodes.IndexOf(treeNodes[i].Parent as ComparisonCategoryTreeNode);
               if (parentId != -1) {
                   ComparisonCategory comparisonCategory = treeNodes[i].comparisonCategory;
                   comparisonCategory.categoryParentId = parentId;
                   comparisonCategory.categoryId = i;
                   InserNewCategory(comparisonCategory, transaction, conn);
                   //  BackEndUtils.InsertFolderName(i, treeNodes[i].Text, parentId, transaction, conn);
               } else {
                   ComparisonCategory comparisonCategory = treeNodes[i].comparisonCategory;
                   comparisonCategory.categoryParentId = parentId;
                   comparisonCategory.categoryId = i;
                   InserNewCategory(comparisonCategory, transaction, conn);
               }
           }
       }

       private static void DeleteEnvResultsCategories(SqlTransaction transaction, SqlConnection conn) {
           SqlCommand command = new SqlCommand(Env_Comparison_Categories_SQL.commandDeleteAllEnvCategories, conn);
           command.Transaction = transaction;
           command.Connection = conn;
           command.ExecuteNonQuery();
       }     

    }
}
