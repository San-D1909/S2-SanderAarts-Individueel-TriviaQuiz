using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.Models
{
    public class ScoreModel
    {
        public double MaxTime = 30;
        public double Score { get; set; }

        public int Question_Amount = 10;

    }
}