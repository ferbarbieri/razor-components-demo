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
    public class CandidatosService
    {
        private readonly RecrutamentoContext _context;

        public CandidatosService(RecrutamentoContext context)
        {
            _context = context;
        }

        public Task AdicionarCandidato(Candidato Candidato)
        {
            _context.Candidatos.Add(Candidato);
            return _context.SaveChangesAsync();
        }

        public Task AtualizarCandidato(Candidato Candidato)
        {
            if (!_context.Candidatos.Local.Any(e => e.Id == Candidato.Id))
            {
                _context.Attach(Candidato);
                _context.Entry(Candidato).State = EntityState.Modified;
            }

            return _context.SaveChangesAsync();
        }

        public async Task<bool> ExcluirCandidato(int id)
        {
            var Candidato = await _context.Candidatos.FindAsync(id);

            if (Candidato == null)
            {
                return false;
            }

            _context.Candidatos.Remove(Candidato);

            await _context.SaveChangesAsync();

            return true;
        }
               
        public Task<List<Candidato>> ListarCandidatos(string nome = null)
        {
            var Candidatos = _context.Candidatos.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                Candidatos = Candidatos
                    .Where(c => c.Nome.Contains(nome));
            }

            return Candidatos
                .Include(c => c.Vaga)
                .ToListAsync();
        }


        public Task<Candidato> ObterCandidato(int id)
        {
            return _context.Candidatos.FindAsync(id);
        }


    }
}
