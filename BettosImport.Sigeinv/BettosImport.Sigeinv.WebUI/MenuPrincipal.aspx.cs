using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BettosImport.Sigeinv.BusinessLogic.INV;
using BettosImport.Sigeinv.BusinessEntities.INV;

namespace BettosImport.Sigeinv.WebUI
{
    public partial class MenuPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
             
               // ListarDetalleProductos();
            }
        }

        //private void ListarProductos()
        //{
        //    List<BE_Producto> lstProducto = BL_Producto.ListarProductos("");
        //    ddlBuscar.DataSource = lstProducto;
        //    ddlBuscar.DataValueField = "codProducto";
        //    ddlBuscar.DataTextField = "dscProducto";
        //    ddlBuscar.DataBind();
        //    ddlBuscar.Items.Insert(0, new ListItem("--Seleccione--", String.Empty));

        //}

        private void ListarDetalleProductos()
        {
            List<BE_DetalleProductoTienda> lstDetProd = BL_DetalleProductoTienda.ListarDetalleProductos(txtDscProducto.Text);  
            gvListado.DataSource = lstDetProd;
            gvListado.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarDetalleProductos();
            lblTotal.InnerText = tot.ToString();
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;
            ListarDetalleProductos();
        }

        Int32 tot = 0;
        protected void gvListado_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                tot = tot + Convert.ToInt32(e.Row.Cells[3].Text);
                lblTotal.InnerText = tot.ToString();
            }
        }

    
    }
}