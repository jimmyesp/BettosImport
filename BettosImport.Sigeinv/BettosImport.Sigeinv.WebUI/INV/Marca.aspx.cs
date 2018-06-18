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
    public partial class Marca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                hfAccion.Value = Request.QueryString["Accion"].ToString();


                if (hfAccion.Value == Constantes.ACCION_EDITAR)
                {
                    string codMarca = Request.QueryString["Id"].ToString();
                    MostrarMarca(codMarca);
                }

            }
        }

        protected void lbRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Marcas.aspx");
        }

        private void MostrarMarca(string codMarca)
        {

            BE_Marca objMarca = BL_Marca.GetMarca(codMarca);
            if (objMarca != null)
            {
                txtCodigo.Text = objMarca.codMarca;
                txtDescripcion.Text = objMarca.dscMarca;
                ddlEstado.SelectedValue = objMarca.dscEstado;
            }


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            BE_Usuario objSesionLogin = (BE_Usuario)Context.Session[Constantes.USUARIO_SESION];

            try
            {
                BE_Marca objMarca = new BE_Marca();

                objMarca.dscUsuCreacion = objSesionLogin.codUsuario;
                objMarca.dscUsuModificacion = objSesionLogin.codUsuario;
                objMarca.dscMarca = txtDescripcion.Text.Trim();
                objMarca.dscEstado = ddlEstado.SelectedValue;


                if (hfAccion.Value == Constantes.ACCION_NUEVO)
                {
                    objMarca.codMarca = BL_Marca.GenerarIdMarca();

                    if (BL_Marca.InsertarMarca(objMarca) == true)
                    {
                        string script = "$(function(){bettosimport.util.alertURL('" + Constantes.SUCCESS_DEFAULT_MESSAGE + "','" + WebUtil.AbsoluteWebRoot + "INV/Marcas.aspx" + "')})";
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
                    objMarca.codMarca = txtCodigo.Text;

                    if (BL_Marca.ModificarMarca(objMarca) == true)
                    {
                        string script = "$(function(){bettosimport.util.alertURL('" + Constantes.SUCCESS_DEFAULT_MESSAGE + "','" + WebUtil.AbsoluteWebRoot + "INV/Marcas.aspx" + "')})";
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