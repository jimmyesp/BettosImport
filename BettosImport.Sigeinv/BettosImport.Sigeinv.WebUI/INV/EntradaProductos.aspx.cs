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

                TxtFecEmision.Text = DateTime.Today.ToString(Constantes.FORMAT_YYYY_MM_DD);
                DateTime fecha = Convert.ToDateTime(TxtFecEmision.Text);
                string anio = fecha.Year.ToString();
                string periodo = fecha.Month.ToString("00");

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
    }
}