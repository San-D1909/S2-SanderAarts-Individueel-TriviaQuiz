using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManager.Data;

namespace BusinessManager.Business
{
    public class LoginContainer
    {
        private LoginRepository loginRepository = new LoginRepository();
        public LoginRepository LoginRepository
        {
            get
            {
                return loginRepository;
            }
            set
            {
                loginRepository = value;
            }
        }
        public UserDTO Login(string email, string password)
        {
            return new UserDTO ( LoginRepository.LoginCheck(email, password) );
        }
    }
}
