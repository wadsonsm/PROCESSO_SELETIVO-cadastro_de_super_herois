using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSuperHeroes.Domain.Entities
{
    public class Herois : BaseEntity
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string NomeHeroi { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public float Altura { get; set; }
        [Required]
        public float Peso { get; set; }

        /*EF Relations*/
        public List<HeroisSuperPoderes> HeroisSuperPoderes { get; set; }    
    }
}
