using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace курсовая_ООП
{
    public partial class Form2 : Form
    {
        form_menu menu;
        public Form2(form_menu m)
        {
            menu = m;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "1234")
                MessageBox.Show("Неверный пароль!");
            else
            {
                Form1 form = new Form1(menu);
                this.Close();
                form.Show();
            }
        }
    }
}
