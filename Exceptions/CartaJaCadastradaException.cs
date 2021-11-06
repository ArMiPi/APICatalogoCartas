using System;
namespace APICatalogoCartas.Exceptions
{
    public class CartaJaCadastradaException : Exception
    {
        public CartaJaCadastradaException() : base("Carta já cadastrada")
        { }
    }
}