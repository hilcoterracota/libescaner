using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using libescaner.Model.Breakers;
using libescaner.Model.Core;

namespace libescaner.Model.Entities

{
    [Table("T_CLIENTE")]
    public class Cliente : Default

    {


        [Required]

        public string Nombre { get; set; }
        public ICollection<Credito> Creditos { get; set; }
    }

}