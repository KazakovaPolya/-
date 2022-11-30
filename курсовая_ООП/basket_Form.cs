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
    public partial class basket_Form : Form
    {
        menu menu;
        Basket_list bas = new Basket_list();
        SqlConnection cnn = null;
        SqlDataAdapter da = null;
        DataTable table = null;
        public basket_Form(menu m)
        {
            InitializeComponent();
            menu = m;
        }
        public void init(int id, int i, string name, float price, int count, float all_price)
        {
            dataGridView1.Rows.Add(i, name, price, count, all_price);
            if (bas.get_name_basket(name) == false)
                bas.add(id, name, price, count, all_price);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
            menu.Show();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string count = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            string name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            string price = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            string all_price = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            /*if (bas.get_name_basket(name) == false)
                bas.add(name, float.Parse(price), int.Parse(count), float.Parse(all_price));
            /*for(int i=0;i<bas.get_count_basket();i++)
                MessageBox.Show("Вы выбрали " + bas.bas[i].Name);*/
        }

        //кнопка купить
        private void Button3_Click(object sender, EventArgs e)
        {
            preparations_list preparat = new preparations_list();
            analitic_list list = new analitic_list();
            int p = dataGridView1.Columns.Count;
            //dataGridView1.Rows.Clear();
            menu.sum = 0;
            textBox1.Text = "Общая сумма покупки: " + menu.sum + "p";
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                DataSet ds = new DataSet();
                int count = int.Parse(menu.dataGridView1[4, bas.bas[i].Id - 1].Value.ToString());
                //string name = dataGridView1[1,i].Value.ToString() ;
                cnn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Polina\Desktop\курсач ооп\курсовая_ООП\курсовая_ООП\preparations.mdf; Integrated Security = True");
                cnn.Open();
                da = new SqlDataAdapter("UPDATE preparations SET count =" + (count - bas.bas[i].Count) + " WHERE id = " + bas.bas[i].Id, cnn);
                table = new DataTable();
                //DateTime date = new DateTime();
                da.Fill(table);
                da = new SqlDataAdapter("select * from Analitic", cnn);
                da.Fill(ds, "Analitic");
                DataRow row = ds.Tables[0].NewRow();
                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    row = ds.Tables[0].Rows[k];
                    list.add(Convert.ToInt32(row[0]), Convert.ToString(row[1]), Convert.ToDouble(row[2]), Convert.ToInt32(row[3]), Convert.ToString(row[4]), Convert.ToDouble(row[5]));

                }
            }
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                if (list.get_count_list_in_analitic() != 0 && list.get_name_analitic(bas.bas[i].Name) == true)
                {
                    for (int q = 0; q < list.get_count_list_in_analitic(); q++)
                    {
                        if (list.list[q].Name == bas.bas[i].Name)
                        {
                            SqlDataAdapter d;
                            list.list[q].Count += bas.bas[i].Count;
                            list.list[q].All_price += bas.bas[i].Count * bas.bas[i].Price;
                            d = new SqlDataAdapter("UPDATE Analitic SET Count =" + list.list[q].Count + ",All_Price=" + list.list[q].All_price + "  WHERE Name = N'" + list.list[i].Name + "'", cnn);
                            table = new DataTable();
                            d.Fill(table);
                        }
                    }
                }
                else
                {
                    SqlDataAdapter daa;
                    daa = new SqlDataAdapter("INSERT INTO Analitic (Name,Price,Count,All_Price)  VALUES (N'" + bas.bas[i].Name + "'," + bas.bas[i].Price + "," + bas.bas[i].Count + "," + bas.bas[i].All_Price + ");", cnn); //Name=" + bas.bas[i].Name+", Price="+bas.bas[i].Price+", Count="+bas.bas[i].Count+ ", Date=CURDATE(), All_Price="+bas.bas[i].All_Price, cnn);
                    table = new DataTable();
                    daa.Fill(table);
                    break;
                }
            }
            dataGridView1.Rows.Clear();
            bas.clear();
            MessageBox.Show("Покупка совершена успешно!");
        }
    }
}
