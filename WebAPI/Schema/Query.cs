using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class Query
{
    [Key]
    public string QueryId { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime SentOn { get; set; }
    public bool HasAttended { get; set; }

    public UserBase Sender { get; set; }
}
