using System;
using System.Collections.Generic;

#nullable disable

namespace EvaluacionEmpresa.Models.prm
{
    public partial class PrmColaborador
    {
        public int IdColaborador { get; set; }
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Puesto { get; set; }
        public string Departamento { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Extension { get; set; }
        public byte[] Foto { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaActivo { get; set; }
        public string UsuarioActivo { get; set; }
        public string IpActivo { get; set; }
        public DateTime? FechaInActivo { get; set; }
        public string UsuarioInActivo { get; set; }
        public string IpInactiva { get; set; }

        public virtual PrmEmpresa IdEmpresaNavigation { get; set; }
    }
}
