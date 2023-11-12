public class ChatEntity
{
    public Guid Id { get; set; }
    public List<UserEntity> Users = null!;
}
public class MessageEntity
{
    public int Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; }
    public UserEntity User { get; set; } = null!;
    public string Username { get; set; } = string.Empty;
}
public class UserEntity
{
    public string Username { get; set; } = string.Empty;
    public string ConnectionId { get; set; } = null!;
    public List<MessageEntity> Messages = null!;
    public ChatEntity Chat { get; set; } = null!;
    public Guid ChatId { get; set; }
}