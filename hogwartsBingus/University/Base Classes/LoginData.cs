namespace hogwartsBingus.Base_Classes
{
    public class LoginData
    {
        private string Username, Password;

        public LoginData(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        
        public bool Compare(string username, string password) 
            => CompareUsername(username) && ComparePassword(password);

        public bool CompareUsername(string username) => Username == username;
        public bool ComparePassword(string password) => Password == password;
    }
}