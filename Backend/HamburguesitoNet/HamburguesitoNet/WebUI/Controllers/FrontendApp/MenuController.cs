using Application.Common.Exceptions;
using Application.Queries.Menu;
using HamburguesitoNet.WebUI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

[Route("api/menu")]
[ApiController]
public class MenuController : ApiController
{
    public MenuController()
    {
        
    }

    [HttpGet]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Conflict)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [Route("/products")]
    public async Task<IActionResult> GetProducts()
    {
        try
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery()));
        }

        catch (GetProductsException ex)
        {
            string message = "Could not get integrations.Failure: " + ex.ToString();
            return BadRequest(message);
        }
    }

    //[HttpGet("{id}")]
    //public IActionResult GetProduct(int id)
    //{
    //    var query = new ProductByIdQuery { Id = id };
    //    var producto = _queryHandler.Handle(query);
    //    if (producto == null) return NotFound();
    //    return Ok(producto);
    //}
}
