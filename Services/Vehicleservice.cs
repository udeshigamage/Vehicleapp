using Microsoft.EntityFrameworkCore;
using WebApplication1.dbcontext;
using WebApplication1.Models.DTO;
using WebApplication1.Services.Interfaces;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class Vehicleservice : IVehicleservice
    {
        private readonly Appdbcontext _context;
        private readonly ILogger<Manufactureservice> _logger;
        public Vehicleservice(Appdbcontext context, ILogger<Manufactureservice> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Vehicle_read_DTO>> GetallAsync()
        {

            try
            {
                return await _context.Vehicles.Select(x => new Vehicle_read_DTO
                {
                    manufacturename = x.Manufacture.manufacturere_name,
                    Id = x.Id,
                    Name = x.Name,
                    Brand = x.Brand
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching vehicles");
                throw new ApplicationException("Something went wrong while retrieving vehicles", ex);
            }

        }
        public async Task<Messages> Createasync(Vehicle_create_DTO vehicle)
        {
            try
            {
                if (vehicle == null)
                {
                    return new Messages { Message = "Invalid input data", Status = "E" };
                }

                // Check if the ManufactureId exists
                var manufactureExists = await _context.Manufactures
                    .AnyAsync(m => m.ManufactureId == vehicle.ManufactureId);

                if (!manufactureExists)
                {
                    return new Messages { Message = "Manufacture ID does not exist", Status = "E" };
                }

                var newVehicle = new Vehicle
                {
                    ManufactureId = vehicle.ManufactureId,
                    Name = vehicle.Name,
                    Brand = vehicle.Brand
                };

                _context.Vehicles.Add(newVehicle);
                await _context.SaveChangesAsync();

                return new Messages { Message = "Vehicle created successfully", Status = "S" };
            }
            catch (Exception ex)
            {
                return new Messages { Message = $"An error occurred: {ex.Message}", Status = "E" };
            }
        }


        public async Task<Messages> Updateasync(int id, Vehicle_update_DTO vehicle)
        {
            try
            {
                var vehicless = await _context.Vehicles.FindAsync(id);
                vehicless.Brand = vehicle.Brand;
                vehicless.Name = vehicle.Name;
                await _context.SaveChangesAsync();
                return new Messages { Message = "Vehicle updated successfully", Status = "S" };

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
                var vehicles=await _context.Vehicles.FindAsync(id);
                 _context.Vehicles.Remove(vehicles);
                await _context.SaveChangesAsync();
                return new Messages { Message = "Vehicle deleted successfully", Status = "S" };
            }
            catch (Exception ex)
            {
                return new Messages { Message = "An error occurred while deleting vehicle", Status = "E" };
            }
        }
    }
}
