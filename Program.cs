var builder = WebApplication.CreateBuilder(args);

// Controllers (necesarios para una API REST)
builder.Services.AddControllers();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Aquí registrarás tus repositorios
// builder.Services.AddSingleton<ITasksRepository, TasksRepository>();

var app = builder.Build();

// Swagger siempre habilitado (Render lo muestra sin problema)
app.UseSwagger();
app.UseSwaggerUI();

// Opcional: CORS para que el frontend pueda consumirlo
app.UseCors(policy =>
{
    policy.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod();
});

// Para URLs https (opcional en Render)
app.UseHttpsRedirection();

// Conecta las rutas de tus controladores
app.MapControllers();

app.Run();

