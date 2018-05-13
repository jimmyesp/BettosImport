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
    public partial class Salidas1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                ListarMovimientoSalidas();

            }
        }

        private void ListarMovimientoSalidas()
        {
            BE_Usuario objSesionLogin = (BE_Usuario)Context.Session[Constantes.USUARIO_SESION];
            BE_UsuarioTienda objUsuTienda = BL_UsuarioTienda.GetUsuarioTienda(objSesionLogin.codUsuario);
            List<BE_Movimiento> lstSalidas = BL_Movimiento.ListarSalidaProductos(objUsuTienda.codTienda, txtDscModelo.Text);
            gvListado.DataSource = lstSalidas;
            gvListado.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("SalidaProductos.aspx?Accion=" + Constantes.ACCION_NUEVO);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarMovimientoSalidas();
        }
    }
}