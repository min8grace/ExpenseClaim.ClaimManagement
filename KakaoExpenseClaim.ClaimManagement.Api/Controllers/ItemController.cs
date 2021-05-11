using KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Commands.CreateItem;
using KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Commands.DeleteItem;
using KakaoExpenseClaim.ClaimManagement.Application.Features.Currencies.Commands.UpdateItem;
using KakaoExpenseClaim.ClaimManagement.Application.Features.Items.Queries.GetItemById;
using KakaoExpenseClaim.ClaimManagement.Application.Features.Items.Queries.GetItemsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KakaoExpenseClaim.ClaimManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ItemListVm>>> GetAllItems()
        {
            var dtos = await _mediator.Send(new GetItemsListQuery());
            return Ok(dtos);
        }

        [HttpGet("{id}", Name = "GetItemById")]
        public async Task<ActionResult<ItemDetailVm>> GetItemById(int id)
        {
            var getItemDetailQuery = new GetItemDetailQuery() { Id = id };
            return Ok(await _mediator.Send(getItemDetailQuery));
        }

        [HttpPost(Name = "AddItem")]
        public async Task<ActionResult<int>> Create([FromBody] CreateItemCommand createItemCommand)
        {
            var id = await _mediator.Send(createItemCommand);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateItemCommand updateItemCommand)
        {
            await _mediator.Send(updateItemCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteItemCommand = new DeleteItemCommand() { ItemId = id };
            await _mediator.Send(deleteItemCommand);
            return NoContent();
        }
    }
}
