using ChineseAuction.Dtos;
using ChineseAuction.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChineseAuction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService _donorService;
        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }
        // Controller methods for handling HTTP requests related to Donor entity

        // Get all donors
        [HttpGet]
        public async Task<IActionResult> GetAllDonors()
        {
                var donors = await _donorService.GetAllDonorsAsync();
                return Ok(donors);
        }

        // get donor by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonorById(int id)
        {
                var donor = await _donorService.GetDonorByIdAsync(id);
                if (donor == null) return NotFound("The id:" + id + " ,did not found🤚");
                return Ok(donor);
        }

        // Add new donor
        [HttpPost]
        public async Task<IActionResult> AddDonor([FromBody] CreateDonorDto createDonorDto)
        {
            try
            {
                var createdDonor = await _donorService.AddDonorAsync(createDonorDto);
                return CreatedAtAction(nameof(GetDonorById), new { id = createdDonor.Id }, createdDonor);
            }
            catch (Exception ex)
            {
                // Log the exception here
                return BadRequest(ex.Message);
            }
        }
        // Update donor
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDonor(int id, [FromBody] CreateDonorDto updateDonorDto)
        {
            try
            {
                var updatedDonor = await _donorService.UpdateDonorAsync(id, updateDonorDto);
                if (updatedDonor == null) return NotFound("The id:" + id + " ,did not found🤚");
                return Ok(updatedDonor);
            }
            catch (Exception ex)
            {
                // Log the exception here
                return BadRequest(ex.Message);
            }
        }
        // Delete donor
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonor(int id)
        {
                var result = await _donorService.DeleteDonorAsync(id);
                if (!result) return NotFound("The id:" + id + " ,did not found🤚");
                return NoContent();
        }

    }
}
