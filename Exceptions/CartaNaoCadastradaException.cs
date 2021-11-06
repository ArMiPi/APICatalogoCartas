using System;
namespace APICatalogoCartas.Exceptions
{
    public class CartaNaoCadastradaException : Exception
    {
        public CartaNaoCadastradaException() : base("Carta não cadastrada")
        { }
    }
}