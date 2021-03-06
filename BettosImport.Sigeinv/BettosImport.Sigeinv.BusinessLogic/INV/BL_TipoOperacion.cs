﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BettosImport.Sigeinv.BusinessEntities.INV;
using BettosImport.Sigeinv.DataAccess.INV;

namespace BettosImport.Sigeinv.BusinessLogic.INV
{
    public class BL_TipoOperacion
    {
        public static List<BE_TipoOperacion> ListarTiposOperacionesEntradas()
        {
            return DA_TipoOperacion.ListarTiposOperacionesEntradas();
        }

        public static List<BE_TipoOperacion> ListarTiposOperacionesSalidas()
        {
            return DA_TipoOperacion.ListarTiposOperacionesSalidas();
        }

        public static BE_TipoOperacion GetTipoOperacion(string codTipoOperacion)
        {
            return DA_TipoOperacion.GetTipoOperacion(codTipoOperacion);
        }

        public static bool ActualizarCorrelativo(string codTipoOperacion)
        {
            return DA_TipoOperacion.ActualizarCorrelativo(codTipoOperacion);
        }
    }
}
