using emedicine_api.Models;
using emedicine_api.Repositories;
using System.Data.SqlClient;

namespace emedicine_api.Services
{
    public class MedicinesService : IMedicinesService
    {
        private readonly IMedicinesRepository _medicinesRepository;
        private readonly IConfiguration _configuration;

        public MedicinesService(IMedicinesRepository medicinesRepository, IConfiguration configuration)
        {
            _medicinesRepository = medicinesRepository;
            _configuration = configuration;
        }

        public Response AddToCart(Cart cart)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("EMedCS")))
            {
                return _medicinesRepository.ManageCart(cart, connection);
            }
        }

        public Response PlaceOrder(int UserID)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("EMedCS")))
            {
                return _medicinesRepository.PlaceOrder(UserID, connection);
            }
        }

        public Response OrderList(string Type, string Email, int ID)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("EMedCS")))
            {
                return _medicinesRepository.OrderList(Type, Email, ID, connection);
            }
        }

        public Response CartList(string Email)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("EMedCS")))
            {
                return _medicinesRepository.CartList(Email, connection);
            }
        }
    }
}
