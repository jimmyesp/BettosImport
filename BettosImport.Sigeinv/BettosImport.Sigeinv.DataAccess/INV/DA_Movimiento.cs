using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.INV;
using MySql.Data.MySqlClient;

namespace BettosImport.Sigeinv.DataAccess.INV
{
    public class DA_Movimiento : DA_BaseClass
    {
        public static List<BE_Movimiento> ListarSalidaProductos(string dscModelo)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Movimiento_ListarSalida", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("_dscModelo", MySqlDbType.VarChar).Value = dscModelo;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_Movimiento> lstSalidaProd = new List<BE_Movimiento>();
                            BE_Movimiento objMovimiento;
                            while (lector.Read())
                            {
                                objMovimiento = new BE_Movimiento();

                                objMovimiento.dscCategoria = Convert.ToString(lector["dscCategoria"]);
                                objMovimiento.dscSubCategoria = Convert.ToString(lector["dscSubCategoria"]);
                                objMovimiento.dscMarca = Convert.ToString(lector["dscMarca"]);
                                objMovimiento.dscModelo = Convert.ToString(lector["dscModelo"]);
                                objMovimiento.dscTiendaDestino = Convert.ToString(lector["dscTienda"]);
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



        public static List<BE_Movimiento> ListarEntradaProductos(string dscModelo)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Movimiento_ListarEntrada", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("_dscModelo", MySqlDbType.VarChar).Value = dscModelo;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_Movimiento> lstEntradaProd = new List<BE_Movimiento>();
                            BE_Movimiento objMovimiento;
                            while (lector.Read())
                            {
                                objMovimiento = new BE_Movimiento();

                                objMovimiento.dscCategoria = Convert.ToString(lector["dscCategoria"]);
                                objMovimiento.dscSubCategoria = Convert.ToString(lector["dscSubCategoria"]);
                                objMovimiento.dscMarca = Convert.ToString(lector["dscMarca"]);
                                objMovimiento.dscModelo = Convert.ToString(lector["dscModelo"]);
                                objMovimiento.dscProveedor = Convert.ToString(lector["dscProveedor"]);
                                objMovimiento.dscTiendaOrigen = Convert.ToString(lector["dscTienda"]);
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
    }
}
