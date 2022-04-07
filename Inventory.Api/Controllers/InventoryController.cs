using Inventory.Service.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        [HttpGet("inventory/getInventoryData")]
        public async Task<IActionResult> GetInventoryData()
        {
            return Ok(await _inventoryService.GetInventoryData());
        }
        [HttpGet("inventory/validateKenrals/{inventoryId}/{requestedKernels}")]
        public async Task<IActionResult> ValidateRequestedKernals(int inventoryId, int requestedKernels)
        {
            return Ok(await _inventoryService.ValidateRequestedKernals(inventoryId, requestedKernels));
        }
    }
}
