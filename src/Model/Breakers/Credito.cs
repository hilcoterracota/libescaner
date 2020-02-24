using System.ComponentModel.DataAnnotations;
using libescaner.Model.Core;
using libescaner.Model.Entities;

namespace libescaner.Model.Breakers
{
    public class Credito : Default
    {

        [Required]

        public string IdAcreditado { get; set; }

        [Required]
        public string IdCliente { get; set; }

        [Required]

        [MaxLength(10)]
        public string NumeroCredito { get; set; }

        public Acreditado Acreditado { get; set; }
        public Cliente Cliente { get; set; }

    }


}

