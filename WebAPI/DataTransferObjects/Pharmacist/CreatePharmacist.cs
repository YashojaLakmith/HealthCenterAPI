namespace WebAPI.DataTransferObjects.Pharmacist;

public record CreatePharmacist(
    string Name,
    string Title,
    string NIC,
    string PhoneNumber,
    string EmailAddress
    );
