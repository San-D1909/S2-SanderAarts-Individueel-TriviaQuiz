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
            var results = repo.Login(email, password);
            UserDTO userDTO = new UserDTO(results);
            return userDTO;
        }
    }
}
