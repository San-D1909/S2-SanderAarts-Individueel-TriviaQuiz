using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Data
{
    public class GetQuestionDataRepository
    {
        private IGetQuestionDataContext context;
        public GetQuestionDataRepository()
        {
            this.context = new GetQuestionDataAPIContext();
        }
        public string Get_JSON_From_API(string requestString)
        {
            return context.Get_JSON_From_API(requestString);
        }
    }
}
