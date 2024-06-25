using Application.Common;

using Domain.Enum;

namespace Application.Patient.Views;
public sealed record PatientDetailView(Guid PatientId, string PatientName, Age PatientAge, Gender Gender, string EmailAddress, string PhoneNumber);