using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.INV;
using BettosImport.Sigeinv.DataAccess.INV;

namespace BettosImport.Sigeinv.BusinessLogic.INV
{
    public class BL_DetalleProductoTienda
    {
        public static bool ActualizarCantProducSalida(string codProducto, string codTienda, int cantidad)
        {
            return DA_DetalleProductoTienda.ActualizarCantProducSalida(codProducto, codTienda, cantidad);
        }

        public static bool ActualizarCantProducEntrada(string codProducto, string codTienda, int cantidad)
        {
            return DA_DetalleProductoTienda.ActualizarCantProducEntrada(codProducto, codTienda, cantidad);
        }

        public static List<BE_DetalleProductoTienda> ListarDetalleProductos(string dscProducto)
        {
            return DA_DetalleProductoTienda.ListarDetalleProductos(dscProducto);
        }

        public static List<BE_DetalleProductoTienda> ListarProductosTienda(string dscProducto, string codTienda)
        {
            return DA_DetalleProductoTienda.ListarProductosTienda(dscProducto, codTienda);
        }

        public static bool InsertarProductoTienda(BE_DetalleProductoTienda objDetalleProducto)
        {
            return DA_DetalleProductoTienda.InsertarProductoTienda(objDetalleProducto);
        }
    }
}
