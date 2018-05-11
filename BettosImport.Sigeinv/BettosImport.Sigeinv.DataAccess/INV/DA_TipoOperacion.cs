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
        public static List<BE_TipoOperacion> ListarTiposOperaciones()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_TipoOperacion_Listar", cn))
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
    }
}
