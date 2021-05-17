using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public interface ILoginDatabaseContext
    {
        UserDTO Login(string email, string password);
    }
}
