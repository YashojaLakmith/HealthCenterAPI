using Domain.Common;
using Domain.Common.Errors;
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
        if(sessionStart > sessionEnd)
        {
            return Result<SessionSpan>.Failure(SessionSpanErrors.Invalid);
        }

        var duration = sessionEnd - sessionStart;

        if(duration.Minutes > MaxSessionLengthMinutes)
        {
            return Result<SessionSpan>.Failure(SessionSpanErrors.ExceedMaxDuration);
        }

        if(duration.Minutes < MinSessionLengthMinutes)
        {
            return Result<SessionSpan>.Failure(SessionSpanErrors.LessThanMinDuration);
        }

        return new SessionSpan(sessionStart, sessionEnd);
    }

    private SessionSpan(DateTime sessionStartValue, DateTime sessionEndValue)
    {
        SessionStartValue = sessionStartValue;
        SessionEndValue = sessionEndValue;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        return [SessionStartValue, SessionEndValue];
    }
}
