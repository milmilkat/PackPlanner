namespace PackPlanner.Models.Dtos
{
    public class Item
    {
        /// <summary>
        /// Id of the item
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Length of item in millimeter
        /// </summary>
        public double Length { get; set; }

        /// <summary>
        /// Quantity of the item
        /// </summary>
        public uint Quantity { get; set; }

        /// <summary>
        /// Weight of item in Kg
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// The date that it was created
        /// </summary>
        public DateTime AddedDate { get; set; }

        /// <summary>
        /// Pack of an itemte
        /// </summary>
        public Pack? Pack { get; set; }
    }
}
