using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.INV;
using MySql.Data.MySqlClient;

namespace BettosImport.Sigeinv.DataAccess.INV
{
    public class DA_Producto : DA_BaseClass
    {
        public static List<BE_Producto> ListarProductos(string dscProducto)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Producto_Listar", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("dscProducto", MySqlDbType.VarChar).Value = dscProducto;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_Producto> lstProducto = new List<BE_Producto>();
                            BE_Producto objProducto;
                            while (lector.Read())
                            {

                                objProducto  = new BE_Producto();

                                objProducto.id = Convert.ToInt64(lector["id"]);
                                objProducto.codProducto = Convert.ToString(lector["codProducto"]);
                                objProducto.codMarca = Convert.ToString(lector["codMarca"]);
                                objProducto.dscMarca = Convert.ToString(lector["dscMarca"]);
                                objProducto.codCategoria = Convert.ToString(lector["codCategoria"]);
                                objProducto.dscCategoria = Convert.ToString(lector["dscCategoria"]);
                                objProducto.codSubCategoria = Convert.ToString(lector["codSubCategoria"]);
                                objProducto.dscSubCategoria = Convert.ToString(lector["dscSubCategoria"]);
                                objProducto.dscProducto = Convert.ToString(lector["dscProducto"]);
                                objProducto.dscModelo = Convert.ToString(lector["dscModelo"]);
                                objProducto.dscSerie = Convert.ToString(lector["dscSerie"]);
                                objProducto.dscColor = Convert.ToString(lector["dscColor"]);
                                objProducto.dscUsuCreacion = Convert.ToString(lector["dscUsuCreacion"]);
                                objProducto.fecCreacion = Convert.ToDateTime(lector["fecCreacion"]);
                                objProducto.dscUsuModificacion = Convert.ToString(lector["dscUsuModificacion"]);
                                objProducto.fecModificacion = Convert.ToDateTime(lector["fecModificacion"]);
                                objProducto.dscEstado = Convert.ToString(lector["dscEstado"]);

                                lstProducto.Add(objProducto);
                            }

                            return lstProducto;

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static string GenerarIdProducto()
        {
            string codProducto = string.Empty;

            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Producto_GenerarId",cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("_codProducto", MySqlDbType.VarChar, 20).Direction = System.Data.ParameterDirection.Output;
                        cmd.ExecuteNonQuery();

                        codProducto = cmd.Parameters["_codProducto"].Value.ToString();
                    }

                }

            }

            catch (Exception ex)
            {
                
                throw ex;
            }

            return codProducto;

        }

        public static bool InsertarProducto(BE_Producto objProducto) {
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
                            using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Producto_Insertar", cn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Transaction = trx;
                                cmd.Parameters.Add("_codProducto", MySqlDbType.VarChar, 20).Value = objProducto.codProducto;
                                cmd.Parameters.Add("_codMarca", MySqlDbType.VarChar, 10).Value = objProducto.codMarca;
                                cmd.Parameters.Add("_codSubCategoria", MySqlDbType.VarChar, 10).Value = objProducto.codSubCategoria;
                                cmd.Parameters.Add("_dscProducto", MySqlDbType.VarChar, 100).Value = objProducto.dscProducto;
                                cmd.Parameters.Add("_dscModelo", MySqlDbType.VarChar, 100).Value = objProducto.dscModelo;
                                cmd.Parameters.Add("_dscSerie", MySqlDbType.VarChar, 50).Value = objProducto.dscSerie;
                                cmd.Parameters.Add("_dscColor", MySqlDbType.VarChar, 50).Value = objProducto.dscColor;
                                cmd.Parameters.Add("_dscUsuCreacion", MySqlDbType.VarChar, 10).Value = objProducto.dscUsuCreacion;
                                cmd.Parameters.Add("_dscEstado", MySqlDbType.VarChar, 1).Value = objProducto.dscEstado;

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



        public static BE_Producto GetProducto(string codProducto)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlTransaction trx = cn.BeginTransaction())
                    {
                        using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Producto_Mostrar", cn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add("_codProducto", MySqlDbType.VarChar).Value = codProducto;

                            using (MySqlDataReader lector = cmd.ExecuteReader())
                            {
                                BE_Producto objProducto = null;
                                while (lector.Read())
                                {

                                    objProducto = new BE_Producto();

                                    objProducto.codProducto = Convert.ToString(lector["codProducto"]);
                                    objProducto.codMarca = Convert.ToString(lector["codMarca"]);
                                    objProducto.codCategoria = Convert.ToString(lector["codCategoria"]);
                                    objProducto.codSubCategoria = Convert.ToString(lector["codSubCategoria"]);
                                    objProducto.dscProducto = Convert.ToString(lector["dscProducto"]);
                                    objProducto.dscModelo = Convert.ToString(lector["dscModelo"]);
                                    objProducto.dscSerie = Convert.ToString(lector["dscSerie"]);
                                    objProducto.dscColor = Convert.ToString(lector["dscColor"]);
                                    objProducto.dscEstado = Convert.ToString(lector["dscEstado"]);
                                }

                                return objProducto;

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



        public static bool ModificarProducto(BE_Producto objProducto)
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
                            using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Producto_Modificar", cn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Transaction = trx;
                                cmd.Parameters.Add("_codProducto", MySqlDbType.VarChar, 20).Value = objProducto.codProducto;
                                cmd.Parameters.Add("_codMarca", MySqlDbType.VarChar, 10).Value = objProducto.codMarca;
                                cmd.Parameters.Add("_codSubCategoria", MySqlDbType.VarChar, 10).Value = objProducto.codSubCategoria;
                                cmd.Parameters.Add("_dscProducto", MySqlDbType.VarChar, 100).Value = objProducto.dscProducto;
                                cmd.Parameters.Add("_dscModelo", MySqlDbType.VarChar, 100).Value = objProducto.dscModelo;
                                cmd.Parameters.Add("_dscSerie", MySqlDbType.VarChar, 50).Value = objProducto.dscSerie;
                                cmd.Parameters.Add("_dscColor", MySqlDbType.VarChar, 50).Value = objProducto.dscColor;
                                cmd.Parameters.Add("_dscUsuModificacion", MySqlDbType.VarChar, 10).Value = objProducto.dscUsuModificacion;
                                cmd.Parameters.Add("_dscEstado", MySqlDbType.VarChar, 1).Value = objProducto.dscEstado;

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


        public static bool EliminarProducto(string codProducto)
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
                            using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Producto_Eliminar", cn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Transaction = trx;
                                cmd.Parameters.Add("_codProducto", MySqlDbType.VarChar, 20).Value = codProducto;
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





        /*
        public static List<BE_DetalleProductoTienda>  Listar_Productos_Tienda(string codTienda)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_ListarProductos_Tienda", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("codTienda", MySqlDbType.VarChar).Value = codTienda;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_DetalleProductoTienda> lista = new List<BE_DetalleProductoTienda>();                       
                            while (lector.Read())
                            {
                                BE_DetalleProductoTienda dp = new BE_DetalleProductoTienda();
                                BE_Producto p = new BE_Producto();

                                p.dscModelo = Convert.ToString(lector["dscModelo"]);
                                BE_Marca m = new BE_Marca();
                                m.dscMarca = Convert.ToString(lector["dscMarca"]);
                                p.codMarca = m;
                                p.dscProducto = Convert.ToString(lector["dscProducto"]);
                                p.dscSerie = Convert.ToString(lector["dscSerie"]);
                                p.dscColor = Convert.ToString(lector["dscColor"]);
                                dp.codProducto = p;
                                dp.cntProducto = Convert.ToInt16(lector["cntProducto"]);

                                lista.Add(dp);
                            }

                            return lista;

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        */
    }
}
