using FluentAssertions;
using PublishSubscribe.Domain.Aggregates.PersonAggregate;

namespace PublishSubscribe.UnitTests.Domain.Aggregates.PersonAggregate;

public class PersonTests
{
    [Fact]
    public void When_Created_ShouldHaveName()
    {
        // Arrange
        const string name = "Jane";

        // Act
        var person = new Person(name);

        // Assert
        person.Name.Should().Be(name);
    }
}