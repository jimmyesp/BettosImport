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
    public class DA_Usuario: DA_BaseClass
    {

        public static BE_Usuario GetLogin(string codUsuario, string dscPassword)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("Sp_Adm_GetLogin", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("codUsuario", MySqlDbType.VarChar).Value = codUsuario;
                        cmd.Parameters.Add("dscPassword", MySqlDbType.VarChar).Value = dscPassword;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_Usuario> lstUsuario = new List<BE_Usuario>();
                            BE_Usuario objUsuario;

                            while (lector.Read())
                            {
                                objUsuario = new BE_Usuario();
                                objUsuario.codUsuario = Convert.ToString(lector["codUsuario"]);
                                objUsuario.dscUsuario = Convert.ToString(lector["dscUsuario"]);
                                objUsuario.codRol = Convert.ToString(lector["codRol"]);
                                objUsuario.dscRol = Convert.ToString(lector["dscRol"]);
                                objUsuario.dscUsuCreacion = Convert.ToString(lector["codUsuario"]);
                                objUsuario.fecCreacion = Convert.ToDateTime(lector["fecCreacion"]);
                                objUsuario.dscUsuModificacion = Convert.ToString(lector["dscUsuModificacion"]);
                                objUsuario.fecModificacion = Convert.ToDateTime(lector["fecModificacion"]);
                                objUsuario.dscEstado = Convert.ToString(lector["dscEstado"]);

                                lstUsuario.Add(objUsuario);
                            }
                            
                            return lstUsuario.FirstOrDefault();

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }  
        }



        public static List<BE_Usuario> ListarUsuarios(string dscUsuario)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Adm_Usuario_Listar", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("_dscUsuario", MySqlDbType.VarChar).Value = dscUsuario;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_Usuario> lstUsuario = new List<BE_Usuario>();
                            BE_Usuario objUsuario;
                            while (lector.Read())
                            {

                                objUsuario = new BE_Usuario();

                                objUsuario.codUsuario = Convert.ToString(lector["codUsuario"]);
                                objUsuario.dscUsuario = Convert.ToString(lector["dscUsuario"]);
                                objUsuario.dscRol = Convert.ToString(lector["dscRol"]);
                                objUsuario.fecModificacion = Convert.ToDateTime(lector["fecModificacion"]);
                                objUsuario.dscEstado = Convert.ToString(lector["dscEstado"]);

                                lstUsuario.Add(objUsuario);
                            }

                            return lstUsuario;

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static bool InsertarUsuario(BE_Usuario objUsuario)
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
                            using (MySqlCommand cmd = new MySqlCommand("SP_Adm_Usuario_Insertar", cn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Transaction = trx;

                                cmd.Parameters.Add("_codUsuario", MySqlDbType.VarChar, 20).Value = objUsuario.codUsuario;
                                cmd.Parameters.Add("_codRol", MySqlDbType.VarChar, 10).Value = objUsuario.codRol;
                                cmd.Parameters.Add("_dscUsuario", MySqlDbType.VarChar, 10).Value = objUsuario.dscUsuario;
                                cmd.Parameters.Add("_dscPassword", MySqlDbType.VarChar, 100).Value = objUsuario.dscPassword;
                                cmd.Parameters.Add("_dscUsuCreacion", MySqlDbType.VarChar, 10).Value = objUsuario.dscUsuCreacion;
                                cmd.Parameters.Add("_dscEstado", MySqlDbType.VarChar, 1).Value = objUsuario.dscEstado;

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


        public static BE_Usuario GetUsuario(string codUsuario)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlTransaction trx = cn.BeginTransaction())
                    {
                        using (MySqlCommand cmd = new MySqlCommand("SP_Adm_Usuario_Mostrar", cn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add("_codUsuario", MySqlDbType.VarChar).Value = codUsuario;

                            using (MySqlDataReader lector = cmd.ExecuteReader())
                            {
                                BE_Usuario objUsuario = null;
                                while (lector.Read())
                                {

                                    objUsuario = new BE_Usuario();

                                    objUsuario.codUsuario = Convert.ToString(lector["codUsuario"]);
                                    objUsuario.codRol = Convert.ToString(lector["codRol"]);
                                    objUsuario.dscUsuario = Convert.ToString(lector["dscUsuario"]);
                                    objUsuario.dscPassword = Convert.ToString(lector["dscPassword"]);
                                    objUsuario.dscEstado = Convert.ToString(lector["dscEstado"]);
                                }

                                return objUsuario;

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


        public static bool ModificarUsuario(BE_Usuario objUsuario)
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
                            using (MySqlCommand cmd = new MySqlCommand("SP_Adm_Usuario_Modificar", cn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Transaction = trx;
                                cmd.Parameters.Add("_codUsuario", MySqlDbType.VarChar, 10).Value = objUsuario.codUsuario;
                                cmd.Parameters.Add("_codRol", MySqlDbType.VarChar, 3).Value = objUsuario.codRol;
                                cmd.Parameters.Add("_dscUsuario", MySqlDbType.VarChar, 100).Value = objUsuario.dscUsuario;
                                cmd.Parameters.Add("_dscPassword", MySqlDbType.VarChar, 50).Value = objUsuario.dscPassword;
                                cmd.Parameters.Add("_dscUsuModificacion", MySqlDbType.VarChar, 10).Value = objUsuario.dscUsuModificacion;
                                cmd.Parameters.Add("_dscEstado", MySqlDbType.VarChar, 1).Value = objUsuario.dscEstado;

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


        public static bool EliminarUsuario(string codUsuario)
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
                            using (MySqlCommand cmd = new MySqlCommand("SP_Adm_Usuario_Eliminar", cn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Transaction = trx;
                                cmd.Parameters.Add("_codUsuario", MySqlDbType.VarChar, 20).Value = codUsuario;
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
