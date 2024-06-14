using emedicine_api.Models;
using System.Data.SqlClient;
using System.Data;

namespace emedicine_api.Repositories
{
    public class MedicinesRepository : IMedicinesRepository
    {
        private readonly IConfiguration _configuration;
        public MedicinesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }      
        public Response ManageCart(Cart cart, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_ManageCart", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", cart.ID);
            cmd.Parameters.AddWithValue("@ProductId", cart.ProductId);
            cmd.Parameters.AddWithValue("@UserId", cart.UserId);
            cmd.Parameters.AddWithValue("@Type", cart.Type);
            cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
                
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = cart.Type == "ADD" ? "Item added successfully" : "Item removed successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = cart.Type == "ADD" ? "Item could not be added" : "Item could not be removed";
            }
            return response;
        }
        public Response CartList(string Email, SqlConnection connection)
        {
            Response response = new Response();
            List<Dictionary<string, object>> listCart = new List<Dictionary<string, object>>();
            SqlDataAdapter da = new SqlDataAdapter("sp_CartList", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Email", Email);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var obj = new Dictionary<string, object>();
                    obj["ID"] = Convert.ToInt32(dt.Rows[i]["ID"]);
                    obj["MedicineName"] = Convert.ToString(dt.Rows[i]["Name"]);
                    obj["Manufacturer"] = Convert.ToString(dt.Rows[i]["Manufacturer"]);
                    obj["UnitPrice"] = Convert.ToDecimal(dt.Rows[i]["UnitPrice"]);
                    obj["Discount"] = Convert.ToDecimal(dt.Rows[i]["Discount"]);
                    obj["Quantity"] = Convert.ToInt32(dt.Rows[i]["Quantity"]);
                    obj["TotalPrice"] = Convert.ToDecimal(dt.Rows[i]["TotalPrice"]);
                    obj["ImageUrl"] = Convert.ToString(dt.Rows[i]["ImageUrl"]);
                    listCart.Add(obj);
                }
                if (listCart.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Cart details fetched";
                    response.listCart = listCart;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Cart details are not available";
                    response.listCart = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Cart details are not available";
                response.listCart = null;
            }
            return response;
        }
        public Response PlaceOrder(int UserID, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_PlaceNewOrder", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserID", UserID);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Order has been placed successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order could not be placed";
            }
            return response;
        }
        public Response OrderList(string Type, string Email, int ID, SqlConnection connection)
            {
            Response response = new Response();
            Users users = new Users(); 
            List<Orders> listOrder = new List<Orders>();
            SqlDataAdapter da = new SqlDataAdapter("sp_OrderList", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@ID", ID);
            da.SelectCommand.Parameters.AddWithValue("@Type", Type);
            da.SelectCommand.Parameters.AddWithValue("@Email", Email);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Orders order = new Orders();
                    order.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    order.OrderNo = Convert.ToString(dt.Rows[i]["OrderNo"]);
                    order.OrderTotal = Convert.ToDecimal(dt.Rows[i]["OrderTotal"]);
                    order.OrderStatus = Convert.ToString(dt.Rows[i]["OrderStatus"]);
                    order.CreatedOn = Convert.ToString(dt.Rows[i]["CreatedOn"]);
                    order.CustomerName = Convert.ToString(dt.Rows[i]["CustomerName"]);
                    if (Type == "UserItems")
                    {
                        order.MedicineName = Convert.ToString(dt.Rows[i]["MedicineName"]);
                        order.Manufacturer = Convert.ToString(dt.Rows[i]["Manufacturer"]);
                        order.UnitPrice = Convert.ToDecimal(dt.Rows[i]["UnitPrice"]);
                        order.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"]);
                        order.TotalPrice = Convert.ToDecimal(dt.Rows[i]["TotalPrice"]);
                        order.CreatedOn = Convert.ToString(dt.Rows[i]["CreatedOn"]);
                        order.ImageUrl = Convert.ToString(dt.Rows[i]["ImageUrl"]);
                    }
                    listOrder.Add(order);
                }
                if (listOrder.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Order details fetched";
                    response.listOrders = listOrder;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Order details are not available";
                    response.listOrders = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order details are not available";
                response.listOrders = null;
            }
            return response;
        }
        
    }
}
