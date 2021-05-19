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
        public UserDTO Login(string email,string password)
        {
            LoginRepository repo = new LoginRepository();

            UserDTO userDTO = new UserDTO(repo.LoginCheck(email, password));
            return userDTO;
        }
    }
}
