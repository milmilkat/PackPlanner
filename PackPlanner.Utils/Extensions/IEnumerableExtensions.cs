using PackPlanner.Models.Entities;

namespace PackPlanner.Utils.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<Item> OrderItems(this IEnumerable<Item> items, Models.Enums.OrderType orderType)
        {
            switch (orderType)
            {
                case Models.Enums.OrderType.ShortToLong:
                    return items.OrderByDescending(item => item.Length);

                case Models.Enums.OrderType.LongToShort:
                    return items.OrderBy(item => item.Length);

                default:
                    return items.OrderBy(item => item.AddedDate);
            }
        }

        public static IEnumerable<Pack> PackItems(this IEnumerable<Item> items, Models.Dtos.ListPackRequest listPackRequest)
        {
            var packs = new List<Pack>();
            packs.AddNewPack(listPackRequest);

            foreach (var item in items)
            {
                if (item.Weight > listPackRequest.MaxWeight)
                    throw new ArgumentException($"Item {item.Id} is heavier than the maximum weight");

                packs.PutItemInPacks(item, listPackRequest);
            }

            return packs;
        }

        private static void AddNewPack(this List<Pack> packs, Models.Dtos.ListPackRequest listPackRequest)
        {
            packs.Add(new Pack
            {
                Id = packs.Count > 0 ? packs.Max(pack => pack.Id) + 1 : 1,
                RemainingWeight = listPackRequest.MaxWeight,
                RemainingSpace = listPackRequest.MaxItems,
            });
        }

        private static void PutItemInPacks(this List<Pack> packs, Item item, Models.Dtos.ListPackRequest listPackRequest)
        {
            foreach (var pack in packs)
            {
                if (item.Quantity <= pack.RemainingSpace && item.Weight <= pack.RemainingWeight)
                {
                    pack.PutItem(item);
                    return;
                }

                if (pack.RemainingSpace > 0 && item.Quantity > pack.RemainingSpace && item.Weight <= pack.RemainingWeight)
                {
                    var items = item.Split(pack.RemainingSpace);

                    packs.PutItemInPacks(items.First(), listPackRequest);
                    packs.PutItemInPacks(items.Last(), listPackRequest);
                    return;
                }
            }
            packs.AddNewPack(listPackRequest);
            packs.PutItemInPacks(item, listPackRequest);
        }
    }
}
