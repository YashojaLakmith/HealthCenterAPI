﻿namespace Services.DataTransferObjects.DiagnosticRequest;

public record NewDiagnosticRequest(
    string UserId,
    string DiagnosysId,
    string Remarks
    );
