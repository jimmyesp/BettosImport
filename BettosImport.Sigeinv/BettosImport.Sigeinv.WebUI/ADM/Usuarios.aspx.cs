using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BettosImport.Sigeinv.BusinessLogic.ADM;
using BettosImport.Sigeinv.BusinessEntities.ADM;
using BettosImport.Sigeinv.Common;

namespace BettosImport.Sigeinv.WebUI.ADM
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                ListarUsuarios();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarUsuarios();
        }

        private void ListarUsuarios()
        {
            List<BE_Usuario> lstUsuario = BL_Usuario.ListarUsuarios(txtDscUsuario.Text);
            gvListado.DataSource = lstUsuario;
            gvListado.DataBind();
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;
            ListarUsuarios();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuario.aspx?Accion=" + Constantes.ACCION_NUEVO);
        }

        protected void gvListado_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index;
            string codUsuario = string.Empty;
            switch (e.CommandName)
            {
                case "Edit":
                    index = Convert.ToInt32(e.CommandArgument);

                    codUsuario = this.gvListado.DataKeys[index][0].ToString();
                    Response.Redirect("Usuario.aspx?Accion=" + Constantes.ACCION_EDITAR + "&Id=" + codUsuario);
                    break;
                case "Delete":
                    codUsuario = (string)(e.CommandArgument);
                    if (BL_Usuario.EliminarUsuario(codUsuario))
                    {
                        ListarUsuarios();
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