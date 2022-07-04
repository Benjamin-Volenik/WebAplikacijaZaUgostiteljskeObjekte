using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using WebAplikacijaZaUgostiteljskeObjekte.Client.AuthProviders;
using WebAplikacijaZaUgostiteljskeObjekte.Client.HttpRepository;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Core;
using WebAplikacijaZaUgostiteljskeObjekte.Server.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Data>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IUgostiteljskiObjektiService, UgostiteljskiObjektiService>();
builder.Services.AddScoped<IDishService, DishService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7058") });

builder.Services.AddSwaggerGen();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, TestAuthStateProvider>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddApiAuthorization();



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor API V1");
});

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
