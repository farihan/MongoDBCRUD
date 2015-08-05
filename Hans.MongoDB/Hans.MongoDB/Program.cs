using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hans.MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadMosques();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static void LoadMosques()
        {
            IList<Mosque> list1 = null;
            IList<Mosque> list2 = null;

            Task.Run(async () =>
            {
                list1 = await GetMosqueList();
                list2 = await GetMosqueListBy();
            }).Wait();

            foreach (var item in list1)
            {
                Console.WriteLine("{0} - {1} - {2}", item.Name, item.District, item.State);
            }

            Console.WriteLine();

            foreach (var item in list2)
            {
                Console.WriteLine("{0} - {1} - {2}", item.Name, item.District, item.State);
            }
        }

        private static async Task<IList<Mosque>> GetMosqueList()
        {
            var repo = new Repository<Mosque>("mosques");
            var list = await repo.FindAll();
            return list.OrderBy(x => x.Name)
                .ToList();
        }

        private static async Task<IList<Mosque>> GetMosqueListBy()
        {
            var repo = new Repository<Mosque>("mosques");
            var list = await repo.FindAllBy(x => x.State.ToLower() == "perak");
            return list.OrderBy(x => x.Name)
                .ToList();
        }

        private static void LoadProducts()
        {
            IList<Product> list1 = null;
            IList<Product> list2 = null;

            Task.Run(async () =>
            {
                list1 = await GetProductList();
                list2 = await GetProductListBy();
            }).Wait();

            foreach (var item in list1)
            {
                Console.WriteLine("{0} - {1} - {2}", item.ProductID, item.ProductName, item.UnitsInStock);
            }
            Console.WriteLine();

            foreach (var item in list2)
            {
                Console.WriteLine("{0} - {1} - {2}", item.ProductID, item.ProductName, item.UnitsInStock);
            }
        }

        private static async Task<IList<Product>> GetProductList()
        {
            var repo = new Repository<Product>("products");
            var list = await repo.FindAll();
            return list.OrderBy(x => x.ProductName)
                .ToList();
        }
        
        private static async Task<IList<Product>> GetProductListBy()
        {
            var repo = new Repository<Product>("products");
            var list = await repo.FindAllBy(x => x.UnitsInStock == 0);
            return list.OrderBy(x => x.ProductName)
                .ToList();
        }
    }
}
