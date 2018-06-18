using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.INV;
using MySql.Data.MySqlClient;

namespace BettosImport.Sigeinv.DataAccess.INV
{
    public class DA_Marca : DA_BaseClass
    {
        public static List<BE_Marca> ListarMarcasEnProducto()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_MarcaEnProducto_Listar", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_Marca> lstMarca = new List<BE_Marca>();
                            BE_Marca objMarca;
                            while (lector.Read())
                            {

                                objMarca = new BE_Marca();
                                objMarca.codMarca = Convert.ToString(lector["codMarca"]);
                                objMarca.dscMarca = Convert.ToString(lector["dscMarca"]);

                                lstMarca.Add(objMarca);
                            }

                            return lstMarca;

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static List<BE_Marca> ListarMarcasBusqueda(string dscMarca)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Marca_Listar", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("_dscMarca", MySqlDbType.VarChar).Value = dscMarca;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_Marca> lstMarca = new List<BE_Marca>();
                            BE_Marca objMarca;
                            while (lector.Read())
                            {

                                objMarca = new BE_Marca();
                                objMarca.codMarca = Convert.ToString(lector["codMarca"]);
                                objMarca.dscMarca = Convert.ToString(lector["dscMarca"]);
                                objMarca.fecCreacion = Convert.ToDateTime(lector["fecCreacion"]);
                                objMarca.fecModificacion = Convert.ToDateTime(lector["fecModificacion"]);
                                objMarca.dscEstado = Convert.ToString(lector["dscEstado"]);

                                lstMarca.Add(objMarca);
                            }

                            return lstMarca;

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static string GenerarIdMarca()
        {
            string codMarca = string.Empty;

            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Marca_GenerarId", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("_codMarca", MySqlDbType.VarChar, 10).Direction = System.Data.ParameterDirection.Output;
                        cmd.ExecuteNonQuery();

                        codMarca = cmd.Parameters["_codMarca"].Value.ToString();
                    }

                }

            }

            catch (Exception ex)
            {

                throw ex;
            }

            return codMarca;

        }

        public static bool InsertarMarca(BE_Marca objMarca)
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
                            using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Marca_Insertar", cn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Transaction = trx;
                                cmd.Parameters.Add("_codMarca", MySqlDbType.VarChar, 10).Value = objMarca.codMarca;
                                cmd.Parameters.Add("_dscMarca", MySqlDbType.VarChar, 100).Value = objMarca.dscMarca;
                                cmd.Parameters.Add("_dscUsuCreacion", MySqlDbType.VarChar, 10).Value = objMarca.dscUsuCreacion;
                                cmd.Parameters.Add("_dscEstado", MySqlDbType.VarChar, 1).Value = objMarca.dscEstado;

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

        public static BE_Marca GetMarca(string codMarca)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlTransaction trx = cn.BeginTransaction())
                    {
                        using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Marca_Mostrar", cn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add("_codMarca", MySqlDbType.VarChar).Value = codMarca;

                            using (MySqlDataReader lector = cmd.ExecuteReader())
                            {
                                BE_Marca objMarca = null;
                                while (lector.Read())
                                {

                                    objMarca = new BE_Marca();

                                    objMarca.codMarca = Convert.ToString(lector["codMarca"]);
                                    objMarca.dscMarca = Convert.ToString(lector["dscMarca"]);
                                    objMarca.dscEstado = Convert.ToString(lector["dscEstado"]);
                                }

                                return objMarca;

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

        public static bool ModificarMarca(BE_Marca objMarca)
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
                            using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Marca_Modificar", cn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Transaction = trx;
                                cmd.Parameters.Add("_codMarca", MySqlDbType.VarChar, 10).Value = objMarca.codMarca;
                                cmd.Parameters.Add("_dscMarca", MySqlDbType.VarChar, 100).Value = objMarca.dscMarca;
                                cmd.Parameters.Add("_dscUsuModificacion", MySqlDbType.VarChar, 10).Value = objMarca.dscUsuModificacion;
                                cmd.Parameters.Add("_dscEstado", MySqlDbType.VarChar, 1).Value = objMarca.dscEstado;

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



        public static bool EliminarMarca(string codMarca)
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
                            using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Marca_Eliminar", cn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Transaction = trx;
                                cmd.Parameters.Add("_codMarca", MySqlDbType.VarChar, 10).Value = codMarca;
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
