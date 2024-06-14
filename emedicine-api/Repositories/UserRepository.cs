using emedicine_api.Models;
using System.Data;
using System.Data.SqlClient;

namespace emedicine_api.Repositories
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using emedicine_api.Helpers;
    using Microsoft.Extensions.Configuration;

    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Response Register(Users user)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("EMedCS")))
            {
                Response response = new Response();
                SqlCommand cmd = new SqlCommand("sp_register", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", 0);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@HashPassword", HashPassword.HashedPassword(user.Password));
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Fund", 0);
                cmd.Parameters.AddWithValue("@Type", "Users");
                cmd.Parameters.AddWithValue("@Status", 1);
                cmd.Parameters.AddWithValue("@ActionType", "Add");
                cmd.Parameters.AddWithValue("@ImageUrl", user.ImageUrl);
                cmd.Parameters.AddWithValue("@ImageAlt", user.ImageAlt);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "User registered successfully";
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "User registration failed";
                }
                return response;
            }
        }
        public Response Login(LoginDTO loginDTO)
        {
            Users user = new Users();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("EMedCS")))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_Newlogin", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Email", loginDTO.Email);
                da.SelectCommand.Parameters.AddWithValue("@HashPassword", HashPassword.HashedPassword(loginDTO.Password));
                DataTable dt = new DataTable();
                da.Fill(dt);
                Response response = new Response();
                if (dt.Rows.Count > 0)
                {
                    user.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                    user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                    user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                    user.Type = Convert.ToString(dt.Rows[0]["Type"]);
                    user.ImageUrl = Convert.ToString(dt.Rows[0]["ImageUrl"]);
                    user.ImageAlt = Convert.ToString(dt.Rows[0]["ImageAlt"]);
                    response.StatusCode = 200;
                    response.StatusMessage = "User is valid";
                    response.User = user;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "User is invalid";
                    response.User = null;
                }
                return response;
            }
        }
        public Response ViewUser(int ID)
        {
            Users user = new Users();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("EMedCS")))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_NewViewUser", connection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@ID", ID);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Response response = new Response();
                if (dt.Rows.Count > 0)
                {
                    user.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                    user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                    user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                    user.Type = Convert.ToString(dt.Rows[0]["Type"]);
                    user.Fund = Convert.ToString(dt.Rows[0]["Fund"]);
                    user.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                    user.Password = Convert.ToString(dt.Rows[0]["Password"]);
                    user.ImageUrl = Convert.ToString(dt.Rows[0]["ImageUrl"]);
                    user.ImageAlt = Convert.ToString(dt.Rows[0]["ImageAlt"]);
                    response.StatusCode = 200;
                    response.StatusMessage = "User exists.";
                    response.User = user;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "User does not exist.";
                    response.User = null;
                }
                return response;
            }
        }
        public Response UpdateProfile(Users user)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("EMedCS")))
            {
                Response response = new Response();
                SqlCommand cmd = new SqlCommand("sp_register", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", user.ID);
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@ActionType", user.ActionType);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Record updated successfully";
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Some error occurred. Try after sometime";
                }
                return response;
            }
        }
    }
}