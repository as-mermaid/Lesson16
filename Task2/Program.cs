using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            using (StreamReader sr = new StreamReader("../../../Products.json"))
            {
                jsonString = sr.ReadToEnd();
            }

            Product[] products = JsonSerializer.Deserialize<Product[]>(jsonString);

            Product mostExpensiveProduct = products[0];
            foreach (Product product in products)
            {
                if (product.Price > mostExpensiveProduct.Price) 
                    mostExpensiveProduct = product;
            }

            Console.WriteLine($"Самый дорогой товар - {mostExpensiveProduct.Code} " +
                $"{mostExpensiveProduct.Name} {mostExpensiveProduct.Price}");
            Console.ReadKey();

        }
    }
}
