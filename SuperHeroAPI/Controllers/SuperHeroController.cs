using Mapster;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Data.Dto;
using SuperHeroAPI.Entities;
using SuperHeroAPI.Interfaces;

namespace SuperHeroAPI.Controllers;




[ApiController]
[Route("api/[controller]")]
public class SuperHeroController(ISuperHeroService service) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<SuperHero>>> Get()
    {
        var heroes = await service.GetAllSuperHeroesService();

        if (heroes == null || heroes.Count == 0)
            return NotFound("No heroes found.");

        var response = heroes.Adapt<List<SuperHeroGetAllDto>>();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SuperHero>> GetSuperHero(int id)
    {
        var hero = await service.GetSuperHeroById(id);
        if (hero == null)
            return NotFound("Hero not found.");

        var response = hero.Adapt<SuperHeroGetDto>();
        return Ok(response);

    }

    [HttpPost]
    public async Task<ActionResult<SuperHero>> CreateSuperHero(SuperHeroCreateDto newHero)
    {
        var hero = newHero.Adapt<SuperHero>();
        var created = await service.CreateSuperHero(hero);

        var read = created.Adapt<SuperHeroGetDto>();

        return Ok(read);
    }

    [HttpPut]
    public async Task<ActionResult<SuperHero>> UpdateSuperHero(SuperHeroUpdateDto updatedHero)
    {

        var hero = updatedHero.Adapt<SuperHero>();
        
        if (hero == null)
        {
            return NotFound("Hero not found.");
        }

        var updated = await service.UpdateSuperHeroService(hero);
        var read = updated.Adapt<SuperHeroGetDto>();

        return Ok(read);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<SuperHero>> DeleteSuperHero(int id)
    {
        var hero = await service.DeleteSuperHero(id);
        if (hero)
        {
            return NotFound("Hero not found.");
        }

        return Ok();
    }
}
