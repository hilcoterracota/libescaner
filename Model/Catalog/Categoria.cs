using libescaner.Model.Breakers;
using libescaner.Model.Core;
using libescaner.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libescaner.Model.Catalog
{
    [Table("C_CATEGORIA")]
    public class Categoria : Default
    {
        [MaxLength(20)]
        [Required]
        public string Nombre { get; set; }

        [MaxLength(20)]
        [Required]
        public string Clave { get; set; }

        public ICollection<ArchivoCategoria> ArchivoCategorias { get; set; }
    }

}
