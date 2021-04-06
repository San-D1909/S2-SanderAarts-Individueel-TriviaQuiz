using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.Models
{
    public class ScoreBoardModel
    {
        public TimeSpan timeSpan { get; set; }
        public enum TimeSpan
        {
            AllTime,
            PastWeek,
            PastMonth
        }
        public Category category { get; set; }
        public enum Category
        {
            Games = 15,
            Science = 17,
            History = 23
        }
        public Difficulty difficulty { get; set; }
        public enum Difficulty
        {
            Easy = 1,
            Medium = 2,
            Hard = 3
        }
    }
}