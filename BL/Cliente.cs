using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Cliente
    {

        private List<ML.Cliente>? clientes = [

        new ML.Cliente {

            IdCliente = 1,
            Cuenta = new ML.CuentaBancaria{
                IdCuenta = 1,
                Saldo = 1200
            },
            Nombre = "Cliente01"

        },

        new ML.Cliente
        {

            IdCliente = 1,
            Cuenta = new ML.CuentaBancaria {
                IdCuenta = 2,
                Saldo = 1200
            },
            Nombre = "Cliente02"


        },

        new ML.Cliente
        {

            IdCliente = 1,
            Cuenta = new ML.CuentaBancaria {
                IdCuenta = 01,
                Saldo = 1200
            },
            Nombre = "Cliente03"


        }
        ];

        private List<ML.Cliente>? clientesVacia;


        public ML.Result GetClientes()
        {


            var result = new ML.Result();
            try
            {

                if (clientes != null)
                {

                    result.Correct = true;
                    result.Object = clientes;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encontraron clientes";
                }

            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.ex = ex;

            }



            return result;
        }


    }
}
