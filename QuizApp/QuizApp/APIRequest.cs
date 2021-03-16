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
    public class APIRequest
    {
        public static string Get_API_JSON(APIRequestModel apiRequestModel)
        {
            string requestString = "" + apiRequestModel.BaseURL + "amount=" + apiRequestModel.Amount + "&category=" + apiRequestModel.Category + "&type=" + apiRequestModel.Type + "";
            WebRequest requestObject = WebRequest.Create(requestString);
            requestObject.Method = "GET";
            HttpWebResponse responseObject = null;
            responseObject = (HttpWebResponse)requestObject.GetResponse();
            string resultJSON = null; 
            using(Stream stream  = responseObject.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                resultJSON = sr.ReadToEnd();
                sr.Close();
            }
            resultJSON = resultJSON.Replace("{\"response_code\":0,\"results\":[", "");
            resultJSON = resultJSON.Remove(resultJSON.Length-2, 2);
            return resultJSON;
        }


        public static QuestionModel GetQuestion(APIRequestModel apiRequestModel)
        {
            QuestionModel questionModel = new QuestionModel { };
            string rawJSON = Get_API_JSON(apiRequestModel);
            questionModel = JsonConvert.DeserializeObject<QuestionModel>(rawJSON);
            return questionModel;
        }
    }
}