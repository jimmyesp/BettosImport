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

        public static List<BE_UsuarioTienda> ListarUsuariosTienda(string codUsuario, string codTienda)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Adm_UsuarioTienda_ListarEnTienda", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("_codUsuario", MySqlDbType.VarChar).Value = codUsuario;
                        cmd.Parameters.Add("_codTienda", MySqlDbType.VarChar).Value = codTienda;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_UsuarioTienda> lstUsuarioTienda = new List<BE_UsuarioTienda>();
                            BE_UsuarioTienda objUsuarioTienda;
                            while (lector.Read())
                            {

                                objUsuarioTienda = new BE_UsuarioTienda();
                                objUsuarioTienda.id = Convert.ToInt64(lector["id"]);
                                objUsuarioTienda.dscTienda = Convert.ToString(lector["dscTienda"]);
                                objUsuarioTienda.codUsuario = Convert.ToString(lector["codUsuario"]);
                                objUsuarioTienda.dscEstado = Convert.ToString(lector["dscEstado"]);

                                lstUsuarioTienda.Add(objUsuarioTienda);
                            }

                            return lstUsuarioTienda;

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public static bool InsertarUsuarioTienda(BE_UsuarioTienda objUsuarioTienda)
        {
            bool resultado = false;
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlTransaction trx = cn.BeginTransaction())
                    {
                        try
                        {
                            using (MySqlCommand cmd = new MySqlCommand("SP_Adm_UsuarioTienda_InsertarEnTienda", cn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Transaction = trx;
                                cmd.Parameters.Add("_codTienda", MySqlDbType.VarChar, 3).Value = objUsuarioTienda.codTienda;
                                cmd.Parameters.Add("_codUsuario", MySqlDbType.VarChar, 10).Value = objUsuarioTienda.codUsuario;
                                cmd.Parameters.Add("_dscUsuCreacion", MySqlDbType.VarChar, 10).Value = objUsuarioTienda.dscUsuCreacion;
                                cmd.Parameters.Add("_dscEstado", MySqlDbType.VarChar, 1).Value = objUsuarioTienda.dscEstado;

                                cmd.ExecuteNonQuery();
                            }

                            trx.Commit();
                            resultado = true;
                        }
                        catch (Exception ex)
                        {
                            trx.Rollback();
                            resultado = false;
                            throw ex;
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                resultado = false;
                throw ex;
            }

            return resultado;
        }
    }
}
