namespace hogwartsBingus.Base_Classes
{
    public class Message
    {
        public string Text { get; protected set; }
        public DateTime Time { get; protected set; }
        
        public MessageType Type { get; protected set; }

        
        public Message(string text, DateTime time, MessageType type)
        {
            Text = text;
            Time = time;
            Type = type;
        }
        
        public Message(string text, DateTime time)
        {
            Text = text;
            Time = time;
            Type = MessageType.Normal;
        }
        
        public Message(string text)
        {
            Text = text;
            Time = null;
            Type = MessageType.Normal;
        }
    }
}