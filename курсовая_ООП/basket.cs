using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовая_ООП
{
    class basket
    {
        int id;
        string name;
        float price;
        int count;
        float all_price;

        public basket(int id, string name,float price, int count, float all_price = 0)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.count = count;
            this.all_price = all_price;
        }
        public int Id { get => id; set => id = value; }
        public float All_Price { get => all_price; set => all_price = value; }
        public string Name { get => name; set => name = value; }
        public float Price { get => price; set => price = value; }
        public int Count { get => count; set => count = value; }
    }
}
