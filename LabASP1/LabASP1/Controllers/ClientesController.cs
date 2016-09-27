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

        public ActionResult Details(string id)
        {
            Cliente cliente = baseDatos.Cliente.Find(id);

            ModeloIntermedio modelo = new ModeloIntermedio();
            modelo.listaClientes = baseDatos.Cliente.ToList();
            modelo.listaTelefonos = baseDatos.Telefono.ToList();
            modelo.listaCuentas = baseDatos.Cuenta.ToList();
            return View(modelo);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(String id)
        {
            if (ModelState.IsValid)
            {
                Cliente cliente = baseDatos.Cliente.Find(id);

                List<Telefono> telefonos = baseDatos.Telefono.Where(a => a.cedula == cliente.cedula).ToList();
                List<Cuenta> cuentas = baseDatos.Cuenta.Where(a => a.cedula == cliente.cedula).ToList();
                ModeloIntermedio modelo = new ModeloIntermedio();
                modelo.listaClientes = new List<Cliente>();
                modelo.listaClientes.Add(cliente);
                modelo.listaTelefonos = telefonos;
                modelo.listaCuentas = cuentas;
                modelo.modeloCliente = cliente;
                modelo.modeloTelefono = telefonos.ElementAt(0);
                modelo.modeloCuenta = cuentas.ElementAt(0);
                baseDatos.SaveChanges();

                return View(modelo);
                return RedirectToAction("Index");

            }

            else
            {
                ModelState.AddModelError("", "Debe completar toda la información necesaria.");
                return View();
            }

        }

    }

}