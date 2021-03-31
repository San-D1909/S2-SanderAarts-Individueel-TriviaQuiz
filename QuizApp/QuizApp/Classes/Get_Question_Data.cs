using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using QuizApp.Models;
using System.IO;
using Newtonsoft.Json;

namespace QuizApp
{
    public class Get_Question_Data
    {
        public static string Get_JSON_From_API(APIRequestModel apiRequestModel)
        {
            //Creates a variable URL based on user input.
            string requestString = "" + apiRequestModel.BaseURL + "amount=" + apiRequestModel.Amount + "&category=" + apiRequestModel.Category + "&type=" + apiRequestModel.Type + "";
            WebRequest requestObject = WebRequest.Create(requestString);
            requestObject.Method = "GET";
            HttpWebResponse responseObject = (HttpWebResponse)requestObject.GetResponse();
            string resultJSON = null; 
            using(Stream stream  = responseObject.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                resultJSON = sr.ReadToEnd();
                sr.Close();
            }
            //Manipulate string to useable JSON
            resultJSON = resultJSON.Replace("{\"response_code\":0,\"results\":[", "");
            resultJSON = resultJSON.Remove(resultJSON.Length-2, 2);
            return resultJSON;
        }


        public static QuestionModel Fill_QuestionModel(APIRequestModel apiRequestModel)
        {
            string rawJSON = Get_JSON_From_API(apiRequestModel);
            QuestionModel questionModel = JsonConvert.DeserializeObject<QuestionModel>(rawJSON);
            if (questionModel.Question!=null)
            {
                return questionModel;
            }
            else
            {
                //create function to extract quesitons from database.
                return questionModel;
            }
        }
    }
}