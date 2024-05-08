using CloudSalesSystem.API.Extensions;
using CloudSalesSystem.Application;
using CloudSalesSystem.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    //options.AddPolicy(name: ORIGIN_FROM_CONFIGURATION,
    //                  policy =>
    //                  {
    //                      policy.WithOrigins("http://example.com",
    //                                          "http://www.contoso.com");
    //                  });


    options.AddDefaultPolicy(x => x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
});
builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureServices();
builder.Services.ConfigureInfrastructure(builder.Configuration);
builder.Services.ConfigureApplication();
builder.Services.AddHttpContextAccessor();

WebApplication app = builder.Build();

await app.MigrateDatabaseAsync();

app.UseSwagger();
app.UseSwaggerUI(c =>
   c.SwaggerEndpoint("/swagger/v1/swagger.json", "CloudSalesSystem.REST v1.1"));

app.UseResponseCompression();

app.UseCors(builder =>
{
    // Should be added if required
    // Update with your actual client origin if needed
    // builder.WithOrigins("http://localhost:4200") 
    //       .AllowAnyHeader()
    //       .AllowAnyMethod();

    builder.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
//app.UseAuthorization();
app.MapControllers();

app.Run();
public partial class Program { }
