using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Login
    {

        public ML.Result verificarCredenciales(ML.Login login)
        {

            var result = new ML.Result();

            List<ML.Login> cuentas = [

                new ML.Login {
                    Usuario = "Admin",
                    Password = "Y?G\u001a?\u0001\u0011*???Y??t??\u0011??\u0006?Y?????s???"
                },
                new ML.Login {
                    Usuario = "Diego01",
                    Password = "?\u0015r?J?8????\u0017?xQ}?W?T?\u001b?4Y^y\f\u0010{\u0005\u0005"
                }




                ];

            var mathUsuario = cuentas.FirstOrDefault(cuenta => cuenta.Usuario == login.Usuario && cuenta.Password == login.Password);


            if (mathUsuario != null)
            {
                result.Correct = true;
                result.Object = login.Usuario;
            }
            else
            {
                result.Correct = false;
                result.ErrorMessage = "Credenciales Incorrectas";
            }

            return result;

        }


    }
}
