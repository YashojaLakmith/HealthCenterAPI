using Domain.ValueObjects;

namespace Application.CustomFilters;

public class SessionFilterByDoctorId
{
    public Id? DoctorId { get; }
    public DateTime? BeginsAfter { get; }
    public DateTime? EndsBefore { get; }
    public Pagination Pagination { get; }
    
    internal static SessionFilterByDoctorId CreateFilter(
        Pagination pagination,
        Id? doctorId = null,
        DateTime? beginsAfter = null,
        DateTime? endsBefore = null)
    {
        return new SessionFilterByDoctorId(
            doctorId,
            beginsAfter,
            endsBefore,
            pagination);
    }

    private SessionFilterByDoctorId(
        Id? doctorId,
        DateTime? beginsAfter,
        DateTime? endsBefore,
        Pagination pagination)
    {
        DoctorId = doctorId;
        BeginsAfter = beginsAfter;
        EndsBefore = endsBefore;
        Pagination = pagination;
    }
}