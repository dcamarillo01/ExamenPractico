using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Cliente
    {

        public int IdCliente { get; set; }

        public ML.CuentaBancaria? Cuenta { get; set; }
        public string? Nombre { get; set; }


    }
}
