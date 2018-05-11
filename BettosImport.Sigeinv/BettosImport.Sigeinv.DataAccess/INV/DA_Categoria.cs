using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.INV;
using MySql.Data.MySqlClient;

namespace BettosImport.Sigeinv.DataAccess.INV
{
    public class DA_Categoria : DA_BaseClass
    {
        public static List<BE_CategoriaProducto> ListarCategorias()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(cnMySql()))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SP_Inv_Categoria_Listar", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        using (MySqlDataReader lector = cmd.ExecuteReader())
                        {
                            List<BE_CategoriaProducto> lstCategoria = new List<BE_CategoriaProducto>();
                            BE_CategoriaProducto objCategoria;
                            while (lector.Read())
                            {

                                objCategoria = new BE_CategoriaProducto();
                                objCategoria.codCategoria = Convert.ToString(lector["codCategoria"]);
                                objCategoria.dscCategoria = Convert.ToString(lector["dscCategoria"]);

                                lstCategoria.Add(objCategoria);
                            }

                            return lstCategoria;

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
