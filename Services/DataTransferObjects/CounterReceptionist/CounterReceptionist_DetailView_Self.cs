namespace Services.DataTransferObjects.CounterReceptionist;

public record CounterReceptionist_DetailView(
    string ReceptionistId,
    string NIC,
    string ReceptionistName,
    string Title,
    string PictureToken,
    DateTime CreatedOn,
    DateTime LastLoginTime
    );
