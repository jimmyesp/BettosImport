using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BettosImport.Sigeinv.BusinessLogic.INV;
using BettosImport.Sigeinv.BusinessLogic.ADM;
using BettosImport.Sigeinv.BusinessEntities.INV;
using BettosImport.Sigeinv.BusinessEntities.ADM;
using BettosImport.Sigeinv.Common;

namespace BettosImport.Sigeinv.WebUI.INV
{
    public partial class ProductoTienda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BE_Usuario objSesionLogin = (BE_Usuario)Context.Session[Constantes.USUARIO_SESION];
            BE_UsuarioTienda objUsuTienda = BL_UsuarioTienda.GetUsuarioTienda(objSesionLogin.codUsuario);
            if (!(Page.IsPostBack))
            {
                hfAccion.Value = Request.QueryString["Accion"].ToString();
                txtTienda.Text = objUsuTienda.dscTienda;
                ListarProductos();
            }
        }

        private void ListarProductos()
        {
            List<BE_Producto> lstProducto = BL_Producto.ListarProductos("");

            ddlProducto.DataSource = lstProducto;
            ddlProducto.DataValueField = "codProducto";
            ddlProducto.DataTextField = "dscProducto";
            ddlProducto.DataBind();
            ddlProducto.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));

        }

        protected void lbRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("DetalleProductoTienda.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            BE_Usuario objSesionLogin = (BE_Usuario)Context.Session[Constantes.USUARIO_SESION];
            BE_UsuarioTienda objUsuTienda = BL_UsuarioTienda.GetUsuarioTienda(objSesionLogin.codUsuario);

            try
            {
                BE_DetalleProductoTienda objProductoTienda = new BE_DetalleProductoTienda();

                objProductoTienda.codTienda = objUsuTienda.codTienda;
                objProductoTienda.codProducto = ddlProducto.SelectedValue;
                objProductoTienda.cntProducto = Convert.ToInt16(txtCantidad.Text);
                objProductoTienda.dscUsuCreacion = objSesionLogin.codUsuario;
                objProductoTienda.dscUsuModificacion = objSesionLogin.codUsuario;

                if (hfAccion.Value == Constantes.ACCION_NUEVO)
                {
   

                    if (BL_DetalleProductoTienda.InsertarProductoTienda(objProductoTienda) == true)
                    {
                        string script = "$(function(){bettosimport.util.alertURL('" + Constantes.SUCCESS_DEFAULT_MESSAGE + "','" + WebUtil.AbsoluteWebRoot + "INV/DetalleProductoTienda.aspx" + "')})";
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