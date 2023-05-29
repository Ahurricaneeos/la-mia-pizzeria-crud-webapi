using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_static.Models
{
    public class PizzaModel
    {
        public int Id { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }
        [Column(TypeName = "text")]
        public string Description { get; set; }
        [MaxLength(300)]
        public string ImgSource { get; set; }
        public float Price { get; set;}
        public int? PizzaCategoryId { get; set; }
        public PizzaCategory? Category { get; set; }

        public PizzaModel(string name, string description, string imgSource, float price)
        {
            Name = name;
            Description = description;
            ImgSource = imgSource;
            Price = price;
        }

        public PizzaModel() { }
    }

}
