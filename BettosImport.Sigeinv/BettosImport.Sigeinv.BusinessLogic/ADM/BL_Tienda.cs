using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.ADM;
using BettosImport.Sigeinv.DataAccess.ADM;

namespace BettosImport.Sigeinv.BusinessLogic.ADM
{
    public class BL_Tienda
    {
        public static List<BE_Tienda> ListarTiendas()
        {
            return DA_Tienda.ListarTiendas();
        }
    }
}
