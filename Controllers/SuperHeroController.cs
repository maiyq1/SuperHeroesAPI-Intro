using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test2.Models;

namespace Test2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
                Name = "Spider-Man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York"
            },
            new SuperHero
            {
                Id = 2,
                Name = "Iron-Man",
                FirstName = "Tony",
                LastName = "Stark",
                Place = "Malibu"
            },
        };
        [HttpGet(Name = "GetSuperheroes")]
        public async Task<ActionResult<SuperHero>> GetAllHeroes()
        {
            return Ok(superHeroes);
        }
        
        [HttpGet("{id}", Name = "GetOneSuperHeroe")]
        public async Task<ActionResult<List<SuperHero>>> GetHeroById(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null)
                return NotFound("Sorry, but this hero doesn't exists.");
            return Ok(hero);
        }
        
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero newHero)
        {
            superHeroes.Add(newHero);
            return Ok(superHeroes);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero request)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null) return NotFound("Sorry, but this hero doesn't exist.");
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return Ok(superHeroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = superHeroes.Find(x => x.Id == id);
            if (hero is null) return NotFound("Sorry, but this hero doesn't exist.");
            superHeroes.Remove(hero);
            return Ok(superHeroes);
        }
    }
}
