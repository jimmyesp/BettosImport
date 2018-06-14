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
    public partial class DetalleProductoTienda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                ListarProductosTienda();

            }
        }

        private void ListarProductosTienda()
        {
            BE_Usuario objSesionLogin = (BE_Usuario)Context.Session[Constantes.USUARIO_SESION];
            BE_UsuarioTienda objUsuTienda = BL_UsuarioTienda.GetUsuarioTienda(objSesionLogin.codUsuario);
            List<BE_DetalleProductoTienda> lstProdTienda = BL_DetalleProductoTienda.ListarProductosTienda(txtDscProducto.Text, objUsuTienda.codTienda);
            gvListado.DataSource = lstProdTienda;
            gvListado.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductoTienda.aspx?Accion=" + Constantes.ACCION_NUEVO);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarProductosTienda();
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;
            ListarProductosTienda();
        }
    }
}