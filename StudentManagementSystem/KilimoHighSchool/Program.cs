using KilimoHighSchool.DataAccess;
using KilimoHighSchool.Database;
using KilimoHighSchool.Extensions;
using KilimoHighSchool.Features.ClassStreams.Database;
using KilimoHighSchool.Features.Students.Database;

var builder = WebApplication.CreateBuilder(args);

//Configure Db

builder.ConfigureDatabaseSQLServer(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();

//add system services
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IBaseGenericRepository<>), typeof(BaseGenericRepository<>));
builder.Services.AddScoped(typeof(IStudentRepository), typeof(StudentRepository));
builder.Services.AddScoped(typeof(IClassStreamRepository), typeof(ClassStreamRepository));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
