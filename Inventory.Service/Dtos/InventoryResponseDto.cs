
namespace Inventory.Service.Dtos
{
    public class InventoryResponseDto
    {
        public IEnumerable<Inventory>? inventory { get; set; }
        public IEnumerable<Request>? requests { get; set; }
    }
}
