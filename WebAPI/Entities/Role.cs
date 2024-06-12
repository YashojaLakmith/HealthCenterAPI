namespace WebAPI.Entities;

[Flags]
public enum Role
{
    GenericPatient =    0,
    GenericDoctor =     1 << 8,
    GenericPharmacist = 1 << 9,
    GenericLabStaff =   3 << 8,
    GenericReceptionist=1 << 10,
    GenericAdmin =      5 << 8
}
