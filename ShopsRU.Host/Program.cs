using Microsoft.EntityFrameworkCore;
using ShopsRU.Persistence.Context.EntityFramework;
using ShopsRU.Persistence.Bootstrapper;
using FluentValidation.AspNetCore;
using ShopsRU.Application.Validators;
using ShopsRU.Infrastructure.Attributes;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
            .AddFluentValidation(configuration => configuration
                .RegisterValidatorsFromAssemblyContaining<ProductValidator>())
            .ConfigureApiBehaviorOptions(o => o.SuppressModelStateInvalidFilter = true);
 




builder.Services.AddPersistenceServiceRegistration(builder.Configuration);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
