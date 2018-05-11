using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.INV;
using MySql.Data.MySqlClient;

namespace BettosImport.Sigeinv.DataAccess.INV
{
    public class DA_TipoDocumento : DA_BaseClass
    {
        public static List<BE_TipoDocumento> ListarTiposDocumentos()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_TipoDocumento_Listar", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_TipoDocumento> lstTipoDocumento = new List<BE_TipoDocumento>();
                            BE_TipoDocumento objTipoDoc;
                            while (lector.Read())
                            {

                                objTipoDoc = new BE_TipoDocumento();
                                objTipoDoc.codTipoDocumento = Convert.ToString(lector["codTipoDocumento"]);
                                objTipoDoc.dscTipoDocumento = Convert.ToString(lector["dscTipoDocumento"]);

                                lstTipoDocumento.Add(objTipoDoc);
                            }

                            return lstTipoDocumento;

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
