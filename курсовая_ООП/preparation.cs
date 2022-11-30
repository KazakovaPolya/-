using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовая_ООП
{
    class preparation
    {
        int id;
        string name;
        string indication;
        float price;
        int count;

        public preparation(int id, string name, string indication, float price, int count)
        {
            this.id = id;
            this.name = name;
            this.indication = indication;
            this.price = price;
            this.count = count;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Indication { get => indication; set => indication = value; }
        public float Price { get => price; set => price = value; }
        public int Count { get => count; set => count = value; }

    }
}
