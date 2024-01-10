
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using server.Configuration;
using server.Data;
using server.middlewares;
using server.Service;
using server.Service.Products;
using server.Services;
using service.Service;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using dotenv.net;
using server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(builder => 
            builder.SetIsOriginAllowed(_ => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
    });
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection(nameof(MailSettings)));
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                    .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    })
    .AddCookie("Cookies",options=>
    {
        options.ExpireTimeSpan = TimeSpan.FromDays(1);
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Login/";
    }
);


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CreateRole", policy => policy.RequireClaim("Permission", "CreateRole"));

});

builder.Services.AddTransient<IMailService, MailService>();

// builder.Services.AddScoped<IStatusActiveService, StatusActiveService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IUserToRoleService, UserToRoleService>();
builder.Services.AddScoped<IRoleToPermissionService, RoleToPermissionService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IVoucherService, VoucherService>();
builder.Services.AddScoped<IInvoiceService,InvoiceService>();
builder.Services.AddScoped<IStrapMaterialService,StrapMaterialService>();
builder.Services.AddScoped<IWaterResistanceService,WaterResistanceService>();
builder.Services.AddScoped<IDialSizeService,DialSizeService>();
builder.Services.AddScoped<IDialShapeService,DialShapeService>();
builder.Services.AddScoped<IBrandService,BrandService>();
builder.Services.AddScoped<IPartnerService,PartnerService>();

builder.Services.AddScoped<AuthJwtToken>();

DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));
builder.Services.AddSingleton<Cloudinary>(provider => new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL")));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors( );


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
