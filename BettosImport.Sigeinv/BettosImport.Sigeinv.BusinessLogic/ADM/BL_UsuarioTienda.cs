using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.ADM;
using BettosImport.Sigeinv.DataAccess.ADM;


namespace BettosImport.Sigeinv.BusinessLogic.ADM
{
    public class BL_UsuarioTienda
    {
        public static BE_UsuarioTienda GetUsuarioTienda(string codUsuario)
        {
            return DA_UsuarioTienda.GetUsuarioTienda(codUsuario);
        }
    }
}

