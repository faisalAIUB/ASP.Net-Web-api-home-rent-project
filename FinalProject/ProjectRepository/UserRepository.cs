using ProjectEntity;
using ProjectInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        ProjectDBContext context = new ProjectDBContext();
        public int LogIn(string Email, string Password)
        {

            User user = context.Users.SingleOrDefault(u => u.Email == Email);
            if (user.Password == Password) { 
            if (user == null)
            {
                return 0;

            }
            else
                return user.Id;
            }
            else
            {
                return 0;
            }

        }
    }
}
