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
        public static void SeedCustomer(DataContext context)
        {
            if (!context.Customers.Any())
            {
                var customerData = System.IO.File.ReadAllText("Customers.json");
                var customers = JsonConvert.DeserializeObject<List<Customer>>(customerData);
                foreach(var customer in customers)
                {
                    context.Customers.Add(customer);
                }
                context.SaveChanges();
            }
        }
    }
}
