using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{

    //1. Crea una clase CuentaBancaria con una propiedad Saldo que solo pueda 
    //modificarse dentro de la clase, y un método Depositar(decimal monto).
    public class CuentaBancaria
    {

        private decimal Saldo { get; set; }



        public ML.Result Depositar(int idCuenta, decimal monto)
        {

            var result = new ML.Result();

            try
            {

                if (idCuenta == 1)
                {
                    Saldo += monto;
                    //Si no salata exception 
                    result.Correct = true;
                    result.Object = Saldo;
                }
                else
                {

                    result.Correct = false;
                    result.ErrorMessage = "Cuenta no encontrada";

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

        public void Consultar()
        {

            Console.WriteLine(Saldo);
        }

        public ML.Result Retirar(int idCuenta, decimal monto)
        {

            var result = new ML.Result();



            Saldo = 200;

            if (monto > Saldo)
            {
                result.Correct = false;
                result.ErrorMessage = "Saldo insuficiente";
                result.ex = new BL.Exepciones.SaldoInsuficienteException("Tu saldo es insuficiente");

            }
            else
            {
                Saldo -= monto;
                result.Correct = true;
                result.Object = Saldo;
            }



            return result;

        }


        public ML.Result Maximo(ML.Saldo saldo)
        {

            var result = new ML.Result();

            try
            {

                List<decimal?> Saldos = [saldo.Saldo1, saldo.Saldo2, saldo.Saldo3];

                if (Saldos != null)
                {

                    result.Correct = true;
                    result.Object = Saldos.Max();
                }
                else
                {

                    result.Correct = false;
                    result.ErrorMessage = "Lista de Saldos vacia";
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


        public ML.Result Ordenar(ML.Saldos saldos)
        {

            var result = new ML.Result();

            try
            {

                if (saldos.ListaSaldos != null)
                {

                    result.Correct = true;
                    //saldos.ListaSaldos.Sort();
                    var ordenado = saldos.ListaSaldos.OrderBy(m => m).Select(m => m).ToList();

                    result.Object = ordenado;

                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "Lista de Saldos vacia";
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
