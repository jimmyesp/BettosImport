using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.ADM;
using BettosImport.Sigeinv.DataAccess.ADM;

namespace BettosImport.Sigeinv.BusinessLogic.ADM
{
    public class BL_Usuario
    {
        public static BE_Usuario GetLogin(string codUsuario, string dscPassword)
        {
            return DA_Usuario.GetLogin(codUsuario, dscPassword);
        }

        public static List<BE_Usuario> ListarUsuarios(string dscUsuario)
        {
            return DA_Usuario.ListarUsuarios(dscUsuario);
        }

        public static bool InsertarUsuario(BE_Usuario objUsuario)
        {
            return DA_Usuario.InsertarUsuario(objUsuario);
        }

        public static BE_Usuario GetUsuario(string codUsuario)
        {
            return DA_Usuario.GetUsuario(codUsuario);
        }

        public static bool ModificarUsuario(BE_Usuario objUsuario)
        {
            return DA_Usuario.ModificarUsuario(objUsuario);
        }

        public static bool EliminarUsuario(string codUsuario)
        {
            return DA_Usuario.EliminarUsuario(codUsuario);
        }
    }
}
