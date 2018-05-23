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
                ListarDetalleProductos();
            }
        }

        private void ListarDetalleProductos()
        {
            List<BE_DetalleProductoTienda> lstDetProd = BL_DetalleProductoTienda.ListarDetalleProductos(txtDscProducto.Text);  
            gvListado.DataSource = lstDetProd;
            gvListado.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ListarDetalleProductos();
            lblTotal.InnerText = "0";
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvListado.PageIndex = e.NewPageIndex;
            ListarDetalleProductos();
        }
    }
}