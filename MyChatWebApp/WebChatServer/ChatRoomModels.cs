using Microsoft.AspNetCore.Mvc.RazorPages;

public class ChatRoomModels
{
    public string? Id { get; set; }

    public List<string> Member { get; set; } = new List<string>();

    public DateTime UpdateTime { get; set; } = DateTime.Now;

    public List<ChatModel> chat { get; set; } = new List<ChatModel>();
}

public class ChatModel
{
    public string? ChatId { get; set; }

    public DateTime ChatTime { get; set; } = DateTime.Now;

    public string Sender { get; set; } = "";

    public string Content { get; set; } = "";
}
public class Chatroom
{
    public string Name { get; set; }
    public ICollection<Message> Messages { get; set; } = new List<Message>();
    public ICollection<User?> Users { get; set; } = new List<User?>();
}
public class Message
{
    public string MessageText { get; set; }
    public User User { get; set; }
    public long ChatroomId { get; set; }
}
public class User : BaseModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Nickname { get; set; }
}


