using System.Collections.Generic;

namespace APIproject.DTO
{
    public class CategoryDTO
    {
        public int ID { get; set; }
        public string Name{ get; set; }

        public List<ProductDTO> ProductDTO { get; set; } = new List<ProductDTO>();
       
    }
}
