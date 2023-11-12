using System.ComponentModel.DataAnnotations.Schema;

public class Client1
{
    public int ClientId { get; set; }
    public string? Name { get; set; }

    public ICollection<Message1>? Messages { get; set; }
    public ICollection<ClientTopic1>? ClientTopics { get; set; }
}
public class ClientTopic1
{
    public int TopicId { get; set; }
    public Topic1? Topic { get; set; }
    public int ClientId { get; set; }
    public Client1? Client { get; set; }
}
public class Message1
{
    public int MessageId { get; set; }
    public DateTime SentDate { get; set; }
    public string Content { get; set; } = string.Empty;

    public int ClientId { get; set; }
    [NotMapped]
    public string ClientName { get; set; } = string.Empty;
    public Client1? Client { get; set; }
    public int TopicId { get; set; }
    public Topic1? Topic { get; set; }
}
public class Topic1
{
    public int TopicId { get; set; }
    public string TopicName { get; set; } = string.Empty;

    public ICollection<ClientTopic1>? ClientTopics { get; set; }
    public ICollection<Message1>? Messages { get; set; }
}