using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSuperHeroes.Domain.Entities
{
    public class SuperPoderes : BaseEntity
    {
        [Required]
        public string SuperPoder { get; set; }        
        public string Descricao { get; set; }

        /*EF Relations*/
        public List<HeroisSuperPoderes> HeroisSuperPoderes { get; set; }
    }
}
