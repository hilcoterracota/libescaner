using libescaner.Model.Catalog;
using libescaner.Model.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libescaner.Model.Breakers
{
    [Table("BRE_ARCHIVO_CATEGORIA")]
    public class ArchivoCategoria 
    {        
        [Key]
        [Required]
        [MaxLength(50)]        
        public string IdArchivo { get; set; }

        [Key]
        [Required]
        [MaxLength(50)]
        public string IdCategoria { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [Required]
        public Boolean Activo { get; set; } = true;
        
        public Archivo Archivo { get; set; }
        public Categoria Categoria { get; set; }
    }
}

