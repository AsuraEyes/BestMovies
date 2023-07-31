using Microsoft.AspNetCore.Components;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using MovieServer.DAO;
using MovieServer.Data;
using MovieServer.Data.Media;
using MovieServer.MiddlePoints;
using MovieServer.MiddlePoints.Media;
using MovieServer.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repositories
builder.Services.AddScoped<ICollectionRepository, CollectionRepository>();
builder.Services.AddScoped<IReviewsRepository, ReviewsRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();

//Services
builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<IMediaService, MediaService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ITVService, TVService>();

//MiddlePoint
builder.Services.AddScoped<ICollectionMiddlePoint, CollectionMiddlePoint>();
builder.Services.AddScoped<IMediaMiddlePoint, MediaMiddlePoint>();
builder.Services.AddScoped<IMovieMiddlePoint, MovieMiddlePoint>();
builder.Services.AddScoped<IReviewMiddlePoint, ReviewMiddlePoint>();
builder.Services.AddScoped<ITVMiddlePoint, TVMiddlePoint>();
builder.Services.AddScoped<IUserMiddlePoint, UserMiddlePoint>();
builder.Services.AddScoped<IPostMiddlePoint, PostMiddlePoint>();
builder.Services.AddScoped<IPersonMiddlePoint, PersonMiddlePoint>();

//MongoDB


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