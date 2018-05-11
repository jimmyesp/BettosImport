using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.ADM;
using MySql.Data.MySqlClient;

namespace BettosImport.Sigeinv.DataAccess.ADM
{
    public class DA_Rol : DA_BaseClass
    {
        public static List<BE_Rol> ListarRol()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Adm_Rol_Listar", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_Rol> lstRol = new List<BE_Rol>();
                            BE_Rol objRol;
                            while (lector.Read())
                            {
                                objRol = new BE_Rol();
                                objRol.codRol = Convert.ToString(lector["codRol"]);
                                objRol.dscRol = Convert.ToString(lector["dscRol"]);

                                lstRol.Add(objRol);
                            }

                            return lstRol;

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
