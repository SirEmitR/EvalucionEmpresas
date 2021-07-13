using System;
using System.Collections.Generic;

#nullable disable

namespace EvaluacionEmpresa.Models.prm
{
    public partial class PrmEvaluacionEmpresa
    {
        public PrmEvaluacionEmpresa()
        {
            PrmContratos = new HashSet<PrmContrato>();
            PrmDesempenios = new HashSet<PrmDesempenio>();
        }

        public int IdEvaluacionEmpresa { get; set; }
        public int? IdEvaluacion { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdResponsable { get; set; }

        public virtual PrmEmpresa IdEmpresaNavigation { get; set; }
        public virtual PrmEvaluacion IdEvaluacionNavigation { get; set; }
        public virtual PrmResponsable IdResponsableNavigation { get; set; }
        public virtual ICollection<PrmContrato> PrmContratos { get; set; }
        public virtual ICollection<PrmDesempenio> PrmDesempenios { get; set; }
    }
}
