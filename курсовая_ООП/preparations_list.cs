using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace курсовая_ООП
{
    class preparations_list
    {
        public List<preparation> assorty = new List<preparation>();
        public preparations_list()
        {
            List<preparation> assorty = new List<preparation>();
        }

        public void add (preparation preparat)
        {
            assorty.Add(preparat);
        }
        public void add(int id, string name, string indication, float price, int count)
        {
            preparation preparat = new preparation(id, name, indication, price, count);
            assorty.Add(preparat);
        }
        public void clear ()
        {
            assorty.Clear();
        }
        public int get_count_preparation()
        {
            return assorty.Count();
        }
        public int getcount(int id)
        {
            foreach (preparation preparat in assorty)
            {
                if (preparat.Id == id)
                {
                    return preparat.Count;
                }
            }
            return 0;
        }
        public bool getname(string name)
        {
            foreach (preparation preparat in assorty)
            {
                if (preparat.Name.Contains(name))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
