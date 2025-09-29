using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace SL_REST.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {

        private readonly BL.CuentaBancaria _cuentaBancaria;
        public CuentaController(BL.CuentaBancaria cuentaBancaria) => _cuentaBancaria = cuentaBancaria;

        /// <summary>
        /// Depositar Saldo
        /// </summary>
        [HttpPost]
        [Route("/cuentas/depositar")]
        public IActionResult Depositar(int idCuenta, decimal monto)
        {

            var result = _cuentaBancaria.Depositar(idCuenta, monto);
            if (result.Correct)
            {
                return Ok(new { Deposito = result.Object });
            }
            else
            {
                return BadRequest(result);
            }

        }

        /// <summary>
        /// Retirar Saldo
        /// </summary>
        [HttpPost]
        [Route("/cuentas/retirar")]
        public IActionResult Retirar(int idCuenta, decimal monto)
        {

            var result = _cuentaBancaria.Retirar(idCuenta, monto);


            return Ok(new { SaldoRestante = result.Object });



        }

        /// <summary>
        /// Maximo Saldo
        /// </summary>
        [HttpPost]
        [Route("/cuentas/maximo")]
        public IActionResult Maximo([FromBody] ML.Saldo saldo)
        {

            var result = _cuentaBancaria.Maximo(saldo);
            if (result.Correct)
            {
                return Ok(new { Maximo = result.Object });

            }
            else
            {
                return BadRequest(result);
            }

        }

        /// <summary>
        /// Saldos ordenado
        /// </summary>
        [HttpPost]
        [Route("/cuentas/ordenar")]
        public IActionResult Ordenar([FromBody] ML.Saldos saldos)
        {

            var result = _cuentaBancaria.Ordenar(saldos);
            if (result.Correct)
            {
                return Ok(new { Ordenados = result.Object });
            }
            else
            {
                return BadRequest(result);
            }

        }


    }
}
