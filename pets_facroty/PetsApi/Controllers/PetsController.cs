using Microsoft.AspNetCore.Mvc;
using PetsApi.Models;
using PetsApi.Services;

namespace PetsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly PetService _petService;

        public PetsController(PetService petService) =>
            _petService = petService;

        [HttpPost]
        public async Task<IActionResult> Post(Pet newPet)
        {
            await _petService.CreateAsync(newPet);
            return CreatedAtAction(nameof(Post), new { id = newPet.Name }, newPet);
        }
    }
}
