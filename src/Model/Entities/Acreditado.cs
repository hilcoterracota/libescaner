using libescaner.Model.Breakers;
using libescaner.Model.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libescaner.Model.Entities
{
    [Table("T_ACREDITADO")]
    public class Acreditado : Default
    {
        [MaxLength(10)]
        [Required]
        public string NumeroLoan { get; set; }

        [MaxLength(150)]
        public string Nombre { get; set; }

        public ICollection<Archivo> Archivos { get; set; }
        public ICollection<Credito> Creditos { get; set; }
    }
}