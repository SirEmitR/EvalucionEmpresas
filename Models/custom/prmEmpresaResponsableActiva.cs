using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionEmpresa.Models.custom
{
    public class prmEmpresaResponsableActiva
    {
        public int IdEmpresa { get; set; }
        public string Giro { get; set; }
        public string Empresa { get; set; }
        public string RazonSocial { get; set; }
        public string RFC { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string URL { get; set; }
    }
}
