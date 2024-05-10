using Teste.ToDoList.Infra.Entidades;
using Teste.ToDoList.Infra.Enumeradores;

namespace Teste.ToDoList.Infra.Repositorio.Interfaces
{
    public interface ITarefaRepositorio
    {
        /// <summary>
        /// Consulta os dados de uma tarefa pelo seu id.
        /// </summary>
        /// <param name="id">Id para consulta.</param>
        /// <returns>Os dados da <see cref="Tarefa"/> (se existir).</returns>
        Task<Tarefa> Obtenha(int id);

        /// <summary>
        /// Consulta todas as tarefas cadastradas.
        /// </summary>
        /// <returns>Os dados das tarefas encontradas. Veja: <see cref="Tarefa"/>.</returns>
        Task<IEnumerable<Tarefa>> ObtenhaTodas();

        /// <summary>
        /// Consulta os dados das tarefas através do status fornecido.
        /// </summary>
        /// <param name="status">Status para consulta.</param>
        /// <returns>Os dados das tarefas encontradas. Veja: <see cref="Tarefa"/>.</returns>
        Task<IEnumerable<Tarefa>> ObtenhaPorStatus(eStatusTarefa status);

        /// <summary>
        /// Adicionar dados de uma tarefa.
        /// </summary>
        /// <param name="tarefa">Dados da tarefa a ser persistida.</param>
        /// <returns>Retorno se a ação foi realizada com sucesso, juntamente com os  dados da <see cref="Tarefa"/> informada.</returns>
        Task<(bool, string)> Adicionar(Tarefa tarefa);

        /// <summary>
        /// Atualiza o cadastro de uma tarefa.
        /// </summary>
        /// <param name="tarefa">Tarefa a ser atualizada.</param>
        /// <returns>Retorno se a ação foi realizada com sucesso, juntamente com os dados da <see cref="Tarefa"/> atualizada.</returns>
        Task<(bool, string)> Alterar(Tarefa tarefa);

        /// <summary>
        /// Exclui os dados da tarefa informada.
        /// </summary>
        /// <param name="id">Id da tarefa a ser removida.</param>
        /// <returns>Retorno se a ação foi realizada com sucesso, juntamente com a mensagem informativa da ação.</returns>
        Task<(bool, string)> Remover(int id);
    }
}