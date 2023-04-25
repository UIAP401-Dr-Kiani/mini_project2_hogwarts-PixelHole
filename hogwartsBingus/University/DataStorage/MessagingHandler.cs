using hogwartsBingus.Base_Classes;

namespace hogwartsBingus.DataStorage
{
    public static class MessagingHandler
    {
        public static void SendMessageTo(Message message, int UserIndex)
        {
            UserManager.GetUserAtIndex(UserIndex).AddMessage(message);
        }
    }
}