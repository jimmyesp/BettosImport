using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.INV;
using MySql.Data.MySqlClient;

namespace BettosImport.Sigeinv.DataAccess.INV
{
    public class DA_DetalleProductoTienda : DA_BaseClass
    {

        public static bool ActualizarCantProducSalida(string codProducto, string codTienda, int cantidad)
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
                            using (MySqlCommand cmd = new MySqlCommand("SP_Inv_DetalleProductoTienda_ActualizarSalida", cn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Transaction = trx;
                                cmd.Parameters.Add("_codProducto", MySqlDbType.VarChar, 20).Value = codProducto;
                                cmd.Parameters.Add("_codTienda", MySqlDbType.VarChar, 3).Value = codTienda;
                                cmd.Parameters.Add("_numCantidad", MySqlDbType.Int16).Value = cantidad;

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



        public static bool ActualizarCantProducEntrada(string codProducto, string codTienda, int cantidad)
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
                            using (MySqlCommand cmd = new MySqlCommand("SP_Inv_DetalleProductoTienda_ActualizarEntrada", cn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Transaction = trx;
                                cmd.Parameters.Add("_codProducto", MySqlDbType.VarChar, 20).Value = codProducto;
                                cmd.Parameters.Add("_codTienda", MySqlDbType.VarChar, 3).Value = codTienda;
                                cmd.Parameters.Add("_numCantidad", MySqlDbType.Int16).Value = cantidad;

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


        public static List<BE_DetalleProductoTienda> ListarDetalleProductos(string dscProducto)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_DetalleProductoTienda_Listar", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("_dscProducto", MySqlDbType.VarChar).Value = dscProducto;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_DetalleProductoTienda> lstDetalleProd = new List<BE_DetalleProductoTienda>();
                            BE_DetalleProductoTienda objDetalleProducto;
                            while (lector.Read())
                            {

                                objDetalleProducto = new BE_DetalleProductoTienda();
                                objDetalleProducto.id = Convert.ToInt64(lector["id"]);
                                objDetalleProducto.dscProducto = Convert.ToString(lector["dscProducto"]);
                                objDetalleProducto.dscTienda = Convert.ToString(lector["dscTienda"]);
                                objDetalleProducto.cntProducto = Convert.ToInt16(lector["cntProducto"]);

                                lstDetalleProd.Add(objDetalleProducto);
                            }

                            return lstDetalleProd;

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
