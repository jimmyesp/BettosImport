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
        public static List<BE_Marca> ListarMarcas()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Marca_Listar", cn))
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
    }
}
