using DatabaseOperations.Interfaces;
using Interfaces;
using Jandag.BLL.Interface;
using Jandag.BLL.Mapper;
using Jandag.BLL.Services;
using Jandag.DLL.Data;
using Jandag.DLL.Entities;
using Jandag.DLL.Interfaces;
using Jandag.DLL.Repositories;
using Jandag.DLL.Repositories.UserRelated;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using Speaker.leison.Database_Layer.Interfaces;
using Speaker.leison.Database_Layer.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddDbContext<GlobalTvDb>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("GlobalCOnnection"));
});

builder.Services.AddIdentity<User, IdentityRole>().
    AddEntityFrameworkStores<GlobalTvDb>()
    .AddUserManager<UserManager>()
    .AddSignInManager<SignInManagerForUser>()
    .AddDefaultTokenProviders();

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://localhost:59561",
            ValidAudience = "http://localhost:59561",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("65E255FF-F399-42D4-9C7F-D5D08B0EC285")),
        };
    });

builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddScoped<SignInManager<User>>();

builder.Services.AddScoped<IChanellRepository,ChanellRepository>();
builder.Services.AddScoped<IDesclamlerCard,DesclamlerCardRepository>();
builder.Services.AddScoped<IDesclambler,DesclamblerRepository>();
builder.Services.AddScoped<IEmr60Info,Emr60InfoRepository>();
builder.Services.AddScoped<IRecieverInterface, RecieverRepository>();
builder.Services.AddScoped<ISourceRepository, SourceRepository>();
builder.Services.AddScoped<ITranscoderRepository, TranscoderReporitory>();
builder.Services.AddScoped<IUniteOfWork, UniteOfWork>();

builder.Services.AddScoped< UserManager<User>,UserManager>();
builder.Services.AddScoped<SignInManager<User>, SignInManagerForUser>();

builder.Services.AddScoped<IUserService, CustomerServices>();
builder.Services.AddScoped<IAllInOneService, AllInOneService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=SignIn}");

app.Run();
