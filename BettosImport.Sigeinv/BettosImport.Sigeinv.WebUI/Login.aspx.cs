using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BettosImport.Sigeinv.Common;
using BettosImport.Sigeinv.BusinessEntities.ADM;
using BettosImport.Sigeinv.BusinessLogic.ADM;

namespace BettosImport.Sigeinv.WebUI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                txtUsuario.Focus();
                txtUsuario.Text = "jespinoza";
                txtPassword.Text = "123456";
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            bool resultado = false;

            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                mensaje = "Ingrese usuario. <br/>";
                resultado = false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                mensaje += "Ingrese password. <br/>";
                resultado = false;
            }

            if (!string.IsNullOrEmpty(txtUsuario.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                BE_Usuario objUsuario = new BE_Usuario();

                objUsuario = BL_Usuario.GetLogin(txtUsuario.Text, txtPassword.Text);

                if (objUsuario != null)
                {
                    if (objUsuario.dscEstado=="I")
                    {
                        mensaje += "Usuario Inactivo";
                        resultado = false;

                    }
                    else
                    {
                        resultado = true;

                        Session[Constantes.USUARIO_SESION] = objUsuario;
                        Response.Redirect("MenuPrincipal.aspx");
                    }                  
                }
                else
                {
                    mensaje += "Usuario o password incorrecto.";
                    resultado = false;
                }
            }

            if (resultado == false)
            {
                string script = "$(function(){mostrarMensaje('" + mensaje + "','" + Constantes.ALERT_DANGER + "')})";
                ScriptManager.RegisterStartupScript(this, Page.GetType(), "", script, true);
            }
        }
    }
}