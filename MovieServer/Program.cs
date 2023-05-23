using MovieServer.DAO;
using MovieServer.Data.Media;
using MovieServer.MiddlePoints;
using MovieServer.MiddlePoints.Media;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repositories
builder.Services.AddScoped<IReviewsRepository, ReviewsRepository>();

//Services
builder.Services.AddScoped<IMediaService, MediaService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<ITVService, TVService>();

//MiddlePoint
builder.Services.AddScoped<IMediaMiddlePoint, MediaMiddlePoint>();
builder.Services.AddScoped<IMovieMiddlePoint, MovieMiddlePoint>();
builder.Services.AddScoped<IReviewMiddlePoint, ReviewMiddlePoint>();
builder.Services.AddScoped<ITVMiddlePoint, TVMiddlePoint>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();