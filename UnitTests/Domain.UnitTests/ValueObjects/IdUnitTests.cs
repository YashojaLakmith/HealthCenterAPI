using Domain.Common;
using Domain.ValueObjects;
using FluentAssertions;

namespace Domain.UnitTests.ValueObjects;

[TestFixture]
public class IdUnitTests
{
    [Test]
    public void CreateId_ShouldReturnIdObject_WithAGuid()
    {
        var guid = Guid.NewGuid();
        var id = Id.CreateId(guid);

        id.GetType().Should().BeOfType<Id>();
        id.Value.Should().Be(guid);
    }

    [TestCase(@"ABC")]
    [TestCase(@"6A4F63AE-D603-4CCC-B0DF-E4E8A0D9EFe")]
    [TestCase(@"71189CC9-907C-4FAA-8547-E51F2EBB492EA")]
    [TestCase(@"71189CC9907C4FAA8547E51F2EBB492E")]
    public void CreateId_ShouldReturnFailedResult_WithInvalidFormatString(string guidStr)
    {
        var result = Id.CreateId(guidStr);

        result.GetType().Should().BeOfType<Result<Id>>();
        result.IsFailure.Should().BeTrue();
    }

    [TestCase(@"71189CC9-907C-4FAA-8547-E51F2EBB492E")]
    [TestCase(@"6ee2b354-a5a7-42f4-a58d-366a1163ebca")]
    public void CreateId_ShouldReturnSuccessResult_WithValidFormatString(string guidStr)
    {
        var result = Id.CreateId(guidStr);

        result.GetType().Should().BeOfType<Result<Id>>();
        result.IsSuccess.Should().BeTrue();
    }

    [Test]
    public void CreateId_ShouldCreateWithRandomGuid_WhenNoInputSpecified()
    {
        var id = Id.CreateId();

        id.Value.GetType().Should().Be(typeof(Guid));
        id.Value.Should().NotBeEmpty();
    }

    [Test]
    public void GetAtomicValues_ShouldReturnGuid()
    {
        var id = Id.CreateId();

        foreach (var obj in id.GetAtomicValues())
        {
            var guid = obj is Guid value ? value : default;
            guid.Should().NotBeEmpty();
            guid.Should().Be(id.Value);
        }
    }

    [Test]
    public void EqualityOperator_ShouldReturnTrue_ForSameId()
    {
        var guid = Guid.NewGuid();
        var id1 = Id.CreateId(guid);
        var id2 = Id.CreateId(guid);
    }
}