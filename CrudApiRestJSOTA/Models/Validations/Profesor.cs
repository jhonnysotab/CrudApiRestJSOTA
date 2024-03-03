using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudApiRestJSOTA.Models
{
    [MetadataType(typeof(Profesor.MedataData))]
    public partial class Profesor
    {

        sealed class MedataData
        {
            [Required]
            public string name;
        
        }

    }
}