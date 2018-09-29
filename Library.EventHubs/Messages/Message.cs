namespace Library.EventHubs.Messages
{
    public class Message : IMessage
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Body { get; set; }
    }
}