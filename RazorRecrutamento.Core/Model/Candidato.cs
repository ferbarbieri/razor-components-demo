using System;
using System.Collections.Generic;
using System.Text;

namespace RazorRecrutamento.Core.Model
{
    public class Candidato
    {
        // ID do candidato
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataRegistro { get; set; }
        public string Descricao { get; set; }
        public string Email { get; set; }
        public Vaga Vaga { get; set; }
        public bool Aprovado { get; set; }
    }
}
