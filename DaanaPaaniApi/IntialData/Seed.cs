using DaanaPaaniApi.Entities;
using DaanaPaaniApi.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace DaanaPaaniApi
{
    public class Seed
    {
        public static void SeedDatabase(DataContext context)
        {
            if (!context.Items.Any())
            {
                context.Items.Add(new Item { ItemName = "Dal", ItemPrice = 10 });
                context.Items.Add(new Item { ItemName = "Sabzi", ItemPrice = 10 });
                context.Items.Add(new Item { ItemName = "Roti", ItemPrice = 10 });
                context.Items.Add(new Item { ItemName = "Dahi", ItemPrice = 10 });
                context.Items.Add(new Item { ItemName = "Chutney", ItemPrice = 10 });
                context.Items.Add(new Item { ItemName = "Rice", ItemPrice = 10 });
                context.Items.Add(new Item { ItemName = "Jumbo Dal", ItemPrice = 20 });
                context.Items.Add(new Item { ItemName = "Jumbo Sabzi", ItemPrice = 10 });
                context.Items.Add(new Item { ItemName = "Pranthe", ItemPrice = 10 });

                context.SaveChanges();
            }

            
            if (!context.Customers.Any())
            {
                var customerData = System.IO.File.ReadAllText("intialData/Customers.json");
                var customers = JsonConvert.DeserializeObject<List<Customer>>(customerData);
                foreach (var customer in customers)
                {
                    context.Customers.Add(customer);
                }
            }
            context.SaveChanges();
        }
    }
}