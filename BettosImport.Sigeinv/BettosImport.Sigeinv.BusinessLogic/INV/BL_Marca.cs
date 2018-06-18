using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.INV;
using BettosImport.Sigeinv.DataAccess.INV;

namespace BettosImport.Sigeinv.BusinessLogic.INV
{
    public class BL_Marca
    {
        public static List<BE_Marca> ListarMarcasEnProducto()
        {
            return DA_Marca.ListarMarcasEnProducto();
        }

        public static List<BE_Marca> ListarMarcasBusqueda(string dscMarca)
        {
            return DA_Marca.ListarMarcasBusqueda(dscMarca);
        }

        public static string GenerarIdMarca()
        {
            return DA_Marca.GenerarIdMarca();
        }

        public static bool InsertarMarca(BE_Marca objMarca)
        {
            return DA_Marca.InsertarMarca(objMarca);
        }

        public static BE_Marca GetMarca(string codMarca)
        {
            return DA_Marca.GetMarca(codMarca);
        }

        public static bool ModificarMarca(BE_Marca objMarca)
        {
            return DA_Marca.ModificarMarca(objMarca);
        }

        public static bool EliminarMarca(string codMarca)
        {
            return DA_Marca.EliminarMarca(codMarca);
        }
    }
}
