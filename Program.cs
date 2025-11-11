using WebAPI_Aprendizado.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddSingleton<DevEventsDbContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();






//Cria o recurso do Swagger, que é uma documentação padrão gerada automaticamente para APIs RESTful
//https://swagger.io/

builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configura o middleware do Swagger para ser usado na aplicação
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}









app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
