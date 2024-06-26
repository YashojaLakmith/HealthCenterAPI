using Application.CustomFilters;
using Domain.Entities;
using Domain.Enum;
using Domain.ValueObjects;

namespace ReadOnlyRepositories.Evaluators;

internal static class AppointmentFilterEvaluator
{
    internal static IQueryable<Appointment> EvaluateAppointmentFilter(
        this IQueryable<Appointment> query,
        AppointmentFilter customQuery)
    {
        query = ApplyPatientIdFilter(query, customQuery.PatientId);
        query = ApplyAppointmentStatusFilter(query, customQuery.AppointmentStatus);

        return query
            .OrderBy(appointment => appointment.AppointmentCreatedOn)
            .ApplyPagination(customQuery.Pagination);
    }

    private static IQueryable<Appointment> ApplyPatientIdFilter(
        IQueryable<Appointment> query,
        Id? patientId)
    {
        return patientId is null ? query : query.Where(appointment => appointment.Patient.Id == patientId);
    }

    private static IQueryable<Appointment> ApplyAppointmentStatusFilter(
        IQueryable<Appointment> query,
        AppointmentStatus? status)
    {
        return status is null ? query : query.Where(appointment => appointment.Status == status);
    }
}