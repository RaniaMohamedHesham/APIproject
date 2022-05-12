using System.ComponentModel.DataAnnotations.Schema;

namespace APIproject.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name{ get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Img { get; set; }


        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }



    }
}
