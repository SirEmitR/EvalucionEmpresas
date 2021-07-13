using System;
using System.Collections.Generic;

#nullable disable

namespace EvaluacionEmpresa.Models.prm
{
    public partial class PrmGiro
    {
        public PrmGiro()
        {
            PrmEmpresas = new HashSet<PrmEmpresa>();
        }

        public int IdGiro { get; set; }
        public string Giro { get; set; }

        public virtual ICollection<PrmEmpresa> PrmEmpresas { get; set; }
    }
}
