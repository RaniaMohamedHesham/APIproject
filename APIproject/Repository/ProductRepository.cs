using APIproject.Models;
using System.Collections.Generic;
using System.Linq;

namespace APIproject.Repository
{
    public class ProductRepository : IProductRepository
    {

        Context context;

        public ProductRepository(Context _context)
        {
            context = _context;
        }

        public List<Product> GetAll()
        {
            return context.Product.ToList();
        }

        public Product GetById(int id)
        {
            return context.Product.FirstOrDefault(x => x.ID == id);
        }

        public Product GetByName(string Name)
        {
            return context.Product.FirstOrDefault(d => d.Name.Contains(Name));

        }

        public List<Product> GetByCategoryID(int catID)
        {
            return context.Product.Where(m => m.CategoryID == catID).ToList();

        }


        


        public int Insert(Product prod)
        {
            context.Product.Add(prod);
            return context.SaveChanges();
        }

        public int Edit(int id, Product product)
        {
            Product oldProduct = GetById(id);
            if (oldProduct != null)
            {
                oldProduct.Name = product.Name;
                oldProduct.Price = product.Price;
                oldProduct.Quantity = product.Quantity;
                oldProduct.CategoryID = product.CategoryID;

                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Product oldProduct = GetById(id);
            context.Product.Remove(oldProduct);
            return context.SaveChanges();
        }

    }
}
