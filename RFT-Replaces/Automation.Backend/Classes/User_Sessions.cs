using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Automation.Backend.Sql_Commands;
using Automation.Common.Classes.Monitoring;

namespace Automation.Backend.Classes {
    public static class User_Sessions {

        public static int InsertNewUserSession(SqlConnection conn) {
            int value = 0;
            SqlCommand command = new SqlCommand(User_Sessions_SQL.commandInsertNewUserSession, conn);
            command.Parameters.Add("@userName", MonitorObject.username);
            command.Parameters.Add("@loginTime", MonitorObject.loginTime);
            command.Parameters.Add("@logoutTime", MonitorObject.logoutTime);
            value = Convert.ToInt32(command.ExecuteNonQuery());
            SqlCommand commandMaxId = new SqlCommand(User_Sessions_SQL.commandMaxId, conn);
            value = Convert.ToInt32(commandMaxId.ExecuteScalar());
            return value;
        }

    }
}
