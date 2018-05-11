using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.ADM;

namespace BettosImport.Sigeinv.BusinessEntities.INV
{
    public class BE_DetalleProductoTienda
    {
        public Int64 id { get; set; }
        public BE_Producto codProducto { get; set; }
        public BE_Tienda codTienda { get; set; }
        public int cntProducto { get; set; }
        public string dscUsuCreacion { get; set; }
        public DateTime fecCreacion { get; set; }
        public string dscUsuModificacion { get; set; }
        public DateTime fecModificacion { get; set; }
        public string dscEstado { get; set; }
      
    }
}
