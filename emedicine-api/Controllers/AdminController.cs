using emedicine_api.Models;
using emedicine_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace emedicine_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IWebHostEnvironment _environment; // Inject the hosting environment

        public AdminController(IAdminService adminService, IWebHostEnvironment environment)
        {
            _adminService = adminService;
            _environment = environment;
        }

        [HttpPost]
        [Route("addUpdateMedicine")]
        public async Task<Response> AddUpdateMedicine([FromForm] Medicines medicines, IFormFile imageUrl)
        {
            // Check if an image file is provided
            if (imageUrl != null && imageUrl.Length > 0)
            {
                medicines.ImageUrl = await SaveImageAsync(imageUrl);
            }

            // Call the service method to handle the rest of the medicine data
            return _adminService.AddUpdateMedicine(medicines);
        }

        [HttpDelete]
        [Route("deleteMedicine")]
        public Response DeleteMedicine(int id)
        {
            return  _adminService.DeleteMedicine(id);
        }
        private async Task<string> SaveImageAsync(IFormFile image)
        {
            // Logic to save the image and return the URL
            // This is just a placeholder. You will need to implement the actual storage logic.
            string uploadsFolder = Path.Combine(_environment.WebRootPath, "medicines");
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return $"{Request.Scheme}://{Request.Host}/medicines/{uniqueFileName}";
        }

        [HttpGet]
        [Route("getMedicines")]
        public Response GetMedicines(int id)
        {
            return _adminService.GetMedicines(id);
        }

        [HttpGet]
        [Route("userList")]
        public Response UserList()
        {
            return _adminService.UserList();
        }

        [HttpPut]
        [Route("updateOrderStatus")]
        public Response UpdateOrderStatus(string OrderNo, string OrderStatus)
        {
            return _adminService.UpdateOrderStatus(OrderNo, OrderStatus);
        }

        [HttpPost]
        [Route("UploadFile")]
        public Response UploadFile([FromForm] FileModel fileModel)
        {
            Response response = new Response();
            try
            {
                string path = Path.Combine(@"D:\EMedicine\Frontend\public\assets\images\", fileModel.FileName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    fileModel.FormFile.CopyTo(stream);
                }
                response.StatusCode = 200;
                response.StatusMessage = "File uploaded";
            }
            catch (Exception ex)
            {
                response.StatusCode = 100;
                response.StatusMessage = "File upload failed: " + ex.Message;
            }
            return response;
        }
    }
}
