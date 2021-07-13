using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionEmpresa.Models.custom
{
    public class prmPeriodos
    {
        public int IdEvaluacion { get; set; }
        public string Periodo { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int Totales { get; set; }
        public int Completos { get; set; }
    }
}
