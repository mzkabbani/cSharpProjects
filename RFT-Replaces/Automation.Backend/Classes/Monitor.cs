using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;

using Automation.Backend.Sql_Commands;
using Automation.Common.Classes.Monitoring;
using Automation.Common.Utils;

namespace Automation.Backend.Classes {
    public static class Monitor {

        public static void InsertNewMonitorObject() {
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            int value = 0;
            try {
                conn.Open();
                int sessionID = User_Sessions.InsertNewUserSession(conn);
                for (int i = 0; i < MonitorObject.formAndAccessTime.Count; i++) {
                    SqlCeCommand command = new SqlCeCommand(Monitor_SQL.commandInsertNewMonitor, conn);
                    command.Parameters.Add("@formName", MonitorObject.formAndAccessTime[i].formName);
                    command.Parameters.Add("@accessTime", MonitorObject.formAndAccessTime[i].AccessTime);
                    command.Parameters.Add("@userName", MonitorObject.username);
                    command.Parameters.Add("@sessionID", sessionID);
                    value = Convert.ToInt32(command.ExecuteNonQuery());
                }
            }catch ( Exception ex){
            	CommonUtils.LogError(ex.Message,ex);
            } finally {
                conn.Close();
            }

        }

    }
}
