using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APICatalogoCartas.Enums;
using APICatalogoCartas.InputModel;
using APICatalogoCartas.ViewModel;

namespace APICatalogoCartas.Services
{
    public interface ICartaService : IDisposable
    {
        Task<List<CartaViewModel>> Obter(int pagina, int quantidade);

        Task<CartaViewModel> Obter(Guid id);
        
        Task<CartaViewModel> Inserir(CartaInputModel carta);

        Task Atualizar(Guid id, CartaInputModel carta);

        Task Atualizar(Guid id, Effects efeito);

        Task Remover(Guid id);
    }
}