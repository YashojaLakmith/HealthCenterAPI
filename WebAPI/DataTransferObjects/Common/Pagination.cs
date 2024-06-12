using System.ComponentModel.DataAnnotations;

namespace WebAPI.DataTransferObjects.Common;

public record Pagination(
    [Range(1, ushort.MaxValue)]
    uint PageNumber = 1,

    [Range(1, 25)]
    uint ResultsPerPage = 10
    );
