using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Robot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label6.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
                {
                    e.Handled = true;
                    label6.Text = "Please Enter Number in the Textbox!";
                }
                else label6.Text = "";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
            {
                e.Handled = true;
                label6.Text = "Please Enter Number in the Textbox!";
            }
            else label6.Text = "";
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
            {
                e.Handled = true;
                label6.Text = "Please Enter Number in the Textbox!";
            }
            else label6.Text = "";
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
            {
                e.Handled = true;
                label6.Text = "Please Enter Number in the Textbox!";
            }
            else label6.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rows, columns;
            if (textBox1.Text != "")
                rows = Convert.ToInt32(textBox1.Text);
            else
                rows = 10;
            if (textBox2.Text != "")
                columns = Convert.ToInt32(textBox2.Text);
            else
                columns = 10;
            if (rows < 3)
                rows = 3;
            if (columns < 3)
                columns = 3;
            if (rows > 50)
                rows = 50;
            if (columns > 50)
                columns = 50;

            Form2 form = new Form2(rows, columns);
            form.Show();
            Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("First fill in the number of rows and columns of the map in this interface" +
                " and click the 'Initialize Interface'button, or fill in the Ip and Port to connect with servers" +
                " and use the data from the servers. If tapping in the number by yourself, then you should set a startpoint," +
                " a endpoint and several barriers in the map by clicking the corresponding button" +
                " and then clicking the grid in the map.You can use the 'Rubber' button to undo your action. " +
                "After clicking the 'Generate' button, a designed path will be showed. You can use the" +
                " 'Restart' button to clear the map at any time. The 'Quit' button can help you close this program.\n" +
                " p.s. if number of rows or columns is greater than 20, the effext of simulation will decrease," +
                " and the best number for simulation is 10.");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
