using System;
using System.ComponentModel.DataAnnotations;

namespace libescaner.Model.Core
{

    public class Default
    {
        [Key]
        [Required]

        public string Id { get; set; } = Guid.NewGuid().ToString();


        public DateTime FechaRegistro { get; set; }


    }
}