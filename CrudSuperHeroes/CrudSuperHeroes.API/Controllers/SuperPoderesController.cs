using CrudSuperHeroes.Domain.Entities;
using CrudSuperHeroes.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrudSuperHeroes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperPoderesController : ControllerBase
    {
        private readonly IRepository<SuperPoderes> _poderesRepository;
        public SuperPoderesController(IRepository<SuperPoderes> poderesRepository)
        {
            this._poderesRepository = poderesRepository;    
        }

        [HttpGet]
        [Route("listagemDePoderes/")]
        public async Task<IActionResult> ListagemDePoderes()
        {
            var poderes = await _poderesRepository.GetAll();
            return Ok(poderes);
        }
    }
}
