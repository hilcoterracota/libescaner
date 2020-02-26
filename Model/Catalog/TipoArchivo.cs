using libescaner.Model.Core;
using libescaner.Model.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace libescaner.Model.Catalog
{
    [Table("C_TIPOARCHIVO")]
    public class TipoArchivo : Default
    {
        [MaxLength(20)]
        [Required]
        public string NombreTipo { get; set; }

        [MaxLength(20)]
        [Required]
        public string ClaveTipoArchivo { get; set; }

        public ICollection<Archivo> Archivos { get; set; }
    }

}
