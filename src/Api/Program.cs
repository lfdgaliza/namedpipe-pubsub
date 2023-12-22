using PublishSubscribe.Application.UseCases.People.Add;
using PublishSubscribe.Application.UseCases.People.Get;
using PublishSubscribe.Domain.Aggregates.PersonAggregate.Repositories;
using PublishSubscribe.IO.Api.UseCases.People.Get;
using PublishSubscribe.Plugins.InMemoryRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblyContaining<AddPersonCommand>(); });

builder.Services.AddScoped<IAddPerson, PersonRepository>();
builder.Services.AddScoped<IFindPerson, PersonRepository>();

builder.Services.AddScoped<IGetPersonQueryOutputPort, GetPersonEndpointPresenter>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.RegisterEndpoints();

app.UseHttpsRedirection();

app.Run();