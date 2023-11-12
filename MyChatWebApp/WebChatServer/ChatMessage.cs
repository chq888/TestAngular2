using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ChatMessage  
{
    public const int MaxMessageLength = 4 * 1024; //4KB

    public Guid UserId { get; set; }

    public Guid TargetUserId { get; set; }

    [Required]
    [StringLength(MaxMessageLength)]
    public string Message { get; set; }

    public DateTime CreationTime { get; set; }

    public ChatSide Side { get; set; }

    public ChatMessageReadState ReadState { get; private set; }

    public ChatMessageReadState ReceiverReadState { get; private set; }

    public Guid? SharedMessageId { get; set; }

    public ChatMessage(
        Guid user,
        Guid targetUser,
        ChatSide side,
        string message,
        ChatMessageReadState readState,
        Guid sharedMessageId,
        ChatMessageReadState receiverReadState)
    {
        UserId = user;
        TargetUserId = targetUser;
        Message = message;
        Side = side;
        ReadState = readState;
        SharedMessageId = sharedMessageId;
        ReceiverReadState = receiverReadState;

        CreationTime = DateTime.Now;
    }

    public void ChangeReadState(ChatMessageReadState newState)
    {
        ReadState = newState;
    }

    protected ChatMessage()
    {

    }

    public void ChangeReceiverReadState(ChatMessageReadState newState)
    {
        ReceiverReadState = newState;
    }
}

public enum ChatSide
{
    Sender = 1,

    Receiver = 2
}

public enum ChatMessageReadState
{
    Unread = 1,

    Read = 2
}

public class FriendDto
{
    public long FriendUserId { get; set; }


    public string FriendUserName { get; set; }

    public string FriendTenancyName { get; set; }

    public Guid? FriendProfilePictureId { get; set; }

    public int UnreadMessageCount { get; set; }

    public bool IsOnline { get; set; }

    public FriendshipState State { get; set; }
}

public enum FriendshipState
{
    Accepted = 1,
    Blocked = 2
}

public class OnlineClient
{
    /// <summary>
    /// Unique connection Id for this client.
    /// </summary>
    public string ConnectionId { get; set; }

    /// <summary>
    /// IP address of this client.
    /// </summary>
    public string IpAddress { get; set; }

    /// <summary>
    /// User Id.
    /// </summary>
    public long? UserId { get; set; }

    /// <summary>
    /// Connection establishment time for this client.
    /// </summary>
    public DateTime ConnectTime { get; set; }

    /// <summary>
    /// Shortcut to set/get <see cref="Properties"/>.
    /// </summary>
    public object this[string key]
    {
        get { return Properties[key]; }
        set { Properties[key] = value; }
    }

    /// <summary>
    /// Can be used to add custom properties for this client.
    /// </summary>
    public Dictionary<string, object> Properties
    {
        get { return _properties; }
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            _properties = value;
        }
    }
    private Dictionary<string, object> _properties;

    /// <summary>
    /// Initializes a new instance of the <see cref="OnlineClient"/> class.
    /// </summary>
    public OnlineClient()
    {
        ConnectTime = DateTime.Now;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OnlineClient"/> class.
    /// </summary>
    /// <param name="connectionId">The connection identifier.</param>
    /// <param name="ipAddress">The ip address.</param>
    /// <param name="tenantId">The tenant identifier.</param>
    /// <param name="userId">The user identifier.</param>
    public OnlineClient(string connectionId, string ipAddress, long? userId)
        : this()
    {
        ConnectionId = connectionId;
        IpAddress = ipAddress;
        UserId = userId;

        Properties = new Dictionary<string, object>();
    }
     
}

public class Agent
{
    public string Id { get; set; }
    public string Name { get; set; }
    public bool IsOnline { get; set; }

    public Agent()
    {
    }
}
public class Connection
{
    public Connection()
    {
    }

    public Connection(string connectionId, string username)
    {
        ConnectionId = connectionId;
        Username = username;
    }

    public string ConnectionId { get; set; }
    public string Username { get; set; }
}
public class Group
{
    public Group()
    {
    }

    public Group(string name)
    {
        Name = name;
    }

    [Key]
    public string Name { get; set; }
    public ICollection<Connection> Connections { get; set; } = new List<Connection>();
}
public class Message
{
    public int Id { get; set; }
    public int SenderId { get; set; }
    public string SenderUsername { get; set; }
    public AppUser Sender { get; set; }
    public int RecipientId { get; set; }
    public string RecipientUsername { get; set; }
    public AppUser Recipient { get; set; }
    public string Content { get; set; }
    public DateTime? DateRead { get; set; }
    public DateTime MessageSent { get; set; } = DateTime.UtcNow;

    public bool SenderDeleted { get; set; }
    public bool RecipientDeleted { get; set; }
}
public class ChatMessage
{
    public string Id { get; set; }
    public string Content { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public DateTime Timestamp { get; set; }
}
public class Message : DeletableEntity
{
    public int Id { get; init; }

    [Required]
    [MaxLength(ChatMessageMaxLength)]
    public string Text { get; set; }

    public string SenderUserId { get; set; }

    [ForeignKey("SenderUserId")]
    public User SenderUser { get; set; }

    [Required]
    public string ReceiverUserId { get; set; }

    [ForeignKey("ReceiverUserId")]
    public User ReceiverUser { get; set; }
}
public class User : IdentityUser
{
    public string ProfileImageUrl { get; set; }

    public ICollection<Message> SendedMessages { get; init; } = new HashSet<Message>();

    public ICollection<Message> ReceivedMessages { get; init; } = new HashSet<Message>();
}
