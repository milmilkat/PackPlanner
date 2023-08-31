namespace PackPlanner.Models.Dtos
{
    public class Pack
    {
        /// <summary>
        /// Id of the pack
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Items in a pack
        /// </summary>
        public IList<Item> Items { get; } = new List<Item>();
    }
}