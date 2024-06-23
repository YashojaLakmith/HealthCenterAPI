using Application.Abstractions.CQRS;
using Application.Common;
using Application.Doctor.Commands;

namespace Application.Abstractions.Factories.Doctor;

public interface IDoctorCommandHandlerFactory
{
    ICommandHandler<CreateDoctorCommand> CreateDoctorCommandHandler { get; }
    ICommandHandler<IdCommand> DeleteDoctorCommandHandler { get; }
    ICommandHandler<ModifyContactInformationCommand> ModifyContactInformationCommandHandler { get; }
    ICommandHandler<ModifyDescriptionCommand> ModifyDescriptionCommandHandler { get; }
}