using WebApplication1.Models;
using WebApplication1.Models.DTO;

namespace WebApplication1.Services.Interfaces
{
    public interface IVehicleservice
    {
        Task<IEnumerable<Vehicle_read_DTO>> GetallAsync();

         

           Task<Messages> Createasync(Vehicle_create_DTO vehicle);

           Task<Messages> Updateasync(int id, Vehicle_update_DTO vehicle);

           Task<Messages> Deleteasync(int id);
    }
}
