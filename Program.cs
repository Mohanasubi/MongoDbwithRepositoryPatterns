using ASP.MongoDb.API.Repository;
using ASP.MongoDb.API.Settings;

var builder = WebApplication.CreateBuilder(args);

//bind mongodb settings
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection(nameof(MongoDbSettings)));



// Add services to the container.
//Add the repositories
   builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//Add the employee repository
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

//Add the department repository
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
