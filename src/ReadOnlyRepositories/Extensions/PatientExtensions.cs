using Application.Common;
using Application.Patient.Views;
using Domain.Entities;

namespace ReadOnlyRepositories.Extensions;

internal static class PatientExtensions
{
    internal static PatientDetailView AsDetailView(this Patient patient)
    {
        return new PatientDetailView(
            patient.Id.Value,
            patient.PatientName.Value,
            new Age(patient.Age.years, patient.Age.months),
            patient.Gender,
            patient.EmailAddress.Value,
            patient.PhoneNumber.Value);
    }

    internal static PatientListItemView AsListItem(this Patient patient)
    {
        return new PatientListItemView(
            patient.Id.Value,
            patient.PatientName.Value);
    }
}