namespace WebAPI.Schema;

public class ServerSideUser : UserBase
{
    public string NIC { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
}
