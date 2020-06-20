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

            if (!context.Packages.Any())
            {
                context.Packages.Add(new Package
                {
                    PackageName = "Bronze",
                    PackagePrice = 100,
                    PackageItems = new List<PackageItem>
                 {
                     new PackageItem{ ItemId = 1 , Quantity = 1 },
                     new PackageItem{ ItemId = 3 , Quantity = 4 }
                 }
                });
                context.Packages.Add(new Package
                {
                    PackageName = "Silver",
                    PackagePrice = 150,
                    PackageItems = new List<PackageItem>
                 {
                     new PackageItem{ ItemId = 1 , Quantity = 1 },
                     new PackageItem{ ItemId = 2 , Quantity = 1 },
                      new PackageItem{ ItemId = 3 , Quantity = 6 }
                 }
                });
                context.Packages.Add(new Package
                {
                    PackageName = "Gold",
                    PackagePrice = 160,
                    PackageItems = new List<PackageItem>
                 {
                     new PackageItem{ ItemId = 1 , Quantity = 1 },
                     new PackageItem{ ItemId = 2 , Quantity = 1 },
                      new PackageItem{ ItemId = 3 , Quantity = 8 }
                 }
                });
                context.Packages.Add(new Package
                {
                    PackageName = "Platium",
                    PackagePrice = 170,
                    PackageItems = new List<PackageItem>
                 {
                     new PackageItem{ ItemId = 1 , Quantity = 1 },
                     new PackageItem{ ItemId = 2 , Quantity = 1 },
                      new PackageItem{ ItemId = 3 , Quantity = 10 }
                 }
                });
                context.Packages.Add(new Package
                {
                    PackageName = "Diamond",
                    PackagePrice = 190,
                    PackageItems = new List<PackageItem>
                 {
                     new PackageItem{ ItemId = 7 , Quantity = 1 },
                     new PackageItem{ ItemId = 8 , Quantity = 1 },
                      new PackageItem{ ItemId = 3 , Quantity = 8 },
                      new PackageItem{ ItemId = 4 , Quantity = 1 }
                 }
                });
                context.Packages.Add(new Package
                {
                    PackageName = "Crown",
                    PackagePrice = 200,
                    PackageItems = new List<PackageItem>
                 {
                     new PackageItem{ ItemId = 7 , Quantity = 1 },
                     new PackageItem{ ItemId = 8 , Quantity = 1 },
                      new PackageItem{ ItemId = 3 , Quantity = 12 }
                 }
                });
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