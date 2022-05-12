using APIproject.Models;
using System.Collections.Generic;

namespace APIproject.Repository
{
    public interface IProductRepository
    {
        int Delete(int id);
        int Edit(int id, Product product);
        List<Product> GetAll();
        Product GetById(int id);
        Product GetByName(string Name);
        List<Product> GetByCategoryID(int catID);
        int Insert(Product prod);
    }
}