using System;
using System.Collections.Generic;

#nullable disable

namespace EvaluacionEmpresa.Models.prm
{
    public partial class PrmEmpresaTipoInformacion
    {
        public int IdEmpInfo { get; set; }
        public int IdEmpresa { get; set; }
        public int IdTipoInfo { get; set; }
        public bool? Transfiere { get; set; }

        public virtual PrmEmpresa IdEmpresaNavigation { get; set; }
        public virtual PrmTipoInformacion IdTipoInfoNavigation { get; set; }
    }
}
