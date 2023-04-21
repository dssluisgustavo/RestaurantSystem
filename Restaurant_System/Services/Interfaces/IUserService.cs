using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        User GetUserById(int id);
        User CreateAccount(User user);
        bool DeleteUser(int id);

        User UpdateUser(int id, User user);
    }
}
