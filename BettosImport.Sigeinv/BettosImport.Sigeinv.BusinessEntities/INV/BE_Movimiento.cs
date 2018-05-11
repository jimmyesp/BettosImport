using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettosImport.Sigeinv.BusinessEntities.INV
{
    public class BE_Movimiento
    {
        public Int64 id { get; set; }
        public string dscAnio { get; set; }
        public string dscPeriodo { get; set; }
        public string codTienda { get; set; }
        public string codTipoOperacion { get; set; }
        public string codProducto { get; set; }
        public string dscMarca { get; set; }
        public string dscCategoria { get; set; }
        public string dscSubCategoria { get; set; }
        public string dscModelo { get; set; }
        public string dscNumDocOper { get; set; }
        public DateTime fecEmision { get; set; }
        public string codProveedor { get; set; }
        public string dscProveedor { get; set; }
        public string codTiendaOrigen { get; set; }
        public string dscTiendaOrigen { get; set; }
        public string codTiendaDestino { get; set; }
        public string dscTiendaDestino { get; set; }
        public int numCantidad { get; set; }
        public string codTipoDocumento { get; set; }
        public string dscTipoDocumento { get; set; }
        public string dscNumTipoDoc { get; set; }
        public string dscComentario { get; set; }
        public string dscUsuCreacion { get; set; }
        public DateTime fecCreacion { get; set; }
        public string dscUsuModificacion { get; set; }
        public DateTime fecModificacion { get; set; }
        public string dscEstado { get; set; }
    }
}
