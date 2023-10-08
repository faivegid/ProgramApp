using ProgramApp;
using ProgramApp.AppService;
using ProgramApp.Domain;
using ProgramApp.Middleware;
using ProgramApp.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureApiBehaviorOptions();
builder.Services.AddDb(builder.Configuration);
builder.Services.ConfigureSharedLibrary(builder.Configuration);
builder.Services.ConfigureDomain();
builder.Services.ConfigureAppServices();
builder.Services.AddAutoMapper(typeof(MappingProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandleMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
