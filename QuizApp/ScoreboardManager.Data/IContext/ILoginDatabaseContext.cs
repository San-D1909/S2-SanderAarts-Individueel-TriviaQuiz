using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public interface ILoginDatabaseContext
    {
        UserDTO LoginCheck(string email, string password);
    }
}
