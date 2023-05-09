using hogwartsBingus.Base_Classes;

namespace hogwartsBingus.DataStorage
{
    public static class MessagingHandler
    {
        public delegate void MessageSentTrigger();

        public static event MessageSentTrigger MessageSent;
        public static void SendMessageTo(Message message, int userIndex)
        {
            UserManager.GetUserAtIndex(userIndex).AddMessage(message);
        }
    }
}