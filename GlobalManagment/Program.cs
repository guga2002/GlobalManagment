using DatabaseOperations.Interfaces;
using Interfaces;
using Jandag.BLL.Interface;
using Jandag.BLL.Mapper;
using Jandag.BLL.Services;
using Jandag.DLL.Data;
using Jandag.DLL.Entities;
using Jandag.DLL.Interfaces;
using Jandag.DLL.Repositories;
using Jandag.Persistance.Interface;
using Jandag.Persistance.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
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

builder.WebHost.UseKestrel(options =>
{
    options.ListenAnyIP(3395); // Bind to all interfaces on port 3056
});

builder.Services.AddDbContext<GlobalTvDb>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("GlobalCOnnection"));
});


builder.Services.AddIdentity<User, IdentityRole>().
    AddEntityFrameworkStores<GlobalTvDb>()
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
builder.Services.AddScoped<ISourceRepository, SourceRepository>();
builder.Services.AddScoped<ITranscoderRepository, TranscoderReporitory>();
builder.Services.AddScoped<IUniteOfWork, UniteOfWork>();


builder.Services.AddScoped<IUserService, CustomerServices>();
builder.Services.AddScoped<IAllInOneService, AllInOneService>();
builder.Services.AddScoped<ITranscoderService, TranscoderServices>();
builder.Services.AddScoped <ISatteliteFrequencyService,SatteliteFrequencyService> ();
builder.Services.AddScoped<ISatteliteFrequency, SatteliteFrequencyRepository>();
builder.Services.AddScoped<IChanellServices, ChanellServices>();

builder.Services.AddScoped<RoleManager<IdentityRole>>();
builder.Services.AddScoped<IService,EmrServices>();
builder.Services.AddScoped<IsourceServices, SourceService>();

builder.Services.AddScoped<ITemperatureService, TemperatureService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(@"C:\"), // Serve from the root of C:
    RequestPath = "" // Make files accessible without a prefix
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Unite}/{action=Index}");

app.Run();
