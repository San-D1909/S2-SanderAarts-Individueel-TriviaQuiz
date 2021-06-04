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
        public ILoginDatabaseContext Context
        {
            get
            {
                return context;
            }
            set
            {
                context = value;
            }
        }
        public LoginRepository()
        {
            this.Context = new LoginDatabaseContext();
        }

        public UserDTO LoginCheck(string email, string password)
        {
            return Context.LoginCheck(email, password);
        }
    }
}
