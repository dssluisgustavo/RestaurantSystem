using Domain;
using Domain.Settings;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Services.Context;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
                User newUser = new User();

                newUser.Username = user.Username;
                newUser.Password = HashMD5.GerarHashMd5(user.Password);
                newUser.Email = user.Email;
                newUser.CPF = user.CPF;
                newUser.IsAdmin = false;
                newUser.IsActive = true;

                _contextRestaurant.Users.Add(newUser);
                _contextRestaurant.SaveChanges();

                return newUser;
            }

            return null;
        }

        public User DeleteUser(string email)
        {
            //entra no banco, na tabela User e deleta as infos do CPF digitado
            User deletedUser = _contextRestaurant.Users.FirstOrDefault(delete => delete.Email == email);

            _contextRestaurant.SaveChanges();

            return deletedUser;
        }

        public User GetUserById(int id)
        {
            //entra no banco, na tabela user e retorna as infos do Id digitado

            User user = _contextRestaurant.Users.FirstOrDefault(user => user.Id == id);

            return user;
        }
    }
}
