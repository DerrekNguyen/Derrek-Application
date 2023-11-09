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
            p.Add("@note", dataObj.Note);
            p.Add("@duration", dataObj.Duration);
            p.Add("@doneCriteria", dataObj.DoneCriteria);
            p.Add("@done", dataObj.Done);
            p.Add("@deadline", dataObj.Deadline);
            p.Add("@assignmentId", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("dbo.spAssignment_Store", p, commandType: CommandType.StoredProcedure);

            dataObj.AssignmentID = p.Get<int>("@assignmentId");

            return dataObj;
         }
         throw new NotImplementedException();
      }
   }
}
