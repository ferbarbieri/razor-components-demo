using System;
using System.Collections.Generic;
using System.Text;

namespace RazorRecrutamento.Core.Model
{
    public class Vaga
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public IList<Candidato> Candidatos { get; set; }

    }
}
