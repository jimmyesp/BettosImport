using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettosImport.Sigeinv.BusinessEntities.INV
{
    public class BE_Producto
    {
        public Int64 id { get; set; }
        public string codProducto { get; set; }
        public string  codMarca { get; set;  }
        public string dscMarca { get; set; }
        public string codCategoria { get; set; }
        public string dscCategoria { get; set; }
        public string codSubCategoria { get; set; }
        public string dscSubCategoria { get; set; }
        public string dscProducto { get; set; }
        public string dscModelo { get; set; }
        public string dscSerie { get; set; }
        public string dscColor { get; set; }
        public string dscUsuCreacion { get; set; }
        public DateTime fecCreacion { get; set; }
        public string dscUsuModificacion { get; set; }
        public DateTime fecModificacion { get; set; }
        public string dscEstado { get; set; }

    }
}
