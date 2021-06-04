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
        public IRegisterDatabaseContext Context
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
        public RegisterRepository()
        {
            this.Context = new RegisterDatabaseContext();
        }
             
        public bool InsertUser( string first, string last, string email, string password, string birth_day)
        {
            UserDTO userDTO = new UserDTO(first, last, email, password, birth_day);
            if (Context.InsertUser(userDTO))
            {
                return true;
            }
            return false;
        }
    }
}
