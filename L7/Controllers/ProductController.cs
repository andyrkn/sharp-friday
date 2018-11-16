using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using L7.Business;
using L7.Business.Product.Edit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace L7.Controllers
{
    [Route("api/v1/products")]
    public class ProductController : BaseApiController
    {
        public ProductController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var result = DispatchQuery<GetProductsQuery, IEnumerable<ProductModel>>(new GetProductsQuery());

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetProduct(Guid id)
        {
            var result = DispatchQuery<GetProductByIdQuery, Result<ProductModel>>(new GetProductByIdQuery(id));

            return result.AsActionResult(Ok);
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] UpsertProductModel model)
        {
            var result = DispatchCommand<AddProductCommand, ProductModel>(new AddProductCommand(model));

            return CreatedAtAction(nameof(GetProduct), new {id = result.Id}, result);
        }

        [HttpPut("{id:guid}")]
        public IActionResult EditProduct([FromRoute] Guid id, [FromBody] UpsertProductModel model)
        {
            var result = DispatchCommand(new EditProductCommand(id, model));

            return result.AsActionResult(Ok);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var result = DispatchCommand(new DeleteProductCommand(id));
            return result.AsActionResult(Ok);            
        }
    }
}