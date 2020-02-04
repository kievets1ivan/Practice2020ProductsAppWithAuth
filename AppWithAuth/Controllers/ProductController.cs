using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppWithAuth.ApiRoutes;
using AppWithAuth.Entity;
using AppWithAuth.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppWithAuth.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;



        public ProductController(IProductService productService)
        {
            _productService = productService;

        }


        [HttpGet(Routes.Products.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAllProds());
        }

        [HttpGet(Routes.Products.Get)]
        public IActionResult Get([FromRoute] int productId)
        {

            var product = _productService.GetProdById(productId);

            if (product == null)
                NotFound();

            return Ok(product);
        }

        [HttpPost(Routes.Products.Create)]
        public IActionResult Create([FromBody] ProductEntity newProduct)
        {
            //маппинг с модели входа(фронт)


            _productService.AddProd(newProduct);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + Routes.Products.Get.Replace("{productId}", newProduct.Id.ToString());

            //маппинг на выходящую модель

            return Created(locationUri, newProduct);

            //_productService.GetProdById(newProduct.Id);
            //return instance
        }

        [HttpPut(Routes.Products.Update)]
        public IActionResult Update([FromRoute] int productId, [FromBody] ProductToUpdateEntity productToUpdate)
        {

            var productUpdated = new ProductEntity
            {
                Id = productId,
                Name = productToUpdate.Name,
                Price = productToUpdate.Price
            };

            if (_productService.UpdateProd(productUpdated))
                return Ok(productUpdated);


            return NotFound();

        }

        [HttpDelete(Routes.Products.Delete)]
        public IActionResult DeleteById(int productId)
        {

            if (_productService.DeleteProd(productId))
                return NoContent();

            return NotFound();
        }

    }
}