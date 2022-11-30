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
    public partial class menu : Form
    {
        public string selectedState;
        public string selectedCount;
        public string count;
        public string name;
        public string price;
        public string id;
        preparations_list preparat = new preparations_list();
        Basket_list bas = new Basket_list();
        public float sum = 0;
        SqlConnection cnn = null;
        SqlDataAdapter da = null;
        DataTable table = null;

        public menu()
        {
            InitializeComponent();
            search_criteria_comboBox1.Items.AddRange(new string[] { "Name", "Indication", "Price" });
            search_criteria_comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        public void Menu_Load_1(object sender, EventArgs e)
        {
            //preparations preparat = new preparations();
            cnn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Polina\Desktop\курсач ооп\курсовая_ООП\курсовая_ООП\preparations.mdf; Integrated Security = True");
            cnn.Open();
            //SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            //cmd.CommandText = "select * from preparations";
            da = new SqlDataAdapter("select * from preparations", cnn);
            table = new DataTable();
            da.Fill(table);
            da.Fill(ds, "preparations");
            dataGridView1.DataSource = table;
            //cnn.Close();
            DataRow row = ds.Tables[0].NewRow();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                row = ds.Tables[0].Rows[i];
                preparat.add(Convert.ToInt32(row[0]), Convert.ToString(row[1]), Convert.ToString(row[2]), Convert.ToInt32(row[3]), Convert.ToInt32(row[4]));

            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedState = search_criteria_comboBox1.SelectedItem.ToString();
        }

        private void Find_Click(object sender, EventArgs e)
        {
            find.Text = "";
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].Visible = true;
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            for (int c = 0; c < dataGridView1.Columns.Count; c++)
            {
                if (dataGridView1.Columns[c].HeaderText == selectedState)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        dataGridView1.CurrentCell = null;
                        dataGridView1.Rows[i].Visible = false;

                        if (dataGridView1[c, i].Value.ToString().ToLower().Contains(find.Text.ToLower()))
                        {
                            dataGridView1.Rows[i].Visible = true;
                        }
                    }
                }
            }
        }

        //выбор количества выбранного лекарства для добавления в корзину
        public void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = "";
            count_comboBox2.Items.Clear();
            count = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            price = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            for (int i = 1; i <= int.Parse(count); i++)
            {
                count_comboBox2.Items.Add(i.ToString());
                count_comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCount = count_comboBox2.SelectedItem.ToString();
        }

        //кнопка "Корзина"
        private void Button2_Click(object sender, EventArgs e)
        {
            basket_Form bask = new basket_Form(this);
            for (int i = 0; i < bas.get_count_basket(); i++)
            {
                bask.init(bas.bas[i].Id, i + 1, bas.bas[i].Name, bas.bas[i].Price, bas.bas[i].Count, bas.bas[i].All_Price);
            }
            bask.textBox1.Text = "Общая сумма покупки: " + sum + "p";
            bask.Show();
            this.Hide();
        }

        //кнопка "добавить в корзину"
        private void Button5_Click(object sender, EventArgs e)
        {
            if (count_comboBox2.SelectedItem == null)
                textBox1.Text = "Не выбран ни один товар или его количество!";
            else
            {
                float s = float.Parse(price);
                int c = int.Parse(selectedCount);
                int iden = int.Parse(id);
                if (bas.get_count_basket() != 0 && bas.get_name_basket(name) == true)
                {
                    for (int i = 0; i < bas.get_count_basket(); i++)
                    {
                        /*if (bas.bas[i].Name == name && preparat.getcount(iden) - bas.bas[i].Count == 0)
                            dataGridView1.Rows[iden - 1].DefaultCellStyle.ForeColor = Color.Red;*/
                        if (bas.bas[i].Name == name && bas.bas[i].Count + c <= preparat.getcount(iden))
                        {
                            bas.bas[i].Count += c;
                            bas.bas[i].All_Price += c * s;
                            sum += (s * c);
                            textBox1.Text = "Добавлено";
                        }
                        else if (bas.bas[i].Name == name && bas.bas[i].Count + c > preparat.getcount(iden))
                        {
                            textBox1.Text = "Данный товар закончился или максимальное количество уже лежит в корзине!";
                            //dataGridView1.Rows[iden - 1].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                }
                else
                {
                    bas.add(iden, name, s, c, (c * s));
                    //bask.init();
                    //data.add_basket(name, s, c);
                    sum += (s * c);
                    textBox1.Text = "Добавлено";
                    for (int i = 0; i < bas.get_count_basket(); i++)
                    {
                        if (preparat.getcount(iden) - bas.bas[i].Count == 0)
                            dataGridView1.Rows[iden - 1].DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }
        //кнопка обновить
        private void Button1_Click_1(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            da = new SqlDataAdapter("select * from preparations", cnn);
            table = new DataTable();
            da.Fill(table);
            da.Fill(ds, "preparations");
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = table;
            for (int i = 0; i < preparat.get_count_preparation(); i++)
            {
                if (preparat.getcount(preparat.assorty[i].Id) != int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()))
                {
                    bas.clear();
                }
            }
            preparat.clear();
            DataRow row = ds.Tables[0].NewRow();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                row = ds.Tables[0].Rows[i];
                preparat.add(Convert.ToInt32(row[0]), Convert.ToString(row[1]), Convert.ToString(row[2]), Convert.ToInt32(row[3]), Convert.ToInt32(row[4]));
            }
        }

        private void Analitic_button4_Click(object sender, EventArgs e)
        {
            analitic_Form analitic = new analitic_Form(this);
            analitic.Show();
            this.Hide();
        }

    }
}
