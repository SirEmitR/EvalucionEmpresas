using System;
using System.Collections.Generic;

#nullable disable

namespace EvaluacionEmpresa.Models.prm
{
    public partial class PrmServicio
    {
        public PrmServicio()
        {
            PrmEmpresaServicios = new HashSet<PrmEmpresaServicio>();
        }

        public int IdServicio { get; set; }
        public string Servicio { get; set; }

        public virtual ICollection<PrmEmpresaServicio> PrmEmpresaServicios { get; set; }
    }
}
