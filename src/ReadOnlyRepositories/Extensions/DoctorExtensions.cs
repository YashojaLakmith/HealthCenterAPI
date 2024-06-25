using Application.Doctor.Views;
using Domain.Entities;

namespace ReadOnlyRepositories.Extensions;

internal static class DoctorExtensions
{
    internal static DoctorDetailViewInternal AsDetailViewInternal(this Doctor doctor)
    {
        return new DoctorDetailViewInternal(
            doctor.Id.Value,
            doctor.DoctorName.Value,
            doctor.DoctorDescription.Value,
            doctor.RegistrationNumber.Value,
            doctor.Gender,
            doctor.DoctorEmailAddress.Value,
            doctor.PhoneNumber.Value);
    }

    internal static DoctorDetailViewPublic AsDetailViewPublic(this Doctor doctor)
    {
        return new DoctorDetailViewPublic(
            doctor.Id.Value,
            doctor.DoctorName.Value,
            doctor.DoctorDescription.Value,
            doctor.RegistrationNumber.Value,
            doctor.Gender);
    }

    internal static DoctorListItem AsListItem(this Doctor doctor)
    {
        return new DoctorListItem(
            doctor.Id.Value,
            doctor.DoctorName.Value);
    }
}