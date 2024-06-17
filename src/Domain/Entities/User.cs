using Domain.Enum;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;
public class User : Entity
{
    public Name UserName { get; private set; }
    public EmailAddress EmailAddress { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public NIC NIC { get; private set; }
    public Role Role { get; private set; }
    public Gender Gender { get; private set; }
    public DateTime CreatedOn { get; private set; }

    public static User CreateUser(Name userName, EmailAddress email, PhoneNumber phoneNumber, NIC nic, Role role, Gender gender)
    {
        var idResult = Id.CreateId();
        return new User(idResult.Value, userName, email, phoneNumber, nic, role, gender, DateTime.Now);
    }

    private User(Id id, Name userName, EmailAddress email, PhoneNumber phoneNumber, NIC nic, Role role, Gender gender, DateTime createOn) : base(id)
    {
        UserName = userName;
        EmailAddress = email;
        PhoneNumber = phoneNumber;
        NIC = nic;
        Role = role;
        Gender = gender;
        CreatedOn = createOn;
    }

    public void ChangeEmailAddress(EmailAddress emailAddress)
    {
        EmailAddress = emailAddress;
    }

    public void ChangeRole(Role newRole)
    {
        Role = newRole;
    }

    private User() : base() { }
}
