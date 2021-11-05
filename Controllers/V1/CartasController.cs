using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogoCartas.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class CartasController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<object>>> Obter()
        {
            return Ok();
        }

        [HttpGet("{idCarta:guid}")]
        public async Task<ActionResult<object>> Obter(Guid idCarta)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<object>> InserirCarta()
        {
            return Ok();
        }

        [HttpPut("{idCarta:guid}")]
        public async Task<ActionResult> AtualizarCarta(Guid idCarta, object carta)
        {
            return Ok();
        }

        [HttpPatch("{idCarta:guid}/efeito/{efeito:string}")]
        public async Task<ActionResult> AtualizarCarta(Guid idCarta, string efeito)
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> ApagarCarta(Guid idCarta)
        {
            return Ok();
        }

    }
}