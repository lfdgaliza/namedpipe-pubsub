using Microsoft.AspNetCore.Mvc;
using PublishSubscribe.MessageHandler;

namespace PublishSubscribe.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private readonly IMessagePublisher _messagePublisher;

    public PersonController(ILogger<PersonController> logger, IMessagePublisher messagePublisher)
    {
        _logger = logger;
        _messagePublisher = messagePublisher;
    }

    [HttpPost(Name = "GetWeatherForecast")]
    public void Post(string name)
    {
        //_messagePublisher.PublishMessage(name);
    }
}