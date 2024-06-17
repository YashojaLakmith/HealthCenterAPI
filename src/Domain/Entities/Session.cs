using Domain.Common;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Session : Entity
{
    private readonly List<Patient> _appointments = [];

    public SessionSpan SessionSpan { get; private set; }
    public Doctor Doctor { get; private set; }
    public IReadOnlyCollection<Patient> Appointments => _appointments;

    public static Result<Session> Create(SessionSpan span, Doctor doctor)
    {
        if(doctor.Sessions.Any(session => session.SessionSpan == span))
        {
            return Result<Session>.Failure(new ArgumentException());
        }

        var idResult = Id.CreateId();
        return new Session(idResult.Value, span, doctor);
    }

    private Session() : base() { }

    private Session(Id id, SessionSpan span, Doctor doctor) : base(id)
    {
        SessionSpan = span;
        Doctor = doctor;
    }
}
