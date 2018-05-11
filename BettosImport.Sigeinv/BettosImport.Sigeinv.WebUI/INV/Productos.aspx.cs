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
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                ListarProductos();
            }
        }

        private void ListarProductos()
        {
            List<BE_Producto> lstProducto = BL_Producto.ListarProductos(txtDscProducto.Text);
            gvListado.DataSource = lstProducto;
            gvListado.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Producto.aspx?Accion=" + Constantes.ACCION_NUEVO);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarProductos();
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;
            ListarProductos();
        }

        protected void gvListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index;
            string codProducto = string.Empty;
            switch (e.CommandName)
            {
                case "Edit":
                    index = Convert.ToInt32(e.CommandArgument);

                    codProducto = this.gvListado.DataKeys[index][0].ToString();
                    Response.Redirect("Producto.aspx?Accion=" + Constantes.ACCION_EDITAR + "&Id=" + codProducto);
                    break;
                case "Delete":
                    codProducto = (string)(e.CommandArgument);
                    if (BL_Producto.EliminarProducto(codProducto))
                    {
                        ListarProductos();
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