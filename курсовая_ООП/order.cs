using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовая_ООП
{
    class order
    {
        int number_order;
        string phone;
        string preparations;
        float all_price;
        string status;
        public order(int number_order, string phone, string preparations, float all_price, string status)
        {
            this.number_order = number_order;
            this.phone = phone;
            this.preparations = preparations;
            this.all_price = all_price;
            this.status = status;
        }
        public int Number_order { get => number_order; set => number_order = value; }
        public float All_Price { get => all_price; set => all_price = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Preparations { get => preparations; set => preparations = value; }
        public string Status { get => status; set => status = value; }
    }
}
