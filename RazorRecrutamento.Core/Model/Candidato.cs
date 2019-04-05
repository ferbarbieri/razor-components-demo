using System;
using System.Collections.Generic;
using System.Text;

namespace RazorRecrutamento.Core.Model
{
    public class Candidato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataRegistro { get; set; }
        public string Descricao { get; set; }
        public string Email { get; set; }
        public Vaga Vaga { get; set; }
    }
}
