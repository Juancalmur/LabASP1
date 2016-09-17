using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabASP1.Models;
namespace LabASP1.Controllers
{
    public class ClientesController : Controller
    {
        LabASP1_Entities baseDatos = new LabASP1_Entities();

        public ActionResult Index()
        {
            ModeloIntermedio modelo = new ModeloIntermedio();
            modelo.listaClientes = baseDatos.Cliente.ToList();
            modelo.listaTelefonos = baseDatos.Telefono.ToList();
            modelo.listaCuentas = baseDatos.Cuenta.ToList();
            return View(modelo);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ModeloIntermedio modelo)
        {
            if (ModelState.IsValid)
            {
                baseDatos.Cliente.Add(modelo.modeloCliente);
                baseDatos.SaveChanges();
                if (modelo.modeloCuenta.numero != null)
                {
                    modelo.modeloCuenta.cedula = modelo.modeloCliente.cedula;
                    baseDatos.Cuenta.Add(modelo.modeloCuenta);
                }
                if (modelo.modeloTelefono.numero != null)
                {
                    modelo.modeloTelefono.cedula = modelo.modeloCliente.cedula;
                    baseDatos.Telefono.Add(modelo.modeloTelefono);
                }
                baseDatos.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Debe completar toda la información necesaria.");
                return View(modelo);
            }
        }
    }

}