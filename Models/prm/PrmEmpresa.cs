using System;
using System.Collections.Generic;

#nullable disable

namespace EvaluacionEmpresa.Models.prm
{
    public partial class PrmEmpresa
    {
        public PrmEmpresa()
        {
            PrmColaboradors = new HashSet<PrmColaborador>();
            PrmEmpresaServicios = new HashSet<PrmEmpresaServicio>();
            PrmEmpresaTipoInformacions = new HashSet<PrmEmpresaTipoInformacion>();
            PrmEvaluacionEmpresas = new HashSet<PrmEvaluacionEmpresa>();
            PrmResponsables = new HashSet<PrmResponsable>();
        }

        public int IdEmpresa { get; set; }
        public int IdGiro { get; set; }
        public string Empresa { get; set; }
        public string RazonSocial { get; set; }
        public string Rfc { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Municipio { get; set; }
        public string Url { get; set; }
        public bool? Activa { get; set; }
        public DateTime? FechaActiva { get; set; }
        public string UsuarioActiva { get; set; }
        public string IpActiva { get; set; }
        public DateTime? FechaInActiva { get; set; }
        public string UsuarioInActiva { get; set; }
        public string IpInactiva { get; set; }
        public int? IdDependencia { get; set; }
        public int? IdArea { get; set; }

        public virtual PrmGiro IdGiroNavigation { get; set; }
        public virtual ICollection<PrmColaborador> PrmColaboradors { get; set; }
        public virtual ICollection<PrmEmpresaServicio> PrmEmpresaServicios { get; set; }
        public virtual ICollection<PrmEmpresaTipoInformacion> PrmEmpresaTipoInformacions { get; set; }
        public virtual ICollection<PrmEvaluacionEmpresa> PrmEvaluacionEmpresas { get; set; }
        public virtual ICollection<PrmResponsable> PrmResponsables { get; set; }
    }
}
