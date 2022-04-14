using FluentResults;
using LivrariaApi.Data.Dtos;
using LivrariaApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace LivrariaApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BibliotecaController : ControllerBase
    {
        private LivroService _livroService;

        public BibliotecaController(LivroService livroService)
        {
            _livroService = livroService;
        }

        [Route("/AdicionaLivro")]
        [HttpPost]
        public IActionResult AdicionaLivro([FromBody] CreateLivroDto createDto)
        {
            ReadLivroDto livroDto = _livroService.AdicionaLivro(createDto);
            return CreatedAtAction(nameof(RecuperaLivrosPorId), new { Id = livroDto.Id }, livroDto);
        }

        [HttpGet]
        public IActionResult RecuperaLivro([FromQuery] string categoria, decimal? precoLivro, string nomeDoLivro)
        {
            List<ReadLivroDto> readDto= _livroService.RecuperaLivro(categoria, precoLivro, nomeDoLivro);
            if (readDto == null) return NotFound();
            if (precoLivro >= 100)
            {
                return NotFound("Não existe preco acima de R$100");
            }
            return Ok(readDto);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaLivrosPorId(int id)
        {
            ReadLivroDto readDto = _livroService.RecuperaCinemasPorId(id);
            if (readDto == null) return NotFound();
            return Ok(readDto);

        }
        
        [HttpPut("{id}")]
      
        public IActionResult AtualizaLivro([FromBody] UpdateLivroDto updateDto, int id)
        {
            Result resultado = _livroService.Atualizalivro(updateDto, id);
                if (resultado.IsFailed) return NotFound();
                return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaLivro(int id)
        {
            Result resultado = _livroService.DeletaLivro(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
