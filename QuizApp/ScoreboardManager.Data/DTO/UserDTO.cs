namespace DataManager.Data

{
    public class UserDTO
    {
        public UserDTO( string first, string last,string email,string password,string birth_day)
        {
            FirstName = first;
            LastName = last;
            Email = email;
            Password = password;
            BirthDay = birth_day;
        }

        public UserDTO()
        {

        }
        public string UniqueID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string BirthDay { get; set; }
    }
}

