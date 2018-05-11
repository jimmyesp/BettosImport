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
    public partial class Proveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                hfAccion.Value = Request.QueryString["Accion"].ToString();


                if (hfAccion.Value == Constantes.ACCION_EDITAR)
                {
                    string codProveedor = Request.QueryString["Id"].ToString();
                    MostrarProveedor(codProveedor);
                }

            }

        }

        protected void lbRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores.aspx");
        }


        private void MostrarProveedor(string codProveedor)
        {

            BE_Proveedor objProveedor = BL_Proveedor.GetProveedor(codProveedor);
            if (objProveedor != null)
            {
                txtCodigo.Text = objProveedor.codProveedor;
                txtDescripcion.Text = objProveedor.dscProveedor;
                txtRuc.Text = objProveedor.dscRuc;
                txtDireccion.Text = objProveedor.dscDireccion;
                txtTelefono.Text = objProveedor.dscTelefono;
                txtCorreo.Text = objProveedor.dscCorreo;
                ddlEstado.SelectedValue = objProveedor.dscEstado;
            }


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            BE_Usuario objSesionLogin = (BE_Usuario)Context.Session[Constantes.USUARIO_SESION];

            try
            {
                BE_Proveedor objProveedor = new BE_Proveedor();

                objProveedor.dscProveedor = txtDescripcion.Text.Trim();
                objProveedor.dscRuc = txtRuc.Text.Trim();
                objProveedor.dscDireccion = txtRuc.Text.Trim();
                objProveedor.dscTelefono = txtTelefono.Text.Trim();
                objProveedor.dscCorreo = txtCorreo.Text.Trim();
                objProveedor.dscUsuCreacion = objSesionLogin.codUsuario;
                objProveedor.dscUsuModificacion = objSesionLogin.codUsuario;
                objProveedor.dscEstado = ddlEstado.SelectedValue;

                if (hfAccion.Value == Constantes.ACCION_NUEVO)
                {
                    objProveedor.codProveedor = BL_Proveedor.GenerarIdProveedor();

                    if (BL_Proveedor.InsertarProveedor(objProveedor) == true)
                    {
                        string script = "$(function(){bettosimport.util.alertURL('" + Constantes.SUCCESS_DEFAULT_MESSAGE + "','" + WebUtil.AbsoluteWebRoot + "INV/Proveedores.aspx" + "')})";
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
                    objProveedor.codProveedor = txtCodigo.Text;

                    if (BL_Proveedor.ModificarProveedor(objProveedor) == true)
                    {
                        string script = "$(function(){bettosimport.util.alertURL('" + Constantes.SUCCESS_DEFAULT_MESSAGE + "','" + WebUtil.AbsoluteWebRoot + "INV/Proveedores.aspx" + "')})";
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