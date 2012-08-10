using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlParsersAndUi.Classes {
    public static class SqlCommands {

        #region Rec_CapturePoints

        public static string commandRemoveAllCapturePointsByRecId = "Delete From Rec_CapturePoints where pointRecId = @pointRecId";

        public static string commandInsertCapturePoint = "INSERT INTO " +
                                                 "Rec_CapturePoints (pointText, pointUsedAttributes, pointParentNode,pointUsedAttribValues,pointRecId,Level,ItemIndex ) " +
                                                 "VALUES (@pointText, @pointUsedAttributes, @pointParentNode, @pointUsedAttribValues, @pointRecId,@Level,@ItemIndex)";

        public static string commandMaxRecommendationId = "SELECT MAX(id) " +
                                                          "FROM Advanced_Recommendations";

        public static string commandMaxCapturePointId = "SELECT MAX(id) " +
                                                        "FROM Rec_CapturePoints";

        public static string commandGetAllRespectiveCapturePoints = "SELECT Rec_CapturePoints.pointText, Rec_CapturePoints.pointUsedAttributes, Rec_CapturePoints.pointParentNode, Rec_CapturePoints.pointUsedAttribValues, Rec_CapturePoints.Level ,Rec_CapturePoints.ItemIndex \n" +
                                                                   "FROM Advanced_Recommendations INNER JOIN  Rec_CapturePoints ON Advanced_Recommendations.id = Rec_CapturePoints.pointRecId \n" +
                                                                   "WHERE (Rec_CapturePoints.pointRecId = @pointRecId)";




        #endregion



        #region Rec_CapturePoints_TextConv

        public static string commandRemoveAllCapturePointsByRecIdTextConv = "Delete From Rec_CapturePoints_TextConv where pointRecId = @pointRecId";

        public static string commandInsertCapturePointTextConv = "INSERT INTO " +
                                                 "Rec_CapturePoints_TextConv (pointText, pointUsedAttributes, pointParentNode,pointUsedAttribValues,pointRecId,Level,ItemIndex,parentLevel,parentIndex ) " +
                                                 "VALUES (@pointText, @pointUsedAttributes, @pointParentNode, @pointUsedAttribValues, @pointRecId,@Level,@ItemIndex,@parentLevel,@parentIndex)";

        public static string commandMaxRecommendationIdTextConv = "SELECT MAX(id) " +
                                                          "FROM Advanced_Recomendations_TextConv";

        public static string commandMaxCapturePointIdTextConv = "SELECT MAX(id) " +
                                                        "FROM Rec_CapturePoints_TextConv";

        public static string commandGetAllRespectiveCapturePointsTextConv = "SELECT Rec_CapturePoints_TextConv.pointText, Rec_CapturePoints_TextConv.pointUsedAttributes, Rec_CapturePoints_TextConv.pointParentNode, "+
                                                                    " Rec_CapturePoints_TextConv.pointUsedAttribValues, Rec_CapturePoints_TextConv.Level ,Rec_CapturePoints_TextConv.ItemIndex ,Rec_CapturePoints_TextConv.parentLevel ,Rec_CapturePoints_TextConv.parentIndex \n" +
                                                                   "FROM Advanced_Recomendations_TextConv INNER JOIN  Rec_CapturePoints_TextConv ON Advanced_Recomendations_TextConv.id = Rec_CapturePoints_TextConv.pointRecId \n" +
                                                                   "WHERE (Rec_CapturePoints_TextConv.pointRecId = @pointRecId)";




        #endregion

        #region Advanced_Recommendations

        public static string commandUpdateRecommendationUsageCountById = "UPDATE    Advanced_Recommendations " +
                                                                "SET       usageCount =@usageCount  " +
                                                                "Where id = @id";


        public static string commandUpdateRecommendationById = "UPDATE    Advanced_Recommendations " +
                                                               "SET       name =@name, description =@description , event_text = @event_text , categoryId =@categoryId , userId =@userId , usageCount =@usageCount  " +
                                                               "Where id = @id";

        public static string commandCountRecommendations = "SELECT COUNT(*) AS Expr1" +
                                                            "FROM   (SELECT DISTINCT Advanced_Recommendations.id" +
                                                            "FROM  Advanced_Recommendations " +
                                                            "INNER JOIN " +
                                                            "Rec_CapturePoints ON Advanced_Recommendations.id = Rec_CapturePoints.pointRecId) AS derivedtbl_1";

        public static string commandGetAllrecommendations = "SELECT * " +
                                                            "FROM Advanced_Recommendations";


        public static string commandInsertRecommendation = "INSERT INTO " +
                                                            "Advanced_Recommendations    (name, description, event_text, categoryId, usageCount, userId) " +
                                                            "VALUES (@name,@description,@eventText, @categoryId, @usageCount, @userId)";

        public static string commandSelectAdvancedRecById = "Select * " +
                                                            "From Advanced_Recommendations " +
                                                            "Where id=@id";

        public static string commandSelectSumOfAllAdvancedRecUsage = "SELECT     SUM(usageCount) AS Total " +
                                                                     "FROM         Advanced_Recommendations";
        #endregion


        #region Advanced_Recomendations_TextConv

        public static string commandUpdateRecommendationUsageCountByIdTextConv = "UPDATE    Advanced_Recomendations_TextConv " +
                                                                "SET       usageCount =@usageCount  " +
                                                                "Where id = @id";


        public static string commandUpdateRecommendationByIdTextConv = "UPDATE    Advanced_Recomendations_TextConv " +
                                                               "SET       name =@name, description =@description , event_text = @event_text , categoryId =@categoryId , userId =@userId , usageCount =@usageCount  " +
                                                               "Where id = @id";

        public static string commandCountRecommendationsTextConv = "SELECT COUNT(*) AS Expr1" +
                                                            "FROM   (SELECT DISTINCT Advanced_Recomendations_TextConv.id" +
                                                            "FROM  Advanced_Recomendations_TextConv " +
                                                            "INNER JOIN " +
                                                            "Rec_CapturePoints_TextConv ON Advanced_Recomendations_TextConv.id = Rec_CapturePoints.pointRecId) AS derivedtbl_1";

        public static string commandGetAllrecommendationsTextConv = "SELECT * " +
                                                            "FROM Advanced_Recomendations_TextConv "+
                                                            "Where isEnabled=1";


        public static string commandInsertRecommendationTextConv = "INSERT INTO " +
                                                            "Advanced_Recomendations_TextConv    (name, description, event_text, categoryId, usageCount, userId,isEnabled) " +
                                                            "VALUES (@name,@description,@eventText, @categoryId, @usageCount, @userId,1)";

        public static string commandSelectAdvancedRecByIdTextConv = "Select * " +
                                                            "From Advanced_Recomendations_TextConv " +
                                                            "Where id=@id";

        public static string commandSelectSumOfAllAdvancedRecUsageTextConv = "SELECT     SUM(usageCount) AS Total " +
                                                                             "FROM         Advanced_Recomendations_TextConv "+
                                                                             "Where isEnabled=1";

        public static string commandDisableAdvancedRecTextConv = "UPDATE    Advanced_Recomendations_TextConv " +
                                                                 "SET              isEnabled = @isEnabled " +
                                                                 "WHERE     ( id=@id)";


        #endregion


        #region UserStatus

        public static string commandGetUserIdByUserName = "SELECT id " +
                                                          "FROM UserStatus " +
                                                          "WHERE username=@username";

        public static string commandUpdateUserStatusWithId = "UPDATE    UserStatus " +
                                                             "SET  onlineStatus =@onlineStatus, loginCount =@loginCount, lastLogin =@lastLogin " +
                                                             "WHERE id=@id ";

        public static string commandGetAllUsersTable = "SELECT * " +
                                                       "FROM UserStatus";

        public static string commandInsertNewUser = "INSERT INTO " +
                                                    "UserStatus(username, onlineStatus, loginCount, lastLogin, firstLogin) " +
                                                    "VALUES  (@username, @onlineStatus, @loginCount, @lastLogin, @firstLogin)";

        public static string commandGetLoginCountByUserId = "SELECT loginCount " +
                                                            "FROM UserStatus " +
                                                            "WHERE id=@id";

        #endregion

        #region Simple_Recommendation

        public static string commandInsertNewSimpleRec = "INSERT INTO " +
                                                         "Simple_Recommendation (SR_name, SR_isRegex, SR_description, SR_pattern, SR_replacement, SR_fileName) " +
                                                         "VALUES (@SR_name, @SR_isRegex, @SR_description, @SR_pattern, @SR_replacement, @SR_fileName)";

        public static string commandMaxSimpleRecommendationId = "SELECT MAX(id) " +
                                                                "FROM Simple_Recommendation";

        public static string commandGetAllSimpleRecommendations = "SELECT * " +
                                                                  "FROM Simple_Recommendation";

        public static string commandUpdateSimpleRecByName = "UPDATE    Simple_Recommendation " +
                                                            "SET  SR_name=@SR_name, SR_isRegex= @SR_isRegex , SR_description= @SR_description, SR_pattern= @SR_pattern , SR_replacement = @SR_replacement, SR_fileName = @SR_fileName " +
                                                            "WHERE id=@id ";

        public static string commandGetSimpleRecIdByName = "SELECT id " +
                                                           "FROM Simple_Recommendation " +
                                                           "WHERE SR_name=@SR_name ";

        #endregion

        #region Application_Settings

        public static string commandGetAllAppConfig = "SELECT * " +
                                                      "FROM Application_Settings";

        public static string commandUpdateAppConfigByName = "UPDATE    Application_Settings " +
                                                            "SET       settingValue = @settingValue " +
                                                            "WHERE settingName = @settingName";

        public static string commandSelectFromAppConfigByKey = "SELECT settingValue " +
                                                               "FROM Application_Settings " +
                                                               "WHERE id = @id";

        #endregion

        #region Folder_Names

        public static string commandGetAllFolderNamesTable = "SELECT * " +
                                                             "FROM Folder_Name";

        public static string commandDeleteAllFolderNames = "DELETE " +
                                                           "FROM Folder_Name";

        public static string commandInsertFolderName = "INSERT INTO Folder_Name " +
                                                       "(id, folderName, parentId) " +
                                                       "VALUES (@id, @folderName, @parentId)";

        #endregion

        #region Advanced_Recommendation_Categories

        public static string commandGetAllCaptureCategories = "SELECT     id, categoryName " +
                                                       "FROM       Advanced_Recommendation_Categories";

        #endregion

        #region Replacement_Events_Categories

        public static string commandGetAllReplacementCategories = "SELECT     id, categoryName " +
                                                                  "FROM       Replacement_Events_Categories";

        #endregion

        #region Advanced_Replacements

        public static string commandGetAllAdvancedReplacements = "SELECT     id, name, description, value, typeId, capturePointId, userId, AF1, AF2, AF3, AF4, usageCount " +
                                                                "FROM         Advanced_Replacements ";

        public static string commandGetCapturePointReplacements = "SELECT     id, name, description, value, typeId, capturePointId,userId, AF1, AF2, AF3, AF4, usageCount " +
                                                                 "FROM         Advanced_Replacements " +
                                                                 "WHERE capturePointId = @capturePointId ";

        public static string commandInsertReplacement = "INSERT INTO Advanced_Replacements " +
                                                        "(name, description, value, typeId, capturePointId, userId, AF1, AF2, AF3, AF4,usageCount) " +
                                                        "VALUES     (@name ,@description ,@value ,@typeId ,@capturePointId ,@userId ,NULL ,NULL ,NULL ,NULL,@usageCount )";

        public static string commandUpdateReplacementById = "UPDATE    Advanced_Replacements " +
                                                        "SET              name =@name, description =@description, value =@value, typeId =@typeId, capturePointId =@capturePointId, userId =@userId, AF1 =NULL, AF2 =NULL, AF3 =NULL, AF4 =NULL,usageCount = @usageCount " +
                                                        "WHERE id = @id ";

        public static string commandMaxReplacementId = "SELECT MAX(id) " +
                                                       "FROM Advanced_Replacements";

        public static string commandSelectSumOfAllReplacementUsage = "SELECT     SUM(usageCount) AS Total " +
                                                                    "FROM         Advanced_Replacements";

        #endregion

        #region Advanced_Replacements_TextConv

        public static string commandGetAllAdvancedReplacementsTextConv = "SELECT     id, name, description, value, typeId, capturePointId, userId, AF1, AF2, AF3, AF4, usageCount " +
                                                                "FROM         Advanced_Replacements_TextConv ";

        public static string commandGetCapturePointReplacementsTextConv = "SELECT     id, name, description, value, typeId, capturePointId,userId, AF1, AF2, AF3, AF4, usageCount " +
                                                                 "FROM         Advanced_Replacements_TextConv " +
                                                                 "WHERE capturePointId = @capturePointId ";

        public static string commandInsertReplacementTextConv = "INSERT INTO Advanced_Replacements_TextConv " +
                                                        "(name, description, value, typeId, capturePointId, userId, AF1, AF2, AF3, AF4,usageCount) " +
                                                        "VALUES     (@name ,@description ,@value ,@typeId ,@capturePointId ,@userId ,NULL ,NULL ,NULL ,NULL,@usageCount )";

        public static string commandUpdateReplacementByIdTextConv = "UPDATE    Advanced_Replacements_TextConv " +
                                                        "SET              name =@name, description =@description, value =@value, typeId =@typeId, capturePointId =@capturePointId, userId =@userId, AF1 =NULL, AF2 =NULL, AF3 =NULL, AF4 =NULL,usageCount = @usageCount " +
                                                        "WHERE id = @id ";

        public static string commandMaxReplacementIdTextConv = "SELECT MAX(id) " +
                                                       "FROM Advanced_Replacements_TextConv";

        public static string commandSelectSumOfAllReplacementUsageTextConv = "SELECT     SUM(usageCount) AS Total " +
                                                                    "FROM         Advanced_Replacements_TextConv";

        #endregion

        #region Form_Updated

        public static string commandSelectAllFormInfo = "SELECT     formName, id, formStatus, formUpdated " +
                                                        "FROM         Form_Updated";

        public static string commandGetFormCount = "SELECT     COUNT(*) AS Expr1 " +
                                                   "FROM         Form_Updated " +
                                                   "WHERE     (formName LIKE '%@formName%') ";

        public static string commandGetFormStatus = "SELECT     formStatus " +
                                                   "FROM         Form_Updated " +
                                                   "WHERE     (formName LIKE '%@formName%') ";

        public static string commandInsertIntoFormInfo = "INSERT INTO Form_Updated " +
                                                         "(formName, formStatus, formUpdated) " +
                                                         "VALUES     (@formName, @formStatus, @formUpdated) ";

        #endregion

        #region Env_Comparison_Filters

        public static string commandSelectComparisonFilterById = "SELECT     name, description, filter, userid, filterType " +
                                                                  "FROM         Env_Comparison_Filters " +
                                                                  "Where id = @id";

        public static string commandSelectAllComparisonFilters = "SELECT     id, name, description, filter, userid, filterType " +
                                                                  "FROM         Env_Comparison_Filters";

        public static string commandInsertNewComparisonFilter = "INSERT INTO Env_Comparison_Filters " +
                                                                 "(name, description, filter, userid, filterType) " +
                                                                 "VALUES     (@name, @description, @filter, @userid, @filterType)";

        public static string commandUpdateComparisonFilterById = "UPDATE    Env_Comparison_Filters " +
                                                             "SET name =@name, description =@description, filter =@filter, userid =@userid, filterType =@filterType " +
                                                             "Where id =@id";

        public static string commandSelectMaxComparisonFilter = "SELECT MAX(id) " +
                                                          "FROM Env_Comparison_Filters";

        #endregion

        #region Env_Comparison_Categories

        public static string commandSelectAllEnvComparisonCategory = "SELECT      " +
                                                                     "id,name, description, path, parentid " +
                                                                     "FROM " +
                                                                     "Env_Comparison_Categories ";

        public static string commandSelectEnvComparisonCategoryById = "SELECT      " +
                                                                      "name,description, path, parentid " +
                                                                      "FROM " +
                                                                      "Env_Comparison_Categories "+
                                                                      "Where "+
                                                                      "id = @id";

        public static string commandInsertNewEnvComparisonCategory = "INSERT INTO  " +
                                                                     "Env_Comparison_Categories " +
                                                                     "(id,name,description, path, parentid) " +
                                                                     "VALUES " +
                                                                     "(@id, @name, @description, @path, @parentid) ";

        public static string commandUpdateEnvComparisonCategoryById = "UPDATE     " +
                                                                      "Env_Comparison_Categories " +
                                                                      "SET               " +
                                                                      "name =@name, description =@description, path =@path, parentid = @parentid " +
                                                                      "Where  " +
                                                                      "id = @id ";

        public static string commandDeleteAllEnvCategories = "Delete From Env_Comparison_Categories";
        public static string commandDeleteEnvCategoryById = "Delete From Env_Comparison_Categories Where id=@id";

        #endregion

    }
}
