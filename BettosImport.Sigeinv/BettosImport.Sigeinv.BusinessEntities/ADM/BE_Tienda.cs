using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettosImport.Sigeinv.BusinessEntities.ADM
{
    public class BE_Tienda
    {
        public Int64 id { get; set; }
        public string codTienda { get; set; }
        public BE_Sede codSede { get; set; }
        public string dscTienda { get; set; }
        public string dscRazonSocial { get; set; }
        public string dscRuc { get; set; }
        public string dscDireccion { get; set; }
        public string dscTelefono { get; set; }
        public string dscUsuCreacion { get; set; }
        public DateTime fecCreacion { get; set; }
        public string dssUsuModificacion { get; set; }
        public DateTime fecModificacion { get; set; }
        public string dscEstado { get; set; }
     
    }
}
