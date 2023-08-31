namespace PackPlanner.Models.Entities
{
    public class Item : ICloneable
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

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public IEnumerable<Item> Split(uint space)
        {
            uint diff = this.Quantity - space;
            return new List<Item>
            {
                new Item
                {
                    Id = this.Id,
                    Weight = this.Weight,
                    AddedDate = this.AddedDate,
                    Length = this.Length,
                    Quantity = diff,
                },
                new Item
                {
                    Id = this.Id,
                    Weight = this.Weight,
                    AddedDate = this.AddedDate,
                    Length = this.Length,
                    Quantity = this.Quantity - diff,
                }
            };
        }
    }
}
