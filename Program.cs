using ReceptWebApi.Repository.Interfaces;
using ReceptWebApi.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
// En service som genrerar en json fil med dokumentation
builder.Services.AddSwaggerGen();

// Automapper är uppsatt som en service som kan injectas
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddTransient<IPersonRepo, PersonRepo>();
builder.Services.AddTransient<IReceptRepo, ReceptRepo>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //Det gränssnitt som finns i webläsaren som visar
    // innehållet i json filen med dokumntation
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();
app.MapControllers();

app.Run();
