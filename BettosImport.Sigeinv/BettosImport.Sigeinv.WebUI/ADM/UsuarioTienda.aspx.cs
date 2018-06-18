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
    public partial class UsuarioTienda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BE_Usuario objSesionLogin = (BE_Usuario)Context.Session[Constantes.USUARIO_SESION];
            BE_UsuarioTienda objUsuTienda = BL_UsuarioTienda.GetUsuarioTienda(objSesionLogin.codUsuario);
            if (!(Page.IsPostBack))
            {
                hfAccion.Value = Request.QueryString["Accion"].ToString();
                txtTienda.Text = objUsuTienda.dscTienda;
                ListarUsuarios();
            }
        }

        private void ListarUsuarios()
        {
            List<BE_Usuario> lstUsuario = BL_Usuario.ListarUsuarios("");

            ddlUsuario.DataSource = lstUsuario;
            ddlUsuario.DataValueField = "codUsuario";
            ddlUsuario.DataTextField = "codUsuario";
            ddlUsuario.DataBind();
            ddlUsuario.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));

        }

        protected void lbRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuariosTiendas.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            BE_Usuario objSesionLogin = (BE_Usuario)Context.Session[Constantes.USUARIO_SESION];
            BE_UsuarioTienda objUsuTienda = BL_UsuarioTienda.GetUsuarioTienda(objSesionLogin.codUsuario);

            try
            {
                BE_UsuarioTienda objUsuarioTienda = new BE_UsuarioTienda();

                objUsuarioTienda.codTienda = objUsuTienda.codTienda;
                objUsuarioTienda.codUsuario = ddlUsuario.SelectedValue;
                objUsuarioTienda.dscUsuCreacion = objSesionLogin.codUsuario;
                objUsuarioTienda.dscUsuModificacion = objSesionLogin.codUsuario;
                objUsuarioTienda.dscEstado = ddlEstado.SelectedValue;

                if (hfAccion.Value == Constantes.ACCION_NUEVO)
                {


                    if (BL_UsuarioTienda.InsertarUsuarioTienda(objUsuarioTienda) == true)
                    {
                        string script = "$(function(){bettosimport.util.alertURL('" + Constantes.SUCCESS_DEFAULT_MESSAGE + "','" + WebUtil.AbsoluteWebRoot + "ADM/UsuariosTiendas.aspx" + "')})";
                        ScriptManager.RegisterStartupScript(this, Page.GetType(), "", script, true);
                    }
                    else
                    {
                        string script = "$(function(){bettosimport.util.showMessage('" + Constantes.ERROR_DEFAULT_MESSAGE + "','" + Constantes.ALERT_DANGER + "')})";
                        ScriptManager.RegisterStartupScript(this, Page.GetType(), "", script, true);
                    }
                }

            }
            catch (Exception)
            {

                string script = "$(function(){bettosimport.util.showMessage('" + Constantes.ERROR_DEFAULT_MESSAGE + "','" + Constantes.ALERT_DANGER + "')})";
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "", script, true);
            }
        }
    }
}