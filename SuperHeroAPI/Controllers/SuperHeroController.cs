using Microsoft.AspNetCore.Mvc;
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

        return Ok(heroes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SuperHero>> GetSuperHero(int id)
    {
        var hero = await service.GetSuperHeroById(id);
        if (hero == null)
            return NotFound("Hero not found.");

        return Ok(hero);

    }

    [HttpPost]
    public async Task<ActionResult<SuperHero>> CreateSuperHero(SuperHero newHero)
    {
        var hero = await service.CreateSuperHero(newHero);

        return Ok(hero);
    }

    [HttpPut]
    public async Task<ActionResult<SuperHero>> UpdateSuperHero(SuperHero updatedHero)
    {
        var hero = await service.UpdateSuperHeroService(updatedHero);
        if (hero == null)
        {
            return NotFound("Hero not found.");
        }

        return Ok(hero);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<SuperHero>> DeleteSuperHero(int id)
    {
        var hero = await service.DeleteSuperHero(id);
        if (hero == null)
        {
            return NotFound("Hero not found.");
        }

        return Ok();
    }
}
