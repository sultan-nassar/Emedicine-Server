using emedicine_api.Models;
using System.Data.SqlClient;
using System.Data;

namespace emedicine_api.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        public Response AddUpdateMedicine(Medicines medicines, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_AddUpdateMedicine", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<Medicines> listMedicine = new List<Medicines>();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", medicines.ID);
            cmd.Parameters.AddWithValue("@Name", medicines.Name);
            cmd.Parameters.AddWithValue("@Manufacturer", medicines.Manufacturer);
            cmd.Parameters.AddWithValue("@UnitPrice", medicines.UnitPrice);
            cmd.Parameters.AddWithValue("@Discount", medicines.Discount);
            cmd.Parameters.AddWithValue("@Quantity", medicines.Quantity);
            cmd.Parameters.AddWithValue("@ExpDate", medicines.ExpDate);
            cmd.Parameters.AddWithValue("@ImageUrl", medicines.ImageUrl);
            cmd.Parameters.AddWithValue("@Status", medicines.Status);
            cmd.Parameters.AddWithValue("@Type", medicines.Type);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                if (medicines.Type == "Add")
                    response.StatusMessage = "Medicine inserted successfully";
                if (medicines.Type == "Update")
                    response.StatusMessage = "Medicine updated successfully";
            }
            else
            {
                response.StatusCode = 100;
                if (medicines.Type == "Add")
                    response.StatusMessage = "Medicine did not save. try again.";
                if (medicines.Type == "Update")
                    response.StatusMessage = "Medicine did not update. try again.";
            }
            return response;
        }

        public Response DeleteMedicine(int id, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_DeleteMedicine", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<Medicines> listMedicine = new List<Medicines>();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Medicine deleted successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Medicine did not delete. try again.";
            }
            return response;
        }
        public Response GetMedicines(int id, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_GetMedicines", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<Medicines> listMedicine = new List<Medicines>();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);

            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Medicines medicine = new Medicines();
                    medicine.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    medicine.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    medicine.Manufacturer = Convert.ToString(dt.Rows[i]["Manufacturer"]);
                    medicine.UnitPrice = Convert.ToString(dt.Rows[i]["UnitPrice"]);
                    medicine.Discount = Convert.ToString(dt.Rows[i]["Discount"]);
                    medicine.Quantity = Convert.ToString(dt.Rows[i]["Quantity"]);
                    medicine.ExpDate = Convert.ToString(dt.Rows[i]["ExpDate"]);
                    medicine.ImageUrl = Convert.ToString(dt.Rows[i]["ImageUrl"]);
                    medicine.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    medicine.ExpDate = Convert.ToString(dt.Rows[i]["ExpDate"]);
                    listMedicine.Add(medicine);
                }
                if (listMedicine.Count > 0)
                {
                    response.StatusCode = 200;
                    response.listMedicines = listMedicine;
                }
                else
                {
                    response.StatusCode = 100;
                    response.listMedicines = null;
                }
            }

            return response;
        }
        public Response UserList(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("sp_UserList", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<Users> listUsers = new List<Users>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Users user = new Users();
                    user.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    user.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                    user.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                    user.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    user.Fund = Convert.ToString(dt.Rows[i]["Fund"]);
                    user.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                    user.Password = Convert.ToString(dt.Rows[i]["Password"]);
                    user.ImageUrl = Convert.ToString(dt.Rows[i]["ImageUrl"]);
                    user.ImageAlt = Convert.ToString(dt.Rows[i]["ImageAlt"]);
                    user.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    listUsers.Add(user);
                }
                response.StatusCode = 200;
                response.listUsers = listUsers;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No users found";
            }
            return response;
        }
        public Response UpdateOrderStatus(string OrderNo, string OrderStatus, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_updateOrderStatus", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@OrderNo", OrderNo);
            cmd.Parameters.AddWithValue("@OrderStatus", OrderStatus);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Order status has been updated successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Some error occurred. Try after sometime.";
            }
            return response;
        }
        
    }
}
