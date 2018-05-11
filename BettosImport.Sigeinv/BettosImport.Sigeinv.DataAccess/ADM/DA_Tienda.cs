using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.ADM;
using MySql.Data.MySqlClient;

namespace BettosImport.Sigeinv.DataAccess.ADM
{
    public class DA_Tienda : DA_BaseClass
    {
        public static List<BE_Tienda> ListarTiendas()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Adm_Tienda_Listar", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_Tienda> lstTienda = new List<BE_Tienda>();
                            BE_Tienda objTienda;
                            while (lector.Read())
                            {

                                objTienda = new BE_Tienda();
                                objTienda.codTienda = Convert.ToString(lector["codTienda"]);
                                objTienda.dscTienda = Convert.ToString(lector["dscTienda"]);

                                lstTienda.Add(objTienda);
                            }

                            return lstTienda;

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
