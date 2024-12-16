using ConstructionMaterials.Api.Extensions;
using ConstructionMaterials.Application.Extensions;
using ConstructionMaterials.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configure services

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Construction Materials API v1"));

app.MapControllers();

app.Run();