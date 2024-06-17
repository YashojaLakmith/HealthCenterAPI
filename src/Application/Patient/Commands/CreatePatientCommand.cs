using Application.Abstractions.CQRS;

using Domain.Enum;

namespace Application.Patient.Commands;
public sealed record CreatePatientCommand(string PatientName, DateTime BirthDate, Gender Gender, string NIC, string PhoneNumber, string EmailAddress) : ICommand;