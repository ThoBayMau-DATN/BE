using BACK_END.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BACK_ENDContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BACK_ENDContext") ?? throw new InvalidOperationException("Connection string 'BACK_ENDContext' not found.")));

builder.Services.AddServices();



// Add Identity services
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    /*- Yêu cầu ít nhất 1 chữ số
    - Độ dài tối thiểu 6 ký tự
    - Không bắt buộc ký tự đặc biệt và chữ hoa
    - Bắt buộc có chữ thường
    - Yêu cầu ít nhất 1 ký tự duy nhất*/
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = true;
    options.Password.RequiredUniqueChars = 1;
})
    .AddEntityFrameworkStores<BACK_ENDContext>()
    .AddErrorDescriber<CustomIdentityErrorDescriber>()
    .AddDefaultTokenProviders();

// Configure JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddMemoryCache(); // su dung cache

var MyCors = "_APP-CORS"; // => Config name cors
// setting cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyCors,
                      policy =>
                      {
                          policy.WithOrigins("*");
                          policy.WithMethods("*");
                          policy.WithHeaders("*");
                      });
});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: MyCors,
//                      policy =>
//                      {
//                          policy.WithOrigins("http://localhost:5173")
//                                .AllowAnyHeader()
//                                .AllowAnyMethod()
//                                .AllowCredentials();
//                      });
//});

var app = builder.Build();

FirebaseApp.Create(new AppOptions()
{
    Credential = GoogleCredential.FromFile("firebase-config.json")
});

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        // Gọi SeedData để tạo tài khoản admin và các role mặc định
        SeedData.Initialize(services).Wait();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyCors);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
