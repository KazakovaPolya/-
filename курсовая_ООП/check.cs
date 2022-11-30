using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace курсовая_ООП
{
    class check
    {
        public check() { }
        public bool StringCheck(string str)
        {
            if (str.Length < 4)
                return false;
            for (int i = 0; i < str.Length; i++)
            {
                if (!(((int)str[i] >= 'А' && (int)str[i] <= 'я') || (int)str[i] == ' ' || (int)str[i] == '-'))
                    return false;
            }
            return true;
        }
        public bool checkdigit(string num)
        {
            if (num.Length < 1)
                return false;
            for (int i = 0; i < num.Length; i++)
            {
                if ((int)num[0] == '0' || (int)num[i] < '0' || (int)num[i] > '9')
                    return false;
            }
            return true;
        }
        public bool checkNumber(string num)
        {
            if ((num.Length != 10) || ((int)num[0] != '9'))
                return false;
            return true;
        }
    }
}
