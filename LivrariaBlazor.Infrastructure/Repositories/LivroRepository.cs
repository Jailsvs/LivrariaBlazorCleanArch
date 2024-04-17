using LivrariaBlazor.Domain.Abstractions;
using LivrariaBlazor.Domain.Entities;
using LivrariaBlazor.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LivrariaBlazor.Infrastructure.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly ApplicationDbContext _context;
        public LivroRepository(ApplicationDbContext context)
        {
            _context = context ;
        }

        public async Task<Livro> Adicionar(Livro livro)
        {
            ValidarDados(livro);
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
            return livro;
        }

        public async Task Atualizar(Livro livro)
        {
            ValidarDados(livro);
            _context.Entry(livro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(int id)
        {
            var livro = await Obter(id);
            ValidarDados(livro);
            _context.Remove(livro);
            await _context.SaveChangesAsync();
        }

        public async Task<Livro?> Obter(int id)
        {
            ValidarDados();
            return await _context.Livros.FirstOrDefaultAsync(l => l.Id.Equals(id)) 
                   ?? throw new InvalidOperationException($"Livro com Id {id} não encontrado!");
        }

        public async Task<IEnumerable<Livro>> ObterTodos()
        {
            ValidarDados();
            return await _context.Livros.ToListAsync();
        }

        private void ValidarDados(Livro livro)
        {
            ValidarDados();
            if (livro is null)
                throw new InvalidOperationException("Dados inválidos!");
        }

        private void ValidarDados()
        {
            if (_context is null ||
               _context.Livros is null)
                throw new InvalidOperationException("Dados inválidos!");
        }
    }
}
