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
    public partial class Form1 : Form
    {
        public string selectedState;
        public string selectedCount;
        public string count1;
        public string name1;
        public string price1;
        public string id1;
        public string all_price;
        public string status;
        public string order_number="";
        preparations_list preparat = new preparations_list();
        Basket_list bas = new Basket_list();
        analitic_list list = new analitic_list();
        order_list order = new order_list();
        check check = new check();
        public float sum = 0; //общая стоимость для корзины
        public double sum1; //общая стоимость для аналитики
        public int count = 0; 
        SqlConnection cnn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Polina\Desktop\курсач_ооп\application_for_pharmacy\курсовая_ООП\preparations.mdf; Integrated Security = True");
        SqlDataAdapter da = null;
        DataTable table = null;
        form_menu menu;
        public Form1(form_menu m)
        {
            InitializeComponent();
            menu = m;
            search_criteria_comboBox1.Items.AddRange(new string[] { "Name", "Indication", "Price" });
            search_criteria_comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedState = search_criteria_comboBox1.SelectedItem.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //cnn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Polina\Desktop\курсач ооп\курсовая_ООП\курсовая_ООП\preparations.mdf; Integrated Security = True");
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
                if (preparat.assorty[i].Count == 0)
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;

            }
            ds = new DataSet();
            da = new SqlDataAdapter("select Id, Name, Price, Count, FORMAT(Date, 'dd/MM/yyyy', 'en-US') as Data, All_price FROM Analitic", cnn);
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
            count = 0;
            for (int j = 0; j < list.get_count_list_in_analitic(); j++)
            {
                sum1 += list.list[j].All_price;
                count += list.list[j].Count;
                textBox4.Text = "Общая сумма покупки: " + sum1 + "p";
                textBox4.Text += "\nКоличество купленных лекарств: " + count;
            }
            dataGridView4.DataSource = table;
            da = new SqlDataAdapter("select * from Basket", cnn);
            ds = new DataSet();
            table = new DataTable();
            da.Fill(ds, "Basket");
            da.Fill(table);
            row = ds.Tables[0].NewRow();
            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {
                row = ds.Tables[0].Rows[k];
                bas.add(Convert.ToInt32(row[0]), Convert.ToString(row[1]), Convert.ToInt32(row[2]), Convert.ToInt32(row[3]), Convert.ToInt32(row[4]));

            }
            dataGridView2.DataSource = table;
            ds = new DataSet();
            da = new SqlDataAdapter("SELECT Order_number, Phone, Preparation, All_price, Status FROM Orders", cnn);
            table = new DataTable();
            da.Fill(table);
            da.Fill(ds, "Orders");
            row = ds.Tables[0].NewRow();
            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {
                row = ds.Tables[0].Rows[k];
                order.add(Convert.ToInt32(row[0]), Convert.ToString(row[1]), Convert.ToString(row[2]), Convert.ToInt32(row[3]), Convert.ToString(row[4]));

            }
            dataGridView3.DataSource = table;
        }

        private void Find_Click(object sender, EventArgs e)
        {
            find.Text = "";
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                dataGridView1.Rows[i].Visible = true;
            }
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

        private void DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id1= dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            count1 = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            price1= dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            name1 = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            all_price = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
        //кнопка "удалить выбранный товавр"
        private void Button6_Click(object sender, EventArgs e)
        {
            int id=int.Parse(id1);
            int count = int.Parse(count1);
            float price = float.Parse(price1);
            float all_price1 = float.Parse(all_price);
            for (int i=0;i<preparat.get_count_preparation();i++)
            {
                if(preparat.assorty[i].Id==id)
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
            sum -= (price * count);
            textBox2.Text = "Общая сумма покупки: " + sum + "p";
            basket basket = new basket(id, name1,price, count, all_price1);
            //bas.remove(basket);
            //bas.bas.Remove(basket);
            da = new SqlDataAdapter("DELETE FROM Basket where Id="+id+";select * from basket", cnn);
            table = new DataTable();
            da.Fill(table);
            dataGridView2.DataSource = table;
        }
       
        //кнопка "Добавить в корзину"
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
                        if (bas.bas[i].Name.Trim() == name1.Trim() && bas.bas[i].Count + c <= preparat.getcount(iden))
                        {
                            bas.bas[i].Count += c;
                            bas.bas[i].All_Price += c * s;
                            sum += (s * c);
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
                    sum += (s * c);
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
            textBox2.Text = "Общая сумма покупки: " + sum + "p";
        }
        private string now_date()
        {
            string date = "";
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            if (day < 10)
            {
                date += "0" + day;
            }
            else
            {
                date += day;
            }
            date += "/";
            if (month < 10)
            {
                date += "0" + month;
            }
            else
            {
                date += month;
            }
            date += "/";
            date += year;
            return date;
        }

        //кнопка "купить"
        private void Button4_Click(object sender, EventArgs e)
        {
            //analitic_list list = new analitic_list();
            //int p = dataGridView2.Columns.Count;
            //dataGridView1.Rows.Clear();
            if (bas.get_count_basket()==0)
            {
                MessageBox.Show("Не выбран ни один товар");
                return;
            }
            sum = 0;
            sum1 = 0;
            count = 0;
            list.clear();
            DataSet ds = new DataSet();
            da = new SqlDataAdapter("select Id, Name, Price, Count, FORMAT(Date, 'dd/MM/yyyy', 'en-US') as Data, All_price FROM Analitic", cnn);
            da.Fill(ds, "Analitic");
            DataRow row = ds.Tables[0].NewRow();
            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {
                row = ds.Tables[0].Rows[k];
                list.add(Convert.ToInt32(row[0]), Convert.ToString(row[1]), Convert.ToDouble(row[2]), Convert.ToInt32(row[3]), Convert.ToString(row[4]), Convert.ToDouble(row[5]));

            }
            for (int j = 0; j < list.get_count_list_in_analitic(); j++)
            {
                sum1 += list.list[j].All_price;
                textBox4.Text = "Общая сумма покупки: " + sum1 + "p";
                textBox4.Text += "\nКоличество купленных лекарств: " + count;
            }
            textBox2.Text = "Общая сумма покупки: " + sum + "p";
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                if (list.get_count_list_in_analitic() != 0 && list.get_name_analitic(bas.bas[i].Name) == true)
                {
                    for (int q = 0; q < list.get_count_list_in_analitic(); q++)
                    {
                        if (list.list[q].Name.Trim() == bas.bas[i].Name.Trim() && list.list[q].Date == now_date())
                        {
                            SqlDataAdapter d;
                            list.list[q].Count += bas.bas[i].Count;
                            list.list[q].All_price += bas.bas[i].Count * bas.bas[i].Price;
                            d = new SqlDataAdapter("UPDATE Analitic SET Count =" + list.list[q].Count + ",All_Price=" + list.list[q].All_price + "  WHERE Id = " + list.list[q].Id + "; select Id, Name, Price, Count, FORMAT(Date, 'dd/MM/yyyy', 'en-US') as Data, All_price from Analitic;", cnn);
                            table = new DataTable();
                            d.Fill(table);
                            dataGridView4.DataSource = table;
                            textBox4.Text = "Общая сумма покупки: " + (sum1 + bas.bas[i].Count * bas.bas[i].Price) + "p";
                            textBox4.Text += "\nКоличество купленных лекарств: " + (count+bas.bas[i].Count);
                            break;
                        }
                        else if (list.list[q].Name.Trim() == bas.bas[i].Name.Trim() && !list.get_now_date_in_list(bas.bas[i].Name, now_date()))
                        {
                            //DataSet ds = new DataSet();
                            SqlDataAdapter daa;
                            daa = new SqlDataAdapter("INSERT INTO Analitic (Name,Price,Count,All_Price)  VALUES (N'" + bas.bas[i].Name + "'," + bas.bas[i].Price + "," + bas.bas[i].Count + "," + bas.bas[i].All_Price + "); select Id, Name, Price, Count, FORMAT(Date, 'dd/MM/yyyy', 'en-US') as Data , All_price from Analitic;", cnn); //Name=" + bas.bas[i].Name+", Price="+bas.bas[i].Price+", Count="+bas.bas[i].Count+ ", Date=CURDATE(), All_Price="+bas.bas[i].All_Price, cnn);
                            table = new DataTable();
                            daa.Fill(table);
                            dataGridView4.DataSource = table;
                            textBox4.Text = "Общая сумма покупки: " + (sum1 + bas.bas[i].All_Price) + "p";
                            textBox4.Text += "\nКоличество купленных лекарств: " + (count+bas.bas[i].Count);
                            break;
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
                    //DataSet ds = new DataSet();
                    SqlDataAdapter daa;
                    daa = new SqlDataAdapter("INSERT INTO Analitic (Name,Price,Count,All_Price)  VALUES (N'" + bas.bas[i].Name + "'," + bas.bas[i].Price + "," + bas.bas[i].Count + "," + bas.bas[i].All_Price + "); select Id, Name, Price, Count, FORMAT(Date, 'dd/MM/yyyy', 'en-US') as Data, All_price from Analitic;", cnn); //Name=" + bas.bas[i].Name+", Price="+bas.bas[i].Price+", Count="+bas.bas[i].Count+ ", Date=CURDATE(), All_Price="+bas.bas[i].All_Price, cnn);
                    table = new DataTable();
                    daa.Fill(table);
                    dataGridView4.DataSource = table;
                    textBox4.Text = "Общая сумма покупки: " +( sum1+ bas.bas[i].All_Price )+ "p";
                    textBox4.Text += "\nКоличество купленных лекарств: " + (count+bas.bas[i].Count);
                    /*da.Fill(ds, "Analitic");
                    DataRow row = ds.Tables[0].NewRow();
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        row = ds.Tables[0].Rows[k];
                        list.add(Convert.ToString(row[1]), Convert.ToDouble(row[2]), Convert.ToInt32(row[3]), Convert.ToString(row[4]), Convert.ToDouble(row[5]));

                    }*/
                    //break;
                }
            }
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
            MessageBox.Show("Покупка совершена успешно!");
        }

        //добавление лекарства
        private void Button1_Click(object sender, EventArgs e)
        {
            //check check = new check();
            if (check.checkdigit(textBox11.Text) && textBox11.ReadOnly == false && check.StringCheck(textBox5.Text))
            {
                if (preparat.getname(textBox5.Text)) //если в таблице есть такой препарат
                {
                    textBox6.Text = "Такой препарат есть в базе! Введите только количество";
                    for (int i = 0; i < preparat.get_count_preparation(); i++)
                    {
                        if (preparat.assorty[i].Name.Contains(textBox5.Text))
                        {
                            da = new SqlDataAdapter("UPDATE preparations SET count =" + (preparat.assorty[i].Count + int.Parse(textBox11.Text)) + " WHERE id = " + preparat.assorty[i].Id + "; select * from preparations", cnn);
                            table = new DataTable();
                            da.Fill(table);
                            dataGridView1.DataSource = table;
                            preparat.assorty[i].Count += int.Parse(textBox11.Text);
                            textBox13.Text = "Добавлено!";
                        }
                    }
                }
                else if (check.checkdigit(textBox9.Text) && check.StringCheck(textBox7.Text))
                {
                    da = new SqlDataAdapter("insert into preparations (Name,Indication,Price, Count) Values (N'" + textBox5.Text + "', N'" + textBox7.Text + "'," + textBox9.Text + "," + textBox11.Text + "); select * from preparations", cnn);
                    table = new DataTable();
                    da.Fill(table);
                    dataGridView1.DataSource = table;
                    preparat.add(preparat.get_count_preparation(), textBox5.Text, textBox7.Text, float.Parse(textBox9.Text), int.Parse(textBox11.Text));
                    textBox13.Text = "Добавлено!";
                    //break;
                }
                else
                {
                    textBox13.Text = "Error!"; //textBox12.Text = "Error!";
                }
            }
            else
            {
                textBox13.Text = "Error!"; //textBox12.Text = "Error!";
            }
            
        }
        private void TextBox5_Click(object sender, EventArgs e)
        {
            textBox5.Clear(); textBox7.Clear(); textBox9.Clear(); textBox11.Clear();
            textBox6.Clear(); textBox8.Clear(); textBox10.Clear();textBox12.Clear();
            textBox13.Clear();
            textBox7.ReadOnly = false; textBox9.ReadOnly = false; textBox11.ReadOnly = false;
        }

        private void TextBox7_Click(object sender, EventArgs e)
        {
            //textBox7.ReadOnly = false; textBox9.ReadOnly = false;
            check check = new check();
            if (check.StringCheck(textBox5.Text))
            {
                if (preparat.getname(textBox5.Text)) //если в таблице есть такой препарат
                {
                    textBox7.ReadOnly = true; textBox9.ReadOnly = true;
                    textBox6.Text = "Такой препарат есть в базе! Введите только количество";
                }
            }
            else
            {
                textBox6.Text = "Error!";
                textBox11.ReadOnly = true; textBox9.ReadOnly = true; textBox7.ReadOnly = true;
            }
        }
        private void TextBox9_Click(object sender, EventArgs e)
        {
            //textBox11.ReadOnly = false;
            check check = new check();
            if (!check.StringCheck(textBox7.Text) && textBox7.ReadOnly == false)
            {
                textBox11.ReadOnly = true;
                textBox8.Text = "Error!";
            }
        }

        private void TextBox11_TextChanged(object sender, EventArgs e)
        {
            check check = new check();
            if (!check.checkdigit(textBox9.Text) && textBox9.ReadOnly==false)
            {
                textBox10.Text = "Error!";
            }
        }
        //кнопка выход в меню авторизации
        private void Button2_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("DELETE FROM Basket", cnn);
            table = new DataTable();
            da.Fill(table);
            this.Close();
            menu.Show();
        }

        private void DataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //id1 = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            //count1 = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
            //price1 = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
            name1 = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
            all_price = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
            status = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
            order_number = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private int count_preparat_in_order(string name)
        {
            int count = 0;
            for(int i=0;i<name.Length;i++)
            {
                if (name[i] == ',')
                    count++;
            }
            return count;
        }

        //кнопка добавить ЗАКАЗ в корзину 
        private void Button3_Click(object sender, EventArgs e)
        {
            int flag = 0;
            if (order.get_count_list_in_orders() == 0)
            { MessageBox.Show("Заказов нет!"); return; }
            else if (bas.get_count_basket() != 0)
            { MessageBox.Show("Корзина не пуста, очистите ее, прежде чем добавлять туда заказ!"); return; }
            else if (order_number == "")
            {
                MessageBox.Show("Заказ не выбран!"); return;
            }
            for (int i = 0; i < order.get_count_list_in_orders(); i++)
            {
                if (order.list[i].Number_order == int.Parse(order_number) && order.list[i].Status.Trim() == "Завершен")
                { flag = 1; break; }
            }
            //flag = 0;
            if (flag==1)
            {
                MessageBox.Show("Этот заказ уже оплачен!");
                return;
            }
            else
            {
                int count_preparat = count_preparat_in_order(name1);
                string str = "";
                for (int i = 0; i < count_preparat; i++)
                {
                    int x = 0;
                    while (name1[x] != ',')
                    {
                        //x++;
                        str += name1[x];
                        x++;
                    }
                    int count = str[str.Length - 1] - '0';
                    string name = str.Substring(0, str.Length - 2);
                    //name = name.Trim();
                    /*for(int j=0;name.Length<30;j++)
                    {
                        name = name.Insert(name.Length, " ");
                    }
                    /*da = new SqlDataAdapter("(select Price from preparations where Name='" + name + "')", cnn);
                    DataSet ds = new DataSet();
                    //DataRow row = new DataRow;
                    da.Fill(ds, "preparations");
                    DataRow row = ds.Tables[0].NewRow();
                    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                    {
                        row = ds.Tables[0].Rows[k];
                        string stroka = Convert.ToString( row[0]);
                        //order.add(Convert.ToInt32(row[0]), Convert.ToString(row[1]), Convert.ToString(row[2]), Convert.ToInt32(row[3]), Convert.ToString(row[4]));

                    }*/
                    int id = 1;
                    float price = 0;
                    for (int j = 0; j < preparat.get_count_preparation(); j++)
                    {
                        if (preparat.assorty[j].Name.Contains(name))
                        {
                            id = preparat.assorty[j].Id;
                            price = preparat.assorty[j].Price;
                            break;
                        }

                    }
                    //da.Fill(table);
                    da = new SqlDataAdapter(//"select Id, Price from preparations where Name="+name+ ";" +
                        "INSERT INTO Basket (Id, Name,Price,Count,All_Price)  " +
                        "VALUES (" + id + ",N'" + name + "'," + price + "," + count + "," + (price * count) + "); select * from Basket", cnn);

                    bas.add(id, name, price, count, (count * price));
                    //bask.init();
                    //data.add_basket(name, s, c);
                    //sum += (s * c);
                    //da = new SqlDataAdapter("INSERT INTO Basket (id, Name,Price,Count,All_Price)  VALUES (" + iden + ", N'" + name1 + "'," + s + "," + c + "," + (c * s) + "); select * from Basket", cnn);
                    table = new DataTable();
                    da.Fill(table);
                    dataGridView2.DataSource = table;
                    //textBox1.Text = "Добавлено";
                    /*for (int i = 0; i < bas.get_count_basket(); i++)
                    {
                        if (preparat.getcount(iden) - bas.bas[i].Count == 0)
                            dataGridView1.Rows[iden - 1].DefaultCellStyle.ForeColor = Color.Red;
                    }*/
                    name1 = name1.Substring(str.Length + 1);
                    str = "";
                }
                textBox2.Text = "Общая сумма покупки: " + all_price + "p";
                da = new SqlDataAdapter("update Orders set Status=N'Завершен' where Order_number=" + order_number + "; select Order_number, Phone, Preparation, All_price, Status FROM Orders", cnn);
                table = new DataTable();
                da.Fill(table);
                dataGridView3.DataSource = table;
                order_number = "";
            }
        }
    }
}
