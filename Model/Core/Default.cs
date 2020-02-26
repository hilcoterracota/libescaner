using System;
using System.ComponentModel.DataAnnotations;

namespace libescaner.Model.Core
{
    public class Default
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [Required]
        public Boolean Activo { get; set; } = true;

    }
}