using emedicine_api.Models;

namespace emedicine_api.Services
{
    public interface IMedicinesService
    {
        Response AddToCart(Cart cart);
        Response PlaceOrder(int UserID);
        Response OrderList(string Type, string Email, int ID);
        Response CartList(string Email);
    }
}
