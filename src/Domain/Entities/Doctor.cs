﻿using Domain.Common;
using Domain.Enum;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Doctor : Entity
{
    private List<Session> _sessions = [];

    public Name DoctorName { get; private set; }
    public Description DoctorDescription { get; private set; }
    public DoctorRegistrationNumber RegistrationNumber { get; private set; }
    public EmailAddress DoctorEmailAddress { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public Gender Gender { get; private set; }

    public IReadOnlyCollection<Session> Sessions => _sessions;

    public static Result<Doctor> Create(Name name, Description description, DoctorRegistrationNumber registrationNumber, Gender gender)
    {
        var idResult = Id.CreateId();
        return new Doctor(idResult.Value, name, description, registrationNumber, gender);
    }

    private Doctor() : base() { }

    private Doctor(Id id, Name doctorName, Description doctorDescription, DoctorRegistrationNumber registrationNumber, Gender gender) : base(id)
    {
        DoctorName = doctorName;
        DoctorDescription = doctorDescription;
        RegistrationNumber = registrationNumber;
        Gender = gender;
    }

    public Result CreateSession(SessionSpan sessionSpan, Ward ward)
    {
        throw new NotImplementedException();
    }

    public Result DeleteSession(Session session)
    {
        throw new NotImplementedException();
    }
}
