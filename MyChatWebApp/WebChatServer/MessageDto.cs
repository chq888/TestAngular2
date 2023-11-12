using System.ComponentModel.DataAnnotations;

public class MessageDto
{
    [Required]
    public string From { get; set; }
    public string To { get; set; }
    [Required]
    public string Content { get; set; }
}


public class UserDto
{
    [Required]
    [StringLength(15, MinimumLength = 3, ErrorMessage = "Name must be at least {2}, and maximum {1} characters")]
    public string Name { get; set; }
}

public class UserByConnection
{
    public string usreId { get; set; }

    public string connectionId { get; set; }
}

public class GroupByConnection
{

    public string connectionId { get; set; }
}

public class Group
{
    public string name { get; set; }

    //$"{from}-{to}" : $"{to}-{from}"}
}