using Newtonsoft.Json;
using QuizApp.Models;
using System.IO;
using System.Net;

namespace QuizApp
{
    public class Get_Question_Data
    {
        public static string Get_JSON_From_API(APIRequestModel apiRequestModel)
        {
            //Creates a variable URL based on user input.
            string requestString = "" + apiRequestModel.BaseURL + "amount=" + apiRequestModel.Amount + "&category=" + apiRequestModel.Category + "&difficulty = medium" + "&type=" + apiRequestModel.Type + "";
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


        public static QuestionModel Fill_QuestionModel(APIRequestModel apiRequestModel)
        {
            string rawJSON = Get_JSON_From_API(apiRequestModel);
            QuestionModel questionModel = JsonConvert.DeserializeObject<QuestionModel>(rawJSON);
            if (questionModel.Question != null)
            {
                QuizApp.Classes.QuestionBackup.Store_question(questionModel, apiRequestModel);
                return questionModel;
            }
            else
            {
                questionModel = QuizApp.Classes.QuestionBackup.Get_Question_Database(apiRequestModel.Difficulty, apiRequestModel.Category, questionModel);
                return questionModel;
            }
        }
    }
}