using EvaluacionEmpresa.Models;
using EvaluacionEmpresa.Models.custom;
using EvaluacionEmpresa.Models.email;
using EvaluacionEmpresa.Models.prm;
using EvaluacionEmpresa.Models.querys;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionEmpresa.Controllers
{
    public class EvaluacionController : Controller
    {

        public IActionResult Index()
        {
            List<prmPeriodos> prmPeriodos = new List<prmPeriodos>();
            prmEvaluaciones prmEvaluaciones = new prmEvaluaciones();
            foreach( var evalauciones in prmEvaluaciones.Vigentes())
            {
                prmPeriodos.Add(prmEvaluaciones.Periodos(evalauciones,  2));
            }
            ViewBag.Periodos = prmPeriodos;
            return View();
        }

        public IActionResult Vigentes()
        {

            return RedirectToAction("Index");
        }
        public IActionResult Pasados()
        {
            List<prmPeriodos> prmPeriodos = new List<prmPeriodos>();
            prmEvaluaciones prmEvaluaciones = new prmEvaluaciones();
            foreach (var evalauciones in prmEvaluaciones.Pasados())
            {
                prmPeriodos.Add(prmEvaluaciones.Periodos(evalauciones, 2));
            }
            ViewBag.Periodos = prmPeriodos;
            return View();
        }
        [HttpGet]
        public IActionResult MisEmpresas(int uag)
        {
            prmEvaluaciones prm = new prmEvaluaciones();
            ViewBag.misEmpresas = prm.MisEmpresas(uag);
            ViewData["id"] = uag;
            return View();
        }
        public IActionResult NoEvaluadas(int IdUAG, int IdEvaluacion)
        {
            prmEvaluaciones prm = new prmEvaluaciones();
            ViewBag.NoEvaluadas = prm.NoEvaluadas(prm.MisEmpresas(IdUAG), IdEvaluacion, IdUAG);
            ViewData["IdEvaluacion"] = IdEvaluacion;
            return View();
        }
        public IActionResult Evaluar(int IdUAG, int IdEvaluacion, int IdEmpresa)
        {
            
            prmEmpresas prmEmpresas = new prmEmpresas();
            prmEvaluaciones prmEvaluaciones = new prmEvaluaciones();
            prmEvaluar prmEvaluar = new prmEvaluar();
            prmEvaluar.IdUAG = IdUAG;
            prmEvaluar.IdEmpresa = IdEmpresa;
            prmEvaluar.IdEvaluacion = IdEvaluacion;
            int ConfirmacionEvaluacion = prmEvaluaciones.confirmarEvaluacionEmpresa(prmEvaluar, 0);
            string empresa = prmEmpresas.Empresa(IdEmpresa);
            ViewData["IdEmpresa"] =IdEmpresa;
            ViewData["empresa"] = empresa;
            ViewData["evaluacion"] = IdEvaluacion;
            ViewData["uag"] = IdUAG;
            if (ConfirmacionEvaluacion != 0)
            {
                PrmContrato prmContrato = new PrmContrato();
                prmContrato = prmEvaluaciones.VerContrato(ConfirmacionEvaluacion);
                ViewBag.Contrato = prmContrato;
                ViewBag.a = ConfirmacionEvaluacion;
            }
            else
            {
                ViewBag.a = ConfirmacionEvaluacion;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GuardarEvaluacion(prmEvaluar prmEvaluar)
        {
                prmEvaluaciones prmEvaluaciones = new prmEvaluaciones();
                int IdResponsable = prmEvaluaciones.VerIdResponsable(prmEvaluar);
                prmEvaluaciones.AgregarEvaluacionEmpresa(prmEvaluar, IdResponsable);
                int IdEvaluacionEmpresa = prmEvaluaciones.confirmarEvaluacionEmpresa(prmEvaluar, IdResponsable);
                prmEvaluaciones.AgregarContrato(prmEvaluar, IdEvaluacionEmpresa);
                prmEvaluaciones.AgregarDesempenio(prmEvaluar, IdEvaluacionEmpresa);
                return RedirectToAction("Index");

        }
        public IActionResult EnviarCorreo()
        {
            email email = new email();
            email.Carta();
            return RedirectToAction("Index");
        }
    }
}
