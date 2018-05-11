using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.INV;
using BettosImport.Sigeinv.DataAccess.INV;

namespace BettosImport.Sigeinv.BusinessLogic.INV
{
    public class BL_SubCategoria
    {
        public static List<BE_SubCategoriaProducto> ListarSubCategorias(string codCategoria)
        {
            return DA_SubCategoria.ListarSubCategorias(codCategoria);
        }
    }
}
