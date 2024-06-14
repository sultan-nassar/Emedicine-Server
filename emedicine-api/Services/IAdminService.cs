using emedicine_api.Models;

namespace emedicine_api.Services
{
    public interface IAdminService
    {
        Response AddUpdateMedicine(Medicines medicines);

        Response DeleteMedicine(int id);
        Response GetMedicines(int id);
        Response UserList();
        Response UpdateOrderStatus(string OrderNo, string OrderStatus);
    }
}
