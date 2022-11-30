using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовая_ООП
{
    class analitic_list
    {
        public List<Analitic> list = new List<Analitic>();
        public analitic_list()
        {
            List<Analitic> list = new List<Analitic>();
        }
        public void add(int id, string name, double price, int count, string date, double all_price)
        {
            Analitic analitic = new Analitic(id, name, price, count, date, all_price);
            list.Add(analitic);
        }

        public bool get_name_analitic(string name)
        {
            foreach (Analitic analitic in list)
            {
                if (analitic.Name.Trim() == name.Trim())
                {
                    return true;
                }
            }
            return false;
        }
        public int get_count_list_in_analitic()
        {
            return list.Count();
        }
        public void clear()
        {
            list.Clear();
        }
        public bool get_now_date_in_list(string name, string date)
        {
            foreach (Analitic analitic in list)
            {
                if (analitic.Name.Trim() == name.Trim() && analitic.Date==date)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
