namespace hogwartsBingus.Base_Classes
{
    public class Message
    {
        public string Sender { get; protected set; }
        public string Receiver { get; protected set; }
        public string Title { get; protected set; }
        public string Text { get; protected set; }

        public Message(string sender, string receiver, string title, string text)
        {
            Sender = sender;
            Receiver = receiver;
            Title = title;
            Text = text;
        }
    }
}