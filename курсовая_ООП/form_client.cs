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
    public partial class form_client : Form
    {
        public string selectedState;
        public string selectedCount;
        form_menu menu;
        public string count1;
        public string name1;
        public string price1;
        public string id1;
        public string all_price;
        preparations_list preparat = new preparations_list();
        Basket_list bas = new Basket_list();
        //analitic_list list = new analitic_list();
        order_list order = new order_list();
        public float summa = 0; //общая стоимость для корзины
        public double sum1; //общая стоимость для аналитики
        SqlConnection cnn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Polina\Desktop\курсач_ооп\application_for_pharmacy\курсовая_ООП\preparations.mdf; Integrated Security = True");
        SqlDataAdapter da = null;
        DataTable table = null;
        check check = new check();
        public form_client(form_menu m)
        {
            menu = m;
            InitializeComponent();
            search_criteria_comboBox1.Items.AddRange(new string[] { "По имени", "По назначению", "По цене" });
            search_criteria_comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedState = search_criteria_comboBox1.SelectedItem.ToString();
        }

        private void Form_client_Load(object sender, EventArgs e)
        {
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
                if (preparat.assorty[i].Count==0)
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;

            }
            ds = new DataSet();
           /* da = new SqlDataAdapter("select Id, Name, Price, Count, FORMAT(Date, 'dd/MM/yyyy', 'en-US') , All_price FROM Analitic", cnn);
            table = new DataTable();
            da.Fill(table);
            da.Fill(ds, "Analitic");
            row = ds.Tables[0].NewRow();
            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {
                row = ds.Tables[0].Rows[k];
                list.add(Convert.ToInt32(row[0]), Convert.ToString(row[1]), Convert.ToDouble(row[2]), Convert.ToInt32(row[3]), Convert.ToString(row[4]), Convert.ToDouble(row[5]));
            }
            sum1 = 0;
            for (int j = 0; j < list.get_count_list_in_analitic(); j++)
            {
                sum1 += list.list[j].All_price;
                textBox4.Text = "Общая сумма покупки: " + sum1 + "p";
            }
            dataGridView4.DataSource = table;*/
            da = new SqlDataAdapter("select * from Basket", cnn);
            table = new DataTable();
            da.Fill(table);
            dataGridView2.DataSource = table;
            ds = new DataSet();
            da = new SqlDataAdapter("SELECT Order_number, Phone, Preparation, All_price, Status FROM Orders", cnn);
            da.Fill(ds, "Orders");
            row = ds.Tables[0].NewRow();
            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {
                row = ds.Tables[0].Rows[k];
                order.add(Convert.ToInt32(row[0]), Convert.ToString(row[1]), Convert.ToString(row[2]), Convert.ToInt32(row[3]), Convert.ToString(row[4]));

            }
        }

        private void Find_Click(object sender, EventArgs e)
        {
            find.Text = "";
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].Visible = true;
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = "";
            count_comboBox2.Items.Clear();
            count1 = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            name1 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            price1 = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            id1 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            for (int i = 1; i <= int.Parse(count1); i++)
            {
                count_comboBox2.Items.Add(i.ToString());
                count_comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCount = count_comboBox2.SelectedItem.ToString();
        }

        private void Find_button1_Click(object sender, EventArgs e)
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

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id1 = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            count1 = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            price1 = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            name1 = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            all_price = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            int id = int.Parse(id1);
            int count = int.Parse(count1);
            float price = float.Parse(price1);
            float all_price1 = float.Parse(all_price);
            for (int i = 0; i < preparat.get_count_preparation(); i++)
            {
                if (preparat.assorty[i].Id == id)
                {
                    preparat.assorty[i].Count += count;
                    da = new SqlDataAdapter("UPDATE preparations SET count =" + (preparat.assorty[i].Count) + " WHERE id = " + id + "; select * from preparations", cnn);
                    table = new DataTable();
                    da.Fill(table);
                    dataGridView1.DataSource = table;
                    //preparat.assorty[j].Count -= c;
                    break;
                    //sum -= (price * count);
                }
            }
            for (int i = 0; i < bas.get_count_basket(); i++)
            {
                if (bas.bas[i].Id == id)
                {
                    bas.bas.RemoveAt(i);
                    break;
                }
            }
            summa -= (price * count);
            textBox2.Text = "Общая сумма покупки: " + summa + "p";
            basket basket = new basket(id, name1, price, count, all_price1);
            //bas.remove(basket);
            //bas.bas.Remove(basket);
            da = new SqlDataAdapter("DELETE FROM Basket where Id=" + id + ";select * from basket", cnn);
            table = new DataTable();
            da.Fill(table);
            dataGridView2.DataSource = table;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (count_comboBox2.SelectedItem == null)
                textBox1.Text = "Не выбран ни один товар или его количество!";
            else
            {
                float s = float.Parse(price1);
                int c = int.Parse(selectedCount);
                int iden = int.Parse(id1);
                if (bas.get_count_basket() != 0 && bas.get_name_basket(name1.Trim()) == true)
                {
                    for (int i = 0; i < bas.get_count_basket(); i++)
                    {
                        /*if (bas.bas[i].Name == name && preparat.getcount(iden) - bas.bas[i].Count == 0)
                            dataGridView1.Rows[iden - 1].DefaultCellStyle.ForeColor = Color.Red;*/
                        if (bas.bas[i].Name == name1 && bas.bas[i].Count + c <= preparat.getcount(iden))
                        {
                            bas.bas[i].Count += c;
                            bas.bas[i].All_Price += c * s;
                            summa += (s * c);
                            da = new SqlDataAdapter("UPDATE Basket SET count =" + bas.bas[i].Count + " WHERE id = " + bas.bas[i].Id + "; select * from Basket", cnn);
                            table = new DataTable();
                            da.Fill(table);
                            dataGridView2.DataSource = table;
                            //dataGridView1.DataSource = table;
                            textBox1.Text = "Добавлено";
                        }
                        else if (bas.bas[i].Name.Trim() == name1.Trim() && bas.bas[i].Count + c > preparat.getcount(iden))
                        {
                            textBox1.Text = "Данный товар закончился или максимальное количество уже лежит в корзине!";
                            //dataGridView1.Rows[iden - 1].DefaultCellStyle.ForeColor = Color.Red;
                        }
                    }
                }
                else
                {
                    bas.add(iden, name1, s, c, (c * s));
                    //bask.init();
                    //data.add_basket(name, s, c);
                    summa += (s * c);
                    da = new SqlDataAdapter("INSERT INTO Basket (id, Name,Price,Count,All_Price)  VALUES (" + iden + ", N'" + name1 + "'," + s + "," + c + "," + (c * s) + "); select * from Basket", cnn);
                    table = new DataTable();
                    da.Fill(table);
                    dataGridView2.DataSource = table;
                    textBox1.Text = "Добавлено";
                    /*for (int i = 0; i < bas.get_count_basket(); i++)
                    {
                        if (preparat.getcount(iden) - bas.bas[i].Count == 0)
                            dataGridView1.Rows[iden - 1].DefaultCellStyle.ForeColor = Color.Red;
                    }*/
                }
                for (int j = 0; j < preparat.get_count_preparation(); j++)
                {
                    if (preparat.assorty[j].Id == iden)
                    {
                        da = new SqlDataAdapter("UPDATE preparations SET count =" + (preparat.assorty[j].Count - c) + " WHERE id = " + iden + "; select * from preparations", cnn);
                        table = new DataTable();
                        da.Fill(table);
                        dataGridView1.DataSource = table;
                        preparat.assorty[j].Count -= c;
                        if (preparat.assorty[j].Count == 0)
                            dataGridView1.Rows[j].DefaultCellStyle.ForeColor = Color.Red;
                        break;
                    }
                }
            }
            textBox2.Text = "Общая сумма покупки: " + summa + "p";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //sum = 0;
            //sum1 = 0;
            //order.clear();
            //DataSet ds = new DataSet();
            //da = new SqlDataAdapter("SELECT Order_number, Phone, Preparation, All_price, Status FROM Orders", cnn);
            //da.Fill(ds, "Orders");
            //DataRow row = ds.Tables[0].NewRow();
            //for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            //{
            //    row = ds.Tables[0].Rows[k];
            //    order.add(Convert.ToInt32(row[0]), Convert.ToInt32(row[1]), Convert.ToString(row[2]), Convert.ToInt32(row[3]), Convert.ToString(row[4]));

            //}
            /*for (int j = 0; j < order.get_count_list_in_orders(); j++)
            {
                sum1 += list.list[j].All_price;
                textBox4.Text = "Общая сумма покупки: " + sum1 + "p";
            }
            textBox2.Text = "Общая сумма покупки: " + sum + "p";*/
            //for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            //{
            if (textBox3.Text != "" && check.checkNumber(textBox3.Text))
            {
                if (order.get_count_list_in_orders() != 0 && order.get_number(textBox3.Text) == true)
                {
                    for (int q = 0; q < order.get_count_list_in_orders(); q++)
                    {
                        if (order.list[q].Phone == textBox3.Text && order.list[q].Status != "Завершен")
                        {
                            /*SqlDataAdapter d;
                            list.list[q].Count += bas.bas[i].Count;
                            list.list[q].All_price += bas.bas[i].Count * bas.bas[i].Price;
                            d = new SqlDataAdapter("UPDATE Analitic SET Count =" + list.list[q].Count + ",All_Price=" + list.list[q].All_price + "  WHERE Id = " + list.list[q].Id + "; select Id, Name, Price, Count, FORMAT(Date, 'dd/MM/yyyy', 'en-US') , All_price from Analitic;", cnn);
                            table = new DataTable();
                            d.Fill(table);
                            dataGridView4.DataSource = table;
                            textBox4.Text = "Общая сумма покупки: " + (sum1 + bas.bas[i].Count * bas.bas[i].Price) + "p";*/
                            MessageBox.Show("По данному номеру телефона уже есть не завершенный заказ!");
                            break;
                        }
                        else if (order.list[q].Phone == textBox3.Text && order.list[q].Status == "Завершен")
                        {
                            //DataSet ds = new DataSet();
                            //Создание объекта для генерации чисел
                            Random rnd = new Random();
                            //Получить очередное (в данном случае - первое) случайное число
                            int value = rnd.Next(10000, 32000);
                            string str = "";
                            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                            {
                                str += bas.bas[i].Name + "-" + bas.bas[i].Count + ",";

                            }
                            SqlDataAdapter daa;
                            daa = new SqlDataAdapter("INSERT INTO Orders (Order_number, Phone, Preparation, All_price, Status)  VALUES (" + value + "," + textBox3.Text + ",N'" + str + "'," + summa + ",N'Готов_к_выдаче'); select Order_number, Phone, Preparation, All_price, Status FROM Orders;", cnn); //Name=" + bas.bas[i].Name+", Price="+bas.bas[i].Price+", Count="+bas.bas[i].Count+ ", Date=CURDATE(), All_Price="+bas.bas[i].All_Price, cnn);
                            table = new DataTable();
                            daa.Fill(table);
                            //dataGridView2.DataSource = table;
                            order.add(value, textBox3.Text, str, summa, "Готов_к_выдаче");
                            MessageBox.Show("Заказ вас ожидает в аптеке");
                            //break
                            //textBox4.Text = "Общая сумма покупки: " + (sum1 + bas.bas[i].All_Price) + "p";
                            /*da.Fill(ds, "Analitic");
                            DataRow row = ds.Tables[0].NewRow();
                            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                            {
                                row = ds.Tables[0].Rows[k];
                                list.add(Convert.ToString(row[1]), Convert.ToDouble(row[2]), Convert.ToInt32(row[3]), Convert.ToString(row[4]), Convert.ToDouble(row[5]));

                            }*/
                        }
                    }
                }
                else
                {
                    Random rnd = new Random();
                    //Получить очередное (в данном случае - первое) случайное число
                    int value = rnd.Next(10000, 32000);
                    string str = "";
                    for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                    {
                        //bas.bas[i].Name=bas.bas[i].Name.Trim();
                        str += bas.bas[i].Name.Trim() + "-" + bas.bas[i].Count + ",";

                    }
                    SqlDataAdapter daa;
                    daa = new SqlDataAdapter("INSERT INTO Orders (Order_number, Phone, Preparation, All_price, Status)  VALUES (" + value + "," + textBox3.Text + ",N'" + str + "'," + summa + ",N'Готов_к_выдаче'); select Order_number, Phone, Preparation, All_price, Status FROM Orders;", cnn); //Name=" + bas.bas[i].Name+", Price="+bas.bas[i].Price+", Count="+bas.bas[i].Count+ ", Date=CURDATE(), All_Price="+bas.bas[i].All_Price, cnn);
                    table = new DataTable();
                    daa.Fill(table);
                    order.add(value, textBox3.Text, str, summa, "Готов к выдаче");
                    //dataGridView2.DataSource = table;
                    MessageBox.Show("Заказ вас ожидает в аптеке");
                    //break;
                }
                //}
                /*double sum1 = 0;
                for (int j = 0; j < list.get_count_list_in_analitic(); j++)
                {
                    sum1 += list.list[j].All_price;
                    textBox1.Text = "Общая сумма покупки: " + sum1 + "p";
                }*/
                da = new SqlDataAdapter("DELETE FROM Basket", cnn);
                table = new DataTable();
                da.Fill(table);
                dataGridView2.DataSource = table;
                //dataGridView2.Rows.Clear();
                bas.clear();
                //MessageBox.Show("Заказ вас ожидает в аптеке");
            }
            else
                textBox4.Text = "Error!";
        }

        private void TextBox3_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox3.Clear();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("DELETE FROM Basket", cnn);
            table = new DataTable();
            da.Fill(table);
            this.Close();
            menu.Show();
        }
    }
}
