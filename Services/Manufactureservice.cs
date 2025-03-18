using Microsoft.EntityFrameworkCore;
using WebApplication1.dbcontext;
using WebApplication1.Models.DTO;
using WebApplication1.Services.Interfaces;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class Manufactureservice : IManufactureservice
    {
        private readonly Appdbcontext _context;
        private readonly ILogger<Manufactureservice> _logger;
        public Manufactureservice(Appdbcontext context, ILogger<Manufactureservice> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<ManufactureReadDTO>> GetallAsync()
        {

            try
            {
                return await _context.Manufactures.Select(x => new ManufactureReadDTO
                {
                    Id = x.ManufactureId,
                    Name = x.manufacturere_name,
                   
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching vehicles");
                throw new ApplicationException("Something went wrong while retrieving vehicles", ex);
            }

        }
        public async Task<Messages> Createasync(ManufactureAddDTO manufacture)
        {
            try
            {
                var manufacture1 = new Manufacture
                {
                   
                  manufacturere_name = manufacture.Name,
                   
                };
                _context.Manufactures.Add(manufacture1);
                await _context.SaveChangesAsync();
                return new Messages { Message = "manufacture created successfully", Status = "S" };
            }
            catch (Exception ex)
            {
                return new Messages { Message = "An error occurred while creating vehicle", Status = "E" };
            }
        }

        public async Task<Messages> Updateasync(int id, ManufactureUpdateDTO manufacture)
        {
            try
            {
                var vehicless = await _context.Manufactures.FindAsync(id);
                vehicless.manufacturere_name = manufacture.Name;
                
                await _context.SaveChangesAsync();
                return new Messages { Message = " updated successfully", Status = "S" };

            }
            catch (Exception ex)
            {
                return new Messages { Message = "An error occurred while updating vehicle", Status = "E" };
            }
        }

        public async Task<Messages> Deleteasync(int id)
        {
            try
            {
                var manufacture=await _context.Manufactures.FindAsync(id);
                 _context.Manufactures.Remove(manufacture);
                await _context.SaveChangesAsync();
                return new Messages { Message = "manufacture deleted successfully", Status = "S" };
            }
            catch (Exception ex)
            {
                return new Messages { Message = "An error occurred while deleting manufacture", Status = "E" };
            }
        }
    }
}
