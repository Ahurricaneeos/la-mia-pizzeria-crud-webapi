using la_mia_pizzeria_static.Database;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new())
            {
                List<PizzaModel> pizze = db.Pizzas.ToList();
                return View(pizze);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contacts()
        {
            return View("Contacts");
        }

        [Authorize(Roles = "ADMIN")]
        public IActionResult AddPizza()
        {
            return View();
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPizza(PizzaModel newPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("AddPizza", newPizza);
            }
            else
            {
                using (PizzaContext db = new PizzaContext())
                {
                    db.Pizzas.Add(newPizza);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
        }
        public IActionResult PizzaDetails(int id)
        {
            using (PizzaContext db = new())
            {
                PizzaModel matchPizza = db.Pizzas.Where(pizze => pizze.Id == id).Include(pizze => pizze.Category).First();
                return View("PizzaDetails", matchPizza);
            }
        }

        public IActionResult SearchPizza(string titleKeyword)
        {
            using (PizzaContext db = new())
            {
                PizzaModel matchedPizza = db.Pizzas.Where(pizze => pizze.Name.Contains(titleKeyword)).First();
                ViewData["titleKeyword"] = titleKeyword;
                return View(matchedPizza);
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            using (PizzaContext db = new())
            {
                PizzaModel? pizzaToEdit = db.Pizzas.Where(pizze => pizze.Id == id).FirstOrDefault();
                if (pizzaToEdit != null)
                {
                    return NotFound("Questa pizza non esiste");
                }
                else
                {
                    return View("Update", pizzaToEdit);
                }
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, PizzaModel updatedPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("AddPizza", updatedPizza);
            }
            else
            {
                using (PizzaContext db = new())
                {
                    PizzaModel? pizzaToUpdate = db.Pizzas.Where(pizze => pizze.Id == id).FirstOrDefault();
                    if (pizzaToUpdate == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        pizzaToUpdate.Name = updatedPizza.Name;
                        pizzaToUpdate.Description = updatedPizza.Description;
                        pizzaToUpdate.ImgSource = updatedPizza.ImgSource;
                        pizzaToUpdate.Price = updatedPizza.Price;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                PizzaModel? pizzaToDelete = db.Pizzas.Where(pizze => pizze.Id == id).FirstOrDefault();

                if (pizzaToDelete != null)
                {
                    db.Remove(pizzaToDelete);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("Non ho torvato l'articolo da eliminare");
                }
            }
        }
    }
}
