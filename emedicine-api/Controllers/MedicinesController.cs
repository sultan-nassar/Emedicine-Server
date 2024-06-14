using emedicine_api.Models;
using emedicine_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace emedicine_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicinesService _medicinesService;

        public MedicinesController(IMedicinesService medicinesService)
        {
            _medicinesService = medicinesService;
        }
        
        [HttpPost]
        [Route("addToCart")]
        public Response AddToCart(Cart cart)
        {
            cart.Type = "ADD";
            return _medicinesService.AddToCart(cart);
        }

        [HttpDelete]
        [Route("removeFromCart")]
        public Response RemoveFromCart(int ID)
        {
            Cart cart = new Cart(); 
            cart.ID = ID;
            cart.Type = "REMOVE";
            return _medicinesService.AddToCart(cart);
        }

        [HttpPost]
        [Route("placeOrder")]
        public Response PlaceOrder(int UserID)
        {
            return _medicinesService.PlaceOrder(UserID);
        }

        [HttpGet]
        [Route("orderList")]
        public Response OrderList(string Type, string Email, int ID)
        {
            return _medicinesService.OrderList(Type, Email, ID);
        }

        [HttpGet]
        [Route("cartList")]
        public Response CartList(string Email)
        {
            return _medicinesService.CartList(Email);
        } 
    }
}
