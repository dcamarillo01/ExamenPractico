using System.ComponentModel;


//2.1 Escribe un programa que recorra una lista de 
//animales y ejecute sus sonidos.


BL.Animal miAnimal = new BL.Animal();
miAnimal.HacerSonido();

Console.WriteLine("----- Polimormismo --------");


List<BL.Animal> animales = new List<BL.Animal>();
animales.Add(new BL.Perro());
animales.Add(new BL.Gato());

animales.ForEach(a => a.HacerSonido());


//4.Escribe un programa que pida al usuario ingresar un número entero y capture 
//la excepción si se ingresa un valor inválido.

Console.WriteLine("------------");
Console.WriteLine("Ingresa un numero entero:");
var input = Console.ReadLine();
BL.Exepciones exepciones = new BL.Exepciones();
var result = exepciones.obtenerNumero(input);
if (result.Correct)
{
    Console.WriteLine("Formato Correcto!");
}
else
{
    Console.WriteLine(result.ErrorMessage);
    Console.WriteLine(result.ex);
}




// =============== MENU ================= 

bool seguir = true;

while (seguir)
{

    ML.CuentaBancaria cuenta = new ML.CuentaBancaria();
    Console.Clear();
    Console.WriteLine("===== Menú de Cuenta =====");
    Console.WriteLine("1. Crear cuenta");
    Console.WriteLine("2. Depositar");
    Console.WriteLine("3. Consultar saldo");
    Console.WriteLine("4. Retirar");
    Console.WriteLine("5. Salir");
    Console.Write("Elige una opción: ");

    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            // Crear cuenta
            Console.Write("Ingresa el monto a depositar: ");
            decimal montoInicial = Convert.ToDecimal(Console.ReadLine());
            var resultCuenta = new BL.CuentaBancaria().crearCuenta(montoInicial);
            if (resultCuenta.Correct)
            {
                cuenta = (ML.CuentaBancaria)resultCuenta.Object;
                Console.WriteLine("Tu numero de cuenta es:" + cuenta.IdCuenta);
            }
            else
            {
                Console.WriteLine(resultCuenta.ErrorMessage);
            }
            break;
        case "2":
            // Depositar
            Console.Write("Ingresa el id de cuenta: ");
            int idCuenta = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingresa el monto a depositar: ");
            decimal montoDepositar = Convert.ToDecimal(Console.ReadLine());
            var resultDepositar = new BL.CuentaBancaria().Depositar(idCuenta, montoDepositar);
            if (resultDepositar.Correct)
            {
                cuenta = (ML.CuentaBancaria)resultDepositar.Object;
                Console.Write("Deposito exitoso de: " + cuenta.Saldo);
            }
            else
            {
                Console.WriteLine(resultDepositar.ErrorMessage);
            }
            break;

        case "3":
            // Consultar saldo
            Console.Write("Ingrese el numero de cuenta");
            cuenta.IdCuenta = Convert.ToInt32(Console.ReadLine());
            var resultConsultar = new BL.CuentaBancaria().Consultar(cuenta.IdCuenta);
            if (resultConsultar.Correct)
            {
                cuenta = (ML.CuentaBancaria)resultConsultar.Object;
                Console.WriteLine("Tu saldo es de: " + cuenta.Saldo);
            }
            break;

        case "4":
            // Retirar
            Console.Write("Ingrese el numero de cuenta");
            cuenta.IdCuenta = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingresa el monto a retirar: ");
            decimal montoRetirar = Convert.ToDecimal(Console.ReadLine());
            var resultRetirar = new BL.CuentaBancaria().Retirar(cuenta.IdCuenta, montoRetirar);
            if (resultRetirar.Correct)
            {

                cuenta = (ML.CuentaBancaria)resultRetirar.Object;
                Console.WriteLine("Saldo restante:" + cuenta.Saldo);
            }
            break;

        case "5":
            // Salir
            Console.WriteLine("¡Gracias por usar el sistema!");
            seguir = false;
            break;

        default:
            // Opción inválida
            Console.WriteLine("Opción no válida. Intenta de nuevo.");
            break;
    }

    if (seguir)
    {
        Console.WriteLine("\nPresiona cualquier tecla para continuar...");
        Console.ReadKey();
    }
}



