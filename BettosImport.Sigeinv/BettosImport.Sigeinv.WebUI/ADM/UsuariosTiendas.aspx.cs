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

namespace BettosImport.Sigeinv.WebUI.ADM
{
    public partial class UsuariosTiendas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                ListarTiendaUsuarios();

            }
        }


        private void ListarTiendaUsuarios()
        {
            BE_Usuario objSesionLogin = (BE_Usuario)Context.Session[Constantes.USUARIO_SESION];
            BE_UsuarioTienda objUsuTienda = BL_UsuarioTienda.GetUsuarioTienda(objSesionLogin.codUsuario);
            List<BE_UsuarioTienda> lstUsuTienda = BL_UsuarioTienda.ListarUsuariosTienda(txtDscUsuario.Text, objUsuTienda.codTienda);
            gvListado.DataSource = lstUsuTienda;
            gvListado.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuarioTienda.aspx?Accion=" + Constantes.ACCION_NUEVO);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarTiendaUsuarios();
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;
            ListarTiendaUsuarios();
        }
    }
}