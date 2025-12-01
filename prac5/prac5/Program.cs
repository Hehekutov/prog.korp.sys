using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac5
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            Product product1 = new Product(
                1,
                1,
                "Title 1",
                25.5,
                2000.8,
                20
            );

            Product product2 = new Product(
                2,
                2,
                "Title 2",
                25.5,
                2000.8,
                20
            );

            Product[] products = { product1, product2 };            

            WareHouse warehouse1 = new WareHouse(
                1,
                "Холодный",
                2000.5,
                "Жопашная ул., д. 5",
                products
            );
            WareHouse warehouse2 = new WareHouse(
                2,
                "Сортироваочный",
                2000.5,
                "Булочная ул., д. 52",
                products
            );

            warehouse1.showWarehouse();
            warehouse2.showWarehouse();
        }
    }
}
