using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataManager.Data;

namespace BusinessManager.Business
{
    public class RegisterContainer
    {
        public RegisterRepository registerRepository = new RegisterRepository();
        public bool InsertUser( string first, string last, string email,string birthDay,string password)
        {
            if (registerRepository.InsertUser( first, last, email, password, birthDay))
            {
                return true;
            }
            return false;
        }
    }
}
