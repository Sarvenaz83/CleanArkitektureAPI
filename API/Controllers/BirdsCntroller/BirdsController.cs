using Application.Commands.Birds.AddBird;
using Application.Commands.Birds.DeleteBird;
using Application.Commands.Birds.UpdateBird;
using Application.Dtos;
using Application.Queries.Birds.GetAll;
using Application.Queries.Birds.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.BirdsCntroller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : Controller
    {
        internal readonly IMediator _mediator;
        public BirdsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //Get all birds from database
        [HttpGet]
        [Route("getAllBirds"), AllowAnonymous]
        public async Task<IActionResult> GetAllBirds()
        {
            //return Ok("GET ALL BIRDS");
            return Ok(await _mediator.Send(new GetAllBirdsQuery()));
        }

        //Get a bird by Id
        [HttpGet]
        [Route("getBirdById/{birdId}"), AllowAnonymous]
        public async Task<IActionResult> GetBirdById(Guid birdId)
        {
            return Ok(await _mediator.Send(new GetBirdByIdQuery(birdId)));
        }

        //Create a new bird
        [HttpPost]
        [Route("addNewBird"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBird([FromBody] BirdDto newBird)
        {
            return Ok(await _mediator.Send(new AddBirdCommand(newBird)));
        }

        //Update a specific Bird
        [HttpPut]
        [Route("updateBird/{updatedBirdId}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBird([FromBody] BirdDto updatedBird, Guid updatedBirdId)
        {
            return Ok(await _mediator.Send(new UpdateBirdByIdCommand(updatedBird, updatedBirdId)));
        }

        //Delete a bird by Id
        [HttpDelete]
        [Route("deleteBird/{deleteBirdById}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBird(Guid birdId)
        {
            return Ok(await _mediator.Send(new DeleteBirdByIdCommand(birdId)));
        }
    }
}
