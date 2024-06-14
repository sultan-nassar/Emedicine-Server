namespace emedicine_api.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<Users> listUsers { get; set; }
        public Users User { get; set; }
        public List<Medicines> listMedicines { get; set; }
        public Medicines medicine { get; set; }
        public List<Dictionary<string, object>> listCart { get; set; }
        public List<Orders> listOrders { get; set; }
        public Orders order { get; set; }
        public string Token { get; set; }
    }
}
