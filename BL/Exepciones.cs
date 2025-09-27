using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Exepciones
    {



        public ML.Result obtenerNumero(string numero)
        {

            ML.Result result = new ML.Result();


            try
            {

                var input = int.Parse(numero);
                result.Correct = true;

            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.ex = ex;

            }

            return result;

        }


        //5. Define una excepción llamada SaldoInsuficienteException y úsala en el
        //método Retirar(decimal monto) de la clase CuentaBancaria.

        public class SaldoInsuficienteException : Exception
        {

            public SaldoInsuficienteException()
            { }

            public SaldoInsuficienteException(string message)
                : base(message)
            { }

            public SaldoInsuficienteException(string message, Exception innerException)
                : base(message, innerException)
            { }
        }

    }
}
