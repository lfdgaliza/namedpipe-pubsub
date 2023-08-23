using InMemoryRepository;
using PublishSubscribe.Application.UseCases.Persons.Add;
using PublishSubscribe.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMessageHandler();
builder.Services.AddPubSubPlugin();

builder.Services.AddScoped<IAddPerson, PersonRepository>();
builder.Services.AddScoped<IFindPerson, PersonRepository>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<Program>();
    cfg.RegisterServicesFromAssemblyContaining<AddPersonCommand>();
});

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