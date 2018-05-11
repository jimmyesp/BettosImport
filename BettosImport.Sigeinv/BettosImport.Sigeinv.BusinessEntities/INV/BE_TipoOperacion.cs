using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettosImport.Sigeinv.BusinessEntities.INV
{
    public class BE_TipoOperacion
    {
        public Int64 id { get; set; }
        public string codTipoOperacion { get; set; }
        public string dscTipoOperacion { get; set; }
        public string tipoOperacion { get; set; }
        public string dscCorrelativo { get; set; }
        public string dscUsuCreacion { get; set; }
        public DateTime fecCreacion { get; set; }
        public string dscUsuModificacion { get; set; }
        public DateTime fecModificacion { get; set; }
        public string dscEstado { get; set; }
    }
}
