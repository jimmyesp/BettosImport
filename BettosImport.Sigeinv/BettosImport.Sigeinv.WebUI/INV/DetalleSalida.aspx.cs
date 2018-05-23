using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BettosImport.Sigeinv.BusinessLogic.INV;
using BettosImport.Sigeinv.BusinessEntities.INV;
using BettosImport.Sigeinv.BusinessLogic.ADM;
using BettosImport.Sigeinv.BusinessEntities.ADM;
using BettosImport.Sigeinv.Common;

namespace BettosImport.Sigeinv.WebUI.INV
{
    public partial class DetalleSalida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {

                string id = Request.QueryString["Id"].ToString();
                MostrarDetalleSalida(id);

            }
        }

        private void MostrarDetalleSalida(string id)
        {

            BE_Movimiento objMovimiento = BL_Movimiento.GetSalidaProducto(Convert.ToInt16(id));
            if (objMovimiento != null)
            {
                lblProducto.InnerText = objMovimiento.dscProducto;
                lblTipoSalida.InnerText = objMovimiento.dscTipoOperacion;
            }
        }

        protected void lbRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Salidas.aspx");
        }
    }
}
