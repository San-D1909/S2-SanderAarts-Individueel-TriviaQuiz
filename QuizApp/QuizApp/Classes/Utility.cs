using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.Classes
{
    public class Utility
    {
        public static List<T> Shuffle<T>(List<T> list)
        {//Creates list with correct answer at random index
            Random random = new Random();
            var newList = list.OrderBy(x => random.Next(0, 3)).ToList();
            return newList;
        }
    }
}