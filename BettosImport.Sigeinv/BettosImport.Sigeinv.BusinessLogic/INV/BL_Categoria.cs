using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.INV;
using BettosImport.Sigeinv.DataAccess.INV;

namespace BettosImport.Sigeinv.BusinessLogic.INV
{
    public class BL_Categoria
    {
        public static List<BE_CategoriaProducto> ListarCategorias()
        {
            return DA_Categoria.ListarCategorias();
        }
    }
}
