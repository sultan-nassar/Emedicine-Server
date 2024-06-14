using emedicine_api.Models;
using System.Data.SqlClient;

namespace emedicine_api.Repositories
{
    public interface IAdminRepository
    {
        Response AddUpdateMedicine(Medicines medicines, SqlConnection connection);
        Response DeleteMedicine(int id, SqlConnection connection);
        Response GetMedicines(int id, SqlConnection connection);
        Response UserList(SqlConnection connection);
        Response UpdateOrderStatus(string OrderNo, string OrderStatus, SqlConnection connection);
    }
}
