using APIproject.Models;
using System.Collections.Generic;

namespace APIproject.Repository
{
    public interface ICategoryRepository
    {
        int Delete(int id);
        int Edit(int id, Category cate);
        List<Category> GetAll();
        Category GetById(int id);
        Category GetByName(string Name);
        Category getCategortWithProduct(int CatID);
        int Insert(Category cate);
    }
}