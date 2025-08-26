using CQRS_lib.Data;
using CQRS_lib.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace CQRS_lib.Reos
{
    public class ItemsRepo : IItemsRepo
    {
        private readonly AppDbContext context;

        public ItemsRepo(AppDbContext context)
        {
            this.context = context;
        }

        public List<Items> GetItems()
        {
            return context.Items.ToList();
        }

        public Items GetItems(int id)
        {
            return context.Items.FirstOrDefault(x => x.Id == id);
        }

        public int InsertItem(Items item)
        {
            context.Items.Add(item);
            return context.SaveChanges(); // Returns the number of state entries written to the database
        }

        public int UpdateItem(Items item)
        {
            var existing = context.Items.FirstOrDefault(x => x.Id == item.Id);
            if (existing == null) return 0;

            existing.Name = item.Name;
            existing.Price = item.Price;
            // Add more fields as necessary

            return context.SaveChanges();
        }

        public int DeleteItem(int id)
        {
            var item = context.Items.FirstOrDefault(x => x.Id == id);
            if (item == null) return 0;

            context.Items.Remove(item);
            return context.SaveChanges();
        }
    }
}
