using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using TrimTrim.DAL;
using TrimTrim.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        //DI

        builder.Services.AddDefaultIdentity<IdentityUser>(options => {
            options.SignIn.RequireConfirmedAccount = false;
            // Configure password requirements
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
          
        })
            
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();

        builder.Services.AddDbContext<AppDbContext>
            (options =>
            options.UseSqlServer
            (builder.Configuration.GetConnectionString
            ("DefaultConnection"))
            );
        
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("UserOnly", policy =>
            {
                policy.RequireAuthenticatedUser(); // Require the user to be authenticated
                policy.RequireRole("User");
            });
            options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
        });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("UserOnly", policy =>
            {
                policy.RequireAuthenticatedUser(); // Require the user to be authenticated
            });
        });

        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Admin/Login"; // Specify your custom login path
            options.AccessDeniedPath = "/Admin/Login"; // Specify your custom access denied path
        });

        builder.Services.AddMvc();

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

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapRazorPages();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
        });

        app.Run();
    }
}