using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICatalogoCartas.Entities;
using APICatalogoCartas.Enums;

namespace APICatalogoCartas.Repositories
{
    public class CartaRepository : ICartaRepository
    {
        private static Dictionary<Guid, Carta> cartas = new Dictionary<Guid, Carta>()
        {
            {Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), new Carta{ Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), Name = "Mago", Attack = 3, Life = 1, Cost = 1, Effect = Effects.Congelar} },
            {Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), new Carta{ Id = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), Name = "Gigante", Attack = 8, Life = 8, Cost = 4, Effect = Effects.Vazio} },
            {Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), new Carta{ Id = Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), Name = "Dragão", Attack = 10, Life = 10, Cost = 5, Effect = Effects.Voar} },
            {Guid.Parse("da033439-f352-4539-879f-515759312f53"), new Carta{ Id = Guid.Parse("da033439-f352-4539-879f-515759312f53"), Name = "Goblin", Attack = 1, Life = 2, Cost = 0, Effect = Effects.Terror} },
            {Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), new Carta{ Id = Guid.Parse("92576bd2-388e-4f5d-96c1-8bfda6c5a268"), Name = "Sereia", Attack = 3, Life = 2, Cost = 2, Effect = Effects.Submergir} },
            {Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), new Carta{ Id = Guid.Parse("c3c9b5da-6a45-4de1-b28b-491cbf83b589"), Name = "Cascavel", Attack = 1, Life = 1, Cost = 2, Effect = Effects.Veneno} },
            {Guid.Parse("5d4a9897-07b7-4667-be27-3b37cdb13c9e"), new Carta{ Id = Guid.Parse("5d4a9897-07b7-4667-be27-3b37cdb13c9e"), Name = "Yeti", Attack = 7, Life = 9, Cost = 5, Effect = Effects.Congelar} }
        };

        public Task<List<Carta>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(cartas.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Carta> Obter(Guid id)
        {
            if(!cartas.ContainsKey(id)) return null;

            return Task.FromResult(cartas[id]);
        }

        public Task<List<Carta>> Obter(string nome, int efeito)
        {
            Effects effectType = (Effects) efeito;
            return Task.FromResult(cartas.Values.Where(carta => carta.Name.Equals(nome) && carta.Effect.Equals(effectType)).ToList());
        }

        public Task Inserir(Carta carta)
        {
            cartas.Add(carta.Id, carta);

            return Task.CompletedTask;
        }

        public Task Atualizar(Carta carta)
        {
            cartas[carta.Id] = carta;

            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            cartas.Remove(id);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            // Fechar conexão com banco de dados quando existir
        }
    }
}