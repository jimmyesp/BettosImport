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

                ListarTiendas();
                ListarTiposDocumentos();
            }

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
    }
}