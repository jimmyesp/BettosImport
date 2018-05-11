using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.ADM;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BettosImport.Sigeinv.DataAccess.ADM
{
    public class DA_MenuWeb:DA_BaseClass
    {
        public static List<BE_MenuWeb> ListarOpcionesRol(string codRol)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Adm_MenuWebAutorizacionRol", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("_codRol", MySqlDbType.VarChar).Value = codRol;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_MenuWeb> lstMenuWeb = new List<BE_MenuWeb>();
                            BE_MenuWeb objMenuWeb;
                            while (lector.Read())
                            {

                                objMenuWeb = new BE_MenuWeb();


                                objMenuWeb.codPadre = Convert.ToString(lector["codPadre"]);
                                objMenuWeb.codOpcion = Convert.ToString(lector["codOpcion"]);
                                objMenuWeb.dscOpcion = Convert.ToString(lector["dscOpcion"]);
                                objMenuWeb.dscUrl = Convert.ToString(lector["dscUrl"]);

                                lstMenuWeb.Add(objMenuWeb);
                            }

                            return lstMenuWeb;

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
