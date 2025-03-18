namespace WebApplication1.Models.DTO
{


    public class Vehicle_update_DTO
    {
        public string Name { get; set; }

        public string Brand { get; set; }
    }
    public class Vehicle_create_DTO
    {
        public int ManufactureId { get; set; }
        public string Name { get; set; }

        public string Brand { get; set; }
    }
    public class Vehicle_read_DTO
    {
        public int Id { get; set; }

        public string manufacturename { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }
    }
}
