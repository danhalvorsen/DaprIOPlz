using MediatR;
using RpiService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClientConfiguration(builder.Configuration)
.AddHttpClientConfigDependencies();
builder.Services.AddControllers().AddDapr();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<GeneralBackgroundHost>();
builder.Services.AddMediatR(typeof(Program));
var app = builder.Build();

app.UseCloudEvents();
app.MapControllers();
app.MapSubscribeHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapGet("/notifications/{userId}",(int userId) => {
	return new List<Notification>();
});

app.MapPost("/notifications/{userId}",(int userId) => {
	return new List<Notification>();
})
.WithName("GetWeatherForecast")
.WithOpenApi();
app.Run();

