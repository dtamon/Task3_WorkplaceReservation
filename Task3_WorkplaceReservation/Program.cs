using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Task3_WorkplaceReservation.Domain;
using Task3_WorkplaceReservation.Models;
using Task3_WorkplaceReservation.Repositories.EmployeeRepository;
using Task3_WorkplaceReservation.Repositories.EquipmentForWorkplaceRepository;
using Task3_WorkplaceReservation.Repositories.EquipmentRepository;
using Task3_WorkplaceReservation.Repositories.ReservationRepository;
using Task3_WorkplaceReservation.Repositories.WorkplaceRepository;
using Task3_WorkplaceReservation.Services.EmployeeService;
using Task3_WorkplaceReservation.Services.EquipmentService;
using Task3_WorkplaceReservation.Services.ReservationService;
using Task3_WorkplaceReservation.Services.WorkplaceService;
using Task3_WorkplaceReservation.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ReservationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));

//Repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEquipmentForWorkplaceRepository, EquipmentForWorkplaceRepository>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IWorkplaceRepository, WorkplaceRepository>();

//Services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IEquipmentService, EquipmentService>();
builder.Services.AddScoped<IWorkplaceService, WorkplaceService>();

//FluentValidation Validators
builder.Services.AddScoped<IValidator<EmployeeViewModel>, EmployeeValidator>();
builder.Services.AddScoped<IValidator<EquipmentViewModel>, EquipmentValidator>();
builder.Services.AddScoped<IValidator<WorkplaceViewModel>, WorkplaceValidator>();
builder.Services.AddScoped<IValidator<EqForWorkViewModel>, EqForWorkValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Reservation}/{action=Index}/{id?}");

app.Run();
