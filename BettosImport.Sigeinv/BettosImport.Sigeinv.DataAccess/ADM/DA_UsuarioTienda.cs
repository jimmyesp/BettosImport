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
    public class DA_UsuarioTienda : DA_BaseClass
    {
        public static BE_UsuarioTienda GetUsuarioTienda(string codUsuario)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlTransaction trx = cn.BeginTransaction())
                    {
                        using (MySqlCommand cmd = new MySqlCommand("Sp_Adm_UsuarioTienda_Listar", cn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add("_codUsuario", MySqlDbType.VarChar).Value = codUsuario;

                            using (MySqlDataReader lector = cmd.ExecuteReader())
                            {
                                BE_UsuarioTienda objUsuarioTienda = null;
                                while (lector.Read())
                                {

                                    objUsuarioTienda = new BE_UsuarioTienda();

                                    objUsuarioTienda.id = Convert.ToInt64(lector["id"]);
                                    objUsuarioTienda.codTienda = Convert.ToString(lector["codTienda"]);
                                    objUsuarioTienda.dscTienda = Convert.ToString(lector["dscTienda"]);
                                    objUsuarioTienda.codUsuario = Convert.ToString(lector["codUsuario"]);

                                }

                                return objUsuarioTienda;

                            }

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
