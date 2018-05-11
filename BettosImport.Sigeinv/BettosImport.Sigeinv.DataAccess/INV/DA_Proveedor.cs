using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.INV;
using MySql.Data.MySqlClient;

namespace BettosImport.Sigeinv.DataAccess.INV
{
    public class DA_Proveedor : DA_BaseClass
    {

        public static List<BE_Proveedor> ListarProveedoresBusqueda(string dscProveedor)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Proveedor_Listar", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("_dscProveedor", MySqlDbType.VarChar).Value = dscProveedor;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_Proveedor> lstProveedor = new List<BE_Proveedor>();
                            BE_Proveedor objProveedor;
                            while (lector.Read())
                            {

                                objProveedor = new BE_Proveedor();
                                objProveedor.codProveedor = Convert.ToString(lector["codProveedor"]);
                                objProveedor.dscProveedor = Convert.ToString(lector["dscProveedor"]);
                                objProveedor.dscRuc = Convert.ToString(lector["dscRuc"]);
                                objProveedor.dscDireccion = Convert.ToString(lector["dscDireccion"]);
                                objProveedor.dscTelefono = Convert.ToString(lector["dscTelefono"]);
                                objProveedor.dscCorreo = Convert.ToString(lector["dscCorreo"]);
                                objProveedor.dscEstado = Convert.ToString(lector["dscEstado"]);
                                objProveedor.dscUsuModificacion = Convert.ToString(lector["dscUsuModificacion"]);
                                objProveedor.fecModificacion = Convert.ToDateTime(lector["fecModificacion"]);


                                lstProveedor.Add(objProveedor);
                            }

                            return lstProveedor;

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public static string GenerarIdProveedor()
        {
            string codProveedor = string.Empty;

            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Proveedor_GenerarId", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("_codProveedor", MySqlDbType.VarChar, 20).Direction = System.Data.ParameterDirection.Output;
                        cmd.ExecuteNonQuery();

                        codProveedor = cmd.Parameters["_codProveedor"].Value.ToString();
                    }

                }

            }

            catch (Exception ex)
            {

                throw ex;
            }

            return codProveedor;

        }



        public static bool InsertarProveedor(BE_Proveedor objProveedor)
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
                            using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Proveedor_Insertar", cn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Transaction = trx;
                                cmd.Parameters.Add("_codProveedor", MySqlDbType.VarChar, 20).Value = objProveedor.codProveedor;
                                cmd.Parameters.Add("_dscProveedor", MySqlDbType.VarChar, 10).Value = objProveedor.dscProveedor;
                                cmd.Parameters.Add("_dscRuc", MySqlDbType.VarChar, 10).Value = objProveedor.dscRuc;
                                cmd.Parameters.Add("_dscDireccion", MySqlDbType.VarChar, 100).Value = objProveedor.dscDireccion;
                                cmd.Parameters.Add("_dscTelefono", MySqlDbType.VarChar, 100).Value = objProveedor.dscTelefono;
                                cmd.Parameters.Add("_dscCorreo", MySqlDbType.VarChar, 50).Value = objProveedor.dscCorreo;
                                cmd.Parameters.Add("_dscUsuCreacion", MySqlDbType.VarChar, 10).Value = objProveedor.dscUsuCreacion;
                                cmd.Parameters.Add("_dscEstado", MySqlDbType.VarChar, 1).Value = objProveedor.dscEstado;

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



        public static BE_Proveedor GetProveedor(string codProveedor)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlTransaction trx = cn.BeginTransaction())
                    {
                        using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Proveedor_Mostrar", cn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add("_codProveedor", MySqlDbType.VarChar).Value = codProveedor;

                            using (MySqlDataReader lector = cmd.ExecuteReader())
                            {
                                BE_Proveedor objProveedor = null;
                                while (lector.Read())
                                {

                                    objProveedor = new BE_Proveedor();

                                    objProveedor.codProveedor = Convert.ToString(lector["codProveedor"]);
                                    objProveedor.dscProveedor = Convert.ToString(lector["dscProveedor"]);
                                    objProveedor.dscRuc = Convert.ToString(lector["dscRuc"]);
                                    objProveedor.dscDireccion = Convert.ToString(lector["dscDireccion"]);
                                    objProveedor.dscTelefono = Convert.ToString(lector["dscTelefono"]);
                                    objProveedor.dscCorreo = Convert.ToString(lector["dscCorreo"]);
                                    objProveedor.dscEstado = Convert.ToString(lector["dscEstado"]);
                                }

                                return objProveedor;

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


        public static bool ModificarProveedor(BE_Proveedor objProveedor)
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
                            using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Proveedor_Modificar", cn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Transaction = trx;
                                cmd.Parameters.Add("_codProveedor", MySqlDbType.VarChar, 20).Value = objProveedor.codProveedor;
                                cmd.Parameters.Add("_dscProveedor", MySqlDbType.VarChar, 100).Value = objProveedor.dscProveedor;
                                cmd.Parameters.Add("_dscRuc", MySqlDbType.VarChar, 25).Value = objProveedor.dscRuc;
                                cmd.Parameters.Add("_dscDireccion", MySqlDbType.VarChar, 100).Value = objProveedor.dscDireccion;
                                cmd.Parameters.Add("_dscTelefono", MySqlDbType.VarChar, 50).Value = objProveedor.dscTelefono;
                                cmd.Parameters.Add("_dscCorreo", MySqlDbType.VarChar, 50).Value = objProveedor.dscCorreo;
                                cmd.Parameters.Add("_dscUsuModificacion", MySqlDbType.VarChar, 10).Value = objProveedor.dscUsuModificacion;
                                cmd.Parameters.Add("_dscEstado", MySqlDbType.VarChar, 1).Value = objProveedor.dscEstado;

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


        public static bool EliminarProveedor(string codProveedor)
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
                            using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Proveedor_Eliminar", cn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Transaction = trx;
                                cmd.Parameters.Add("_codProveedor", MySqlDbType.VarChar, 20).Value = codProveedor;
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



        public static List<BE_Proveedor> ListarProveedores()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Proveedor_ListarMov", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_Proveedor> lstProveedor = new List<BE_Proveedor>();
                            BE_Proveedor objProveedor;
                            while (lector.Read())
                            {

                                objProveedor = new BE_Proveedor();
                                objProveedor.codProveedor = Convert.ToString(lector["codProveedor"]);
                                objProveedor.dscProveedor = Convert.ToString(lector["dscProveedor"]);

                                lstProveedor.Add(objProveedor);
                            }

                            return lstProveedor;

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
