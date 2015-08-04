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
            IList<Product> list1 = null;
            IList<Product> list2 = null;

            Task.Run(async () =>
            {
                list1 = await GetList();
                list2 = await GetListBy();
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

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static async Task<IList<Product>> GetList()
        {
            var repo = new Repository<Product>("products");
            var list = await repo.FindAll();
            return list.OrderBy(x => x.ProductName)
                .ToList();
        }
        
        public static async Task<IList<Product>> GetListBy()
        {
            var repo = new Repository<Product>("products");
            var list = await repo.FindAllBy(x => x.UnitsInStock == 0);
            return list.OrderBy(x => x.ProductName)
                .ToList();
        }
    }
}
