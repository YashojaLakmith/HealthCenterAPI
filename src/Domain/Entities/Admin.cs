using Domain.Common;
using Domain.Enum;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;
public sealed class Admin : Entity
{
    public Name AdminName { get; private set; }
    public EmailAddress EmailAddress { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public NIC NIC { get; private set; }
    public Role Role { get; private set; }
    public Gender Gender { get; private set; }
    public DateTime CreatedOn { get; private set; }

    public static Admin CreateUser(Name userName, EmailAddress email, PhoneNumber phoneNumber, NIC nic, Role role, Gender gender)
    {
        return new Admin(Id.CreateId(), userName, email, phoneNumber, nic, role, gender, DateTime.UtcNow);
    }

    private Admin(Id id, Name adminName, EmailAddress email, PhoneNumber phoneNumber, NIC nic, Role role, Gender gender, DateTime createOn) : base(id)
    {
        AdminName = adminName;
        EmailAddress = email;
        PhoneNumber = phoneNumber;
        NIC = nic;
        Role = role;
        Gender = gender;
        CreatedOn = createOn;
    }

    public Result ChangeEmailAddress(EmailAddress emailAddress)
    {
        EmailAddress = emailAddress;
        return Result.Success();
    }

    public Result ChangePhoneNumber(PhoneNumber phoneNumber)
    {
        PhoneNumber = phoneNumber;
        return Result.Success();
    }

    public Result ChangeRole(Role newRole)
    {
        Role = newRole;
        return Result.Success();
    }
    
    private Admin(){}
}
