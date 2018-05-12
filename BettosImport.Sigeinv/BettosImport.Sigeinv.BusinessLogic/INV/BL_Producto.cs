using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.INV;
using BettosImport.Sigeinv.DataAccess.INV;

namespace BettosImport.Sigeinv.BusinessLogic.INV
{
    public class BL_Producto
    {
        public static List<BE_Producto> ListarProductos(string dscProducto)
        {
            return DA_Producto.ListarProductos(dscProducto);
        }

        public static string GenerarIdProducto() {
            return DA_Producto.GenerarIdProducto();
        }

        public static bool InsertarProducto(BE_Producto objProducto)
        {
            return DA_Producto.InsertarProducto(objProducto);
        }

        public static BE_Producto GetProducto(string codProducto) {
            return DA_Producto.GetProducto(codProducto);

        }

        public static bool ModificarProducto(BE_Producto objProducto)
        {
            return DA_Producto.ModificarProducto(objProducto);
        }

        public static bool EliminarProducto(string codProducto)
        {
            return DA_Producto.EliminarProducto(codProducto);
        }

        public static List<BE_Producto> ListarProductosActivos(string dscModelo, string dscProducto, string dscTodos){
            return DA_Producto.ListarProductosActivos(dscModelo,dscProducto,dscTodos);
        }
    }
}
