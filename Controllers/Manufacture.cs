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
    public class Manufacturecontroller:ControllerBase
    {
        private readonly IManufactureservice _manufactureservice;
        //dependency injection
        public Manufacturecontroller(IManufactureservice manufactureservice)
        {
            _manufactureservice = manufactureservice;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var vehicles = await _manufactureservice.GetallAsync();

                

                return Ok(vehicles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching vehicles.", error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ManufactureAddDTO vehicle_)
        {
            try
            {
                var message = await _manufactureservice.Createasync(vehicle_);
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
        public async Task<IActionResult> UpdateAsync(int id, ManufactureUpdateDTO vehicle)
        {
            try { 
                var message = await _manufactureservice.Updateasync( id,vehicle);

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
               var message= await _manufactureservice.Deleteasync(id);
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
