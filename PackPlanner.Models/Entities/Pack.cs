using System.ComponentModel.DataAnnotations.Schema;

namespace PackPlanner.Models.Entities
{
    public class Pack
    {
        /// <summary>
        /// Id of the pack
        /// </summary>
        public int Id { get; set; }

        [NotMapped]
        public double RemainingWeight { get; set; }

        [NotMapped]
        public uint RemainingSpace { get; set; }

        /// <summary>
        /// Items in a pack
        /// </summary>
        public IList<Item> Items { get; } = new List<Item>();

        public void PutItem(Item item)
        {
            this.Items.Insert(0, item);
            this.RemainingWeight -= item.Weight;
            this.RemainingSpace -= item.Quantity;
        }
    }
}