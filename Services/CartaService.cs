using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICatalogoCartas.Entities;
using APICatalogoCartas.Enums;
using APICatalogoCartas.Exceptions;
using APICatalogoCartas.InputModel;
using APICatalogoCartas.Repositories;
using APICatalogoCartas.ViewModel;

namespace APICatalogoCartas.Services
{
    public class CartaService : ICartaService
    {
        private readonly ICartaRepository _cartaRepository;

        public CartaService(ICartaRepository cartaRepository)
        {
            _cartaRepository = cartaRepository;
        }

        public async Task<List<CartaViewModel>> Obter(int pagina, int quantidade)
        {
            var cartas = await _cartaRepository.Obter(pagina, quantidade);

            return cartas.Select(carta => new CartaViewModel
            {
                Id = carta.Id,
                Name = carta.Name,
                Attack = carta.Attack,
                Life = carta.Attack,
                Cost = carta.Cost,
                Effect = carta.Effect.ToString()
            }).ToList();
        }

        public async Task<CartaViewModel> Obter(Guid id)
        {
            var carta = await _cartaRepository.Obter(id);

            if(carta == null) return null;

            return new CartaViewModel
            {
                Id = carta.Id,
                Name = carta.Name,
                Attack = carta.Attack,
                Life = carta.Attack,
                Cost = carta.Cost,
                Effect = carta.Effect.ToString()
            };
        }

        public async Task<CartaViewModel> Inserir(CartaInputModel carta)
        {
            var entidadeCarta = await _cartaRepository.Obter(carta.Name, carta.Effect);

            if(entidadeCarta.Count > 0) throw new CartaJaCadastradaException();

            var cartaInsert = new Carta
            {
                Id = Guid.NewGuid(),
                Name = carta.Name,
                Attack = carta.Attack,
                Life = carta.Life,
                Cost = carta.Cost,
                Effect = (Effects) carta.Effect
            };

            await _cartaRepository.Inserir(cartaInsert);

            return new CartaViewModel
            {
                Id = cartaInsert.Id,
                Name = carta.Name,
                Attack = carta.Attack,
                Life = carta.Life,
                Cost = carta.Cost,
                Effect = carta.Effect.ToString()
            };
        }

        public async Task Atualizar(Guid id, CartaInputModel carta)
        {
            var entidadeCarta = await _cartaRepository.Obter(id);

            if(entidadeCarta == null) throw new CartaNaoCadastradaException();

            entidadeCarta.Name = carta.Name;
            entidadeCarta.Attack = carta.Attack;
            entidadeCarta.Life = carta.Life;
            entidadeCarta.Cost = carta.Cost;
            entidadeCarta.Effect = (Effects) carta.Effect;

            await _cartaRepository.Atualizar(entidadeCarta);
        }

        public async Task Atualizar(Guid id, int efeito)
        {
            var entidadeCarta = await _cartaRepository.Obter(id);

            if(entidadeCarta == null) throw new CartaNaoCadastradaException();

            entidadeCarta.Effect = (Effects) efeito;

            await _cartaRepository.Atualizar(entidadeCarta);
        }

        public async Task Remover(Guid id)
        {
            var carta = await _cartaRepository.Obter(id);

            if(carta == null) throw new CartaNaoCadastradaException();

            await _cartaRepository.Remover(id);
        }

        public void Dispose()
        {
            _cartaRepository?.Dispose();
        }
    }
}