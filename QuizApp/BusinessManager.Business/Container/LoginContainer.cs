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
            var results = LoginRepository.LoginCheck(email, password);
            if (results != null)
            {
                UserDTO userDTO = new UserDTO(results);
                return userDTO;
            }
            return null;
        }
    }
}
