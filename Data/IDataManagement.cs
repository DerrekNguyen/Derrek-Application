using Derrek_Application.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derrek_Application.Data
{
   public interface IDataManagement
   {
      Assignment StoreAssignment(Assignment dataObj);
      List<Assignment> GetAllAssignment();
   }
}
