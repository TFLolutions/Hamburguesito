using Application.Command.ProductCommand.AdminActionsProduct.AdminActionCreateProduct;
using Application.Command.ProductCommand.AdminActionsProduct.AdminActionDeleteProduct;
using Application.Command.ProductCommand.AdminActionsProduct.AdminActionUpdateProduct;
using Application.Common.Exceptions;
using HamburguesitoNet.WebUI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using System;
using Application.Command.ProductCommand.CustomerActions.CreateProduct;

namespace WebUI.Controllers.CustomerApp
{
    [Route("api/Order")]
    [ApiController]
    public class OrderController : ApiController
    {
        public OrderController()
        {

        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [Route("/CreateOrder")]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand createOrderCommand)
        {
            try
            {
                return Ok(await Mediator.Send(createOrderCommand));
            }
            catch (Exception ex)
            {
                string message = "No se pudo crear la orden: " + ex.ToString();
                return BadRequest(message);
            }
        }
        


    }
}
