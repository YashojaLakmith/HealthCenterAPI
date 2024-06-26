using Application.Abstractions.CQRS;
using Application.Abstractions.Factories.Session;
using Application.Session.CommandHandlers;
using Application.Session.Commands;

using Domain.Repositories;

namespace Application.Factories.Session;

internal sealed class SessionCommandHandlerFactoryImpl : ISessionCommandHandlerFactory
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISessionRepository _sessionRepository;
    private readonly IDoctorRepository _doctorRepository;

    private ICommandHandler<CreateSessionCommand>? _createHandler;
    private ICommandHandler<DeleteSessionCommand>? _deleteHandler;
    private ICommandHandler<ModifySessionTimeCommand>? _modifyHandler;

    public SessionCommandHandlerFactoryImpl(
        IUnitOfWork unitOfWork,
        ISessionRepository sessionRepository,
        IDoctorRepository doctorRepository)
    {
        _unitOfWork = unitOfWork;
        _sessionRepository = sessionRepository;
        _doctorRepository = doctorRepository;
    }

    public ICommandHandler<CreateSessionCommand> CreateSessionCommandHandler
        => _createHandler ??= new CreateSessionCommandHandler(_unitOfWork, _doctorRepository);

    public ICommandHandler<DeleteSessionCommand> DeleteSessionCommandHandler
        => _deleteHandler ??= new DeleteSessionCommandHandler(_doctorRepository, _unitOfWork);

    public ICommandHandler<ModifySessionTimeCommand> ModifySessionTimeCommandHandler
        => _modifyHandler ??= new ModifySessionTimeCommandHandler(_unitOfWork, _sessionRepository);
}