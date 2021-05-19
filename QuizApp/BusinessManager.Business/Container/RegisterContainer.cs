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
        public bool InsertUser( string first, string last, string email,string birthDay,string password)
        {
            RegisterRepository registerRepository = new RegisterRepository();
            if (registerRepository.InsertUser( first, last, email, password, birthDay))
            {
                return true;
            }
            return false;
        }
    }
}
