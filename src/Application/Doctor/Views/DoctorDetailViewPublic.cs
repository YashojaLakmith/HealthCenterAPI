using Domain.Enum;

namespace Application.Doctor.Views;
public sealed record DoctorDetailViewPublic(Guid DoctorId, string DoctorName, string Description, string RegistrationNumber, Gender Gender);