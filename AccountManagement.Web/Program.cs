using AccountManagement.Web.Endpoints;
using AccountManagement.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddRepositories();

var app = builder.Build();

app.RegisterUserAccountEndpoints();

app.Run();
