using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Crud.Models
{
    public class MarcaCE
    {   
        [Required]
        [Display(Name = "nombre")]
        public string nombre { get; set; }
    }


    [MetadataType(typeof(MarcaCE))]
    public partial class marcas{
        public String nombreCompleto {
            get
            {
                return nombre + "123";

            }
        }
    }


}