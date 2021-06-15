using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bmusicalh.Models
{
    public class BandaMusic
    {
        [Key]
        public int BandaMusicId { get; set; }

        [Display(Name = "Nombre")]
        public string BandaMusicName { get; set; }

        [Display(Name = "Genero")]
        public string BandaMusicGenero { get; set; }

        [Display(Name = "Pais")]
        public string BandaMusicCountry { get; set; }
    }
}
