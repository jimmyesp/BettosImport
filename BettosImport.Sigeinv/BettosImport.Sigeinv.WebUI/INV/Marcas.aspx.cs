using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BettosImport.Sigeinv.BusinessLogic.INV;
using BettosImport.Sigeinv.BusinessEntities.INV;
using BettosImport.Sigeinv.BusinessEntities.ADM;
using BettosImport.Sigeinv.Common;

namespace BettosImport.Sigeinv.WebUI.INV
{
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                ListarMarcas();
            }
        }

        private void ListarMarcas()
        {
            List<BE_Marca> lstMarca = BL_Marca.ListarMarcasBusqueda(txtDscMarca.Text);
            gvListado.DataSource = lstMarca;
            gvListado.DataBind();
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;
            ListarMarcas();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarMarcas();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Marca.aspx?Accion=" + Constantes.ACCION_NUEVO);
        }

        protected void gvListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index;
            string codMarca = string.Empty;
            switch (e.CommandName)
            {
                case "Edit":
                    index = Convert.ToInt32(e.CommandArgument);

                    codMarca = this.gvListado.DataKeys[index][0].ToString();
                    Response.Redirect("Marca.aspx?Accion=" + Constantes.ACCION_EDITAR + "&Id=" + codMarca);
                    break;
                case "Delete":
                    codMarca = (string)(e.CommandArgument);
                    if (BL_Marca.EliminarMarca(codMarca))
                    {
                        ListarMarcas();
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