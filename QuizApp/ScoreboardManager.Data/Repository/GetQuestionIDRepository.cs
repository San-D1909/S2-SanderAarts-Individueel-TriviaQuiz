using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public class GetQuestionIDRepository
    {
        private IGetQuestionID context;
        public IGetQuestionID Context
        {
            get
            {
                return context;
            }
            set
            {
                context = value;
            }
        }
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
