using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettosImport.Sigeinv.BusinessEntities.ADM
{
    public class BE_UsuarioTienda
    {
        public Int64 id{ get; set; }
        public string codTienda { get; set; }
        public string dscTienda { get; set; }
        public string codUsuario { get; set; }
        public string dscUsuCreacion { get; set; }
        public DateTime fecCreacion { get; set; }
        public string dscUsuModificacion { get; set; }
        public DateTime fecModificacion { get; set; }
        public string dscEstado { get; set; }
    }
}
