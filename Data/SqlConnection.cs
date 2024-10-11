using Dapper;
using Derrek_Application.MVVM.Model;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.TaskScheduler;
using System.Xml.XPath;

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
            p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

            connection.Execute("dbo.spAssignment_Store", p, commandType: CommandType.StoredProcedure);

            dataObj.AssignmentID = p.Get<int>("@id");

            p = new DynamicParameters();
            p.Add("@assignmentID", dataObj.AssignmentID);
            p.Add("@schedule", dataObj.GetSchedule());

            connection.Execute("dbo.spAssignment_StoreSchedule", p, commandType: CommandType.StoredProcedure);

            return dataObj;
         }
      }
      public List<Assignment> GetAllAssignment()
      {
         using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.ConnectionStr("DerrekApp")))
         {
            List<Assignment> result = new List<Assignment>();
            var output = connection.Query("dbo.spAssignment_GetAll").ToList();
            foreach (var item in output)
            {
               result.Add(new Assignment(item.title, item.description, item.done, item.schedule));
            }
            return result;
         }
      }
   }
}
