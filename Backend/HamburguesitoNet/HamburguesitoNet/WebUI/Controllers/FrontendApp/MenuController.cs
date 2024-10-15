using Application.Common.Exceptions;
using Application.Queries.Menu;
using Application.Queries.Menu.GetAllProductsQuery;
using Application.Queries.Menu.GetProductByIdQuery;
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

    [HttpGet("{id:int}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.Conflict)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    public async Task<IActionResult> GetProductById(int id)
    {
        try
        {
            return Ok(await Mediator.Send(new GetProductByIdQuery(id)));
        }

        catch (GetProductsException ex)
        {
            string message = "Could not get integrations.Failure: " + ex.ToString();
            return BadRequest(message);
        }
    }
}
