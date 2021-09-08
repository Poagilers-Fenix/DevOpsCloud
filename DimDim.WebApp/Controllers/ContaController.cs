using DimDim.WebApp.Models;
using DimDim.WebApp.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DimDim.WebApp.Controllers
{
    public class ContaController : Controller
    {

        private static DataBaseContext ctx = new DataBaseContext();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            //Envia as opções do select do cadastro          
            var lista = ctx.Cliente.ToList<Cliente>();
            ViewBag.nomes = lista;
            ViewBag.status = new List<string>(new string[] { "A", "D" });
            return View();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            ViewBag.lista = ctx.Conta.ToList<Conta>();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Conta conta)
        {
            ctx.Conta.Add(conta);
            ctx.SaveChanges();
            TempData["msg"] = "Cadastrado com sucesso";

            return RedirectToAction("Cadastrar");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var conta = ctx.Conta.Find(id);
            ViewBag.status = new List<string>(new string[] { "A", "D" });
            return View(conta);

        }

        [HttpPost]
        public IActionResult Editar(Conta conta)
        {
            try
            {
                var entry = ctx.Conta.First(e => e.Id == conta.Id);
                ctx.Entry(entry).CurrentValues.SetValues(conta);
                ctx.SaveChanges();
                TempData["msg"] = "Conta atualizada!";
                return RedirectToAction("Listar");
            }
            catch(Exception e)
            {
                TempData["msg"] = "Problema ao atualizar a conta, veja se as informações estão corretas.";
                return RedirectToAction("Editar");
            }
        }

        [HttpPost]
        public IActionResult Listar(int id)
        {
            var conta = ctx.Conta.Find(id);
            ctx.Conta.Remove(conta);
            ctx.SaveChanges();
            TempData["msg"] = "Conta Removida!";
            return RedirectToAction("Listar");

        }

    }
}
