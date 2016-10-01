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
                if (modelo.modeloCuenta2.numero != null)
                {
                    modelo.modeloCuenta2.cedula = modelo.modeloCliente.cedula;
                    baseDatos.Cuenta.Add(modelo.modeloCuenta2);
                }
                if (modelo.modeloCuenta3.numero != null)
                {
                    modelo.modeloCuenta3.cedula = modelo.modeloCliente.cedula;
                    baseDatos.Cuenta.Add(modelo.modeloCuenta3);
                }
                if (modelo.modeloTelefono.numero != null)
                {
                    modelo.modeloTelefono.cedula = modelo.modeloCliente.cedula;
                    baseDatos.Telefono.Add(modelo.modeloTelefono);
                }
                if (modelo.modeloTelefono2.numero != null)
                {
                    modelo.modeloTelefono2.cedula = modelo.modeloCliente.cedula;
                    baseDatos.Telefono.Add(modelo.modeloTelefono2);
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

            List<Telefono> telefonos = baseDatos.Telefono.Where(a => a.cedula == cliente.cedula).ToList();
            List<Cuenta> cuentas = baseDatos.Cuenta.Where(a => a.cedula == cliente.cedula).ToList();

            ModeloIntermedio modelo = new ModeloIntermedio();

            modelo.listaClientes = new List<Cliente>();
            modelo.listaClientes.Add(cliente);
            modelo.listaTelefonos = telefonos;
            modelo.listaCuentas = cuentas;

            return View(modelo);
        }

        public ActionResult Edit(string id)
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
            modelo.modeloTelefono2 = telefonos.ElementAt(1);
            modelo.modeloCuenta = cuentas.ElementAt(0);
            modelo.modeloCuenta2 = cuentas.ElementAt(1);
            modelo.modeloCuenta3 = cuentas.ElementAt(2);

            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModeloIntermedio modelo, string id)
        {
            if (ModelState.IsValid)
            {
                baseDatos.Cliente.Attach(modelo.modeloCliente);
                baseDatos.Entry(modelo.modeloCliente).State = System.Data.Entity.EntityState.Modified;
                baseDatos.SaveChanges();
                if (modelo.modeloTelefono.numero != null)
                {
                    modelo.modeloTelefono.cedula = modelo.modeloCliente.cedula;
                    baseDatos.Entry(modelo.modeloTelefono).State = System.Data.Entity.EntityState.Modified;
                    baseDatos.SaveChanges();
                }
                if (modelo.modeloTelefono2.numero != null)
                {
                    modelo.modeloTelefono2.cedula = modelo.modeloCliente.cedula;
                    baseDatos.Entry(modelo.modeloTelefono2).State = System.Data.Entity.EntityState.Modified;
                    baseDatos.SaveChanges();
                }
                if (modelo.modeloCuenta.numero != null)
                {
                    modelo.modeloCuenta.cedula = modelo.modeloCliente.cedula;
                    baseDatos.Entry(modelo.modeloCuenta).State = System.Data.Entity.EntityState.Modified;
                    baseDatos.SaveChanges();
                }
                if (modelo.modeloCuenta2.numero != null)
                {
                    modelo.modeloCuenta2.cedula = modelo.modeloCliente.cedula;
                    baseDatos.Entry(modelo.modeloCuenta2).State = System.Data.Entity.EntityState.Modified;
                    baseDatos.SaveChanges();
                }
                if (modelo.modeloCuenta3.numero != null)
                {
                    modelo.modeloCuenta3.cedula = modelo.modeloCliente.cedula;
                    baseDatos.Entry(modelo.modeloCuenta3).State = System.Data.Entity.EntityState.Modified;
                    baseDatos.SaveChanges();
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

        public ActionResult Delete(string id)
        {
            Cliente cliente = baseDatos.Cliente.Find(id);

            List<Telefono> telefonos = baseDatos.Telefono.Where(a => a.cedula == cliente.cedula).ToList();
            List<Cuenta> cuentas = baseDatos.Cuenta.Where(a => a.cedula == cliente.cedula).ToList();

            ModeloIntermedio modelo = new ModeloIntermedio();

            modelo.listaClientes = new List<Cliente>();
            modelo.listaClientes.Add(cliente);
            modelo.listaTelefonos = telefonos;
            modelo.listaCuentas = cuentas;

            return View(modelo);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cliente cliente = baseDatos.Cliente.Find(id);
            //baseDatos.Telefono.Remove(cliente);
            //baseDatos.Cuenta.Remove(cliente);
            baseDatos.Cliente.Remove(cliente);
            baseDatos.SaveChanges();
            return RedirectToAction("Index");
        }

    }

}