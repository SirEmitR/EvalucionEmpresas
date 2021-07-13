using System;
using System.Collections.Generic;

#nullable disable

namespace EvaluacionEmpresa.Models.prm
{
    public partial class PrmEvaluacion
    {
        public PrmEvaluacion()
        {
            PrmEvaluacionEmpresas = new HashSet<PrmEvaluacionEmpresa>();
        }

        public int IdEvaluacion { get; set; }
        public string Periodo { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }

        public virtual ICollection<PrmEvaluacionEmpresa> PrmEvaluacionEmpresas { get; set; }
    }
}
