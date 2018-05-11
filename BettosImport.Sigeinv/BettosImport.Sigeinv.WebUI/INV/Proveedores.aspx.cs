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
    public partial class Proveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                ListarProveedores();
            }

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedor.aspx?Accion=" + Constantes.ACCION_NUEVO);
        }

        private void ListarProveedores()
        {
            List<BE_Proveedor> lstProveedor = BL_Proveedor.ListarProveedoresBusqueda(txtDscProveedor.Text);
            gvListado.DataSource = lstProveedor;
            gvListado.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarProveedores();
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;
            ListarProveedores();
        }

        protected void gvListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index;
            string codProveedor = string.Empty;
            switch (e.CommandName)
            {
                case "Edit":
                    index = Convert.ToInt32(e.CommandArgument);

                    codProveedor = this.gvListado.DataKeys[index][0].ToString();
                    Response.Redirect("Proveedor.aspx?Accion=" + Constantes.ACCION_EDITAR + "&Id=" + codProveedor);
                    break;
                case "Delete":
                    codProveedor = (string)(e.CommandArgument);
                    if (BL_Proveedor.EliminarProveedor(codProveedor))
                    {
                        ListarProveedores();
                        string script = "$(function(){bettosimport.util.showMessage('" + Constantes.SUCCESS_DEFAULT_MESSAGE + "','" + Constantes.ALERT_SUCCESS + "')})";
                        ScriptManager.RegisterStartupScript(this, Page.GetType(), "", script, true);
                    }
                    else
                    {
                        string script = "$(function(){bettosimport.util.showMessage('" + Constantes.ERROR_DEFAULT_MESSAGE + "','" + Constantes.ALERT_DANGER + "')})";
                        ScriptManager.RegisterStartupScript(this, Page.GetType(), "", script, true);
                    }
                    break;
            }
        }

        protected void gvListado_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}