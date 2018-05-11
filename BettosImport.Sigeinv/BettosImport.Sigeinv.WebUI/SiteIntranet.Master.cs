using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using BettosImport.Sigeinv.BusinessLogic.ADM;
using BettosImport.Sigeinv.BusinessEntities.ADM;
using BettosImport.Sigeinv.Common;

namespace BettosImport.Sigeinv.WebUI
{
    public partial class SiteIntranet : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page.IsPostBack))
            {
                CargarMenu();
            }
        }


        private void CargarMenu()
        {
            BE_Usuario objSesionLogin = (BE_Usuario)Context.Session[Constantes.USUARIO_SESION];

            List<BE_MenuWeb> lstMenuWeb = BL_MenuWeb.ListarOpcionesRol(objSesionLogin.codRol);

            string ruta = WebUtil.AbsoluteWebRoot.ToString();

            var strMenu = new StringBuilder();


            foreach (BE_MenuWeb item in lstMenuWeb.Where(x => x.codPadre == "00"))
            {
                strMenu.Append("<ul >");
                strMenu.Append("<li><a href=\'#\'>");
                strMenu.Append(item.dscOpcion);
                strMenu.Append("</a>");

                strMenu.Append("<ul>");
                foreach (BE_MenuWeb itemHijo in lstMenuWeb.Where(x => x.codPadre == item.codOpcion))
                {
                    strMenu.Append("<li><a href=\'");
                    strMenu.Append(itemHijo.dscUrl);
                    strMenu.Append("\' title=\'");
                    strMenu.Append(itemHijo.dscOpcion);
                    strMenu.Append("\'>");
                    strMenu.Append(itemHijo.dscOpcion);
                    strMenu.Append("</a></li>");
                }
                strMenu.Append("</ul>");
                strMenu.Append("</li>");
                strMenu.Append("</ul>");
            }
            divmenu.InnerHtml = strMenu.ToString();
        }
    }

    
}