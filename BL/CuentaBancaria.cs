using ML;
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

        private static decimal Saldo { get; set; } = 200;

        private List<ML.CuentaBancaria>? cuentas = [
        
        new ML.CuentaBancaria{
                IdCuenta = 1,
                Saldo = 1800
            },
        new ML.CuentaBancaria {
                IdCuenta = 2,
                Saldo = 700
            },
       new ML.CuentaBancaria {
                IdCuenta = 3,
                Saldo = 250
       }
       ];


        public ML.Result Depositar(int idCuenta, decimal monto)
        {

            var result = new ML.Result();
            var cuenta = cuentas.FirstOrDefault(m => m.IdCuenta == idCuenta);


            if (cuenta != null)
            {
                cuenta.Saldo += monto;
                //Si no salata exception 
                result.Correct = true;
                result.Object = cuenta;
            }
            else
            {

                result.Correct = false;
                result.ErrorMessage = "Cuenta no encontrada";

            }

            return result;
        }

        public ML.Result crearCuenta(decimal SaldoInicial) {

            var result = new ML.Result();

            if (SaldoInicial > 50)
            {

                var numeroCuentas = cuentas.Count();
                var nuevaCuenta = new ML.CuentaBancaria
                {
                    IdCuenta = numeroCuentas + 1,
                    Saldo = SaldoInicial
                };
                cuentas.Add(nuevaCuenta);
                result.Correct = true;
                result.Object = nuevaCuenta;
            }
            else {

                result.Correct = false;
                result.ErrorMessage = "Para abrir una cuenta tienes que hacer un deposito mayor a 50";
            }

            return result;

        }

        public ML.Result Consultar(int IdCuenta)
        {

            var result = new ML.Result();
            var cuenta = cuentas.FirstOrDefault(m => m.IdCuenta == IdCuenta);

            if (cuenta != null)
            {
                result.Correct = true;
                result.Object = cuenta;
            }
            else {
                result.Correct = false;
                result.ErrorMessage = "No se encontro cuenta";
            }

            return result;
        }

        public ML.Result Retirar(int idCuenta, decimal monto)
        {

            var result = new ML.Result();
            var cuenta = cuentas.FirstOrDefault(m => m.IdCuenta == idCuenta);


            if (cuenta != null) {
                if (monto > Saldo)
                {
                    throw new BL.Exepciones.SaldoInsuficienteException("");

                }
                else
                {
                    cuenta.Saldo -= monto;
                    result.Correct = true;
                    result.Object = cuenta;
                }
            }
            else {
                result.Correct = false;
                result.ErrorMessage = "No se encontro cuenta";
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
