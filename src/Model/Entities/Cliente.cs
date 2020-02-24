using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using libescaner.Model.Core;

namespace libescaner.Model.Breakers
{
    public class Cliente : Default
    {


        [Required]

        public string Nombre { get; set; }
        public ICollection<Credito> Creditos { get; set; }
    }

}