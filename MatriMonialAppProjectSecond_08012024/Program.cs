
using AllModels.helper;
using AllModels.Model;
using BusinessLayer_08012024.IServices;

using BusinessLayer_08012024.Services;
using DataAccessLayer_08012024.DbConnection;
using MatriMonialAppProjectSecond_08012024.ExceptionHandling;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MatriMonialAppProjectSecond_08012024
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson(option =>
            {
                option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAutoMapper(typeof(UserProfile));

            builder.Services.AddScoped<ICountryMasterService,CountryService>();
            builder.Services.AddScoped<IStateMasterService,StateMasterService>();
            builder.Services.AddScoped<IDistrictMasterService,DistrictMasterService>();
            builder.Services.AddScoped<ISubCasteMasterService,SubCasteMasterService>();
            builder.Services.AddScoped<IGotraMasterService, GotraMasterService>();
            builder.Services.AddScoped<IEducationMasterService,EducationMasterService>();
            builder.Services.AddScoped<IEnquiryService,EnquiryService>();
            builder.Services.AddScoped<IProfessionMasterService,ProfessionMasterSevice>();
            builder.Services.AddScoped<IQualificationService,QualificationService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IUserService,UserService>();
            builder.Services.AddScoped<INewRegistrationService, NewRegistrationService>();
   
          

            builder.Services.AddDbContext<Connection>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnett"));
            });

            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("connt", builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });




            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "your_issuer",
                    ValidAudience = "your_audience",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JwtToken:SecretKey")),
                };
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors("connt");
            }
            app.UseMiddleware(typeof(GlobalErrorHandlingMiddleware));

            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Assets/Image")),
                RequestPath = "/Assets/Image"
            });
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Assets/Image")),
                RequestPath = "/Assets/Image"
            });


            app.MapControllers();

            app.Run();
        }
    }
}