using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.Models
{
    public class ScoreboardInputModel
    {
        public SelectedTimeSpan selectedTimeSpan { get; set; }
        public enum SelectedTimeSpan
        {
            AllTime,
            PastMonth,
            PastWeek
        }
        public SelectedCategory selectedCategory { get; set; }
        public enum SelectedCategory
        {
            Games = 15,
            Science = 17,
            History = 23
        }
        public SelectedDifficulty selectedDifficulty { get; set; }
        public enum SelectedDifficulty
        {
            Easy = 1,
            Medium = 2,
            Hard = 3
        }
    }
}