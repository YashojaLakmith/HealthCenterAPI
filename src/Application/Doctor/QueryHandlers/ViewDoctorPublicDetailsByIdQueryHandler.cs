﻿using Application.Abstractions.CQRS;
using Application.Abstractions.ReadOnlyRepositories;
using Application.Common;
using Application.Doctor.Views;

using Domain.Common;
using Domain.ValueObjects;

namespace Application.Doctor.QueryHandlers;
internal class ViewDoctorPublicDetailsByIdQueryHandler : IQueryHandler<DoctorDetailViewPublic, IdQuery>
{
    private readonly IReadOnlyDoctorRepository _doctorRepository;

    public ViewDoctorPublicDetailsByIdQueryHandler(IReadOnlyDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<Result<DoctorDetailViewPublic>> HandleAsync(IdQuery query, CancellationToken cancellationToken = default)
    {
        var idResult = Id.CreateId(query.Id);
        if (idResult.IsFailure)
        {
            return Result<DoctorDetailViewPublic>.Failure(idResult.Error);
        }

        return await _doctorRepository.GetDoctorDetailsForPublicAsync(idResult.Value, cancellationToken);
    }
}
