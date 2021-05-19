using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public class LoginRepository
    {
        private ILoginDatabaseContext context;
        public LoginRepository()
        {
            this.context = new LoginDatabaseContext();
        }

        public UserDTO LoginCheck(string email, string password)
        {
            return context.LoginCheck(email, password);
        }
    }
}
