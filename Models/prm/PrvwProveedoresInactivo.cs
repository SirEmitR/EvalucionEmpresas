using System;
using System.Collections.Generic;

#nullable disable

namespace EvaluacionEmpresa.Models.prm
{
    public partial class PrvwProveedoresInactivo
    {
        public string Empresa { get; set; }
        public string RazonSocial { get; set; }
        public string Domicilio { get; set; }
        public string CorreoEmpresa { get; set; }
        public string TelefonoEmpresa { get; set; }
        public int IdColaborador { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Puesto { get; set; }
        public string Departamento { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Extension { get; set; }
        public int? IdDependencia { get; set; }
        public string Dependencia { get; set; }
        public int? Idarea { get; set; }
        public string Rhvdesasipre { get; set; }
    }
}
