using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.INV;
using MySql.Data.MySqlClient;

namespace BettosImport.Sigeinv.DataAccess.INV
{
    public class DA_TipoOperacion : DA_BaseClass
    {
        public static List<BE_TipoOperacion> ListarTiposOperacionesEntradas()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_TipoOperacion_ListarEntradas", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_TipoOperacion> lstTipoOperacion = new List<BE_TipoOperacion>();
                            BE_TipoOperacion objTipoOper;
                            while (lector.Read())
                            {

                                objTipoOper = new BE_TipoOperacion();
                                objTipoOper.codTipoOperacion = Convert.ToString(lector["codTipoOperacion"]);
                                objTipoOper.dscTipoOperacion = Convert.ToString(lector["dscTipoOperacion"]);


                                lstTipoOperacion.Add(objTipoOper);
                            }

                            return lstTipoOperacion;

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        public static List<BE_TipoOperacion> ListarTiposOperacionesSalidas()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_TipoOperacion_ListarSalidas", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_TipoOperacion> lstTipoOperacionSalida = new List<BE_TipoOperacion>();
                            BE_TipoOperacion objTipoOper;
                            while (lector.Read())
                            {

                                objTipoOper = new BE_TipoOperacion();
                                objTipoOper.codTipoOperacion = Convert.ToString(lector["codTipoOperacion"]);
                                objTipoOper.dscTipoOperacion = Convert.ToString(lector["dscTipoOperacion"]);


                                lstTipoOperacionSalida.Add(objTipoOper);
                            }

                            return lstTipoOperacionSalida;

                        }

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public static BE_TipoOperacion GetTipoOperacion(string codTipoOperacion)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlTransaction trx = cn.BeginTransaction())
                    {
                        using (MySqlCommand cmd = new MySqlCommand("SP_Inv_TipoOperacion_Obtener", cn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add("_codTipoOperacion", MySqlDbType.VarChar).Value = codTipoOperacion;

                            using (MySqlDataReader lector = cmd.ExecuteReader())
                            {
                                BE_TipoOperacion objTipoOperacion = null;
                                while (lector.Read())
                                {

                                    objTipoOperacion = new BE_TipoOperacion();

                                    objTipoOperacion.indProveedor = Convert.ToString(lector["indProveedor"]);

                                }

                                return objTipoOperacion;

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

        public static bool ActualizarCorrelativo(string codTipoOperacion)
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
                            using (MySqlCommand cmd = new MySqlCommand("SP_Inv_TipoOperacion_Actualizar", cn))
                            {
                                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                cmd.Transaction = trx;
                                cmd.Parameters.Add("_codTipoOperacion", MySqlDbType.VarChar, 3).Value = codTipoOperacion;
     
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
