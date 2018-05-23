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
        public static List<BE_Movimiento> ListarSalidaProductos(string codTienda, string dscModelo)
        {
            return DA_Movimiento.ListarSalidaProductos(codTienda, dscModelo);
        }

        public static List<BE_Movimiento> ListarEntradaProductos(string codTienda, string dscModelo)
        {
            return DA_Movimiento.ListarEntradaProductos(codTienda, dscModelo);
        }

        public static string GenerarIdMovimiento(string codTipoOperacion)
        {
            return DA_Movimiento.GenerarIdMovimiento(codTipoOperacion);
        }

        public static bool InsertarSalidaProducto(BE_Movimiento objMovimiento)
        {
            return DA_Movimiento.InsertarSalidaProducto(objMovimiento);
        }

        public static bool InsertarEntradaProducto(BE_Movimiento objMovimiento)
        {
            return DA_Movimiento.InsertarEntradaProducto(objMovimiento);
        }

        public static BE_Movimiento GetSalidaProducto(int id)
        {
            return DA_Movimiento.GetSalidaProducto(id);
        }
    }
}
