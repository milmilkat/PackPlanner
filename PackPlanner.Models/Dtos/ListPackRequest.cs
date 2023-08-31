using PackPlanner.Models.Enums;

namespace PackPlanner.Models.Dtos
{
    public class ListPackRequest
    {
        public double MaxWeight { get; set; }
        public uint MaxItems { get; set; }
        public OrderType OrderType { get; set; } = OrderType.Natural;
    }
}
