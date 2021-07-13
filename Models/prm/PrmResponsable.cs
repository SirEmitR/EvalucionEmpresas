using System;
using System.Collections.Generic;

#nullable disable

namespace EvaluacionEmpresa.Models.prm
{
    public partial class PrmResponsable
    {
        public PrmResponsable()
        {
            PrmEvaluacionEmpresas = new HashSet<PrmEvaluacionEmpresa>();
        }

        public int IdResponsable { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdUag { get; set; }

        public virtual PrmEmpresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<PrmEvaluacionEmpresa> PrmEvaluacionEmpresas { get; set; }
    }
}
