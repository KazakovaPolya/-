using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовая_ООП
{
    class Basket_list
    {
        public List<basket> bas = new List<basket>();
        public Basket_list()
        {
            List<basket> bas = new List<basket>();
        }

        public void add(basket basket)
        {
            bas.Add(basket);
        }
        public void add(int id, string name, float price, int count, float all_price)
        {
            basket basket = new basket(id, name, price, count, all_price);
            bas.Add(basket);
        }
        public int get_count_basket()
        {
            return bas.Count();
        }
        public void clear()
        {
            bas.Clear();
        }
        public bool get_name_basket(string name)
        {
            foreach (basket basket in bas)
            {
                if (basket.Name.Trim() == name.Trim())
                {
                    return true;
                }
            }
            return false;
        }
        public void remove(basket basket)
        {
            bas.Remove(basket);
        }
    }
}
