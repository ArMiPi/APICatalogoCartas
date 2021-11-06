using System;
using APICatalogoCartas.Enums;

namespace APICatalogoCartas.ViewModel
{
    public class CartaViewModel
    {
        public Guid Id { get; set;}
        public string Name { get; set;}
        public int Attack { get; set;}
        public int Life { get; set;}
        public int Cost { get; set; }
        public int Effect { get; set; }
    }
}