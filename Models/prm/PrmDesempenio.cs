using System;
using System.Collections.Generic;

#nullable disable

namespace EvaluacionEmpresa.Models.prm
{
    public partial class PrmDesempenio
    {
        public int IdDesempenio { get; set; }
        public int? IdEvaluacionEmpresa { get; set; }
        public DateTime? Fecha { get; set; }
        public double? Especializacion { get; set; }
        public double? Solucion { get; set; }
        public double? Tecnologia { get; set; }
        public double? AtencionSoporte { get; set; }
        public double? TiempoEntrega { get; set; }
        public double? Precio { get; set; }
        public double? Calidad { get; set; }
        public string Comentarios { get; set; }

        public virtual PrmEvaluacionEmpresa IdEvaluacionEmpresaNavigation { get; set; }
    }
}
