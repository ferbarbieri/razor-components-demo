using RazorRecrutamento.Core.Data;
using RazorRecrutamento.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorRecrutamento.Core.Services
{
    public class VagasService
    {
        private readonly RecrutamentoContext _context;

        public VagasService(RecrutamentoContext context)
        {
            _context = context;
        }

        public Task AdicionarVaga(Vaga vaga)
        {
            _context.Vagas.Add(vaga);
            return _context.SaveChangesAsync();
        }

        public Task AtualizarVaga(Vaga vaga)
        {
            if (!_context.Vagas.Local.Any(e => e.Id == vaga.Id))
            {
                _context.Attach(vaga);
                _context.Entry(vaga).State = EntityState.Modified;
            }

            return _context.SaveChangesAsync();
        }

        public async Task<bool> ExcluirVaga(int id)
        {
            var vaga = await _context.Vagas.FindAsync(id);

            if(vaga == null)
            {
                return false;
            }

            _context.Vagas.Remove(vaga);

            await _context.SaveChangesAsync();

            return true;
        }


        public Task<List<Vaga>> ListarVagas(string nome = null)
        {
            var vagas = _context.Vagas.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                vagas = vagas
                    .Where(c => c.Nome.Contains(nome));
            }

            return vagas
                .Include(c => c.Candidatos)
                .ToListAsync();
        }


        public Task<Vaga> ObterVaga(int id)
        {
            return _context.Vagas.FindAsync(id);
        }

    }
}
