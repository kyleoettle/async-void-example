using Void.Demo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDemoService, DemoService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//register exception middleware
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


TaskScheduler.UnobservedTaskException += (sender, e) =>
{
    Console.WriteLine($"*** UnhandledException in TaskScheduler! - {e.Exception}");
};

AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
{
    Console.WriteLine($"*** UnhandledException in AppDomain! - {e.ExceptionObject}");
};


app.Run();
