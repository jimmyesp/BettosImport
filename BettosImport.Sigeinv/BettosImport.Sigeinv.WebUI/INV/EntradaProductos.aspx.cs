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
    public partial class EntradaProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                hfAccion.Value = Request.QueryString["Accion"].ToString();

                ListarTiendas();
                ListarTiposDocumentos();
                ListarProveedores();
                ListarTiposOperaciones();

            }
        }

        private void ListarTiendas()
        {
            List<BE_Tienda> lstTienda = BL_Tienda.ListarTiendas();
            ddlTiendaOrigen.DataSource = lstTienda;
            ddlTiendaOrigen.DataValueField = "codTienda";
            ddlTiendaOrigen.DataTextField = "dscTienda";
            ddlTiendaOrigen.DataBind();
            ddlTiendaOrigen.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
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

        private void ListarProveedores()
        {
            List<BE_Proveedor> lstProveedor = BL_Proveedor.ListarProveedores();
            ddlProveedor.DataSource = lstProveedor;
            ddlProveedor.DataValueField = "codProveedor";
            ddlProveedor.DataTextField = "dscProveedor";
            ddlProveedor.DataBind();
            ddlProveedor.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
        }

        private void ListarTiposOperaciones()
        {
            List<BE_TipoOperacion> lstTipoOper = BL_TipoOperacion.ListarTiposOperaciones();
            ddlTipoEntrada.DataSource = lstTipoOper;
            ddlTipoEntrada.DataValueField = "codTipoOperacion";
            ddlTipoEntrada.DataTextField = "dscTipoOperacion";
            ddlTipoEntrada.DataBind();
            ddlTipoEntrada.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
        }

        protected void lbRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Entradas.aspx");
        }

        protected void ddlTipoEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlProveedor.SelectedIndex = 0;
            ddlTiendaOrigen.SelectedIndex = 0;
            if (ddlTipoEntrada.SelectedIndex == 0)
            {
                ddlProveedor.Enabled = false;
                ddlTiendaOrigen.Enabled = false;
               
                return;
            }

            BE_TipoOperacion objTipoOperacion = BL_TipoOperacion.GetTipoOperacion(ddlTipoEntrada.SelectedValue);

            if (objTipoOperacion != null)
            {
                
                if (objTipoOperacion.indProveedor == Constantes.ESTADO_INDPROVEEDOR)
                {
                    ddlProveedor.Enabled = true;
                    ddlTiendaOrigen.Enabled = false;
                }
                else
                {
                    ddlTiendaOrigen.Enabled = true;
                    ddlProveedor.Enabled = false;
                }
       
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            BE_Usuario objSesionLogin = (BE_Usuario)Context.Session[Constantes.USUARIO_SESION];
            BE_UsuarioTienda objUsuTienda = BL_UsuarioTienda.GetUsuarioTienda(objSesionLogin.codUsuario);

            try
            {
                BE_Movimiento objMovimiento = new BE_Movimiento();

                objMovimiento.codTienda = objUsuTienda.codTienda;
                objMovimiento.codTipoOperacion = ddlTipoEntrada.SelectedValue;
                objMovimiento.codProducto = hfCodProducto.Value;
                objMovimiento.fecEmision = Convert.ToDateTime(TxtFecEmision.Text);
                objMovimiento.dscAnio = objMovimiento.fecEmision.Year.ToString();
                objMovimiento.dscPeriodo = objMovimiento.dscAnio + objMovimiento.fecEmision.Month.ToString("00");

                if(objMovimiento.codTipoOperacion == "IAP")
                {
                    objMovimiento.codProveedor = ddlProveedor.SelectedValue;
                    objMovimiento.codTiendaOrigen = null;
                }

                if (objMovimiento.codTipoOperacion == "IAT")
                {
                    objMovimiento.codProveedor = null;
                    objMovimiento.codTiendaOrigen = ddlTiendaOrigen.SelectedValue; ;
                }

                objMovimiento.codTiendaDestino = objUsuTienda.codTienda; ;
                objMovimiento.numCantidad = Convert.ToInt16(txtCantidad.Text);
                objMovimiento.codTipoDocumento = ddlTipoDocumento.SelectedValue;
                objMovimiento.dscNumTipoDoc = txtNumDoc.Text.Trim();
                objMovimiento.dscComentario = txtComentario.Text.Trim();
                objMovimiento.dscUsuCreacion = objSesionLogin.codUsuario;
                objMovimiento.dscUsuModificacion = objSesionLogin.codUsuario;


                if (hfAccion.Value == Constantes.ACCION_NUEVO)
                {
                    objMovimiento.dscNumDocOper = BL_Movimiento.GenerarIdMovimiento(objMovimiento.codTipoOperacion);



                    if (BL_Movimiento.InsertarEntradaProducto(objMovimiento) == true)
                    {
                        BL_TipoOperacion.ActualizarCorrelativo(objMovimiento.codTipoOperacion);
                        BL_DetalleProductoTienda.ActualizarCantProducEntrada(objMovimiento.codProducto, objMovimiento.codTienda, objMovimiento.numCantidad);
                        string script = "$(function(){bettosimport.util.alertURL('" + Constantes.SUCCESS_DEFAULT_MESSAGE + "','" + WebUtil.AbsoluteWebRoot + "INV/Entradas.aspx" + "')})";
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