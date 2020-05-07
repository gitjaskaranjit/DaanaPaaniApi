using DaanaPaaniApi.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaanaPaaniApi
{
    public class Seed
    {
        public static void SeedDatabase(DataContext context) {



            if (!context.Packages.Any())
            {
                var PackagesData = System.IO.File.ReadAllText("intialData/Packages.json");
                var Packages = JsonConvert.DeserializeObject<List<Package>>(PackagesData);
                foreach (var Package in Packages)
                {
                    context.Packages.Add(Package);
                }
            }

        
            if(!context.Items.Any()){

                var itemData = System.IO.File.ReadAllText("intialData/items.json");
                var items = JsonConvert.DeserializeObject<List<Item>>(itemData);
                foreach(var item in items)
                {
                    context.Items.Add(item);
                }
            }

            if (!context.PackageItems.Any())
            {
                var PackagesItemData = System.IO.File.ReadAllText("intialData/PackageItems.json");
                var PackageItems = JsonConvert.DeserializeObject<List<PackageItem>>(PackagesItemData);
                foreach (var PackageItem in PackageItems)
                {
                    context.PackageItems.Add(PackageItem);
                }
            }
            if (!context.Customers.Any())
            {
                var customerData = System.IO.File.ReadAllText("intialData/Customers.json");
                var customers = JsonConvert.DeserializeObject<List<Customer>>(customerData);
                foreach(var customer in customers)
                {
                    context.Customers.Add(customer);
                }
                
            }
            context.SaveChanges();
        }
    }
}
