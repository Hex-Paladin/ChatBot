namespace WebApplication.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public string UserQuery { get; set; }
        public string BotResponse { get; set; }
        public DateTime Timestamp { get; set; }
    }
}