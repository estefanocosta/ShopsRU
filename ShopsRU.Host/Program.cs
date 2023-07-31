using ShopsRU.Persistence.Bootstrapper;
using FluentValidation.AspNetCore;
using ShopsRU.Application.Validators;

using ShopsRU.Host.Extensions;
using ShopsRU.Host.Middlewares;
using ShopsRU.Host.Attributes;
using NLog;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
            .AddFluentValidation(configuration => configuration
                .RegisterValidatorsFromAssemblyContaining<ProductValidator>())
            .ConfigureApiBehaviorOptions(o => o.SuppressModelStateInvalidFilter = true);
builder.Services.AddPersistenceServiceRegistration(builder.Configuration);



 
 

#region Versioning


#endregion


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shops RU", Version = "v1" });
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shops RU V1");
        c.DocumentTitle = "Shops RU V1 Docs";
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List); 
        c.InjectStylesheet("/assets/css/swagger-ui.css");
        c.DefaultModelsExpandDepth(-1);
    });
}
app.UseGlobalExceptionHandler();
app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseAuthorization();
app.UseSwagger();
app.UseStaticFiles();



app.MapControllers();

app.Run();
