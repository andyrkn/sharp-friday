using System;
using System.Collections.Generic;
using CSharpFunctionalExtensions;
using L7.Business;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace L7.Controllers
{
    [Route("api/v1/shoppingCarts")]
    public class ShoppingCartController : BaseApiController
    {

        public ShoppingCartController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public IActionResult GetShoppingCarts()
        {
            var result = DispatchQuery<GetShoppingCartsQuery, IEnumerable <ShoppingCartModel>>(new GetShoppingCartsQuery());

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetShoppingCart(Guid id)
        {
            var result = DispatchQuery<GetShoppingCartQuery, Result<ShoppingCartModel>>(new GetShoppingCartQuery(id));

            return result.AsActionResult(Ok);
        }

        [HttpPost]
        public IActionResult AddShoppingCart([FromBody] UpsertShoppingCartModel model)
        {
            var result = DispatchCommand<AddShoppingCartCommand, ShoppingCartModel>(new AddShoppingCartCommand(model));

            return CreatedAtAction(nameof(GetShoppingCart), new { id = result.Id } , result);
        }


        [HttpPut("{id:guid}/product")]
        public IActionResult AddProductToCart(Guid id, [FromBody] AddProductToShoppingCartModel model)
        {
            var result = DispatchCommand(new AddProductToShoppingCartCommand(id, model));

            return result.AsActionResult(NoContent);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteShoppingCart([FromRoute] Guid id)
        {
            var result = DispatchCommand(new DeleteShoppingCartCommand(id));

            return result.AsActionResult(NoContent);
        }

        [HttpPut("{id:guid}")]
        public IActionResult EditShoppingCart([FromRoute] Guid id, [FromBody] UpsertShoppingCartModel model)
        {
            var result = DispatchCommand(new EditShoppingCartCommand(id, model));

            return result.AsActionResult(NoContent);
        }
    }
}