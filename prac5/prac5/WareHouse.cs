using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac5
{
    internal class WareHouse
    {
        private int id {  get; set; }
        private string type {  get; set; }
        private double volume { get; set; }
        private string address { get; set; }
        private Product[] products { get; set; }

        public WareHouse(int id, string type, double volume, string address, Product[] products)
        {
            this.id = id;
            this.type = type;
            this.volume = volume;
            this.address = address;
            this.products = products;
        }

        public void showWarehouse()
        {
            Console.WriteLine($"Id: {id}\nType: {type}\nVolume: {volume}\nAddress: {address}");
            Console.WriteLine("Products:");
            foreach (Product p in products)
            {
                p.showProduct();
            }
        }
    }
}
