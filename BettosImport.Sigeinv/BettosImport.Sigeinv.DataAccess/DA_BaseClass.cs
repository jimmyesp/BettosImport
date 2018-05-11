using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BettosImport.Sigeinv.DataAccess
{
    public class DA_BaseClass
    {
        public static string cnMySql()
        {
            return ConfigurationManager.AppSettings["cnMySql"].ToString();
        }
    }
}
