using System.ComponentModel;


//2.1 Escribe un programa que recorra una lista de 
//animales y ejecute sus sonidos.


BL.Animal miAnimal = new BL.Animal();
miAnimal.HacerSonido();

Console.WriteLine("----- Polimormismo --------");
//BL.Animal animalPerro = new BL.Perro();
//animalPerro.HacerSonido();
//BL.Perro perro = new BL.Perro();
//perro.HacerSonido();
//BL.Gato gato = new BL.Gato();
//gato.HacerSonido();

List<BL.Animal> animales = new List<BL.Animal>();
animales.Add(new BL.Perro());
animales.Add(new BL.Gato());

animales.ForEach(a => a.HacerSonido());


//4.Escribe un programa que pida al usuario ingresar un número entero y capture 
//la excepción si se ingresa un valor inválido.

Console.WriteLine("------------");
Console.WriteLine("Ingresa un numero entero");
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


BL.CuentaBancaria cuenta = new BL.CuentaBancaria();
//cuenta.Depositar(10);
//cuenta.Consultar();
//cuenta.Retirar(11);