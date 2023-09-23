using AutoMapper;
using Back.Controller.Filters;
using Back.Data;
using Back.Framework;
using Back.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        p => p.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(180), null)), ServiceLifetime.Scoped);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var config = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); });
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "MaximaTech API", Version = "v1" }); });

#region Filtro para validar o ModelState

builder.Services.Configure<ApiBehaviorOptions>(options
    => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddScoped<ModelStateValidationFilter>();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ModelStateValidationFilter>();
    options.Filters.Add<ExceptionFilter>();
});

#endregion

InjecaoDepedencia(builder.Services);

var app = builder.Build();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin 
    .AllowCredentials());


app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "MaximaTech API"); });

app.MapControllers();

app.Run();


void InjecaoDepedencia(IServiceCollection services)
{
    builder.Services.Scan(scan => scan
        .FromCallingAssembly()
        .AddClasses(classes => classes.AssignableTo<IScoped>())
        .AsImplementedInterfaces()
        .WithScopedLifetime());

    builder.Services.Scan(scan => scan
        .FromCallingAssembly()
        .AddClasses(classes => classes.AssignableTo<ISingleton>())
        .AsImplementedInterfaces()
        .WithSingletonLifetime());
}