using AutoMapper;
using FluentResults;
using LivrariaApi.Data;
using LivrariaApi.Data.Dtos;
using LivrariaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LivrariaApi.Services
{
    public class LivroService
    {
        private IMapper _mapper;
        private AppDbContext _context;


        public LivroService(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadLivroDto AdicionaLivro(CreateLivroDto createDto)
        {
            Livro livro = _mapper.Map<Livro>(createDto);
            _context.Livros.Add(livro);
            _context.SaveChanges();
            return _mapper.Map<ReadLivroDto>(livro);
        }

        public List<ReadLivroDto> RecuperaLivro(string categoria, decimal? precoLivro, string nomeDoLivro)
        {
            List<Livro> livros = _context.Livros.ToList();
            if (categoria!=null) livros = Categoria(categoria);
            if (precoLivro!= null) livros = PrecoLivro(precoLivro);
            if (nomeDoLivro != null) livros = NomeDoLivro(nomeDoLivro);

            if (livros != null)
            {
                return RetornaLivrosExistentes(livros);
            }

            return null;
        }

      
        public ReadLivroDto RecuperaCinemasPorId(int id)
        {
            Livro livro = PegarIdLivro(id);
            if (livro != null)
            {
                return _mapper.Map<ReadLivroDto>(livro);
            }
            return null;


        }

        public Result Atualizalivro(UpdateLivroDto updateDto, int id)
        {
            Livro livro = PegarIdLivro(id);
            if (livro == null)
            {
                return Result.Fail("Falha ao atualizar o livro");

            }
            _mapper.Map(updateDto, livro);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaLivro(int id)
        {
            Livro livro = PegarIdLivro(id);
            if (livro == null)
            {
                return Result.Fail("Livro Não Encontrado");
            }
            _context.Remove(livro);
            _context.SaveChanges();
            return Result.Ok();
        }
        private List<Livro> RetornaLivros()
        {
            return _context.Livros.ToList();
        }
        private Livro PegarIdLivro(int id)
        {
            Livro livro = _context.Livros.FirstOrDefault(livro => livro.Id == id);
            return livro;
        }
        private List<Livro> NomeDoLivro(string nomeDoLivro)
        {
            List<Livro> livros;
            if (nomeDoLivro == null)
            {
                livros = RetornaLivros();
            }
            else
            {
                livros = _context.Livros.Where(livro => livro.NomeLivro == nomeDoLivro).ToList();

            }

            return livros;
        }

        private List<Livro> PrecoLivro(decimal? precoLivro)
        {
            List<Livro> livros;
            if (precoLivro == null)
            {
                livros = RetornaLivros();
            }
            else
            {
                livros = _context.Livros.Where(livro => livro.Preco <= precoLivro).ToList();

            }

            return livros;
        }

        private List<Livro> Categoria(string categoria)
        {
            List<Livro> livros;
            if (categoria == null)
            {
                livros = RetornaLivros();
            }
            else
            {
                livros = _context.Livros.Where(livro => livro.Categoria == categoria).ToList();
            }

            return livros;
        }
        private List<ReadLivroDto> RetornaLivrosExistentes(List<Livro> livros)
        {
            return _mapper.Map<List<ReadLivroDto>>(livros);
        }


    }
}
