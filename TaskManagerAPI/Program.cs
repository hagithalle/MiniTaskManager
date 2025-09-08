var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer(); // חובה ל-Swagger
builder.Services.AddSwaggerGen(); // חובה ל-Swagger

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();         // מאפשר Swagger JSON
    app.UseSwaggerUI();       // מאפשר Swagger UI ב /swagger
}

app.UseHttpsRedirection();

app.Run();


