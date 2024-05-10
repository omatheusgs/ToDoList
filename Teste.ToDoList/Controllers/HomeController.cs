using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using Teste.ToDoList.Infra.Entidades;
using Teste.ToDoList.Infra.Enumeradores;
using Teste.ToDoList.Infra.Repositorio.Interfaces;

namespace Teste.ToDoList.Controllers
{
    /// <summary>
    /// Controle relacionado as ações da <see cref="Teste.ToDoList.Infra.Entidades.Tarefa"/>.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        /// <param name="tarefaRepositorio"></param>
        public HomeController(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        /// <summary>
        /// Abre a view com todas as tarefas.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index()
            => View(await _tarefaRepositorio.ObtenhaTodas());

        /// <summary>
        /// Abre a view com todas as tarefas com o status em andamento.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> EmAndamento()
            => View(await _tarefaRepositorio.ObtenhaPorStatus(eStatusTarefa.EmAndamento));

        /// <summary>
        /// Abre a view com todas as tarefas com o status pendente.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Pendentes()
            => View(await _tarefaRepositorio.ObtenhaPorStatus(eStatusTarefa.Pendente));

        /// <summary>
        /// Abre a view para adicionar uma tarefa.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Adicionar()
            => View("Tarefa", new Tarefa() { DataInicio = DateTime.Now });

        /// <summary>
        /// Abre a view para editar a tarefa selecionada.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Tarefa(int id)
            => View(await _tarefaRepositorio.Obtenha(id));

        /// <summary>
        /// Adiciona ou atualiza a tarefa informada.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> AdicionarOuEditar(Tarefa tarefa)
        {
            try
            {
                (bool, string) resultado;

                if (tarefa.Id == 0)
                    resultado = await _tarefaRepositorio.Adicionar(tarefa);
                else
                    resultado = await _tarefaRepositorio.Alterar(tarefa);

                return Json(new { sucesso = resultado.Item1, mensagem =  resultado.Item2 });
            }
            catch (Exception ex)
            {
                return Json(new { sucesso = false, mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Remove a tarefa informada.
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Remover(int id)
        {
            var resultado = await _tarefaRepositorio.Remover(id);
            return Json(new { sucesso = resultado.Item1, mensagem = resultado.Item2 });
        }
    }
}