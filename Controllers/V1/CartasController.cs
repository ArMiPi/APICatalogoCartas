using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using APICatalogoCartas.Enums;
using APICatalogoCartas.Exceptions;
using APICatalogoCartas.InputModel;
using APICatalogoCartas.Services;
using APICatalogoCartas.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogoCartas.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class CartasController : ControllerBase
    {
        private readonly ICartaService _cartaService;

        public CartasController(ICartaService cartaService)
        {
            _cartaService = cartaService;
        }

        /// <summary>
        /// Buscar todas as cartas de forma paginada
        /// </summary>
        /// <remarks>
        /// Não é possível retornar as cartas sem paginação
        /// </remarks>
        /// <param name="pagina">Indica qual página está sendo consultada. Mínimo 1</param>
        /// <param name="quantidade">Indica a quantidade de registros por página. Mínimo 1 e Máximo 50</param>
        /// <response code="200">Retorna a lista de jogos</response>
        /// <response code="204">Caso não haja cartas</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartaViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var cartas = await _cartaService.Obter(pagina, quantidade);

            if(cartas.Count() == 0) return NoContent();

            return Ok(cartas);
        }

        /// <summary>
        /// Buscar uma carta pelo seu Id
        /// </summary>
        /// <param name="idCarta">Id da carta procurada</param>
        /// <response code="200">Retorna a carta procurada</response>
        /// <response code="204">Caso não haja uma carta com esse Id</response>
        [HttpGet("{idCarta:guid}")]
        public async Task<ActionResult<CartaViewModel>> Obter([FromRoute] Guid idCarta)
        {
            var carta = await _cartaService.Obter(idCarta);

            if(carta == null) return NoContent();

            return Ok(carta);
        }

        /// <summary>
        /// Insere uma carta nova
        /// </summary>
        /// <param name="cartaInputModel">Carta a ser inserida</param>
        /// <response code="200">Retorna a carta inserida</response>
        /// <response code="422">Caso já exista uma carta cadastrada com o mesmo nome e mesmo efeito</response>
        [HttpPost]
        public async Task<ActionResult<CartaViewModel>> InserirCarta([FromBody] CartaInputModel cartaInputModel)
        {
            try
            {
                var carta = await _cartaService.Inserir(cartaInputModel);

                return Ok(carta);
            }
            catch(CartaJaCadastradaException)
            {
                return UnprocessableEntity("Já existe uma carta com esse nome e esse efeito");
            }
        }

        /// <summary>
        /// Atualiza todas as informações de uma carta
        /// </summary>
        /// <param name="idCarta">Id da carta a ser atualizada</param>
        /// <param name="cartaInputModel">Carta contendo as informações atualizadas</param>
        /// <response code="200">Caso a carta tenha sido atualizada</response>
        /// <response code="404">Caso a carta não exista</response>
        [HttpPut("{idCarta:guid}")]
        public async Task<ActionResult> AtualizarCarta([FromRoute] Guid idCarta, [FromBody] CartaInputModel cartaInputModel)
        {
            try
            {
                await _cartaService.Atualizar(idCarta, cartaInputModel);

                return Ok();
            }
            catch(CartaNaoCadastradaException)
            {
                return NotFound("Não existe essa carta");
            }
        }

        /// <summary>
        /// Atualiza o efeito de uma carta
        /// </summary>
        /// <param name="idCarta">Id da carta a ser atualizada</param>
        /// <param name="efeito">Novo efeito da carta</param>
        /// <remarks>
        /// Efeitos:
        /// 0 - Vazio
        /// 1 - Voar
        /// 2 - Submergir
        /// 3 - Veneno
        /// 4 - Congelar
        /// 5 - Terror
        /// </remarks>
        /// <response code="200">Caso a carta tenha sido atualizada</response>
        /// <response code="404">Caso a carta não exista</response>
        [HttpPatch("{idCarta:guid}/efeito/{efeito:string}")]
        public async Task<ActionResult> AtualizarCarta([FromRoute] Guid idCarta, [FromRoute] int efeito)
        {
            try
            {
                await _cartaService.Atualizar(idCarta, efeito);

                return Ok();
            }
            catch(CartaNaoCadastradaException)
            {
                return NotFound("Não existe essa carta");
            }
        }

        /// <summary>
        /// Remove uma carta
        /// </summary>
        /// <param name="idCarta">Id da carta a ser removida</param>
        /// <response code="200">Caso a carta tenha sido removida</response>
        /// <response code="404">Caso a carta não exista</response>
        [HttpDelete]
        public async Task<ActionResult> ApagarCarta([FromRoute] Guid idCarta)
        {
            try
            {
                await _cartaService.Remover(idCarta);

                return Ok();
            }
            catch(CartaNaoCadastradaException)
            {
                return NotFound("Não existe essa carta");
            }
        }

    }
}