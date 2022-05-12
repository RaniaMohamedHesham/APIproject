using APIproject.DTO;
using APIproject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace APIproject.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        Context context; 

        public CategoryRepository(Context _context)
        {
            context = _context;
        }

        public List<Category> GetAll()
        {
            return context.Category.ToList();
        }

        public Category GetById(int id)
        {
            return context.Category.FirstOrDefault(x => x.ID == id);
        }
        public Category GetByName(string Name)
        {
            return context.Category.FirstOrDefault(d => d.Name.Contains(Name));

        }


        public int Insert(Category cate)
        {
            context.Category.Add(cate);
            return context.SaveChanges();
        }

        public int Edit(int id, Category cate)
        {
            Category oldCate = GetById(id);
            if (oldCate != null)
            {
                oldCate.Name = cate.Name;

                return context.SaveChanges();
            }
            return 0;
        }

        public int Delete(int id)
        {
            Category oldCate = GetById(id);
            context.Category.Remove(oldCate);
            return context.SaveChanges();
        }

        public Category getCategortWithProduct(int CatID)
        {
            Category catModel = context.Category.Include(d => d.Products).FirstOrDefault(d => d.ID == CatID);
           
            return catModel;
        }



    }
}
