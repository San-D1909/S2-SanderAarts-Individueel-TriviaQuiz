using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public class GetQuestionIDRepository
    {
        public IGetQuestionID Context;
        public GetQuestionIDRepository()
        {
            this.Context = new GetQuestionID();
        }
        public int SelectQuestionIDAddToQuestionList(string question)
        {
            return Context.SelectQuestionIDAddToQuestionList(question);
        }
    }
}
