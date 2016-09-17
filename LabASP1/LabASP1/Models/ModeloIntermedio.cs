using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabASP1.Models
{
    public class ModeloIntermedio
    {
        public Cliente modeloCliente { get; set; }
        public Telefono modeloTelefono { get; set; }
        public Cuenta modeloCuenta { get; set; }
        public List<Cliente> listaClientes { get; set; }
        public List<Telefono> listaTelefonos { get; set; }
        public List<Cuenta> listaCuentas { get; set; }

    }
}
