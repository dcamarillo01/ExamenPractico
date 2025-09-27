using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    //2. Crea una clase Animal con un método HacerSonido(), este método escribe en
    //consola el sonido que hace el animal.Implementa las clases Perro y Gato que
    //sobrescriban ese método.

    public class Animal
    {

        public virtual void HacerSonido()
        {
            Console.WriteLine("El animal hace un sonido");
        }

    }


    public class Perro : Animal
    {
        public override void HacerSonido()
        {
            Console.WriteLine("El perro ladra");
        }
    }

    public class Gato : Animal
    {
        public override void HacerSonido()
        {
            Console.WriteLine("El gato maulla");
        }
    }

}
