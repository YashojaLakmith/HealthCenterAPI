using Application.Abstractions.CQRS;

using Domain.Enum;

namespace Application.Doctor.Commands;
public sealed record CreateDoctorCommand(string DoctorName, string Description, Gender Gender, string RegistrationNumber, string EmailAddress, string PhoneNumber) : ICommand;