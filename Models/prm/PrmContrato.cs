using System;
using System.Collections.Generic;

#nullable disable

namespace EvaluacionEmpresa.Models.prm
{
    public partial class PrmContrato
    {
        public int IdContrato { get; set; }
        public int? IdEvaluacionEmpresa { get; set; }
        public bool? Contrato { get; set; }
        public bool? Cconfidencialidad { get; set; }
        public bool? PoliticasNormas { get; set; }
        public bool? NivelesServicio { get; set; }
        public bool? Incidentes { get; set; }
        public string Comentarios { get; set; }

        public virtual PrmEvaluacionEmpresa IdEvaluacionEmpresaNavigation { get; set; }
    }
}
