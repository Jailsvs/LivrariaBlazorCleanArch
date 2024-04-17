using LivrariaBlazor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaBlazor.Domain.Abstractions
{
    public interface ILivroRepository
    {
        Task<IEnumerable<Livro>> ObterTodos();
        Task<Livro?> Obter(int id);
        Task<Livro> Adicionar(Livro livro);
        Task Deletar(int id);
        Task Atualizar(Livro livro);
    }
}
