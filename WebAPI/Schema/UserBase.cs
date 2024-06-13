using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public abstract class UserBase
{
    [Key]
    public string UserId { get; set; }
    public string UserName { get; set; }
    public DateTime UserCreatedOn { get; set; }

    public Genders Gender { get; set; }
    public ICollection<Query> Queries { get; set; }
}
