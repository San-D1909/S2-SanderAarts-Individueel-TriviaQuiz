using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    class GetQuestionID : IGetQuestionID
    {
        public int SelectQuestionIDAddToQuestionList(string question)
        {
            MySqlCommand Get_Question_ID = new MySqlCommand("SELECT * FROM question WHERE `question` = @val1");
            Get_Question_ID.Parameters.AddWithValue("@val1", question);
            List<string> results = Utility.GetData(Get_Question_ID,true);
            return Convert.ToInt32(results[0]);
        }
    }
}
