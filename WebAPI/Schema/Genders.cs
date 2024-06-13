using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class Genders
{
    [Key]
    public string Gender { get; set; }

    public ICollection<UserBase> Users { get; set; }
}
