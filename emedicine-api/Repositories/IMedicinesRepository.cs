using emedicine_api.Models;
using System.Data.SqlClient;

namespace emedicine_api.Repositories
{
    public interface IMedicinesRepository
    {
        Response ManageCart(Cart cart, SqlConnection connection);
        Response PlaceOrder(int UserID, SqlConnection connection);
        Response OrderList(string Type, string Email, int ID, SqlConnection connection);
        Response CartList(string Email, SqlConnection connection);
    }
}
