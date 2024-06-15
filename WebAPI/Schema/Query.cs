using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class Query
{
    [Key]
    public string QueryId { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime SentOn { get; set; }
    public string? Reply { get; set; }
    public DateTime? RepliedOn { get; set; }

    public IndependentPatient Sender { get; set; }

    public override bool Equals(object? obj)
    {
        if(obj is Query q)
        {
            return GetHashCode() == q.GetHashCode() && QueryId.Equals(q.QueryId);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return QueryId.GetHashCode();
    }
}
