using CYBERQUIZ.BLL.SERVICES;
using CYBERQUIZ.DAL.DATA;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registrerar AppDbContext med connection string från appsettings.json
// EnableRetryOnFailure gör att EF Core försöker igen om LocalDB inte
// hunnit starta upp än
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorNumbersToAdd: null
        )
    ));



// Add services to the container.
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped<IProfileService, ProfileService>();
// Tror inte vi behöver lägga till dessa i UI i och med att UI > API > Services > DAL? Vi får se :) 

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowALL", policy =>
    {
        policy.WithOrigins(builder.Configuration["AllowedOrigins"] ?? "https://localhost:7270")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Krävs för Identity-cookies
    });
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


// AddIdentity registrerar UserManager, SignInManager och RoleManager
// AddEntityFrameworkStores kopplar Identity till vår AppDbContext

//builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => {
//    options.SignIn.RequireConfirmedAccount = false;
//    options.Password.RequireDigit = true;
//    options.Password.RequiredLength = 6;
//    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
//    options.User.RequireUniqueEmail = true;
//})
//.AddEntityFrameworkStores<AppDbContext>();
builder.Services
    .AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddCookie(IdentityConstants.ApplicationScheme);
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(@"C:\keys"))
    .SetApplicationName("CyberQuiz");

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


//skapar användare "user" med lösenord "Password1234!"
//using (var scope = app.Services.CreateScope())
//{
//    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
//    if (await userManager.FindByNameAsync("user") == null)
//    {
//        var defaultUser = new IdentityUser { UserName = "user", Email = "user@cyberquiz.se" };
//        await userManager.CreateAsync(defaultUser, "Password1234!");
//    }
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors("AllowALL");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
