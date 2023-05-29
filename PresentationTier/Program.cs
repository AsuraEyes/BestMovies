using Microsoft.AspNetCore.Components.Authorization;
using MovieServer.Controllers;
using MovieServer.MiddlePoints;
using MovieServer.Repository;
using PresentationTier.Authorization;
using PresentationTier.Data;
using PresentationTier.Data.Media;
using Radzen;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

//Radzen Services
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

// Add HttpContextAccessor
builder.Services.AddHttpContextAccessor();

//Services
builder.Services.AddScoped<ICollectionService, CollectionService>();
builder.Services.AddScoped<IMediaService, MediaService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ITVService, TVService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IUserMiddlePoint, UserMiddlePoint>();
builder.Services.AddScoped<IPostMiddlePoint, PostMiddlePoint>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Reviewer", a => a.RequireAuthenticatedUser().RequireClaim("Level", "Reviewer"));
    options.AddPolicy("Administrator", a => a.RequireAuthenticatedUser().RequireClaim("Level", "Administrator"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
