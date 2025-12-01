using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac5
{
    internal class Product
    {
        private int id { get; set; }
        private int supplierId { get; set; }
        private string title {  get; set; }
        private double volume { get; set; }
        private double price { get; set; }
        private int  daysCount { get; set; }

        public Product(int _id, int _supplierId, string _tytle, double _volume, double _price, int _daysCount)
        {
            this.id = _id;
            this.supplierId = _supplierId;
            this.title = _tytle;
            this.volume = _volume;
            this.price = _price;
            this.daysCount = _daysCount;  
        }

        public void showProduct()
        {
            Console.WriteLine($"Id: {id}\nSupplier Id: {supplierId}\nTitle: {title}\n" +
                $"Volume: {volume}\nPrice: {price}\n Days Count: {daysCount}");
        }


    }
}
