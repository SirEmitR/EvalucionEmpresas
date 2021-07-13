using EvaluacionEmpresa.Models.prm;
using EvaluacionEmpresa.Models.querys;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionEmpresa.Controllers
{
    public class PeriodoController : Controller
    {
        private readonly bdSistemasContext _db;

        public PeriodoController(bdSistemasContext database)
        {
            _db = database;
        }
        public IActionResult Index()
        {
            prmEvaluaciones periodos = new prmEvaluaciones();
            ViewBag.Periodo = periodos.Vigentes();
            return View();
        }
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(PrmEvaluacion prmEvaluacion)
        {
            prmEvaluaciones prmevaluaciones = new prmEvaluaciones();
            prmevaluaciones.AgregarEvaluacion(prmEvaluacion);
            //_db.PrmEvaluaciones.Add(prmEvaluacion);
            //_db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
