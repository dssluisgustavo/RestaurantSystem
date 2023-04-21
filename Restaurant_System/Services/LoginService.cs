using Domain;
using Domain.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Services.Context;
using Services.Interfaces;

namespace Services
{
    [Serializable]
    public class LoginService : ILoginService
    {

        private readonly RestaurantContext _contextRestaurant;
        public LoginService(Context.RestaurantContext restaurantContext)
        {
            _contextRestaurant = restaurantContext;
        }
        public string Login(Login login)
        {
            //pega user no repository para comparar info com o login
            User user = _contextRestaurant.Users.FirstOrDefault(user => user.Username == login.Username);

            if (login == null)
            {
                return null;
            }
            if (user == null
             || login.Password.ToMD5() != user.Password)
            {
                return null;
            }

            // gera token
            TokenService token = new TokenService();

            string newToken = token.GenerateToken(user);

            // retorna token
            return newToken;
        }
    }
}