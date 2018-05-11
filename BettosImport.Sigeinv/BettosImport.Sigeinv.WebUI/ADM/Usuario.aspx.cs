using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BettosImport.Sigeinv.BusinessEntities.ADM;
using BettosImport.Sigeinv.BusinessLogic.ADM;
using BettosImport.Sigeinv.Common;


namespace BettosImport.Sigeinv.WebUI.ADM
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                hfAccion.Value = Request.QueryString["Accion"].ToString();

                ListarRol();

                if (hfAccion.Value == Constantes.ACCION_EDITAR)
                {
                    string codUsuario = Request.QueryString["Id"].ToString();
                    MostrarUsuario(codUsuario);
                }
            }

        }

        private void MostrarUsuario(string codUsuario)
        {

            BE_Usuario objUsuario = BL_Usuario.GetUsuario(codUsuario);
            if (objUsuario != null)
            {

                txtUsuario.Text = objUsuario.codUsuario;
                txtDescripcion.Text = objUsuario.dscUsuario;
                txtPassword.Text = objUsuario.dscPassword;
                ddlRol.SelectedValue = objUsuario.codRol;
                ddlEstado.SelectedValue = objUsuario.dscEstado;

            }


        }

        private void ListarRol()
        {
            List<BE_Rol> lstRol = BL_Rol.ListarRol();
            ddlRol.DataSource = lstRol;
            ddlRol.DataValueField = "codRol";
            ddlRol.DataTextField = "dscRol";
            ddlRol.DataBind();
            ddlRol.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            BE_Usuario objSesionLogin = (BE_Usuario)Context.Session[Constantes.USUARIO_SESION];

            try
            {
                BE_Usuario objUsuario = new BE_Usuario();

                objUsuario.dscUsuario = txtDescripcion.Text.Trim();
                objUsuario.codUsuario = txtUsuario.Text.Trim();             
                objUsuario.dscPassword = txtPassword.Text.Trim();
                objUsuario.codRol = ddlRol.SelectedValue;
                objUsuario.dscEstado = ddlEstado.SelectedValue;
                objUsuario.dscUsuCreacion = objSesionLogin.dscUsuCreacion;
                objUsuario.dscUsuModificacion = objSesionLogin.dscUsuCreacion;


                if (hfAccion.Value == Constantes.ACCION_NUEVO)
                {

                    if (BL_Usuario.InsertarUsuario(objUsuario) == true)
                    {
                        string script = "$(function(){bettosimport.util.alertURL('" + Constantes.SUCCESS_DEFAULT_MESSAGE + "','" + WebUtil.AbsoluteWebRoot + "ADM/Usuarios.aspx" + "')})";
                        ScriptManager.RegisterStartupScript(this, Page.GetType(), "", script, true);
                    }
                    else
                    {
                        string script = "$(function(){bettosimport.util.showMessage('" + Constantes.ERROR_DEFAULT_MESSAGE + "','" + Constantes.ALERT_DANGER + "')})";
                        ScriptManager.RegisterStartupScript(this, Page.GetType(), "", script, true);
                    }
                }

                if (hfAccion.Value == Constantes.ACCION_EDITAR)
                {
                    objUsuario.codUsuario = txtUsuario.Text;


                    if (BL_Usuario.ModificarUsuario(objUsuario) == true)
                    {
                        string script = "$(function(){bettosimport.util.alertURL('" + Constantes.SUCCESS_DEFAULT_MESSAGE + "','" + WebUtil.AbsoluteWebRoot + "ADM/Usuarios.aspx" + "')})";
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

        protected void lbRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }
    }
}