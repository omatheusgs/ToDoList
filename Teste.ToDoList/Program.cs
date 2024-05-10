using Microsoft.EntityFrameworkCore;
using Teste.ToDoList.Infra.Context;
using Teste.ToDoList.Infra.Repositorio;
using Teste.ToDoList.Infra.Repositorio.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

/* 
 * Aqui estamos configurando o EF Core para utilizar um banco em mem�ria. 
 * Como o prop�sito da atividade � s� demonstrar o conhecimento com EF, n�o achei necess�rio utilizar algum outro banco de dados.
 * Mas se fosse necess�rio, era s� configurar a aplica��o com a ConnectionString necess�ria que o funcionamento restante ia ser o mesmo.
 */
builder.Services.AddDbContext<MyDbContext>(opt => opt.UseInMemoryDatabase("minhas_tarefas"));
builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
