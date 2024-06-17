using Domain.Common;
using Domain.Primitives;

namespace Domain.ValueObjects;

public class Pagination : ValueObject
{
    public int ResultsPerPageValue { get; }
    public int PageNumberValue { get; }

    public static Result<Pagination> Create(int resultsPerPage, int pageNumber)
    {
        if(!ValidateValues(resultsPerPage, pageNumber))
        {
            return Result<Pagination>.Failure(new ArgumentException());
        }

        return new Pagination(resultsPerPage, pageNumber);
    }

    private static bool ValidateValues(int  resultsPerPage, int pageNumber)
    {
        return false;
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
