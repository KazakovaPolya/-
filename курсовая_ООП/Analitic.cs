using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовая_ООП
{
    class Analitic
    {
        int id;
        string name;
        //string indication;
        double price;
        int count;
        string date;
        double all_price;
        public Analitic(int id, string name, double price, int count, string date, double all_price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.count = count;
            this.date = date;
            this.all_price = all_price;
        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public int Count { get => count; set => count = value; }
        public string Date { get => date; set => date = value; }
        public double All_price { get => all_price; set => all_price = value; }
    }
}
