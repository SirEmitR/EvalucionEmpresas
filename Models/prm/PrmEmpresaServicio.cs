using System;
using System.Collections.Generic;

#nullable disable

namespace EvaluacionEmpresa.Models.prm
{
    public partial class PrmEmpresaServicio
    {
        public int IdEmpSvr { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdServicio { get; set; }

        public virtual PrmEmpresa IdEmpresaNavigation { get; set; }
        public virtual PrmServicio IdServicioNavigation { get; set; }
    }
}
