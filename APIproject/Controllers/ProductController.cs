using APIproject.Models;
using APIproject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepository productRepository; 
    
       public ProductController(IProductRepository prodRepository)
        {
            productRepository = prodRepository;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            List<Product> products =productRepository.GetAll();
            if (products == null)
            {
                return BadRequest("Empty Department");
            }
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "getRoute")]
        public IActionResult getByID(int id)
        {
            Product productList = productRepository.GetById(id);
            if (productList == null)
            {
                return BadRequest("Empty product");
            }
            return Ok(productList);
        }

        


        [HttpGet("Catid")]
        public IActionResult GetByCategoryID([FromQuery] int catID)
        {
            List<Product> ProductList = productRepository.GetByCategoryID(catID);
                
            if (ProductList == null)
            {
                return BadRequest("NO Matches");
            }
            return Ok(ProductList);
        }


        [HttpGet("{Name:alpha}")]
        public IActionResult getByName(string Name)
        {
            Product productList = productRepository.GetByName(Name);
            if (productList == null)
            {
                return BadRequest("Empty category");
            }
            return Ok(productList);

        }
        [HttpPost]
        public IActionResult New(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    productRepository.Insert(product);
                    string url = Url.Link("getRoute", new { id = product.ID });
                    return Created(url, product);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }


        [HttpPut("{id:int}")]
        public IActionResult Edit(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   

                    productRepository.Edit(id, product);
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
                   

                    productRepository.Delete(id);

                    return StatusCode(204, "Data daleted");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState);

        }



    }
}
