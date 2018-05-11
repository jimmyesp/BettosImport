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
    public partial class Producto : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                hfAccion.Value =  Request.QueryString["Accion"].ToString();

                ListarMarcas();
                ListarCategorias();

                if (hfAccion.Value == Constantes.ACCION_EDITAR)
                {
                    string codProducto = Request.QueryString["Id"].ToString();
                    MostrarProducto(codProducto);
                }

            }

        }

        private void MostrarProducto(string codProducto)
        {

            BE_Producto objProducto = BL_Producto.GetProducto(codProducto);
            if (objProducto != null)
            {
                txtCodigo.Text = objProducto.codProducto;
                txtDescripcion.Text = objProducto.dscProducto;
                ddlCategoria.SelectedValue = objProducto.codCategoria;

                ListarSubCategorias(ddlCategoria.SelectedValue);

                ddlSubCategoria.SelectedValue = objProducto.codSubCategoria;

                ddlMarca.SelectedValue = objProducto.codMarca;
                txtModelo.Text = objProducto.dscModelo;
                txtSerie.Text = objProducto.dscSerie;
                txtColor.Text = objProducto.dscColor;
                ddlEstado.SelectedValue = objProducto.dscEstado;
            }
            

        }
        
        private void ListarMarcas()
        {
            List<BE_Marca> lstMarca = BL_Marca.ListarMarcas();
            ddlMarca.DataSource = lstMarca;
            ddlMarca.DataValueField = "codMarca";
            ddlMarca.DataTextField = "dscMarca";
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
        }

        private void ListarCategorias()
        {
            List<BE_CategoriaProducto> lstCategoria = BL_Categoria.ListarCategorias();
            ddlCategoria.DataSource = lstCategoria;
            ddlCategoria.DataValueField = "codCategoria";
            ddlCategoria.DataTextField = "dscCategoria";
            ddlCategoria.DataBind();
            ddlCategoria.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
        }

        private void ListarSubCategorias(string codCategoria)
        {
            List<BE_SubCategoriaProducto> lstSubCategoria = BL_SubCategoria.ListarSubCategorias(codCategoria);
            ddlSubCategoria.DataSource = lstSubCategoria;
            ddlSubCategoria.DataValueField = "codSubCategoria";
            ddlSubCategoria.DataTextField = "dscSubCategoria";
            ddlSubCategoria.DataBind();
            ddlSubCategoria.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarSubCategorias(ddlCategoria.SelectedValue);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            
            BE_Usuario objSesionLogin = (BE_Usuario)Context.Session[Constantes.USUARIO_SESION];

            try
            {
                BE_Producto objProducto = new BE_Producto();
                
                objProducto.codMarca = ddlMarca.SelectedValue;
                objProducto.codSubCategoria = ddlSubCategoria.SelectedValue;
                objProducto.dscProducto = txtDescripcion.Text.Trim();
                objProducto.dscModelo = txtModelo.Text.Trim();
                objProducto.dscSerie = txtSerie.Text.Trim();
                objProducto.dscColor = txtColor.Text.Trim();
                objProducto.dscUsuCreacion = objSesionLogin.codUsuario;
                objProducto.dscUsuModificacion = objSesionLogin.codUsuario;
                objProducto.dscEstado = ddlEstado.SelectedValue;

                if (hfAccion.Value == Constantes.ACCION_NUEVO)
                {
                    objProducto.codProducto = BL_Producto.GenerarIdProducto();

                    if (BL_Producto.InsertarProducto(objProducto) == true)
                    {
                        string script = "$(function(){bettosimport.util.alertURL('" + Constantes.SUCCESS_DEFAULT_MESSAGE + "','" + WebUtil.AbsoluteWebRoot + "INV/Productos.aspx" + "')})";
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
                    objProducto.codProducto = txtCodigo.Text;

                    if (BL_Producto.ModificarProducto(objProducto) == true)
                    {
                        string script = "$(function(){bettosimport.util.alertURL('" + Constantes.SUCCESS_DEFAULT_MESSAGE + "','" + WebUtil.AbsoluteWebRoot + "INV/Productos.aspx" + "')})";
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
            Response.Redirect("Productos.aspx");
        }
    }
}