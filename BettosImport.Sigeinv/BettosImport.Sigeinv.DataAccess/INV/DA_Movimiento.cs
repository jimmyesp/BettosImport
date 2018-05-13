using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.INV;
using BettosImport.Sigeinv.Common;
using MySql.Data.MySqlClient;

namespace BettosImport.Sigeinv.DataAccess.INV
{
    public class DA_Movimiento : DA_BaseClass
    {
        public static List<BE_Movimiento> ListarSalidaProductos(string codTienda, string dscModelo)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Movimiento_ListarSalida", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("_codTienda", MySqlDbType.VarChar).Value = codTienda;
                        cmd.Parameters.Add("_dscModelo", MySqlDbType.VarChar).Value = dscModelo;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_Movimiento> lstSalidaProd = new List<BE_Movimiento>();
                            BE_Movimiento objMovimiento;
                            while (lector.Read())
                            {
                                objMovimiento = new BE_Movimiento();

                                objMovimiento.id = Convert.ToInt64(lector["id"]);
                                objMovimiento.dscCategoria = Convert.ToString(lector["dscCategoria"]);
                                objMovimiento.dscSubCategoria = Convert.ToString(lector["dscSubCategoria"]);
                                objMovimiento.dscMarca = Convert.ToString(lector["dscMarca"]);
                                objMovimiento.dscModelo = Convert.ToString(lector["dscModelo"]);
                                objMovimiento.dscTiendaDestino = Convert.ToString(lector["Tienda Destino"]);
                                objMovimiento.numCantidad = Convert.ToInt16(lector["numCantidad"]);
                                objMovimiento.fecEmision = Convert.ToDateTime(lector["fecEmision"]);


                                lstSalidaProd.Add(objMovimiento);
                            }

                            return lstSalidaProd;

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        public static List<BE_Movimiento> ListarEntradaProductos(string codTienda, string dscModelo)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Movimiento_ListarEntrada", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("_codTienda", MySqlDbType.VarChar).Value = codTienda;
                        cmd.Parameters.Add("_dscModelo", MySqlDbType.VarChar).Value = dscModelo;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_Movimiento> lstEntradaProd = new List<BE_Movimiento>();
                            BE_Movimiento objMovimiento;
                            while (lector.Read())
                            {
                                objMovimiento = new BE_Movimiento();

                                objMovimiento.id = Convert.ToInt64(lector["id"]);
                                objMovimiento.dscCategoria = Convert.ToString(lector["dscCategoria"]);
                                objMovimiento.dscSubCategoria = Convert.ToString(lector["dscSubCategoria"]);
                                objMovimiento.dscMarca = Convert.ToString(lector["dscMarca"]);
                                objMovimiento.dscModelo = Convert.ToString(lector["dscModelo"]);
                                objMovimiento.dscProveedor = Convert.ToString(lector["dscProveedor"]);
                                objMovimiento.dscTiendaOrigen = Convert.ToString(lector["Tienda Origen"]);
                                objMovimiento.numCantidad = Convert.ToInt16(lector["numCantidad"]);
                                objMovimiento.fecEmision = Convert.ToDateTime(lector["fecEmision"]);


                                lstEntradaProd.Add(objMovimiento);
                            }

                            return lstEntradaProd;

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public static string GenerarIdMovimiento(string codTipoOperacion)
        {
            string dscNumDocOper = string.Empty;

            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Movimiento_GenerarId", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("_codTipoOperacion", MySqlDbType.VarChar).Value = codTipoOperacion;
                        cmd.Parameters.Add("_dscNumDocOper", MySqlDbType.VarChar, 3).Direction = System.Data.ParameterDirection.Output;
                        cmd.ExecuteNonQuery();

                        dscNumDocOper = cmd.Parameters["_dscNumDocOper"].Value.ToString();
                    }

                }

            }

            catch (Exception ex)
            {

                throw ex;
            }

            return dscNumDocOper;

        }

        public static bool InsertarSalidaProducto(BE_Movimiento objMovimiento)
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
                            using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Movimiento_InsertarSalida", cn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Transaction = trx;
                                cmd.Parameters.Add("_dscAnio", MySqlDbType.VarChar, 4).Value = objMovimiento.dscAnio;
                                cmd.Parameters.Add("_dscPeriodo", MySqlDbType.VarChar, 6).Value = objMovimiento.dscPeriodo;
                                cmd.Parameters.Add("_codTienda", MySqlDbType.VarChar, 3).Value = objMovimiento.codTienda;
                                cmd.Parameters.Add("_codTipoOperacion", MySqlDbType.VarChar, 3).Value = objMovimiento.codTipoOperacion;
                                cmd.Parameters.Add("_codProducto", MySqlDbType.VarChar, 20).Value = objMovimiento.codProducto;
                                cmd.Parameters.Add("_dscNumDocOper", MySqlDbType.VarChar, 7).Value = objMovimiento.dscNumDocOper;
                                cmd.Parameters.Add("_fecEmision", MySqlDbType.Date).Value = objMovimiento.fecEmision.ToString(Constantes.FORMAT_YYYY_MM_DD);
                                cmd.Parameters.Add("_codTiendaOrigen", MySqlDbType.VarChar, 3).Value = objMovimiento.codTiendaOrigen;
                                cmd.Parameters.Add("_codTiendaDestino", MySqlDbType.VarChar, 3).Value = objMovimiento.codTiendaDestino;
                                cmd.Parameters.Add("_numCantidad", MySqlDbType.Int16).Value = objMovimiento.numCantidad;
                                cmd.Parameters.Add("_codTipoDocumento", MySqlDbType.VarChar, 3).Value = objMovimiento.codTipoDocumento;
                                cmd.Parameters.Add("_dscNumTipoDoc", MySqlDbType.VarChar, 100).Value = objMovimiento.dscNumTipoDoc;
                                cmd.Parameters.Add("_dscComentario", MySqlDbType.VarChar, 500).Value = objMovimiento.dscComentario;
                                cmd.Parameters.Add("_dscUsuCreacion", MySqlDbType.VarChar, 10).Value = objMovimiento.dscUsuCreacion;

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


        public static bool InsertarEntradaProducto(BE_Movimiento objMovimiento)
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
                            using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Movimiento_InsertarEntrada", cn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Transaction = trx;
                                cmd.Parameters.Add("_dscAnio", MySqlDbType.VarChar, 4).Value = objMovimiento.dscAnio;
                                cmd.Parameters.Add("_dscPeriodo", MySqlDbType.VarChar, 6).Value = objMovimiento.dscPeriodo;
                                cmd.Parameters.Add("_codTienda", MySqlDbType.VarChar, 3).Value = objMovimiento.codTienda;
                                cmd.Parameters.Add("_codTipoOperacion", MySqlDbType.VarChar, 3).Value = objMovimiento.codTipoOperacion;
                                cmd.Parameters.Add("_codProducto", MySqlDbType.VarChar, 20).Value = objMovimiento.codProducto;
                                cmd.Parameters.Add("_dscNumDocOper", MySqlDbType.VarChar, 7).Value = objMovimiento.dscNumDocOper;
                                cmd.Parameters.Add("_fecEmision", MySqlDbType.Date).Value = objMovimiento.fecEmision.ToString(Constantes.FORMAT_YYYY_MM_DD);
                                cmd.Parameters.Add("_codProveedor", MySqlDbType.VarChar, 20).Value = objMovimiento.codProveedor;
                                cmd.Parameters.Add("_codTiendaOrigen", MySqlDbType.VarChar, 3).Value = objMovimiento.codTiendaOrigen;
                                cmd.Parameters.Add("_codTiendaDestino", MySqlDbType.VarChar, 3).Value = objMovimiento.codTiendaDestino;
                                cmd.Parameters.Add("_numCantidad", MySqlDbType.Int16).Value = objMovimiento.numCantidad;
                                cmd.Parameters.Add("_codTipoDocumento", MySqlDbType.VarChar, 3).Value = objMovimiento.codTipoDocumento;
                                cmd.Parameters.Add("_dscNumTipoDoc", MySqlDbType.VarChar, 100).Value = objMovimiento.dscNumTipoDoc;
                                cmd.Parameters.Add("_dscComentario", MySqlDbType.VarChar, 500).Value = objMovimiento.dscComentario;
                                cmd.Parameters.Add("_dscUsuCreacion", MySqlDbType.VarChar, 10).Value = objMovimiento.dscUsuCreacion;

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
