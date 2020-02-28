using libescaner.Model.Breakers;
using libescaner.Model.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libescaner.Model.Entities
{
    [Table("T_ARCHIVO")]
    public class Archivo : Default
    {



        [MaxLength(150)]
        public string Titulo { get; set; }

        [MaxLength(100)]
        public string Descripcion { get; set; }

        [MaxLength(50)]
        [Required]
        public string Identificador { get; set; }
        
        [MaxLength(100)]
        public string PathArchivo { get; set; }

        [MaxLength(100)]
        [Required]
        public string Nombre { get; set; }

        public ICollection<ArchivoCategoria> ArchivoCategorias { get; set; }
    }
}
