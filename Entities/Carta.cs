using System;
using APICatalogoCartas.Enums;

namespace APICatalogoCartas.Entities
{
    public class Carta
    {
        public Guid Id { get; set;}
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Life { get; set; }
        public int Cost { get; set; }
        public Effects Effect { get; set; }
    }
}