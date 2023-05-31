using la_mia_pizzeria_static.Database;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaAPIController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPizza()
        {
            using (PizzaContext db = new())
            {
                List<PizzaModel> pizze = db.Pizzas.ToList();
                return Ok(pizze);
            }
        }

        [HttpGet]
        public IActionResult GetPizzaDetails(string name)
        {
            using (PizzaContext db = new())
            {
                PizzaModel? matchedPizza = db.Pizzas.Where(pizze => pizze.Name.Contains(name)).FirstOrDefault();
                if (matchedPizza != null)
                { return Ok(matchedPizza); }
                else { return BadRequest(); }

            }
        }

        [HttpGet("{id})")]
        public IActionResult SearchById(int id)
        {
            using (PizzaContext db = new())
            {
                PizzaModel? pizzaToSearch = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();
                if (pizzaToSearch != null)
                { return Ok(pizzaToSearch); }
                else { return NotFound(); }
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] PizzaModel pizza)
        {
            if (!ModelState.IsValid)
            { return BadRequest(); }
            else
            {
                using (PizzaContext db = new())
                {
                    db.Pizzas.Add(pizza);
                    db.SaveChanges();

                    return Ok();
                }
            }
        }
    }
}
