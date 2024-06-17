using Domain.Common;
using Domain.Primitives;

namespace Domain.ValueObjects;

public class SessionSpan : ValueObject
{
    public const int MaxSessionLengthMinutes = 360;
    public const int MinSessionLengthMinutes = 30;

    public DateTime SessionStartValue { get; }
    public DateTime SessionEndValue { get; }

    public static Result<SessionSpan> Create(DateTime sessionStart, DateTime sessionEnd)
    {
        if(!ValidateSessionTimes(sessionStart, sessionEnd))
        {
            return Result<SessionSpan>.Failure(new ArgumentException());
        }

        return new SessionSpan(sessionStart, sessionEnd);
    }

    private static bool ValidateSessionTimes(DateTime sessionStart, DateTime sessionEnd)
    {
        return sessionStart >= DateTime.UtcNow
            && sessionEnd > sessionStart
            && (sessionEnd - sessionStart).TotalMinutes >= MinSessionLengthMinutes
            && (sessionEnd - sessionStart).TotalMinutes <= MaxSessionLengthMinutes;
    }

    private SessionSpan(DateTime sessionStart, DateTime sessionEnd)
    {
        SessionStartValue = sessionStart;
        SessionEndValue = sessionEnd;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        return [SessionStartValue, SessionEndValue];
    }
}
