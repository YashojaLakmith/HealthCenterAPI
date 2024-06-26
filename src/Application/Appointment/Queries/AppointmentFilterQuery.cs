using Application.Abstractions.CQRS;
using Application.Common;

using Domain.Enum;

namespace Application.Appointment.Queries;
public sealed record AppointmentFilterQuery(Guid? PatientId, AppointmentStatus? AppointmentStatus, Pagination Pagination) : IQuery; 