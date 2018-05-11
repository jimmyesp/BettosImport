using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.INV;
using BettosImport.Sigeinv.DataAccess.INV;

namespace BettosImport.Sigeinv.BusinessLogic.INV
{
    public class BL_TipoOperacion
    {
        public static List<BE_TipoOperacion> ListarTiposOperaciones()
        {
            return DA_TipoOperacion.ListarTiposOperaciones();
        }
    }
}
