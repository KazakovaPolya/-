using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace курсовая_ООП
{
    public partial class analitic_Form : Form
    {
        menu menu;
        SqlConnection cnn = null;
        SqlDataAdapter da = null;
        DataTable table = null;
        analitic_list list = new analitic_list();
        public analitic_Form(menu m)
        {
            InitializeComponent();
            menu = m;
        }

        private void Return_menu_button1_Click(object sender, EventArgs e)
        {
            this.Close();
            menu.Show();
        }

        private void Analitic_Form_Load(object sender, EventArgs e)
        {
            double sum=0;
            DataSet ds = new DataSet();
            cnn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Polina\Desktop\курсач ооп\application_for_pharmacy\курсовая_ООП\preparations.mdf; Integrated Security = True");
            cnn.Open();
            //da = new SqlDataAdapter("UPDATE preparations SET count =" + (count - bas.bas[i].Count) + " WHERE id = " + bas.bas[i].Id, cnn);
            table = new DataTable();
            da = new SqlDataAdapter("select * from Analitic", cnn);
            da.Fill(table);
            da.Fill(ds, "Analitic");
            DataRow row = ds.Tables[0].NewRow();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                row = ds.Tables[0].Rows[i];
                list.add(Convert.ToInt32(row[0]), Convert.ToString(row[1]), Convert.ToDouble(row[2]), Convert.ToInt32(row[3]), Convert.ToString(row[4]), Convert.ToDouble(row[5]));

            }
            for(int j=0; j<list.get_count_list_in_analitic();j++)
            {
                sum += list.list[j].All_price;
                textBox1.Text = "Общая сумма покупки: " + sum + "p";
            }
            /*int count=list.list[0].Count;
            for(int i=1;i<list.get_count_list_in_analitic();i++)
            {
                if (count > list.list[i].Count && count !=list.list[i].Count)
                    count = list.list[i].Count;
            }
            if(count!=)*/
            dataGridView1.DataSource = table;
            cnn.Close();
        }
    }
}
