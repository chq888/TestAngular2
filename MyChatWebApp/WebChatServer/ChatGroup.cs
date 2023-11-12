using System.Net;

public class ChatGroup
{
    public Guid Id { get; set; }

    public Guid CreatorId { get; set; }

    public string Name { get; set; } = default!;

    public string About { get; set; } = default!;

    public Media? Picture { get; set; }

    public ISet<Guid> AdminIds { get; set; } = new HashSet<Guid>();

    public ISet<User> Admins { get; set; } = new HashSet<User>();

    public ISet<PinnedMessage> PinnedMessages { get; set; } = new HashSet<PinnedMessage>();

    public Metadata Metadata { get; set; } = new Dictionary<string, string>();

    public DateTimeOffset? UpdatedAt { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
}

public record PinnedMessage(
    Guid MessageId,
    DateTime CreatedAt,
    Guid PinnerId);
public class ChatGroupAttachment
{
    public Guid ChatGroupId { get; set; }

    public Guid AttachmentId { get; set; }

    public Guid UserId { get; set; }

    public string Username { get; set; } = default!;

    public Media MediaInfo { get; set; } = default!;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime? UpdatedAt { get; set; }
}
public class ChatGroupJoinRequest
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ChatGroupId { get; set; }

    public DateTime CreatedAt { get; set; }

    public sbyte Status { get; set; }
}
public class ChatGroupMember
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Username { get; set; } = default!;

    public User User { get; set; }

    public Guid ChatGroupId { get; set; }

    public ChatGroup ChatGroup { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

    public sbyte MembershipType { get; set; }
}
public class Media
{
    public Guid Id { get; set; }

    public string MediaUrl { get; set; } = default!;

    public string? FileName { get; set; }

    public string? Type { get; set; }
}


public class ChatMessage
{
    public Guid Id { get; set; }

    public Guid ChatGroupId { get; set; }

    public ChatGroup ChatGroup { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; }

    public string Content { get; set; } = default!;

    private readonly HashSet<Media> _attachments = new();

    public Guid? ForwardedMessageId { get; set; }

    public IReadOnlyCollection<Media> Attachments
    {
        get => _attachments.ToList().AsReadOnly();
        init => _attachments = value.ToHashSet();
    }

    public ReactionCounts ReactionCounts { get; set; } = new Dictionary<long, long>();

    public void AddAttachment(Media media) => _attachments.Add(media);

    public bool DeleteAttachment(Guid attachmentId)
        => _attachments.RemoveWhere(m => m.Id == attachmentId) > 0;

    public void IncrementReactionCount(long reactionType)
    {
        if (!ReactionCounts.ContainsKey(reactionType))
        {
            ReactionCounts[reactionType] = 0;
        }

        ReactionCounts[reactionType]++;
    }

    public void DecrementReactionCount(long reactionType)
    {
        if (ReactionCounts.ContainsKey(reactionType))
        {
            ReactionCounts[reactionType]--;
        }
    }

    public void ChangeReaction(long from, long to)
    {
        if (ReactionCounts.ContainsKey(from))
        {
            ReactionCounts[from]--;
        }

        if (!ReactionCounts.ContainsKey(to))
        {
            ReactionCounts[to] = 0;
        }

        ReactionCounts[to]++;
    }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;

    public Metadata Metadata { get; set; } = new Dictionary<string, string>();
}
public class ChatMessageReaction
{
    public Guid Id { get; set; }

    public Guid MessageId { get; set; }

    public ChatMessage Message { get; set; }

    public Guid ChatGroupId { get; set; }

    public ChatGroup ChatGroup { get; set; }

    public Guid UserId { get; set; }

    public string Username { get; set; } = default!;

    public User User { get; set; }

    public long ReactionCode { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }
}
public class ChatMessageReply : ChatMessage
{
    public Guid ReplyToId { get; set; }
}
public class FriendInvitation
{
    public Guid Id { get; set; }

    public Guid InviterId { get; set; }

    public Guid InviteeId { get; set; }

    public FriendInvitationStatus Status { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

    public DateTimeOffset? UpdatedAt { get; set; }
}
public enum FriendInvitationStatus : sbyte
{
    Pending,
    Declined,
    Accepted
}
public class FriendsRelation
{
    public Guid Id { get; set; }

    public Guid FriendOneId { get; set; }

    public Guid FriendTwoId { get; set; }

    public Guid GroupId { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
}
public class MessageRepliersInfo
{
    public Guid Id { get; set; }
    public Guid ChatGroupId { get; set; }

    public Guid MessageId { get; set; }

    public DateTime? LastUpdatedAt { get; set; } = default;

    public DateTimeOffset CreatedAt { get; set; }

    public long Total { get; set; }

    public ISet<MessageReplierInfo> ReplierInfos { get; set; } = new HashSet<MessageReplierInfo>();
}

public record MessageReplierInfo(
    Guid UserId,
    string Username,
    string ProfilePictureUrl
); public class User : IDomainEntity
{
    public Guid Id { get; set; }

    public string Username { get; set; } = default!;

    public Email Email { get; set; } = default!;

    public UserStatus Status { get; set; }

    public List<string> Roles { get; set; } = new();

    public ISet<PhoneNumber> PhoneNumbers { get; set; } = new HashSet<PhoneNumber>();

    public Media ProfilePicture { get; set; } = default!;

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

    public DateTimeOffset? UpdatedAt { get; set; }

    public DateTimeOffset LastLogin { get; set; } = DateTimeOffset.Now;

    public HashSet<IPAddress> DeviceIps { get; init; } = new();

    public Metadata Metadata { get; init; } = new Dictionary<string, string>();

    public string DisplayName { get; set; }

    public string UserHandle { get; set; }

    public void AddDeviceIp(IPAddress ipAddress)
        => DeviceIps.Add(ipAddress);
}

public enum UserStatus : sbyte
{
    Online,
    Away,
    Offline
}
public class UserNotification
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public User? User { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

    public DateTimeOffset? UpdatedAt { get; set; }

    public virtual UserNotificationType Type { get; set; }

    public UserNotificationMetadata? Metadata { get; set; }

    public virtual string? Summary { get; set; }

    public bool Read { get; set; } = false;
}

public class IncomingFriendInvitationNotification : UserNotification
{
    public Guid InviteId { get; set; }

    public override UserNotificationType Type
    {
        get => UserNotificationType.IncomingFriendInvite;
        set { }
    }
}

public class AcceptedFriendInvitationNotification : UserNotification
{
    public Guid InviteId { get; set; }

    public Guid ChatGroupId { get; set; }
    public Guid InviterId { get; set; }

    public override UserNotificationType Type
    {
        get => UserNotificationType.AcceptedFriendInvite;
        set { }
    }
}

public class DeclinedFriendInvitationNotification
    : AcceptedFriendInvitationNotification
{
    public override UserNotificationType Type
    {
        get => UserNotificationType.DeclinedFriendInvite;
        set { }
    }
}

public enum UserNotificationType : sbyte
{
    Unspecified,
    IncomingFriendInvite,
    AcceptedFriendInvite,
    DeclinedFriendInvite,
    UserMention
}

public class UserNotificationMetadata
{
    public Media? UserMedia { get; set; }
}