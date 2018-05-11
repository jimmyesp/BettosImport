using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.INV;
using BettosImport.Sigeinv.DataAccess.INV;

namespace BettosImport.Sigeinv.BusinessLogic.INV
{
    public class BL_Movimiento
    {
        public static List<BE_Movimiento> ListarSalidaProductos(string dscModelo)
        {
            return DA_Movimiento.ListarSalidaProductos(dscModelo);
        }

        public static List<BE_Movimiento> ListarEntradaProductos(string dscModelo)
        {
            return DA_Movimiento.ListarEntradaProductos(dscModelo);
        }
    }
}
