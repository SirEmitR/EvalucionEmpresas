using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionEmpresa.Models.custom
{
    public class prmEvaluar
    {
        public int IdEvaluacion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUAG { get; set; }
        public int IdEmpresa { get; set; }
        [Required]
        public bool Contrato { get; set; }
        [Required]
        public bool CConfidencialidad { get; set; }
        [Required]
        public bool PoliticasNormas { get; set; }
        [Required]
        public bool NvlServicio { get; set; }
        [Required]
        public bool Incidentes { get; set; }
        [Required]
        public string Comentarios1 { get; set; }
        [Required]
        public int Especializacion { get; set; }
        [Required]
        public int Solucion { get; set; }
        [Required]
        public int Tecnologia { get; set; }
        [Required]
        public int AtencionSoporte { get; set; }
        [Required]
        public int TiempoEntrega { get; set; }
        [Required]
        public int Precio { get; set; }
        [Required]
        public int Calidad { get; set; }
        [Required]
        public string Comentario2 { get; set; }
    }
}
