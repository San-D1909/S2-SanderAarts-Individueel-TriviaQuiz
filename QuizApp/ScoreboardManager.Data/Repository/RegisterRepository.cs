using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public class RegisterRepository
    {
        private IRegisterDatabaseContext context;
        public RegisterRepository()
        {
            this.context = new RegisterDatabaseContext();
        }
             
        public bool StoreUser( string first, string last, string email, string password, string birth_day)
        {
            UserDTO userDTO = new UserDTO(first,last,email,password,birth_day);
            if(context.StoreUser(userDTO))
            {
                return true;
            }
            return false;
        }
    }
}
