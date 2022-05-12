using APIproject.DTO;
using APIproject.Models;
using APIproject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CategoryController : ControllerBase
    {
        ICategoryRepository categoryrepository; /*= new CategoryRepository();*/
        // Context context = new Context();

        public CategoryController(ICategoryRepository CateRepository)
        {
            categoryrepository = CateRepository;
        }

        [HttpGet]
        //[Authorize]
        public IActionResult getAll()
        {
            List<Category> categories = categoryrepository.GetAll();
            if (categories == null)
            {
                return BadRequest("Empty Department");
            }
            return Ok(categories);
        }
        [HttpGet("{id:int}", Name = "getOneRoute")]
        public IActionResult getByID(int id)
        {
            Category categoryList = categoryrepository.GetById(id);
            if (categoryList == null)
            {
                return BadRequest("Empty Category");
            }
            return Ok(categoryList);
        }


        [HttpGet("{Name:alpha}")]
        public IActionResult getByName(string Name)
        {
            Category categoryList = categoryrepository.GetByName(Name);
            if (categoryList == null)
            {
                return BadRequest("Empty category");
            }
            return Ok(categoryList);

        }
        [HttpPost]
        public IActionResult New(Category cat)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    categoryrepository.Insert(cat);
                    string url = Url.Link("getOneRoute", new { id = cat.ID });
                    return Created(url, cat);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }


        [HttpPut("{id:int}")]
        public IActionResult Edit([FromRoute] int id, Category cat)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    categoryrepository.Edit(id, cat);
                   
                   

                    return StatusCode(204, "Data Saved");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }


        [HttpDelete("{id:int}")]
        public IActionResult delete(int id)
        {
            if (ModelState.IsValid)
            { 
                try
                {
                    categoryrepository.Delete(id);
                    
                  

                    return StatusCode(204, "Data daleted");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }
        [HttpGet("Details/{CatID:int}")]
        public IActionResult GetCategorytWithProduct(int CatID)
        {
            Category catModel = categoryrepository.getCategortWithProduct(CatID);
            CategoryDTO categoryDTO = new CategoryDTO()
            {
                ID = catModel.ID,
                Name = catModel.Name
            };
            foreach (var item in catModel.Products)
            {
                ProductDTO productDTO = new ProductDTO();
                productDTO.ID = item.ID;
                productDTO.Name = item.Name;
                productDTO.Img = item.Img;
                productDTO.Quantity = item.Quantity;
                productDTO.Price = item.Price;

                categoryDTO.ProductDTO.Add(productDTO);
            }

            return Ok(categoryDTO);

            //return Ok(catModel);
        }

    }
}
