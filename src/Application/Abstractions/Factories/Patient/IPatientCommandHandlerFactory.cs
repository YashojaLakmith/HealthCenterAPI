using Application.Abstractions.CQRS;
using Application.Common;
using Application.Patient.Commands;

namespace Application.Abstractions.Factories.Patient;

public interface IPatientCommandHandlerFactory
{
    ICommandHandler<CreatePatientCommand> CreatePatientCommandHandler { get; }
    ICommandHandler<IdCommand> DeletePatientCommandHandler { get; }
    ICommandHandler<ModifyContactInformationCommand> ModifyPatientContactInformationCommandHandler { get; }
}