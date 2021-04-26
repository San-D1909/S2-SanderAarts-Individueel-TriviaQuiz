using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public class SubmitDTO
    {
        public int Unique_ID { get; set; }
        public int Category { get; set; }
        public string Difficulty { get; set; }
        public int Score { get; set; }
        public int Question_Amount { get; set; }
        public List<string> Question_List { get; set; }
    }
}
