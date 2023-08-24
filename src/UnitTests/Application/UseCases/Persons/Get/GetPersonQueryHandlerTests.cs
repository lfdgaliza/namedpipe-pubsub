using Moq;
using PublishSubscribe.Application.UseCases.Persons.Get;
using PublishSubscribe.Domain.Aggregates.PersonAggregate;
using PublishSubscribe.Domain.Aggregates.PersonAggregate.Repositories;

namespace PublishSubscribe.UnitTests.Application.UseCases.Persons.Get;

public class GetPersonQueryHandlerTests
{
    [Fact]
    public async Task When_ElizabethII_ShouldReturnTeaPot()
    {
        // Arrange
        var findPersonMock = new Mock<IFindPerson>();
        findPersonMock
            .Setup(s => s.Execute(It.IsAny<Guid>()))
            .Returns(new Person("Elizabeth II"));

        var handler = new GetPersonQueryHandler(findPersonMock.Object);

        var outputPortMock = new Mock<IGetPersonQueryOutputPort>();
        var query = new GetPersonQuery(Guid.Empty, outputPortMock.Object);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        outputPortMock.Verify(v => v.TeaPot(), Times.Once);
    }
}