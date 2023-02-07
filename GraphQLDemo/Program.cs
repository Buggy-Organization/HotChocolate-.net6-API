using GraphQLDemo.DataAccess;
using GraphQLDemo.Models;
using GraphQLDemo.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();

builder.Services.AddDbContext<GraphQldemoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddInMemorySubscriptions();
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>().AddSubscriptionType<Subscription>();
builder.Services.AddScoped<EmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddCors(option => {
    option.AddPolicy("allowedOrigin", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});


var app = builder.Build();
// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

app.UseCors("allowedOrigin");
app.UseWebSockets();
app.UseRouting().UseEndpoints(endpoints => {
    endpoints.MapGraphQL();
});

app.Run();
