using System.Linq;
using Torshia.Data;
using Torshia.Models;
using Torshia.Models.Enums;

namespace Torshia.Services
{
    public class UserService : IUserService
    {
        private readonly TorshiaDBContext context;
        public UserService(TorshiaDBContext torshiaDBContext)
        {
            this.context = torshiaDBContext;
        }
        public User CreateUser(User user)
        {
            user.Role = this.context.Users.Count() == 0 ? Role.Admin : Role.User;
            user = this.context.Users.Add(user).Entity;
            this.context.SaveChanges();
            return user;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            var user = this.context.Users
                .SingleOrDefault(u => 
                    (u.UserName == username || u.Email == username) && u.Password == password);

            return user;

        }
    }
}
