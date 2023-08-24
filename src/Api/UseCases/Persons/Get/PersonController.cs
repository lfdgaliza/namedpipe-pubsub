using MediatR;
using Microsoft.AspNetCore.Mvc;
using PublishSubscribe.Application.UseCases.Persons.Get;
using PublishSubscribe.Domain.Aggregates.PersonAggregate;

namespace PublishSubscribe.IO.Api.UseCases.Persons.Get;

[ApiController]
[Route("person")]
public class PersonController : ControllerBase, IGetPersonQueryOutputPort
{
    private readonly ILogger<PersonController> _logger;
    private readonly IMediator _mediator;
    private IActionResult? _result;

    public PersonController(ILogger<PersonController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public void Found(Person person)
    {
        _result = Ok(person);
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public new void NotFound()
    {
        _result = base.NotFound();
    }

    [ApiExplorerSettings(IgnoreApi = true)]
    public void TeaPot()
    {
        _result = StatusCode(StatusCodes.Status418ImATeapot);
    }

    [HttpGet]
    [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Get(Guid id)
    {
        _mediator.Send(new GetPersonQuery(id, this));
        return _result!;
    }
}