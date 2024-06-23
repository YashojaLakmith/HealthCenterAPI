using Domain.Common;
using Domain.Common.Errors;
using Domain.Primitives;

namespace Domain.ValueObjects;

public class Pagination : ValueObject
{
    public int ResultsPerPageValue { get; }
    public int PageNumberValue { get; }

    public static Result<Pagination> Create(int resultsPerPage, int pageNumber)
    {
        if(resultsPerPage < 0 || pageNumber < 0)
        {
            return Result<Pagination>.Failure(PaginationErrors.NegativeValues);
        }

        if(resultsPerPage == 0)
        {
            return Result<Pagination>.Failure(PaginationErrors.ResultsPerPageIsZero);
        }

        if(resultsPerPage > 100)
        {
            return Result<Pagination>.Failure(PaginationErrors.ResultsPerPageCountLimitExceeded);
        }

        return new Pagination(resultsPerPage, pageNumber);
    }

    private Pagination(int resultsPerPage, int pageNumber)
    {
        ResultsPerPageValue = resultsPerPage;
        PageNumberValue = pageNumber;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        throw new NotImplementedException();
    }
}
