using WebApplication1.Models;
using WebApplication1.Models.DTO;

namespace WebApplication1.Services.Interfaces
{
    public interface IManufactureservice
    {
        Task<IEnumerable<ManufactureReadDTO>> GetallAsync();

         

           Task<Messages> Createasync(ManufactureAddDTO manufacture);

           Task<Messages> Updateasync(int id, ManufactureUpdateDTO manufacture );

           Task<Messages> Deleteasync(int id);
    }
}
