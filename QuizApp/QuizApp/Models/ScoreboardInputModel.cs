using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            Physics = 17,
            Computerscience = 18,
            History = 23,
            Geography = 22,
            Sports = 21,
            Animals = 27
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