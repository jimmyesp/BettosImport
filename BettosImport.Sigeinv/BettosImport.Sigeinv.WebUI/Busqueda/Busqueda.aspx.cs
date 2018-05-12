using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BettosImport.Sigeinv.BusinessLogic.INV;
using BettosImport.Sigeinv.BusinessEntities.INV;
using BettosImport.Sigeinv.Common;

namespace BettosImport.Sigeinv.WebUI.Busqueda
{
    public partial class Busqueda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                Buscar();
            }
        }

        private void Buscar() {
            string dscProducto = string.Empty;
            string dscModelo = string.Empty;
            string dscTodos = string.Empty;

            if (ddlBuscarPor.SelectedValue == "TODOS")
            {
                dscTodos = ddlBuscarPor.SelectedValue;
            }
            else if (ddlBuscarPor.SelectedValue == "dscModelo")
            {
                dscModelo = txtValor.Text;
            }
            else if (ddlBuscarPor.SelectedValue == "dscProducto")
            {
                dscProducto = txtValor.Text;
            }

            gvBusqueda.DataSource = BL_Producto.ListarProductosActivos(dscModelo, dscProducto, dscTodos);
            gvBusqueda.DataBind();
        }

        protected void gvBusqueda_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBusqueda.PageIndex = e.NewPageIndex;
            Buscar();
        }

        protected void gvBusqueda_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button btn = (Button)e.Row.FindControl("btnSeleccionar");
                btn.OnClientClick = "javascript:retornarDatosProducto('" +
                                    DataBinder.Eval(e.Row.DataItem, "codProducto") + "','" +
                                    DataBinder.Eval(e.Row.DataItem, "dscProducto") + "','" +
                                    DataBinder.Eval(e.Row.DataItem, "dscMarca") + "','" +
                                    DataBinder.Eval(e.Row.DataItem, "dscCategoria") + "','" +
                                    DataBinder.Eval(e.Row.DataItem, "dscSubCategoria") + "');";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}