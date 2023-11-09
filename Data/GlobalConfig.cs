using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derrek_Application.Data
{
   public class GlobalConfig
   {
      public static SqlConnection sql = new SqlConnection();
      public static string ConnectionStr(string str)
      {
         return ConfigurationManager.ConnectionStrings[str].ConnectionString;
      }
   }
}
