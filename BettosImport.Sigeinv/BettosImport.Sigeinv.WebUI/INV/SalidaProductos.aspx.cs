using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BettosImport.Sigeinv.BusinessLogic.ADM;
using BettosImport.Sigeinv.BusinessLogic.INV;
using BettosImport.Sigeinv.BusinessEntities.INV;
using BettosImport.Sigeinv.BusinessEntities.ADM;
using BettosImport.Sigeinv.Common;

namespace BettosImport.Sigeinv.WebUI.INV
{
    public partial class SalidaProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                hfAccion.Value = Request.QueryString["Accion"].ToString();

                ListarTiposOperacionesSalidas();
                ListarTiendas();
                ListarTiposDocumentos();
            }

        }

        private void ListarTiposOperacionesSalidas()
        {
            List<BE_TipoOperacion> lstTipoOper = BL_TipoOperacion.ListarTiposOperacionesSalidas();
            ddlTipoSalida.DataSource = lstTipoOper;
            ddlTipoSalida.DataValueField = "codTipoOperacion";
            ddlTipoSalida.DataTextField = "dscTipoOperacion";
            ddlTipoSalida.DataBind();
            ddlTipoSalida.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
        }

        private void ListarTiendas()
        {
            List<BE_Tienda> lstTienda = BL_Tienda.ListarTiendas();
            ddlTiendaDestino.DataSource = lstTienda;
            ddlTiendaDestino.DataValueField = "codTienda";
            ddlTiendaDestino.DataTextField = "dscTienda";
            ddlTiendaDestino.DataBind();
            ddlTiendaDestino.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
        }

        private void ListarTiposDocumentos()
        {
            List<BE_TipoDocumento> lstTipoDoc = BL_TipoDocumento.ListarTiposDocumentos();
            ddlTipoDocumento.DataSource = lstTipoDoc;
            ddlTipoDocumento.DataValueField = "codTipoDocumento";
            ddlTipoDocumento.DataTextField = "dscTipoDocumento";
            ddlTipoDocumento.DataBind();
            ddlTipoDocumento.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
        }

        protected void lbRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Salidas.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            BE_Usuario objSesionLogin = (BE_Usuario)Context.Session[Constantes.USUARIO_SESION];
            BE_UsuarioTienda objUsuTienda = BL_UsuarioTienda.GetUsuarioTienda(objSesionLogin.codUsuario);

            try
            {
                BE_Movimiento objMovimiento = new BE_Movimiento();

                objMovimiento.codTienda = objUsuTienda.codTienda;
                objMovimiento.codTipoOperacion = ddlTipoSalida.SelectedValue;
                objMovimiento.codProducto = hfCodProducto.Value;
                objMovimiento.fecEmision = Convert.ToDateTime(TxtFecEmision.Text);
                objMovimiento.dscAnio = objMovimiento.fecEmision.Year.ToString();
                objMovimiento.dscPeriodo = objMovimiento.dscAnio + objMovimiento.fecEmision.Month.ToString("00");
                objMovimiento.codTiendaOrigen = objUsuTienda.codTienda;

                if (objMovimiento.codTipoOperacion == "SAT")
                {
                    objMovimiento.codTiendaDestino = ddlTiendaDestino.SelectedValue; ;
                }
                else
                {
                    objMovimiento.codTiendaDestino = null;
                }

                objMovimiento.numCantidad = Convert.ToInt16(txtCantidad.Text);
                objMovimiento.codTipoDocumento = ddlTipoDocumento.SelectedValue;
                objMovimiento.dscNumTipoDoc = txtNumDoc.Text.Trim();
                objMovimiento.dscComentario = txtComentario.Text.Trim();
                objMovimiento.dscUsuCreacion = objSesionLogin.codUsuario;
                objMovimiento.dscUsuModificacion = objSesionLogin.codUsuario;

              

                if (hfAccion.Value == Constantes.ACCION_NUEVO)
                {
                    objMovimiento.dscNumDocOper = BL_Movimiento.GenerarIdMovimiento(objMovimiento.codTipoOperacion);

  

                    if (BL_Movimiento.InsertarSalidaProducto(objMovimiento) == true)
                    {
                        BL_TipoOperacion.ActualizarCorrelativo(objMovimiento.codTipoOperacion);
                        BL_DetalleProductoTienda.ActualizarCantProducSalida(objMovimiento.codProducto, objMovimiento.codTienda, objMovimiento.numCantidad);
                        string script = "$(function(){bettosimport.util.alertURL('" + Constantes.SUCCESS_DEFAULT_MESSAGE + "','" + WebUtil.AbsoluteWebRoot + "INV/Salidas.aspx" + "')})";
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

        protected void ddlTipoSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTiendaDestino.SelectedIndex = 0;
            if (ddlTipoSalida.SelectedIndex == 0)
            {
                ddlTiendaDestino.Enabled = false;

                return;
            }

            if (ddlTipoSalida.SelectedValue == Constantes.ESTADO_SALIDATIENDA)
            {
                 ddlTiendaDestino.Enabled = true;
            }
            else
            {
                 ddlTiendaDestino.Enabled = false;
            }
        }
    }
}