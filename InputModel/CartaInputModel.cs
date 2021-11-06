using System.ComponentModel.DataAnnotations;
using APICatalogoCartas.Enums;

namespace APICatalogoCartas.InputModel
{
    public class CartaInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O nome da carta deve conter entre 1 e 100 caracteres")]
        public string Name { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "O ataque da carta deve ser de no mínimo 0 e no máximo 10")]
        public int Attack { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "A vida da carta deve ser de no mínimo 1 e no máximo 10")]
        public int Life { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "O custo da carta deve ser de no mínimo 0 e no máximo 5")]
        public int Cost { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Escolha um dos efeitos: \n0 - Nenhum;\n1 - Voar;\n2 - Submergir;\n3 - Veneno;\n4 - Congelar;\n5 - Terror;")]
        public Effects Effect { get; set; }
    }
}