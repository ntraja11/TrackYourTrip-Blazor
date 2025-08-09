using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Radzen;
using TrackYourTrip.Components;
using TrackYourTrip.Components.Account;
using TrackYourTrip.Data;
using TrackYourTrip.Data.DbInitializer;
using TrackYourTrip.Hubs;
using TrackYourTrip.Repository;
using TrackYourTrip.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IJobPostRepository, JobPostRepository>();
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
builder.Services.AddScoped<IParticipantRepository, ParticipantRepository>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<TrackYourTripDbContext>(options =>
    options.UseSqlServer(connectionString));


//builder.Services.AddDataProtection()f
//    .PersistKeysToFileSystem(new DirectoryInfo("/app/DataProtection-Keys"));

builder.Services.AddRadzenComponents();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<TrackYourTripDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();



var blobServiceClient = new BlobServiceClient(builder.Configuration.GetValue<string>("BlobConnectionString"));
var containerClient = blobServiceClient.GetBlobContainerClient(builder.Configuration.GetValue<string>("BlobContainerName"));
containerClient.CreateIfNotExists();

var blobClient = containerClient.GetBlobClient("keys.xml");

builder.Services.AddDataProtection()
    .PersistKeysToAzureBlobStorage(blobClient);

builder.Services.AddSignalR();
builder.Services.AddResponseCompression(options =>
{
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes
        .Concat(new[] { "application/octet-stream"});
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.UseResponseCompression();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapHub<JobPostHub>("/jobPostHub");
app.MapHub<CompanyHub>("/companyHub");

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();



DbInitializer();

app.Run();


void DbInitializer()
{
    using var scope = app.Services.CreateScope();

    //var dbContext = scope.ServiceProvider.GetRequiredService<TrackYourTripDbContext>();
    //dbContext.Database.Migrate(); // Apply migrations and create DB if needed

    var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
    dbInitializer.InitializeAsync();
}

