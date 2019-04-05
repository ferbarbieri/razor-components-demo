using Microsoft.AspNetCore.Mvc;
using RazorRecrutamento.Core.Model;
using RazorRecrutamento.Core.Services;
using RazorRecrutamento.Web.Blazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorRecrutamento.Web.Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    public class VagasController : Controller
    {
        private readonly VagasService _service;

        public VagasController(VagasService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<VagaDTO>> GetVagas()
        {
            var vagas = (await _service.ListarVagas()).ToArray();

            var dtos = vagas.Select(c => new VagaDTO
            {
                Nome = c.Nome,
                Descricao = c.Descricao,
                Id = c.Id
            });

            return dtos;
        }

        [HttpGet("{id}")]
        public async Task<VagaDTO> GetVaga(int id)
        {
            var vaga = (await _service.ObterVaga(id));
            var dto = new VagaDTO { Id = vaga.Id, Nome = vaga.Nome, Descricao = vaga.Descricao };
            return dto;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateVaga(int id, [FromBody] VagaDTO vaga)
        {
            Vaga v = new Vaga { Id = id, Nome = vaga.Nome, Descricao = vaga.Descricao };
            await _service.AtualizarVaga(v);
            return Ok(vaga);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVaga([FromBody] VagaDTO vaga)
        {
            Vaga v = new Vaga { Id = vaga.Id, Nome = vaga.Nome, Descricao = vaga.Descricao };
            await _service.AdicionarVaga(v);
            vaga.Id = v.Id;
            return Created($"/api/vagas/{v.Id}", vaga);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaga(int id)
        {
            await _service.ExcluirVaga(id);
            return Ok();
        }

    }
}