using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовая_ООП
{
    class order_list
    {
        public List<order> list = new List<order>();
        public order_list()
        {
            List<order> list = new List<order>();
        }
        public void add(int number_order, string phone, string preparations, float all_price, string status)
        {
            order order = new order(number_order,phone,preparations,all_price,status);
            list.Add(order);
        }
        public int get_count_list_in_orders()
        {
            return list.Count();
        }
        public bool get_number(string number)
        {
            foreach (order order in list)
            {
                if (order.Phone == number)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
