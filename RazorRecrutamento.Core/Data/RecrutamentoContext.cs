using Microsoft.EntityFrameworkCore;
using RazorRecrutamento.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorRecrutamento.Core.Data
{
    public class RecrutamentoContext : DbContext
    {
        public RecrutamentoContext(DbContextOptions<RecrutamentoContext> options)
            : base(options)
        {
        }

        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Vaga> Vagas { get; set; }

    }
}
