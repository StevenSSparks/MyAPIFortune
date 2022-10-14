using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using MyAPIFortune.Interfaces;
using MyAPIFortune.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(o => o.AddPolicy("CORSPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

// allows for MVC and API functionality 
builder.Services.AddMvc(options => options.EnableEndpointRouting = false)
                .AddControllersAsServices(); // this adds the controllers as services to all for DI to resolve them 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API Fortune", Version = "v1" });
}); ;

// add custom services 
builder.Services.AddSingleton<IGetFortune, GetFortuneService>();
builder.Services.AddTransient<IAppVersionService, AppVersionService>();
builder.Services.AddSingleton<IDiceRolling, DiceRollingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseCors("CORSPolicy");
app.UseSwagger();
app.UseSwaggerUI(c => {

    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API Fortune v1");

});

app.UseStaticFiles();
app.UseMvc();

app.Run();
