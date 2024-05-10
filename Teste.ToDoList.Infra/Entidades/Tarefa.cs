using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Teste.ToDoList.Infra.Enumeradores;

namespace Teste.ToDoList.Infra.Entidades
{
    public class Tarefa
    {
        [Required, Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Titulo { get; set; }

        [Required, MaxLength(500)]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        public DateTime? DataFim { get; set; }

        [Required]
        public eStatusTarefa Status { get; set; } = eStatusTarefa.Pendente;

        public string StatusDescricao
        {
            get
            {
                switch (Status)
                {
                    case eStatusTarefa.Pendente:
                        return "Pendente";
                    case eStatusTarefa.Concluida:
                        return "Concluída";
                    default:
                        return "Em Andamento";
                }
            }
        }
    }
}