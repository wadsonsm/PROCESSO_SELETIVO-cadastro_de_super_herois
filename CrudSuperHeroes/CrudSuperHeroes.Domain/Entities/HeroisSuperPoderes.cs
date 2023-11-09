using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSuperHeroes.Domain.Entities
{
    public class HeroisSuperPoderes : BaseEntity
    {
        public int HeroiId { get; set; }
        public Herois Herois { get; set; }
        public int SuperPoderId { get; set; }
        public SuperPoderes SuperPoderes { get; set; }
    }
}
