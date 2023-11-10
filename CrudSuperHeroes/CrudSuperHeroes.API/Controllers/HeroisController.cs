using CrudSuperHeroes.Domain.Entities;
using CrudSuperHeroes.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrudSuperHeroes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroisController : ControllerBase
    {
        private readonly IRepository<Herois> _heroisRepository;
        public HeroisController(IRepository<Herois> heroiRepository)
        {
            this._heroisRepository = heroiRepository;
        }

        [HttpGet]
        [Route("listagemDosSuperHerois/")]
        public async Task<IActionResult> ListagemDosSuperHerois()
        { 
            var herois = await _heroisRepository.GetAll();
            return Ok(herois);
        }

        [HttpGet]
        [Route("buscarSuperHeroPeloId/{id:int}")]
        public async Task<IActionResult> BuscarSuperHeroiPorId(int id)
        {
            return Ok(await _heroisRepository.GetById(id));
        }

        [HttpPost]
        [Route("AdicionarUmNovoSuperHeroi")]
        public async Task<IActionResult> AdicionarHeroi(Herois heroi)
        {           
            if (heroi == null) return BadRequest();
            await _heroisRepository.Add(heroi);
            return Ok();
        }

        [HttpPut]
        [Route("AlterarHeroi")]
        public async Task<IActionResult> AlterarHeroi(Herois heroi)
        {
            if (heroi == null) return NotFound();
            await _heroisRepository.Update(heroi);
            return Ok();
        }

        [HttpDelete]
        [Route("ExcluirHeroi")]
        public async Task<IActionResult> ExcluirHeroi(int id)
        {
            await _heroisRepository.Remove(id);
            return Ok(200);
        }
    }
}
