using ChineseAuction.Dtos;
using ChineseAuction.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChineseAuction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftController : ControllerBase
    {
        private readonly IGiftService _giftService;
        public GiftController(IGiftService giftService)
        {
            _giftService = giftService;
        }
        // Controller methods for handling HTTP requests related to Gift entity

        // Get all approved gifts
        [HttpGet]
        public async Task<IActionResult> GetAllApprovedGiftsAsync()
        { 
            var gifts =await _giftService.GetAllApprovedGiftsAsync();
            return Ok(gifts);
        }

        // Get all unapproved gifts
        [HttpGet("Unapproved")]
        public async Task<IActionResult> GetNoneUnapprovedGifts()
        {
            var gifts =await _giftService.GetAllUnapprovedGiftsAsync();
            return Ok(gifts);
        }

        // get gift by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGiftById(int id)
        {
            var gift =await _giftService.GetGiftByIdAsync(id);
            if (gift == null) return NotFound("The id:" + id + " ,did not found🤚");
            return Ok(gift);
        }

        // Add new gift
        [HttpPost]
        public async Task<IActionResult> AddGift([FromBody] CreateGiftDto giftDto)
        {
            try
            {
                var createdGift =await _giftService.AddGiftAsync(giftDto);
                return CreatedAtAction(nameof(GetGiftById), new { id = createdGift.Id }, createdGift);
            }
            catch (Exception ex)
            {
                // Log the exception here
                return BadRequest(ex.Message);
            }
        }

        // Update gift
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGift(int id, [FromBody] CreateGiftDto giftDto)
        {
            try
            {
                var updatedGift =await _giftService.UpdateGiftAsync(id, giftDto);
                if (updatedGift == null) return NotFound("The id:" + id + " ,did not found🤚");
                return Ok(updatedGift);
            }
            catch (Exception ex)
            {
                // Log the exception here
                return BadRequest(ex.Message);
            }
        }

        // Update gift purchases quantity
        [HttpPut("purchase/{giftId}")]
        public async Task<IActionResult> UpdateGiftPurchasesQuantity(int giftId)
        {
            try
            {
                var updatedGift =await _giftService.UpdateGiftPurchasesQuantityAsync(giftId);
                if (updatedGift == null) return NotFound("The id:" + giftId + " ,did not found🤚");
                return Ok(updatedGift);
            }
            catch (Exception ex)
            {
                // Log the exception here
                return BadRequest(ex.Message);
            }
        }

        // Delete gift
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGift(int id)
        {
            try
            {
                var result =await _giftService.DeleteGiftAsync(id);
                if (!result) return NotFound("The id:" + id + " ,did not found🤚");
                return Ok("Gift with id:" + id + " has been deleted successfully🗑️");
            }
            catch (Exception ex)
            {
                // Log the exception here
                return BadRequest(ex.Message);
            }
        }
    }
}