using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.INV;
using BettosImport.Sigeinv.DataAccess.INV;

namespace BettosImport.Sigeinv.BusinessLogic.INV
{
    public class BL_Proveedor
    {

        public static List<BE_Proveedor> ListarProveedoresBusqueda(string dscProveedor)
        {
            return DA_Proveedor.ListarProveedoresBusqueda(dscProveedor);
        }

        public static List<BE_Proveedor> ListarProveedores()
        {
            return DA_Proveedor.ListarProveedores();
        }

        public static string GenerarIdProveedor()
        {
            return DA_Proveedor.GenerarIdProveedor();
        }

        public static bool InsertarProveedor(BE_Proveedor objProveedor)
        {
            return DA_Proveedor.InsertarProveedor(objProveedor);
        }

        public static BE_Proveedor GetProveedor(string codProveedor)
        {
            return DA_Proveedor.GetProveedor(codProveedor);
        }

        public static bool ModificarProveedor(BE_Proveedor objProveedor)
        {
            return DA_Proveedor.ModificarProveedor(objProveedor);
        }

        public static bool EliminarProveedor(string codProveedor)
        {
            return DA_Proveedor.EliminarProveedor(codProveedor);
        }
    }

}
