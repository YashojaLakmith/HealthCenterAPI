namespace Services.DataTransferObjects.Doctor;

public record Doctor_DetaiView_Public(
    string DoctorId,
    string Title,
    string Name,
    string Specialization,
    string PictureToken
    );
