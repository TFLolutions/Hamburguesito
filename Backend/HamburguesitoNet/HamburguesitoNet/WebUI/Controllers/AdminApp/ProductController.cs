using Application.Common.Exceptions;
using Application.Command;
using HamburguesitoNet.WebUI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Application.Command.ProductCommand.AdminActionsProduct.AdminActionCreateProduct;
using Application.Command.ProductCommand.AdminActionsProduct.AdminActionUpdateProduct;
using Application.Command.ProductCommand.AdminActionsProduct.AdminActionDeleteProduct;
using Microsoft.AspNetCore.Authorization;
using System;


namespace WebUI.Controllers.AdminApp
{
    [Route("api/AdminApp")]
    [ApiController]
    public class ProductController : ApiController
    {
        public ProductController()
        {

        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [Route("/CreateProduct")]
        public async Task<IActionResult> CreateProduct(AdminActionCreateProductCommand adminActionCreateProductCommand)
        {
            try
            {
                return Ok(await Mediator.Send(adminActionCreateProductCommand));
            }

            // TODO : Personalizar excepcion 

            catch (GetProductsException ex) 
            {
                string message = "Could not get integrations.Failure: " + ex.ToString();
                return BadRequest(message);
            }
        } 
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [Route("/UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] AdminActionUpdateProductCommand adminActionUpdateProductCommand )
        {
            try
            {
                return Ok(await Mediator.Send(adminActionUpdateProductCommand));
            }

            // TODO : Personalizar excepcion 

            catch (GetProductsException ex)
            {
                string message = "Could not get integrations.Failure: " + ex.ToString();
                return BadRequest(message);
            }
        }
        //Delete controller 
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [Route("/DeleteProduct/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await Mediator.Send(new AdminActionDeleteProductCommand {id=id}));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }


    }
}
