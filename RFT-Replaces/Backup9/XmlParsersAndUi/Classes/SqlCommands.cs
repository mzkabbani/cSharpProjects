using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlParsersAndUi.Classes {
    public static class SqlCommands {
        
        #region Rec_CapturePoints

        public static string commandInsertCapturePoint = "INSERT INTO " +
                                                 "Rec_CapturePoints (pointText, pointUsedAttributes, pointParentNode,pointUsedAttribValues,pointRecId,Level,ItemIndex ) " +
                                                 "VALUES (@pointText, @pointUsedAttributes, @pointParentNode, @pointUsedAttribValues, @pointRecId,@Level,@ItemIndex)";

        public static string commandMaxRecommendationId = "SELECT MAX(id) " +
                                                          "FROM Advanced_Recommendations";

        public static string commandMaxCapturePointId = "SELECT MAX(id) "+
                                                        "FROM Rec_CapturePoints"; 

        #endregion

        #region Advanced_Recommendations

        public static string commandCountRecommendations = "SELECT COUNT(*) AS Expr1" +
                                                    "FROM   (SELECT DISTINCT Advanced_Recommendations.id" +
                                                    "FROM  Advanced_Recommendations " +
                                                    "INNER JOIN " +
                                                    "Rec_CapturePoints ON Advanced_Recommendations.id = Rec_CapturePoints.pointRecId) AS derivedtbl_1";

        public static string commandGetAllrecommendations = "SELECT * " +
                                                            "FROM Advanced_Recommendations";

        public static string commandGetAllRespectiveCapturePoints = "SELECT Rec_CapturePoints.pointText, Rec_CapturePoints.pointUsedAttributes, Rec_CapturePoints.pointParentNode, Rec_CapturePoints.pointUsedAttribValues, Rec_CapturePoints.Level ,Rec_CapturePoints.ItemIndex \n" +
                                                                     "FROM Advanced_Recommendations INNER JOIN  Rec_CapturePoints ON Advanced_Recommendations.id = Rec_CapturePoints.pointRecId \n" +
                                                                     "WHERE (Rec_CapturePoints.pointRecId = @pointRecId)";

        public static string commandInsertRecommendation = "INSERT INTO " +
                                                            "Advanced_Recommendations (name, description, event_text ) " +
                                                            "VALUES (@name,@description,@eventText)";

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

        #region Application_Preferences

        public static string commandGetAllAppConfig = "SELECT * " +
                                                      "FROM Application_Preferences";

        public static string commandUpdateAppConfigByName = "UPDATE    Application_Preferences " +
                                                            "SET       AP_value = @AP_value " +
                                                            "WHERE AP_name = @AP_name";

        public static string commandSelectFromAppConfigByKey = "SELECT AP_value " +
                                                               "FROM Application_Preferences " +
                                                               "WHERE id = @id";

        #endregion
    }
}
