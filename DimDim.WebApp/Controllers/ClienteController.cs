using DimDim.WebApp.Models;
using DimDim.WebApp.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DimDim.WebApp.Controllers
{
    public class ClienteController : Controller
    {
        private static DataBaseContext ctx = new DataBaseContext();

        [HttpGet]
        public IActionResult Index()
        {
            return View(ctx.Cliente.ToList<Cliente>());
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
            ctx.Cliente.Add(cliente);
            ctx.SaveChanges();
            TempData["msg"] = "Cadastrado com sucesso";

            return RedirectToAction("Cadastrar");
        }

    }
}
