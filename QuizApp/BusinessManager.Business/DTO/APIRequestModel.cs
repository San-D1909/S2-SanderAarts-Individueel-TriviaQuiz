namespace BusinessManager.Business
{ 
    public class APIRequestModel
    {
        private static string baseURL = "https://opentdb.com/api.php?";
        private static string amount = "1";
        private string category;
        private string difficulty = "easy";
        private static string type = "multiple";

        public string BaseURL
        {
            get { return baseURL; }
            set { baseURL = value; }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public string Difficulty
        {
            get { return difficulty; }
            set { difficulty = value; }
        }
        public string Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}