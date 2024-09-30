using Dapper;
using Derrek_Application.Classes;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.TaskScheduler;

namespace Derrek_Application.Data
{
   public class SqlConnection : IDataManagement
   {
      public Assignment StoreAssignment(Assignment dataObj)
      {
         using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionStr("DerrekApp")))
         {
            var p = new DynamicParameters();
            p.Add("@title", dataObj.Title);
            p.Add("@description", dataObj.Description);
            p.Add("@done", dataObj.Done);
            // TODO: Implement a seperate table to store days
            p.Add("@deadline", dataObj.Schedule);
            p.Add("@assignmentId", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("dbo.spAssignment_Store", p, commandType: CommandType.StoredProcedure);

            dataObj.AssignmentID = p.Get<int>("@assignmentId");

            return dataObj;
         }
         throw new NotImplementedException();
      }
      public List<Assignment> GetAllAssignment()
      {
         List<Assignment> output;
         using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionStr("DerrekApp")))
         {
            output = connection.Query<Assignment>("dbo.spAssignment_GetAll").ToList();
            return output;
         }
      throw new NotImplementedException();
      }
   }
}
