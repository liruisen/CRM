using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL
{
   public  enum LoginState
    {
        Success=1,
        PwdWrong=0,
        EmpNotExist=-1
    }
}
