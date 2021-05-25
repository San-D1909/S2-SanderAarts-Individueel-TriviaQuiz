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
            MySqlCommand checkQuestion = new MySqlCommand("SELECT * FROM question WHERE `question` = @val1");
            checkQuestion.Parameters.AddWithValue("@val1", questionDTO.Question);
            List<string> results = DatabaseClass.GetData(checkQuestion,true);
            if (results.Count >= 1)
            {
                return true;
            }
            else
            {
                MySqlCommand insertQuestion = new MySqlCommand("INSERT INTO `question`(`question`, `category`,`incorrect_answer1`, `incorrect_answer2`, `incorrect_answer3`, `correct_answer`,`difficulty`) VALUES (@val1,@val2,@val3,@val4,@val5,@val6,@val7)");
                insertQuestion.Parameters.AddWithValue("@val1", questionDTO.Question);
                insertQuestion.Parameters.AddWithValue("@val2", category);
                insertQuestion.Parameters.AddWithValue("@val3", questionDTO.IncorrectAnswers[0]);
                insertQuestion.Parameters.AddWithValue("@val4", questionDTO.IncorrectAnswers[1]);
                insertQuestion.Parameters.AddWithValue("@val5", questionDTO.IncorrectAnswers[2]);
                insertQuestion.Parameters.AddWithValue("@val6", questionDTO.CorrectAnswer);
                insertQuestion.Parameters.AddWithValue("@val7", difficulty);
                Boolean succes = DatabaseClass.StoreData(insertQuestion, true);
                if (succes == true)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
