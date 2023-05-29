namespace la_mia_pizzeria_static.Models
{
    public class PizzaListCategory
    {
        public PizzaModel pizza { get; set; }
        public List<PizzaCategory>? categories { get; set; }
    }
}
