using emedicine_api.Models;
using emedicine_api.Repositories;
using System.Data.SqlClient;

namespace emedicine_api.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IConfiguration _configuration;

        public AdminService(IAdminRepository adminRepository, IConfiguration configuration)
        {
            _adminRepository = adminRepository;
            _configuration = configuration;
        }

        public Response AddUpdateMedicine(Medicines medicines)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("EMedCS")))
            {
                return _adminRepository.AddUpdateMedicine(medicines, connection);
            }
        }

        public Response DeleteMedicine(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("EMedCS")))
            {
                return _adminRepository.DeleteMedicine(id, connection);
            }
        }

        public Response GetMedicines(int id)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("EMedCS")))
            {
                return _adminRepository.GetMedicines(id, connection);
            }
        }

        public Response UserList()
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("EMedCS")))
            {
                return _adminRepository.UserList(connection);
            }
        }

        public Response UpdateOrderStatus(string OrderNo, string OrderStatus)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("EMedCS")))
            {
                return _adminRepository.UpdateOrderStatus(OrderNo, OrderStatus, connection);
            }
        }
    }
}
