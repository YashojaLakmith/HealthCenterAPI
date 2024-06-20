using Domain.Common;
using Domain.Common.Errors;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Session : Entity
{
    public SessionSpan SessionSpan { get; private set; }
    public Doctor Doctor { get; private set; }

    public static Session Create(SessionSpan span, Doctor doctor)
    {
        return new Session(Id.CreateId(), span, doctor);
    }

    private Session(Id id, SessionSpan sessionSpan, Doctor doctor) : base(id)
    {
        SessionSpan = sessionSpan;
        Doctor = doctor;
    }

    public Result ModifySessionTime(SessionSpan sessionSpan)
    {
        var now = DateTime.UtcNow;

        if(SessionSpan.SessionStartValue < now)
        {
            return Result.Failure(SessionErrors.ModifyingAnAlreadyStatedSessionTime);
        }

        SessionSpan = sessionSpan;
        return Result.Success();
    }
}
