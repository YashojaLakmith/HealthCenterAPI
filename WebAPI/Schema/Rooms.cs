using System.ComponentModel.DataAnnotations;

namespace WebAPI.Schema;

public class Rooms
{
    [Key]
    public string Room { get; set; }

    public ICollection<Sessions> Sessions { get; set; }
}
