namespace hogwartsBingus.Base_Classes
{
    public class Professor : AuthorizedPerson
    {
        public bool CanTeachAtMultipleClasses { get; protected set; }

        public Professor(LoginData login) : base (login)
        {
            AuthType = AuthorizationType.Professor;
        }
    }
}