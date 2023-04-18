using Domain;
using Domain.Settings;
using Services.Context;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    [Serializable]
    public class UserService : IUserService
    {
        private readonly RestaurantContext _contextRestaurant;
        public UserService(Context.RestaurantContext restaurantContext)
        {
             _contextRestaurant = restaurantContext; 
        }
        // método para a criação de usuário
        // método para deletar
        public User CreateAccount(User user)
        {

            if (user.Username.Length.IsBetween(4, 10) && user.Password.Length.IsBetween(8, 16))
            {
                var cripto = GerarHashMd5(user.Password);
                User newUser = new User();

                newUser.Username = user.Username;
                newUser.Password = cripto;
                newUser.Email = user.Email;
                newUser.CPF = user.CPF;

                _contextRestaurant.Users.Add(newUser);
                _contextRestaurant.SaveChanges();
                //criptografa senha usando o token?
                // salva no banco
            }

            throw new NotImplementedException();
        }

        public User DeleteUser(string cpf)
        {
            //entra no banco, na tabela User e deleta as infos do CPF digitado
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            //entra no banco, na tabela user e retorna as infos do Id digitado
            
            User user = _contextRestaurant.Users.FirstOrDefault(user => user.Id == id);

            return user;
        }


        public string GerarHashMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
