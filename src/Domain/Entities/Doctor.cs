using Domain.Common;
using Domain.Common.Errors;
using Domain.Enum;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Doctor : Entity
{
    private List<Session> _sessions = [];

    public Name DoctorName { get; private set; }
    public Description DoctorDescription { get; private set; }
    public DoctorRegistrationNumber RegistrationNumber { get; private set; }
    public EmailAddress DoctorEmailAddress { get; internal set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public Gender Gender { get; private set; }

    public IReadOnlyCollection<Session> Sessions => _sessions;

    public static Result<Doctor> Create(
        Name name,
        Description description,
        DoctorRegistrationNumber registrationNumber,
        EmailAddress doctorEmailAddress,
        PhoneNumber phoneNumber,
        Gender gender)
    {
        return new Doctor(Id.CreateId(), name, description, registrationNumber, doctorEmailAddress, phoneNumber, gender);
    }

    private Doctor(
        Id id,
        Name doctorName,
        Description doctorDescription,
        DoctorRegistrationNumber registrationNumber,
        EmailAddress doctorEmailAddress,
        PhoneNumber phoneNumber,
        Gender gender) : base(id)
    {
        DoctorName = doctorName;
        DoctorDescription = doctorDescription;
        RegistrationNumber = registrationNumber;
        DoctorEmailAddress = doctorEmailAddress;
        PhoneNumber = phoneNumber;
        Gender = gender;
    }

    public Result AddSession(SessionSpan sessionSpan)
    {
        var hasOverlappings = _sessions.Any(session => IsOverlappingSessions(session, sessionSpan));

        if (hasOverlappings)
        {
            return Result.Failure(SessionErrors.HasOverlappingSessions);
        }

        var newSession = Session.Create(sessionSpan, this);
        _sessions.Add(newSession);
        return Result.Success();
    }

    private static bool IsOverlappingSessions(Session session, SessionSpan sessionSpan)
    {
        return sessionSpan.SessionStartValue < session.SessionSpan.SessionEndValue
            && sessionSpan.SessionEndValue > session.SessionSpan.SessionStartValue;
    }

    public Result RemoveSession(Id sessionId)
    {
        var session = _sessions.FirstOrDefault(s => s.Id == sessionId);

        if(session is null)
        {
            return Result.Failure(SessionErrors.SessionNotFound);
        }

        var now = DateTime.UtcNow;
        if(session.SessionSpan.SessionStartValue < now && session.SessionSpan.SessionEndValue > now)
        {
            return Result.Failure(SessionErrors.RemovingAnAlreadyStatedSession);
        }

        _sessions.Remove(session);       
        return Result.Success();
    }

    public Result ChangeDescription(Description description)
    {
        DoctorDescription = description;
        return Result.Success();
    }

    public Result ChangeEmail(EmailAddress emailAddress)
    {
        DoctorEmailAddress = emailAddress;
        return Result.Success();
    }

    public Result ChangePhoneNumber(PhoneNumber phoneNumber)
    {
        PhoneNumber = phoneNumber;
        return Result.Success();
    }
}
