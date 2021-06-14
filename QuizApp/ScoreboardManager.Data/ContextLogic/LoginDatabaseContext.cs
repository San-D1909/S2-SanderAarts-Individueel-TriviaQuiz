using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public class LoginDatabaseContext : ILoginDatabaseContext
    {
        UserDTO ILoginDatabaseContext.GetLoginData(string email, string password)
        {
            MySqlCommand getUserData = new MySqlCommand("SELECT `unique_id`,`firstname`,`lastname` FROM user WHERE email=@val1 AND password=@val2");
            getUserData.Parameters.AddWithValue("@val1", email);
            getUserData.Parameters.AddWithValue("@val2", password);
            List<string> results = DatabaseClass.GetData(getUserData, true);
            if (results != null && results.Count > 0)
            {
                return new UserDTO { UniqueID = results[0], FirstName = results[1], LastName = results[2], Email = email };
            }
            return null;
        }
    }
}
