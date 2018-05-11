using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BettosImport.Sigeinv.BusinessLogic.INV;
using BettosImport.Sigeinv.BusinessEntities.INV;
using BettosImport.Sigeinv.Common;

namespace BettosImport.Sigeinv.WebUI.INV
{
    public partial class Salidas1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalidaProductos.aspx?Accion=" + Constantes.ACCION_NUEVO);
        }
    }
}