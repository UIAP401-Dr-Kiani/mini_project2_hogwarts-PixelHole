namespace hogwartsBingus.Base_Classes
{
    public class LoginData
    {
        public readonly string Username, Password;

        public LoginData(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        
        public bool Compare(string username, string password) 
            => CompareUsername(username) && ComparePassword(password);
        
        public bool Compare(LoginData loginData) 
            => CompareUsername(loginData.Username) && ComparePassword(loginData.Password);

        private bool CompareUsername(string username) => Username == username;
        private bool ComparePassword(string password) => Password == password;
    }
}