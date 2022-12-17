using TestCrud.models.db;
using TestCrud.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// inyectando db
builder.Services.AddSqlServer<TestCrudContext>(builder.Configuration.GetConnectionString("TestCrud"));

//configurando cors
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
}));

// configurando automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// inyectando servicios
builder.Services.AddScoped<IPeliculaRepository,PeliculaRepository>();
builder.Services.AddScoped<IGeneroRepository,GeneroRepository>();
builder.Services.AddScoped<IUsuarioRepository,UsuarioRepository>();


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

app.UseCors("MyPolicy");

app.MapControllers();

app.Run();
