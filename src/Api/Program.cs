using PublishSubscribe.Application.UseCases.Persons.Add;
using PublishSubscribe.Domain.Aggregates.PersonAggregate.Repositories;
using PublishSubscribe.Plugins.InMemoryRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPubSubPlugin();
builder.Services.AddMediatR(cfg => { cfg.RegisterServicesFromAssemblyContaining<AddPersonCommand>(); });

builder.Services.AddScoped<IAddPerson, PersonRepository>();
builder.Services.AddScoped<IFindPerson, PersonRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();