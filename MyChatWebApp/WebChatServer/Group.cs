using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Group
{
    [Key]
    public int GroupId { get; set; }
    [MaxLength(50)]
    public string? GroupName { get; set; }
}
 public class GroupMember
{
    [Key]
    public int Id { get; set; }
    public Group? Group { get; set; }
    public User? User { get; set; }
}
public class Message
{
    [Key]
    public int MessageId { get; set; }
    public User? MessageFrom { get; set; }
    public User? MessageToUser { get; set; }
    public Group? MessageToGroup { get; set; }
    public string? MessageContent { get; set; }
    public DateTime MessageTime { get; set; }
}
public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    [StringLength(20, MinimumLength = 3)]
    public string? Username { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]
    public string? Email { get; set; }
}

https://github.com/qianshipoi/QianShiChat.WebApi/blob/master/src/QianShiChat.Domain/Models/UserGroupRealtion.cs


public class Message : EntityBase
{
    public string Text { get; set; }
    public int UserId { get; set; }
    public int RoomId { get; set; }
}
public class Room : EntityBase
{
    public string Name { get; set; }
}
public class User : EntityBase
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Photo { get; set; }
    public string RoleName { get; set; }
    public string PasswordHash { get; set; } = string.Empty;
    public int DepartmanId { get; set; }
}
public class UserRoom
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoomId { get; set; }
}




public partial class Conversation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();
}
public partial class Message
{
    [Key]
    public int Id { get; set; }

    public int ConversationId { get; set; }

    public int SenderId { get; set; }

    public required string Content { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Conversation Conversation { get; set; } = null!;

    public virtual User Sender { get; set; } = null!;
}
public partial class Participant
{
    public int Id { get; set; }

    public int ConversationId { get; set; }

    public int UserId { get; set; }

    public virtual Conversation Conversation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
public record User  /* IdentityUser<int> */
{
    [Key, JsonIgnore]
    public int Id { get; set; }

    [Required]
    public string Username { get; set; }

    public string Password { get; set; }

    public DateTime CreatedAt { get; set; }

    public string Email { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();


}

public class ChatRoom
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? DisplayName { get; set; }

    [JsonIgnore]
    public virtual AppUser? Admin { get; set; }
    [JsonIgnore]
    public virtual List<AppUser> Users { get; set; } = new List<AppUser>();
}

public class Message
{
    public int Id { get; set; }
    public string Text { get; set; }
    public DateTime Date { get; set; }

    [JsonIgnore]
    public virtual ChatRoom ChatRoom { get; set; }

    [JsonIgnore]
    public virtual AppUser Sender { get; set; }


    [NotMapped]
    public string UserName { get; set; }

    [NotMapped]
    public string UserId { get; set; }

    [NotMapped]
    public string ChatRoomName { get; set; }
}
public class UserRoomModel
{
    public string UserName { get; set; }
    public string ChatRoomName { get; set; }
}




public class Chat
{

    public Chat()
    {
        Messages = new List<Message>();
        Users = new List<AppUser>();
    }
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<Message> Messages { get; set; }

    public ICollection<AppUser> Users { get; set; }

    public ChatType Type { get; set; }

}

https://github.com/Silvenga/Rocket.Chat.Net/blob/master/src/Rocket.Chat.Net/Models/User.cs
public enum ChatType
{
    Room = 1,
    Private
}
public class Message
{
    public int Id { get; set; }

    public string UserName { get; set; }

    public string Text { get; set; }

    public DateTime Timestamp { get; set; }
}
}
