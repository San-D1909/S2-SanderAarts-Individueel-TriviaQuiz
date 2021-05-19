using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using MySql.Data.MySqlClient;

namespace DataManager.Data
{
    class GetQuestionAPIContext : IGetQuestionAPIContext
    {
        public string SelectJSONFromAPI(string requestString)
        {
            WebRequest requestObject = WebRequest.Create(requestString);
            requestObject.Method = "GET";
            HttpWebResponse responseObject = (HttpWebResponse)requestObject.GetResponse();
            string resultJSON = null;
            using (Stream stream = responseObject.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                resultJSON = sr.ReadToEnd();
                sr.Close();
            }
            //Manipulate string to useable JSON
            resultJSON = resultJSON.Replace("{\"response_code\":0,\"results\":[", "");
            resultJSON = resultJSON.Remove(resultJSON.Length - 2, 2);
            return resultJSON;
        }
        public bool InsertQuestionDatabase(QuestionDTO questionDTO, string difficulty, string category)
        {
            MySqlCommand checkQuestion = new MySqlCommand("SELECT * FROM question WHERE `question` = '" + questionDTO.Question + "'");
            List<string> results = Utility.GetData(checkQuestion);
            if (results.Count >= 1)
            {
                return true;
            }
            else
            {
                MySqlCommand insertQuestion = new MySqlCommand("INSERT INTO `question`(`question`, `category`,`incorrect_answer1`, `incorrect_answer2`, `incorrect_answer3`, `correct_answer`,`difficulty`) VALUES ('" + questionDTO.Question + "','" + category + "','" + questionDTO.IncorrectAnswers[0] + "','" + questionDTO.IncorrectAnswers[1] + "','" + questionDTO.IncorrectAnswers[2] + "','" + questionDTO.CorrectAnswer + "','" + difficulty + "')");
                Boolean succes = Utility.StoreData(insertQuestion, false);
                if (succes == true)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
