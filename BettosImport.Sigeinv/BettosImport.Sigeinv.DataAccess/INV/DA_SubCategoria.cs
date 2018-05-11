using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.INV;
using MySql.Data.MySqlClient;

namespace BettosImport.Sigeinv.DataAccess.INV
{
    public class DA_SubCategoria : DA_BaseClass
    {
        public static List<BE_SubCategoriaProducto> ListarSubCategorias(string codCategoria)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_SubCategoria_Listar", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("_codCategoria", MySqlDbType.VarChar).Value = codCategoria;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_SubCategoriaProducto> lstSubCategoria = new List<BE_SubCategoriaProducto>();
                            BE_SubCategoriaProducto objSubCategoria;
                            while (lector.Read())
                            {

                                objSubCategoria = new BE_SubCategoriaProducto();
                                objSubCategoria.codSubCategoria = Convert.ToString(lector["codSubCategoria"]);
                                objSubCategoria.dscSubCategoria = Convert.ToString(lector["dscSubCategoria"]);

                                lstSubCategoria.Add(objSubCategoria);
                            }

                            return lstSubCategoria;

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
