using MediatR;
using Microsoft.AspNetCore.Mvc;
using PublishSubscribe.Application.UseCases.Persons.Add;

namespace PublishSubscribe.IO.Api.UseCases.Persons.Add;

[ApiController]
[Route("person")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private readonly IMediator _mediator;

    public PersonController(ILogger<PersonController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost]
    public IActionResult Post(string name)
    {
        var person = _mediator.Send(new AddPersonCommand(name));
        return Created(person.Id.ToString(), person);
    }
}