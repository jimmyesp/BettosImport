using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.INV;
using BettosImport.Sigeinv.DataAccess.INV;

namespace BettosImport.Sigeinv.BusinessLogic.INV
{
    public class BL_TipoDocumento
    {
        public static List<BE_TipoDocumento> ListarTiposDocumentos()
        {
            return DA_TipoDocumento.ListarTiposDocumentos();
        }
    }
}
