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
        public bool StoreUser( string first, string last, string email,string birth_day,string password)
        {
            RegisterRepository registerRepository = new RegisterRepository();
            if (registerRepository.StoreUser( first, last, email, password, birth_day))
            {
                return true;
            }
            return false;
        }
    }
}
