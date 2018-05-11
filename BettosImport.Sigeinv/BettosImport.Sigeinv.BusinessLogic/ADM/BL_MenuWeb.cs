using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.ADM;
using BettosImport.Sigeinv.DataAccess.ADM;


namespace BettosImport.Sigeinv.BusinessLogic.ADM
{
    public class BL_MenuWeb
    {
        public static List<BE_MenuWeb> ListarOpcionesRol(string codRol) {
            return DA_MenuWeb.ListarOpcionesRol(codRol); 
        }
    }
}
