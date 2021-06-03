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
        public LoginRepository loginRepository = new LoginRepository();
        public UserDTO Login(string email,string password)
        {
            UserDTO userDTO = new UserDTO(loginRepository.LoginCheck(email, password));
            return userDTO;
        }
    }
}
