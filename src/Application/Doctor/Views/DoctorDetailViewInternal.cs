using Domain.Enum;

namespace Application.Doctor.Views;
public sealed record DoctorDetailViewInternal(Guid DoctorId, string DoctorName, string Description, string RegistrationNumber, Gender Gender, string EmailAddress, string PhoneNumber);