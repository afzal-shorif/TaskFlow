using TaskFlow.Application;
using TaskFlow.Application.Commands;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(options =>
{
    options.LicenseKey = "";
    options.RegisterServicesFromAssembly(typeof(CreateTaskCommand).Assembly);
});

builder.Services.AddApplicationDepencency();

//builder.Services.AddDbContext<AppDbContext>(options => { });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "";
    });
}

app.MapControllers();

app.Run();
