using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APICatalogoCartas.Entities;
using APICatalogoCartas.Enums;

namespace APICatalogoCartas.Repositories
{
    public interface ICartaRepository : IDisposable
    {
        Task<List<Carta>> Obter(int pagina, int quantidade);

        Task<Carta> Obter(Guid id);

        Task<List<Carta>> Obter(string nome, int efeito);

        Task Inserir(Carta carta);

        Task Atualizar(Carta carta);

        Task Remover(Guid id);
    }
}