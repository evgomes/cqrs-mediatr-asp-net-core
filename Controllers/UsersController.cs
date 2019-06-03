using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSMediatR.Controllers.Resources;
using CQRSMediatR.Domain.Commands.Users;
using CQRSMediatR.Domain.Communication;
using CQRSMediatR.Domain.Models;
using CQRSMediatR.Domain.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatR.Controllers
{
    [Route("api/users")]
    [Produces("application/json")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Lists all users from the API. 
        /// </summary>
        /// <returns>List of users.</returns>
        [HttpGet]
        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _mediator.Send(new ListUsersQuery());
        }

        /// <summary>
        /// Lists a given user by their ID.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <returns>User.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(User), 200)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var user = await _mediator.Send(new GetUserQuery(id));
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        /// <summary>
        /// Creates a new user in the API.
        /// </summary>
        /// <param name="resource">Updated user data.</param>
        /// <returns>Response for the request.</returns>
        /// <response code="201">Returns the newly created user data.</response>
        /// <response code="400">Return data containing information about why has the request failed.</response>
        [HttpPost]
        [ProducesResponseType(typeof(User), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] UserResource resource)
        {
            var user = await _mediator.Send(new CreateUserCommand(resource.Name, resource.Age));
            return Created($"/api/users/{user.Id}", user);
        }

        /// <summary>
        /// Updates a given user by their identifier.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <param name="resource">Updated user data.</param>
        /// <returns>Response for the request.</returns>
        /// <response code="200">Returns the response data container the updated user information.</response>
        /// <response code="400">Return data containing information about why has the request failed.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Response<User>), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UserResource resource)
        {
            var response = await _mediator.Send(new UpdateUserCommand(id, resource.Name, resource.Age));
            return ProduceUserResponse(response);
        }

        /// <summary>
        /// Deletes a given user by their identifier.
        /// </summary>
        /// <param name="id">User ID.</param>
        /// <returns>Response for the request</returns>
        /// <response code="200">Returns the response data container the deleted user information.</response>
        /// <response code="400">Return data containing information about why has the request failed.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Response<User>), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _mediator.Send(new DeleteUserCommand(id));
            return ProduceUserResponse(response);
        }

        private IActionResult ProduceUserResponse(Response<User> response)
        {
            if (!response.Success)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Data);
        }
    }
}