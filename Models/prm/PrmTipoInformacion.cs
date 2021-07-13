using System;
using System.Collections.Generic;

#nullable disable

namespace EvaluacionEmpresa.Models.prm
{
    public partial class PrmTipoInformacion
    {
        public PrmTipoInformacion()
        {
            PrmEmpresaTipoInformacions = new HashSet<PrmEmpresaTipoInformacion>();
        }

        public int IdTipoInfo { get; set; }
        public string TipoInformacion { get; set; }

        public virtual ICollection<PrmEmpresaTipoInformacion> PrmEmpresaTipoInformacions { get; set; }
    }
}
