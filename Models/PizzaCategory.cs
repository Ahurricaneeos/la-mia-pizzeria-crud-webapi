namespace la_mia_pizzeria_static.Models
{
    public class PizzaCategory
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<PizzaModel> Pizzas { get; set; }

        public PizzaCategory(string type) 
        {
            Type = type;
            Pizzas = new List<PizzaModel>();
        }

        public PizzaCategory() { }
    }
}
