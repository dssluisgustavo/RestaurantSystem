using Domain;
using Domain.Settings;
using Services.Context;
using Services.Interfaces;

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
                newUser.Password = user.Password.ToMD5();
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

        public bool DeleteUser(int id)
        {
            //entra no banco, na tabela User e deleta as infos do CPF digitado
            User deletedUser = _contextRestaurant.Users.FirstOrDefault(user => user.Id == id);
            
            if(deletedUser != null)
            {
                deletedUser.IsActive = false;

                _contextRestaurant.SaveChanges();

                return true;
            }

            return false; 
        }

        public User GetUserById(int id)
        {
            //entra no banco, na tabela user e retorna as infos do Id digitado

            User user = _contextRestaurant.Users.FirstOrDefault(user => user.Id == id);

            return user;
        }

        public User UpdateUser(int id, User user)
        {
            User updateUser = _contextRestaurant.Users.FirstOrDefault(_user => _user.Id == id);

            if(updateUser == null)
            {
                return null;
            }

            updateUser.Username = user.Username;
            updateUser.Email = user.Email;

            return updateUser;
        }
    }
}
