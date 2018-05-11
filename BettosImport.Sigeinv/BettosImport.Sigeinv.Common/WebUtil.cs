using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BettosImport.Sigeinv.Common
{
    public class WebUtil
    {
        private static string rutaRealitva;

        /// <summary>
        /// Retorna la ruta relativa del sitio
        /// </summary>
        public static string RelativeWebRoot
        {

            get {
                if (string.IsNullOrEmpty(rutaRealitva)) {
                    rutaRealitva = VirtualPathUtility.ToAbsolute("~/");
                }
                return rutaRealitva;
            }
        }

        /// <summary>
        /// Retorna la ruta absoluta del sitio
        /// </summary>
        public static Uri AbsoluteWebRoot {
          get {
                HttpContext context = HttpContext.Current;

                if(context == null){
                    throw new System.Net.WebException("El contexto es nulo");
                }

                if (context.Items["absoluteurl"] == null)
                {
                    context.Items["absoluteurl"] = new Uri(context.Request.Url.GetLeftPart(UriPartial.Authority) + RelativeWebRoot);
                }

                return (Uri)(context.Items["absoluteurl"]);
            }    
        }
        
    }
}
