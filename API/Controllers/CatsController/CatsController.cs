using Application.Commands.Cats.AddCat;
using Application.Commands.Cats.DeleteCat;
using Application.Commands.Cats.UpdateCat;
using Application.Dtos;
using Application.Queries.Cats.GetAll;
using Application.Queries.Cats.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.CatsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        internal readonly IMediator _mediator;
        public CatsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get all cats from database
        [HttpGet]
        [Route("getAllCats"), AllowAnonymous]
        public async Task<IActionResult> GetAllCats()
        {
            //return Ok("GET ALL CATS");
            return Ok(await _mediator.Send(new GetAllCatsQuery()));
        }

        //Get a cat by Id
        [HttpGet]
        [Route("getCatById/{catId}"), AllowAnonymous]
        public async Task<IActionResult> GetCatById(Guid catId)
        {
            return Ok(await _mediator.Send(new GetCatByIdQuery(catId)));
        }

        //Create a new cat
        [HttpPost]
        [Route("addNewCat"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCat([FromBody] CatDto newCat)
        {
            return Ok(await _mediator.Send(new AddCatCommand(newCat)));
        }

        //Update a specific Cat
        [HttpPut]
        [Route("updateCat/{updatedCatId}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateCat([FromBody] CatDto updatedCat, Guid updatedCatId)
        {
            return Ok(await _mediator.Send(new UpdateCatByIdCommand(updatedCat, updatedCatId)));
        }

        //Delete a cat by Id
        [HttpDelete]
        [Route("deleteCat/{deleteCatById}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteCat(Guid catId)
        {
            return Ok(await _mediator.Send(new DeleteCatByIdCommand(catId)));
        }

    }

}
