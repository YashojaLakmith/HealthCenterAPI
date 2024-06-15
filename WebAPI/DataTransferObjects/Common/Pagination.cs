using System.ComponentModel.DataAnnotations;

namespace WebAPI.DataTransferObjects.Common;

public record Pagination(
    [Range(1, ushort.MaxValue)]
    int PageNumber = 1,

    [Range(1, 25)]
    int ResultsPerPage = 10
    );
