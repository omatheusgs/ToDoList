using Microsoft.EntityFrameworkCore;
using Teste.ToDoList.Infra.Context;
using Teste.ToDoList.Infra.Entidades;
using Teste.ToDoList.Infra.Enumeradores;
using Teste.ToDoList.Infra.Repositorio.Interfaces;

namespace Teste.ToDoList.Infra.Repositorio
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly MyDbContext _context;

        public TarefaRepositorio(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Tarefa> Obtenha(int id)
        {
            return await _context.Tarefas.FindAsync(id);
        }

        public async Task<IEnumerable<Tarefa>> ObtenhaTodas()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public async Task<IEnumerable<Tarefa>> ObtenhaPorStatus(eStatusTarefa status)
        {
            return await _context.Tarefas.Where(c => c.Status == status).ToListAsync();
        }

        public async Task<(bool, string)> Adicionar(Tarefa tarefa)
        {
            try
            {
                await ValideTarefa(tarefa);
                await _context.Tarefas.AddAsync(tarefa);
                await _context.SaveChangesAsync();
                return (true, "A tarefa foi adicionada.");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string)> Alterar(Tarefa tarefa)
        {
            try
            {
                await ValideTarefa(tarefa);

                var persistido = await Obtenha(tarefa.Id);
                if (persistido == null)
                    throw new Exception("A tarefa persistida não foi encontrada.");

                persistido.Titulo = tarefa.Titulo;
                persistido.Descricao = tarefa.Descricao;
                persistido.DataInicio = tarefa.DataInicio;
                persistido.DataFim = tarefa.DataFim;
                persistido.Status = tarefa.Status;

                _context.Tarefas.Update(persistido);
                await _context.SaveChangesAsync();

                return (true, "A tarefa foi alterada.");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string)> Remover(int id)
        {
            try
            {
                var persistido = await Obtenha(id);
                if (persistido == null)
                    throw new Exception("A tarefa persistida não foi encontrada.");

                _context.Tarefas.Remove(persistido);
                await _context.SaveChangesAsync();

                return (true, "A tarefa foi removida.");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        private async Task ValideTarefa(Tarefa tarefa)
        {
            if (string.IsNullOrEmpty(tarefa.Titulo))
                throw new Exception("O título da tarefa é obrigatório.");

            if (string.IsNullOrEmpty(tarefa.Descricao))
                throw new Exception("A descrição da tarefa é obrigatória.");

            if (tarefa.DataInicio == DateTime.MinValue)
                throw new Exception("A data inicial da tarefa é obrigatória.");

            if (tarefa.DataFim.HasValue && tarefa.DataInicio > tarefa.DataFim)
                throw new Exception("A data inicial não pode ser maior que a final.");

            if (await _context.Tarefas.AnyAsync(c => c.Id != tarefa.Id && c.Titulo.ToLower().Equals(tarefa.Titulo.ToLower())))
                throw new Exception("Já existe uma outra tarefa com essa mesma descrição.");
        }
    }
}