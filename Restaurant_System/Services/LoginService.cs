using Domain;
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
            User user = _contextRestaurant.Users.FirstOrDefault(userReq => userReq.Username == login.Username);

            if (login == null)
            {
                return null;
            }
            if (user == null
             || login.Password != user.Password)
            {
                return null;
            }

            // gera token
            TokenService token = new TokenService();

            string newToken = token.GenerateToken(user);

            // retorna token
            return newToken;
        }
        public void Logout(string userToken)
        {

            string deletedToken = userToken.Remove(1, 2);

        }
    }
}