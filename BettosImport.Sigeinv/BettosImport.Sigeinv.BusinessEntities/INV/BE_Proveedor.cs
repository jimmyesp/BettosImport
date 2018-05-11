using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettosImport.Sigeinv.BusinessEntities.INV
{
    public class BE_Proveedor
    {
        public Int64 id { get; set; }
        public string codProveedor { get; set; }
        public string dscProveedor { get; set; }
        public string dscRuc { get; set; }
        public string dscDireccion { get; set; }
        public string dscTelefono { get; set; }
        public string dscCorreo { get; set; }
        public string dscUsuCreacion { get; set; }
        public DateTime fecCreacion { get; set; }
        public string dscUsuModificacion { get; set; }
        public DateTime fecModificacion { get; set; }
        public string dscEstado { get; set; }
    }
}
