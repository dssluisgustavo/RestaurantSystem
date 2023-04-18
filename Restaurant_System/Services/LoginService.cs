using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Services.Interfaces;

namespace Services
{
    [Serializable]
    public class LoginService : ILoginService
    {
        /* método para efetuar login
         * {
         *  pega login e compara
         *  pega senha e compara
         *  }
         *  */
        
        // método para efetuar logout

        public Login Login(Login login)
        {
            //pega user no repository para comparar info com o login
            //User user = repository (login.username)

            User user = new User(); // user ilustrativo

            if(login == null
             ||login.Username != user.Username 
             ||login.Password != user.Password)
            {
                return null;
            }

            // gera token
            // retorna token

            throw new NotImplementedException();
        }
        public void Logout()
        {
            // User user = Repository
            throw new NotImplementedException();
        }
    }
}