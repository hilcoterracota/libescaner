using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using libescaner.Model.Catalog;
using libescaner.Model.Core;

namespace libescaner.Model.Entities
{
[Table("T_ARCHIVO")]
    public class Archivo:Default

    {
        

        [MaxLength(10)]
        [Required]
        public string IdCredito { get; set; }

        [MaxLength(150)]
        public string Titulo { get; set; }

        [MaxLength(100)]
        public string Descripcion { get; set; }

       public string IdTipoArchivo {get; set;}

        [MaxLength(100)]
        public string Tipo { get; set; }

        [MaxLength(100)]
        [Required]
        public string Nombre { get; set; }
public TipoArchivo TipoArchivo {get; set;}



    }
}
