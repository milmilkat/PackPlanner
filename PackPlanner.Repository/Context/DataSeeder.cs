namespace PackPlanner.Repository.Context
{
    public static class DataSeeder
    {
        public static void Seed(this DataContext context)
        {
            if (context.Items.Any() || context.Packs.Any())
            {
                return;
            }

            var item1 = new Models.Entities.Item
            {
                Id = 1,
                Length = 1,
                Quantity = 1,
                Weight = 1,
                AddedDate = DateTime.Now.AddMinutes(-1),
            };

            var item2 = new Models.Entities.Item
            {
                Id = 2,
                Length = 2,
                Quantity = 2,
                Weight = 2,
                AddedDate = DateTime.Now,
            };

            context.Items.Add(item1);
            context.Items.Add(item2);
            context.SaveChanges();
        }
    }
}
