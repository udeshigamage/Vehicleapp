using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Models.DTO;
using WebApplication1.Services.Interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Vehiclecontroller:ControllerBase
    {
        private readonly IVehicleservice _vehicleservice;
        //dependency injection
        public Vehiclecontroller (IVehicleservice vehicleservice)
        {
            _vehicleservice = vehicleservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var vehicles = await _vehicleservice.GetallAsync();

                

                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching vehicles.", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Vehicle_create_DTO vehicle_)
        {
            try
            {
                var message = await _vehicleservice.Createasync(vehicle_);
                if (message.Status == "S")
                {
                    return Ok(message);
                }
                else
                {
                    return StatusCode(500, message);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating vehicle.", error = ex.Message });

            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Vehicle_update_DTO vehicle)
        {
            try { 
                var message = await _vehicleservice.Updateasync( id,vehicle);

                if (message.Status == "S")
                {
                    return Ok(message);
                }
                else
                {
                    return StatusCode(500, message);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating vehicle.", error = ex.Message });
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteasync(int id)
        {
            try
            {
               var message= await _vehicleservice.Deleteasync(id);
                if (message.Status == "S")
                {
                    return Ok(message);
                }
                else
                {
                    return StatusCode(500, message);
                }

            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting vehicle.", error = ex.Message });
            }
        }
    }
}
