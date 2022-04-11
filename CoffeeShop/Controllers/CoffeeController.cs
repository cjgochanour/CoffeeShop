using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoffeeShop.Models;
using CoffeeShop.Repositories;

namespace CoffeeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeRepository _coffeeRepo;
        public CoffeeController(ICoffeeRepository coffeeRepository)
        {
            _coffeeRepo = coffeeRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_coffeeRepo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var coffee = _coffeeRepo.Get(id);
            if (coffee == null)
            {
                return NotFound();
            }
            return Ok(coffee);
        }
        [HttpPost]
        public IActionResult Post(Coffee coffee)
        {
            _coffeeRepo.Add(coffee);
            return CreatedAtAction("Get", new { id = coffee.Id }, coffee);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Coffee coffee)
        {
            if (id != coffee.Id)
            {
                return BadRequest();
            }
            _coffeeRepo.Update(coffee);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _coffeeRepo.Delete(id);
            return NoContent();
        }
    }
}
