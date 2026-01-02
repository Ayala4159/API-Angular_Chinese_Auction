using ChineseAuction.Dtos;
using ChineseAuction.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChineseAuction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;
        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }
        // Controller methods for handling HTTP requests related to Category entity

        // get all packages
        [HttpGet]
        public async Task<IActionResult> GetAllPackages()
        {
                var packages = await _packageService.GetAllPackagesAsync();
                return Ok(packages);
        }

        // get package by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPackageById(int id)
        {

                var package = await _packageService.GetPackageByIdAsync(id);
                if (package == null) return NotFound("The id:" + id + " ,did not found🤚");
                return Ok(package);
        }
        // add new package
        [HttpPost]
        public async Task<IActionResult> AddPackage([FromBody] CreatePackageDto createPackageDto)
        {
            try
            {
                GetPackageDto package = await _packageService.AddPackageAsync(createPackageDto);
                return CreatedAtAction(nameof(GetPackageById), new { id = package.Id }, package);
            }
            catch (Exception)
            {
                //שליחת האקספשין ללוגר כאן
                return BadRequest("Internal server error occurred.");
            }
        }
        // update package
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePackage(int id, [FromBody] CreatePackageDto updatePackageDto)
        {
            try
            {
                var updatedPackage = await _packageService.UpdatePackageAsync(id, updatePackageDto);
                if (updatedPackage == null) return NotFound("The id:" + id + " ,did not found🤚");
                return Ok(updatedPackage);
            }
            catch (Exception ex)
            {
                //שליחת האקספשין ללוגר כאן
                return BadRequest(ex.Message);
            }
        }
        // delete package
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackage(int id)
        {
            try
            {
                var isDeleted = await _packageService.DeletePackageAsync(id);
                if (!isDeleted) return NotFound("The id:" + id + " ,did not found🤚");
                return Ok("Sucsses");
            }
            catch (Exception)
            {
                //שליחת האקספשין ללוגר כאן
                return BadRequest("Internal server error occurred.");
            }
        }
    }
}
