using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroControllercs : ControllerBase
    {
        //List of heroes
        private static List<Hero> heroes = new List<Hero>
            {
                new Hero {
                    Id=1,
                    Name="Midorya",
                    Description=". . . "
                    ,Power="Strength"
                },
                 new Hero {
                    Id=2,
                    Name="Goku",
                    Description="Is a sayan "
                    ,Power="All"
                },

            };


        //Get method all
        [HttpGet]
        public async Task<ActionResult<List<Hero>>> Get()
        {
            return Ok(heroes);
        }

        // Get method one
        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> Get(int id)
        {
            var myhero = heroes.Find(h => h.Id == id);
            if (myhero == null)
            {
                return BadRequest("Hero not found");
            }
            return Ok(myhero);
        }

        //Post method create
        [HttpPost]
        public async Task<ActionResult<List<Hero>>> AddHero(Hero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<Hero>>> UpdateHero(Hero request)
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null)
            {
                return BadRequest("Hero not found");
            }
            hero.Name = request.Name;
            hero.Description = request.Description;
            hero.Power = request.Power;
            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Hero>>> DeleteHero(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
            {
                return BadRequest("Hero not found");
            }
            heroes.Remove(hero);
            return Ok(heroes);
        }
    }
}
