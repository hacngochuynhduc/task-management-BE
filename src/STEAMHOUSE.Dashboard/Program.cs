using System.Reflection;
using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using STEAMHOUSE.Dashboard.TaskServices;
using STEAMHOUSE.Dashboard.TaskServices.Task_Management.Validator;
using STEAMHOUSE.Infrastruture;
using STEAMHOUSE.Infrastruture.Behaviors;
using STEAMHOUSE.Infrastruture.Data;
using STEAMHOUSE.Infrastruture.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices(builder.Configuration);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
});

// --- 2. MediatR & Validation (Trái tim của Logic) ---
builder.Services.AddValidatorsFromAssembly(typeof(CreateTaskListValidator).Assembly);

builder.Services.AddMediatR(cfg => 
{
    // Quét Handler ở cả Project Web và Project Services
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    cfg.RegisterServicesFromAssembly(typeof(TaskServicesDependencies).Assembly);
    
    // Đăng ký Pipeline Behavior để tự động chặn dữ liệu lỗi
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>)); 
});

// --- 3. Authentication & JWT ---
var jwtKey = builder.Configuration["JwtSettings:Key"] ?? throw new InvalidOperationException("JWT Secret Key is not configured.");
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
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

// --- 4. API Controllers & Filters ---
builder.Services.AddControllers(options =>
{
    // Bắt lỗi Validation và trả về Result<T>
    options.Filters.Add<ValidationExceptionFilter>();
});

builder.Services.AddAuthorization();
builder.Services.AddTaskServices();


var myCors = "AllowAngularApp";
var allowedOrigins = builder.Configuration
    .GetSection("CorsSettings:AllowedOrigins")
    .Get<string[]>() ?? [];

builder.Services.AddCors(options =>
{
    options.AddPolicy(myCors, policy =>
    {
        policy
            .WithOrigins(allowedOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); 
    });
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Task Management API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "Enter 'Bearer' [space] and then your token."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// --- 6. Pipeline HTTP Request ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors(myCors);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers().RequireCors(myCors);

app.Run();