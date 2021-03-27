using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Robot
{
    public partial class Form2 : Form
    {
        public static int Rows, Columns, length, barrier, brushstate = 0, orientation;
        public List<int> grid;
        public Map map;
        public Brush brushred = Brushes.Red;
        public Brush brushgreen = Brushes.Green;
        public Brush brushblack = Brushes.Black;
        public Brush brushblue = Brushes.DeepSkyBlue;
        public Brush brushwhite = Brushes.White;
        public Brush brushgold = Brushes.Gold;
        public Pen pengold = new Pen(Color.Gold, 3);
        public Pen penblue = new Pen(Color.Blue, 3);

        public Form2(int rows, int columns)
        {
            InitializeComponent();
            this.BackColor = Color.White;
            //比例系数设定
            string columntext, rowtext;
            columntext = columns.ToString();
            rowtext = rows.ToString();
            label1.Text = " ";
            label2.Text = "Rows:";
            label3.Text = "Columns:";
            label2.Text = label2.Text + rowtext;
            label3.Text = label3.Text + columntext;
            label4.Text = "Barriers:"+barrier.ToString();
            label5.Text = "";
            label6.Text = "";
            label8.Text = "";
            //公共变量赋值
            Rows = rows;
            Columns = columns;
            //按钮颜色
            button1.BackColor = System.Drawing.Color.Gold;
            button2.BackColor = System.Drawing.Color.Gold;
            button3.BackColor = System.Drawing.Color.Gold;
            button4.BackColor = System.Drawing.Color.Gold;
            button5.BackColor = System.Drawing.Color.Gold;
            button6.BackColor = System.Drawing.Color.Gold;
            button7.BackColor = System.Drawing.Color.Gold;
            button8.BackColor = System.Drawing.Color.Gold;
            button9.BackColor = System.Drawing.Color.Gold;
            //计算每个小格子的边长
            if (Columns >= Rows)
                length = 400 / Columns;
            else
                length = 400 / Rows;
           map = new Map(Rows, Columns);  //新建一个Map类的实例
        }

        public Form2(int rows, int columns,List<int> mapstate)
        {
            button10.BackColor = System.Drawing.Color.Gold;
            Graphics g = this.CreateGraphics();
            InitializeComponent();
            this.BackColor = Color.White;
            //比例系数设定
            grid = mapstate;
            string columntext, rowtext;
            columntext = columns.ToString();
            rowtext = rows.ToString();
            label1.Text = " ";
            label2.Text = "Rows:";
            label3.Text = "Columns:";
            label2.Text = label2.Text + rowtext;
            label3.Text = label3.Text + columntext;
            label4.Text = "Barriers:" + barrier.ToString();
            label5.Text = "";
            label6.Text = "";
            label8.Text = "";
            //公共变量赋值
            Rows = rows;
            Columns = columns;
            //按钮颜色
            button1.BackColor = System.Drawing.Color.Gold;
            button2.BackColor = System.Drawing.Color.Gold;
            button3.BackColor = System.Drawing.Color.Gold;
            button4.BackColor = System.Drawing.Color.Gold;
            button5.BackColor = System.Drawing.Color.Gold;
            button6.BackColor = System.Drawing.Color.Gold;
            button7.BackColor = System.Drawing.Color.Gold;
            button8.BackColor = System.Drawing.Color.Gold;
            button9.BackColor = System.Drawing.Color.Gold;

            int k = 0;
            //计算每个小格子的边长
            if (Columns >= Rows)
                length = 400 / Columns;
            else
                length = 400 / Rows;
            map = new Map(Rows, Columns);  //新建一个Map类的实例
            for(int i=0;i<Rows;i++)
            {
                for(int j=0;j<Columns;j++)
                {
                    map.sign[i, j] = grid[k];
                    if (map.sign[i, j] == 1)
                        g.FillRectangle(brushblack, 52 + i * length, 52 + j * length, length - 3, length - 3);
                    if (map.sign[i, j] == 5)
                        g.FillRectangle(brushgreen, 52 + i * length, 52 + j * length, length - 3, length - 3);
                    if (map.sign[i, j] == 6)
                        g.FillRectangle(brushred, 52 + i * length, 52 + j * length, length - 3, length - 3);
                }
            }
        }




        private void button1_Click(object sender, EventArgs e)//画起点状态
        {
            button2.BackColor = System.Drawing.Color.Gold;
            button3.BackColor = System.Drawing.Color.Gold;
            button4.BackColor = System.Drawing.Color.Gold;
            button6.BackColor = System.Drawing.Color.Gold;
            button7.BackColor = System.Drawing.Color.Gold;
            button8.BackColor = System.Drawing.Color.Gold;
            button9.BackColor = System.Drawing.Color.Gold;
            button10.BackColor = System.Drawing.Color.Gold;
            button1.BackColor = System.Drawing.Color.DarkGray;
            brushstate = 1;//画笔状态为1，画起点
        }

        private void button2_Click(object sender, EventArgs e)//画终点状态
        {
            button1.BackColor = System.Drawing.Color.Gold;
            button3.BackColor = System.Drawing.Color.Gold;
            button4.BackColor = System.Drawing.Color.Gold;
            button6.BackColor = System.Drawing.Color.Gold;
            button7.BackColor = System.Drawing.Color.Gold;
            button8.BackColor = System.Drawing.Color.Gold;
            button9.BackColor = System.Drawing.Color.Gold;
            button10.BackColor = System.Drawing.Color.Gold;
            button2.BackColor = System.Drawing.Color.DarkGray;
            brushstate = 2;//画笔状态为2，画终点
        }

        private void button3_Click(object sender, EventArgs e)//障碍物状态
        {
            button1.BackColor = System.Drawing.Color.Gold;
            button2.BackColor = System.Drawing.Color.Gold;
            button4.BackColor = System.Drawing.Color.Gold;
            button6.BackColor = System.Drawing.Color.Gold;
            button7.BackColor = System.Drawing.Color.Gold;
            button8.BackColor = System.Drawing.Color.Gold;
            button9.BackColor = System.Drawing.Color.Gold;
            button10.BackColor = System.Drawing.Color.Gold;
            button3.BackColor = System.Drawing.Color.DarkGray;
            brushstate = 3;//画笔状态为3，画障碍物
        }

        private void button6_Click(object sender, EventArgs e)//橡皮擦状态
        {
            button1.BackColor = System.Drawing.Color.Gold;
            button2.BackColor = System.Drawing.Color.Gold;
            button3.BackColor = System.Drawing.Color.Gold;
            button4.BackColor = System.Drawing.Color.Gold;
            button7.BackColor = System.Drawing.Color.Gold;
            button8.BackColor = System.Drawing.Color.Gold;
            button9.BackColor = System.Drawing.Color.Gold;
            button10.BackColor = System.Drawing.Color.Gold;
            button6.BackColor = System.Drawing.Color.DarkGray;
            brushstate = 4;

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)//机器人动画模拟
        {
            Graphics g = this.CreateGraphics();
            button1.BackColor = System.Drawing.Color.Gold;
            button2.BackColor = System.Drawing.Color.Gold;
            button3.BackColor = System.Drawing.Color.Gold;
            button4.BackColor = System.Drawing.Color.Gold;
            button6.BackColor = System.Drawing.Color.Gold;
            button7.BackColor = System.Drawing.Color.Gold;
            button9.BackColor = System.Drawing.Color.Gold;
            button10.BackColor = System.Drawing.Color.Gold;
            button8.BackColor = System.Drawing.Color.DarkGray;
            button1.Update();
            button2.Update();
            button3.Update();
            button4.Update();
            button6.Update();
            button7.Update();
            button8.Update();
            button9.Update();
            button10.Update();

            int n = map.Path.Count;
            if (n != 0)
            {
                int o = map.Orientation.Count;
                g.FillRectangle(brushred, map.Path[0].X * length + 52, map.Path[0].Y * length + 52, length - 3, length - 3);
                g.DrawEllipse(pengold, map.Path[n - 1].X * length + 54, 54 + map.Path[n - 1].Y * length, length - 7, length - 7);
                if (map.Path[n - 1].X == map.Path[n - 2].X && (map.Path[n - 1].Y - map.Path[n - 2].Y) < 0)
                {
                    orientation = 10;
                }
                if (map.Path[n - 1].X == map.Path[n - 2].X && (map.Path[n - 1].Y - map.Path[n - 2].Y) > 0)
                {
                    orientation = 8;
                }
                if (map.Path[n - 1].Y == map.Path[n - 2].Y && (map.Path[n - 1].X - map.Path[n - 2].X) < 0)
                {
                    orientation = 9;
                }
                if (map.Path[n - 1].Y == map.Path[n - 2].Y && (map.Path[n - 1].X - map.Path[n - 2].X) > 0)
                {
                    orientation = 11;
                }
                map.Orientation.Add(orientation);
                switch (orientation % 4)
                {
                    case 0: label8.Text = "Orientation: North"; break;
                    case 1: label8.Text = "Orientation: East"; break;
                    case 2: label8.Text = "Orientation: South"; break;
                    case 3: label8.Text = "Orientation: West"; break;
                }

                switch (orientation % 4)
                {
                    case 0: g.FillEllipse(brushgold, map.Path[n - 1].X * length + 52 + length / 3, 52 + map.Path[n - 1].Y * length+length/8, length / 4, length / 4); break;
                    case 1: g.FillEllipse(brushgold, map.Path[n - 1].X * length + 48 + 2 * length / 3, 52 + map.Path[n - 1].Y * length + length / 3, length / 4, length / 4); break;
                    case 2: g.FillEllipse(brushgold, map.Path[n - 1].X * length + 52 + length / 3, 48 + map.Path[n - 1].Y * length + 2 * length / 3, length / 4, length / 4); break;
                    case 3: g.FillEllipse(brushgold, map.Path[n - 1].X * length + 52+length/8, 52 + map.Path[n - 1].Y * length + length / 3, length / 4, length / 4); break;
                }
                label8.Update();
                label5.Text = "Location:  ( " + (map.Path[n-1].X + 1).ToString() + " , " + (map.Path[n-1].Y + 1).ToString() + " )";
                label5.Update();
                label6.Text = "Movement: Advance";
                label6.Update();

                System.Threading.Thread.Sleep(800);


                for (int i = n - 2; i > 0; i--)
                {
                    if (i == n - 2) g.FillRectangle(brushgreen, map.Path[n - 1].X * length + 52, 52 + map.Path[n - 1].Y * length, length - 3, length - 3);
                    if (i != n - 2) g.FillRectangle(brushblue, map.Path[i + 1].X * length + 52, map.Path[i + 1].Y * length + 52, length - 3, length - 3);
                    g.DrawEllipse(pengold, map.Path[i].X * length + 54, 54 + map.Path[i].Y * length, length - 7, length - 7);
                    switch (orientation % 4)
                    {
                        case 0: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 3, 52 + map.Path[i].Y * length + length / 8, length / 4, length / 4); break;
                        case 1: g.FillEllipse(brushgold, map.Path[i].X * length + 48 + 2 * length / 3, 52 + map.Path[i].Y * length + length / 3, length / 4, length / 4); break;
                        case 2: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 3, 48 + map.Path[i].Y * length + 2 * length / 3, length / 4, length / 4); break;
                        case 3: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 8, 52 + map.Path[i].Y * length + length / 3, length / 4, length / 4); break;
                    }
                    label5.Text = "Location:  ( " + (map.Path[i].X + 1).ToString() + " , " + (map.Path[i].Y + 1).ToString() + " )";
                    label5.Update();

                    if (map.Path[i + 1].X == map.Path[i].X && map.Path[i].X == map.Path[i - 1].X)
                    {
                        label6.Text = "Movement: Advance";
                        label6.Update();
                    }

                    if (map.Path[i + 1].Y == map.Path[i].Y && map.Path[i].Y == map.Path[i - 1].Y)
                    {
                        label6.Text = "Movement: Advance";
                        label6.Update();
                    }

                    if ((map.Path[i].Y - map.Path[i + 1].Y) > 0)
                    {
                        if ((map.Path[i - 1].X - map.Path[i].X) < 0)
                        {
                            label6.Text = "Movement: Turn Right\n and Advance";
                            label6.Update();
                            orientation++;
                            System.Threading.Thread.Sleep(800);
                            g.FillRectangle(brushblue, map.Path[i].X * length + 52, map.Path[i].Y * length + 52, length - 3, length - 3);
                            g.DrawEllipse(pengold, map.Path[i].X * length + 54, 54 + map.Path[i].Y * length, length - 7, length - 7);
                            switch (orientation % 4)
                            {
                                case 0: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 3, 52 + map.Path[i].Y * length + length / 8, length / 4, length / 4); break;
                                case 1: g.FillEllipse(brushgold, map.Path[i].X * length + 48 + 2 * length / 3, 52 + map.Path[i].Y * length + length / 3, length / 4, length / 4); break;
                                case 2: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 3, 48 + map.Path[i].Y * length + 2 * length / 3, length / 4, length / 4); break;
                                case 3: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 8, 52 + map.Path[i].Y * length + length / 3, length / 4, length / 4); break;
                            }
                        }
                        if ((map.Path[i - 1].X - map.Path[i].X) > 0)
                        {
                            label6.Text = "Movement: Turn Left\n and Advance";
                            label6.Update();
                            orientation--;
                            System.Threading.Thread.Sleep(800);
                            g.FillRectangle(brushblue, map.Path[i].X * length + 52, map.Path[i].Y * length + 52, length - 3, length - 3);
                            g.DrawEllipse(pengold, map.Path[i].X * length + 54, 54 + map.Path[i].Y * length, length - 7, length - 7);
                            switch (orientation % 4)
                            {
                                case 0: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 3, 52 + map.Path[i].Y * length + length / 8, length / 4, length / 4); break;
                                case 1: g.FillEllipse(brushgold, map.Path[i].X * length + 48 + 2 * length / 3, 52 + map.Path[i].Y * length + length / 3, length / 4, length / 4); break;
                                case 2: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 3, 48 + map.Path[i].Y * length + 2 * length / 3, length / 4, length / 4); break;
                                case 3: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 8, 52 + map.Path[i].Y * length + length / 3, length / 4, length / 4); break;
                            }
                        }
                    }

                    if ((map.Path[i].Y - map.Path[i + 1].Y) < 0)
                    {
                        if ((map.Path[i - 1].X - map.Path[i].X) > 0)
                        {
                            label6.Text = "Movement: Turn Right\n and Advance";
                            label6.Update();
                            orientation++;
                            System.Threading.Thread.Sleep(800);
                            g.FillRectangle(brushblue, map.Path[i].X * length + 52, map.Path[i].Y * length + 52, length - 3, length - 3);
                            g.DrawEllipse(pengold, map.Path[i].X * length + 54, 54 + map.Path[i].Y * length, length - 7, length - 7);
                            switch (orientation % 4)
                            {
                                case 0: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 3, 52 + map.Path[i].Y * length + length / 8, length / 4, length / 4); break;
                                case 1: g.FillEllipse(brushgold, map.Path[i].X * length + 48 + 2 * length / 3, 52 + map.Path[i].Y * length + length / 3, length / 4, length / 4); break;
                                case 2: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 3, 48 + map.Path[i].Y * length + 2 * length / 3, length / 4, length / 4); break;
                                case 3: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 8, 52 + map.Path[i].Y * length + length / 3, length / 4, length / 4); break;
                            }
                        }
                        if ((map.Path[i - 1].X - map.Path[i].X) < 0)
                        {
                            label6.Text = "Movement: Turn Left\n and Advance";
                            label6.Update();
                            orientation--;
                            System.Threading.Thread.Sleep(800);
                            g.FillRectangle(brushblue, map.Path[i].X * length + 52, map.Path[i].Y * length + 52, length - 3, length - 3);
                            g.DrawEllipse(pengold, map.Path[i].X * length + 54, 54 + map.Path[i].Y * length, length - 7, length - 7);
                            switch (orientation % 4)
                            {
                                case 0: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 3, 52 + map.Path[i].Y * length + length / 8, length / 4, length / 4); break;
                                case 1: g.FillEllipse(brushgold, map.Path[i].X * length + 48 + 2 * length / 3, 52 + map.Path[i].Y * length + length / 3, length / 4, length / 4); break;
                                case 2: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 3, 48 + map.Path[i].Y * length + 2 * length / 3, length / 4, length / 4); break;
                                case 3: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 8, 52 + map.Path[i].Y * length + length / 3, length / 4, length / 4); break;
                            }
                        }
                    }

                    if ((map.Path[i].X - map.Path[i + 1].X) > 0)
                    {
                        if ((map.Path[i - 1].Y - map.Path[i].Y) > 0)
                        {
                            label6.Text = "Movement: Turn Right\n and Advance";
                            label6.Update();
                            orientation++;
                            System.Threading.Thread.Sleep(800);
                            g.FillRectangle(brushblue, map.Path[i].X * length + 52, map.Path[i].Y * length + 52, length - 3, length - 3);
                            g.DrawEllipse(pengold, map.Path[i].X * length + 54, 54 + map.Path[i].Y * length, length - 7, length - 7);
                            switch (orientation % 4)
                            {
                                case 0: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 3, 52 + map.Path[i].Y * length + length / 8, length / 4, length / 4); break;
                                case 1: g.FillEllipse(brushgold, map.Path[i].X * length + 48 + 2 * length / 3, 52 + map.Path[i].Y * length + length / 3, length / 4, length / 4); break;
                                case 2: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 3, 48 + map.Path[i].Y * length + 2 * length / 3, length / 4, length / 4); break;
                                case 3: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 8, 52 + map.Path[i].Y * length + length / 3, length / 4, length / 4); break;
                            }
                        }
                        if ((map.Path[i - 1].Y - map.Path[i].Y) < 0)
                        {
                            label6.Text = "Movement: Turn Left\n and Advance";
                            label6.Update();
                            orientation--;
                            System.Threading.Thread.Sleep(800);
                            g.FillRectangle(brushblue, map.Path[i].X * length + 52, map.Path[i].Y * length + 52, length - 3, length - 3);
                            g.DrawEllipse(pengold, map.Path[i].X * length + 54, 54 + map.Path[i].Y * length, length - 7, length - 7);
                            switch (orientation % 4)
                            {
                                case 0: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 3, 52 + map.Path[i].Y * length + length / 8, length / 4, length / 4); break;
                                case 1: g.FillEllipse(brushgold, map.Path[i].X * length + 48 + 2 * length / 3, 52 + map.Path[i].Y * length + length / 3, length / 4, length / 4); break;
                                case 2: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 3, 48 + map.Path[i].Y * length + 2 * length / 3, length / 4, length / 4); break;
                                case 3: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 8, 52 + map.Path[i].Y * length + length / 3, length / 4, length / 4); break;
                            }
                        }
                    }

                    if ((map.Path[i].X - map.Path[i + 1].X) < 0)
                    {
                        if ((map.Path[i - 1].Y - map.Path[i].Y) < 0)
                        {
                            label6.Text = "Movement: Turn Right\n and Advance";
                            label6.Update();
                            orientation++;
                            System.Threading.Thread.Sleep(800);
                            g.FillRectangle(brushblue, map.Path[i].X * length + 52, map.Path[i].Y * length + 52, length - 3, length - 3);
                            g.DrawEllipse(pengold, map.Path[i].X * length + 54, 54 + map.Path[i].Y * length, length - 7, length - 7);
                            switch (orientation % 4)
                            {
                                case 0: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 3, 52 + map.Path[i].Y * length + length / 8, length / 4, length / 4); break;
                                case 1: g.FillEllipse(brushgold, map.Path[i].X * length + 48 + 2 * length / 3, 52 + map.Path[i].Y * length + length / 3, length / 4, length / 4); break;
                                case 2: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 3, 48 + map.Path[i].Y * length + 2 * length / 3, length / 4, length / 4); break;
                                case 3: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 8, 52 + map.Path[i].Y * length + length / 3, length / 4, length / 4); break;
                            }
                        }
                        if ((map.Path[i - 1].Y - map.Path[i].Y) > 0)
                        {
                            label6.Text = "Movement: Turn Left\n and Advance";
                            label6.Update();
                            orientation--;
                            System.Threading.Thread.Sleep(800);
                            g.FillRectangle(brushblue, map.Path[i].X * length + 52, map.Path[i].Y * length + 52, length - 3, length - 3);
                            g.DrawEllipse(pengold, map.Path[i].X * length + 54, 54 + map.Path[i].Y * length, length - 7, length - 7);
                            switch (orientation % 4)
                            {
                                case 0: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 3, 52 + map.Path[i].Y * length + length / 8, length / 4, length / 4); break;
                                case 1: g.FillEllipse(brushgold, map.Path[i].X * length + 48 + 2 * length / 3, 52 + map.Path[i].Y * length + length / 3, length / 4, length / 4); break;
                                case 2: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 3, 48 + map.Path[i].Y * length + 2 * length / 3, length / 4, length / 4); break;
                                case 3: g.FillEllipse(brushgold, map.Path[i].X * length + 52 + length / 8, 52 + map.Path[i].Y * length + length / 3, length / 4, length / 4); break;
                            }
                        }
                    }
                    map.Orientation.Add(orientation);
                    switch (orientation % 4)
                    {
                        case 0: label8.Text = "Orientation: North"; break;
                        case 1: label8.Text = "Orientation: East"; break;
                        case 2: label8.Text = "Orientation: South"; break;
                        case 3: label8.Text = "Orientation: West"; break;
                    }
                    label8.Update();

                    System.Threading.Thread.Sleep(800);
                    //MessageBox.Show(i.ToString());
                    label6.Text = "";
                    label6.Update();
                }
                g.FillRectangle(brushblue, map.Path[1].X * length + 52, map.Path[1].Y * length + 52, length - 3, length - 3);
                g.DrawEllipse(pengold, map.Path[0].X * length + 54, 54 + map.Path[0].Y * length, length - 7, length - 7);
                switch (orientation % 4)
                {
                    case 0: g.FillEllipse(brushgold, map.Path[0].X * length + 52 + length / 3, 52 + map.Path[0].Y * length + length / 8, length / 4, length / 4); break;
                    case 1: g.FillEllipse(brushgold, map.Path[0].X * length + 48 + 2 * length / 3, 52 + map.Path[0].Y * length + length / 3, length / 4, length / 4); break;
                    case 2: g.FillEllipse(brushgold, map.Path[0].X * length + 52 + length / 3, 48 + map.Path[0].Y * length + 2 * length / 3, length / 4, length / 4); break;
                    case 3: g.FillEllipse(brushgold, map.Path[0].X * length + 52 + length / 8, 52 + map.Path[0].Y * length + length / 3, length / 4, length / 4); break;
                }
                label5.Text = "Location:  ( " + (map.Path[0].X + 1).ToString() + " , " + (map.Path[0].Y + 1).ToString() + " )";
            }
            else
            {
                MessageBox.Show("Please Generate the Path First!");
            }
        }

        private void button9_Click(object sender, EventArgs e)//返回上一界面
        {
            Form1 form = new Form1();
            form.Show();
            Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button1.BackColor = System.Drawing.Color.Gold;
            button2.BackColor = System.Drawing.Color.Gold;
            button3.BackColor = System.Drawing.Color.Gold;
            button4.BackColor = System.Drawing.Color.Gold;
            button6.BackColor = System.Drawing.Color.Gold;
            button7.BackColor = System.Drawing.Color.Gold;
            button8.BackColor = System.Drawing.Color.Gold;
            button9.BackColor = System.Drawing.Color.Gold;
            button10.BackColor = System.Drawing.Color.DarkGray;
        }

        private void button7_Click(object sender, EventArgs e)//清屏
        {
            Graphics g = this.CreateGraphics();
            button1.BackColor = System.Drawing.Color.Gold;
            button2.BackColor = System.Drawing.Color.Gold;
            button3.BackColor = System.Drawing.Color.Gold;
            button4.BackColor = System.Drawing.Color.Gold;
            button6.BackColor = System.Drawing.Color.Gold;
            button8.BackColor = System.Drawing.Color.Gold;
            button9.BackColor = System.Drawing.Color.Gold;
            button10.BackColor = System.Drawing.Color.Gold;
            button7.BackColor = System.Drawing.Color.DarkGray;

            map.startvalue = 0;
            map.endvalue = 0;
            map.openlist = new List<Point>();
            map.closelist = new List<Point>();
            map.Path = new List<Point>();
            map.Movement = new List<string>();
            map.Movement.Add("Advance");
            map.Orientation = new List<int>();
            barrier = 0;
            label5.Text = "";
            label4.Text = "Barriers: "+barrier.ToString();
            label8.Text = "";

            int i, j;
            for(i=0;i<Rows;i++)
            {
                for(j=0;j<Columns;j++)
                {
                    map.sign[i, j] = 0;
                    g.FillRectangle(brushwhite, i * length + 52, j * length + 52, length - 3, length - 3);
                }
            }

        }

        private void button4_Click(object sender, EventArgs d)//路径规划
        {
            Graphics g = this.CreateGraphics();
            button1.BackColor = System.Drawing.Color.Gold;
            button2.BackColor = System.Drawing.Color.Gold;
            button3.BackColor = System.Drawing.Color.Gold;
            button6.BackColor = System.Drawing.Color.Gold;
            button7.BackColor = System.Drawing.Color.Gold;
            button8.BackColor = System.Drawing.Color.Gold;
            button9.BackColor = System.Drawing.Color.Gold;
            button10.BackColor = System.Drawing.Color.Gold;
            button4.BackColor = System.Drawing.Color.DarkGray;
            button1.Update();
            button2.Update();
            button3.Update();
            button4.Update();
            button6.Update();
            button7.Update();
            button8.Update();
            button9.Update();

            if (map.startvalue == 1 && map.endvalue == 1)
            {
                map.FindPath();
                if (map.Path.Exists(map.end))
                {
                    int n = map.Path.Count;
                    if(map.Path[n-1].X==map.Path[n-2].X&&(map.Path[n-1].Y-map.Path[n-2].Y) < 0)
                    {
                        orientation = 2;
                    }
                    if (map.Path[n - 1].X == map.Path[n - 2].X && (map.Path[n - 1].Y - map.Path[n - 2].Y) > 0)
                    {
                        orientation = 0;
                    }
                    if (map.Path[n - 1].Y == map.Path[n - 2].Y && (map.Path[n - 1].X - map.Path[n - 2].X) < 0)
                    {
                        orientation = 1;
                    }
                    if (map.Path[n - 1].Y == map.Path[n - 2].Y && (map.Path[n - 1].X - map.Path[n - 2].X) > 0)
                    {
                        orientation = 3;
                    }
                    map.Orientation.Add(orientation);
                    switch(orientation%4)
                    {
                        case 0:label8.Text = "Orientation: North";break;
                        case 1: label8.Text = "Orientation: East"; break;
                        case 2: label8.Text = "Orientation: South"; break;
                        case 3: label8.Text = "Orientation: West"; break;
                    }
                    label8.Update();


                    for (int i = n - 2; i > 0; i--)
                    {
                        if(i!=n-2) g.FillRectangle(brushblue, map.Path[i+1].X * length + 52, map.Path[i+1].Y * length + 52, length - 3, length - 3);
                        g.FillRectangle(brushgold, map.Path[i].X * length + 52, map.Path[i].Y * length + 52, length - 3, length - 3);
                        label5.Text = "Location:  ( " + (map.Path[i].X + 1).ToString() + " , " + (map.Path[i].Y + 1).ToString() + " )";
                        label5.Update();

                        if (map.Path[i + 1].X == map.Path[i].X && map.Path[i].X == map.Path[i - 1].X)
                        {
                            label6.Text = "Movement: Advance";
                            label6.Update();
                            map.Movement.Add("Advance");
                        }

                        if (map.Path[i + 1].Y == map.Path[i].Y && map.Path[i].Y == map.Path[i - 1].Y)
                        {
                            label6.Text = "Movement: Advance";
                            label6.Update();
                            map.Movement.Add("Advance");
                        }

                        if ((map.Path[i].Y - map.Path[i + 1].Y) > 0)
                        {
                            if ((map.Path[i - 1].X - map.Path[i].X) < 0)
                            {
                                label6.Text = "Movement: Turn Right\n and Advance";
                                label6.Update();
                                map.Movement.Add("Turn Right and Advance");
                                orientation++;
                            }
                            if ((map.Path[i - 1].X - map.Path[i].X) > 0)
                            {
                                label6.Text = "Movement: Turn Left\n and Advance";
                                label6.Update();
                                map.Movement.Add("Turn Left and Advance");
                                orientation--;
                            }
                        }

                        if ((map.Path[i].Y - map.Path[i + 1].Y) < 0)
                        {
                            if ((map.Path[i - 1].X - map.Path[i].X) > 0)
                            {
                                label6.Text = "Movement: Turn Right\n and Advance";
                                label6.Update();
                                map.Movement.Add("Turn Right and Advance");
                                orientation++;
                            }
                            if ((map.Path[i - 1].X - map.Path[i].X) < 0)
                            {
                                label6.Text = "Movement: Turn Left\n and Advance";
                                label6.Update();
                                map.Movement.Add("Turn Left and Advance");
                                orientation--;
                            }
                        }

                        if ((map.Path[i].X - map.Path[i + 1].X) > 0)
                        {
                            if ((map.Path[i - 1].Y - map.Path[i].Y) > 0)
                            {
                                label6.Text = "Movement: Turn Right\n and Advance";
                                label6.Update();
                                map.Movement.Add("Turn Right and Advance");
                                orientation++;
                            }
                            if ((map.Path[i - 1].Y - map.Path[i].Y) < 0)
                            {
                                label6.Text = "Movement: Turn Left\n and Advance";
                                label6.Update();
                                map.Movement.Add("Turn Left and Advance");
                                orientation--;
                            }
                        }

                        if ((map.Path[i].X - map.Path[i + 1].X) < 0)
                        {
                            if ((map.Path[i - 1].Y - map.Path[i].Y) < 0)
                            {
                                label6.Text = "Movement: Turn Right\n and Advance";
                                label6.Update();
                                map.Movement.Add("Turn Right and Advance");
                                orientation++;
                            }
                            if ((map.Path[i - 1].Y - map.Path[i].Y) > 0)
                            {
                                label6.Text = "Movement: Turn Left\n and Advance";
                                label6.Update();
                                map.Movement.Add("Turn Left and Advance");
                                orientation--;
                            }
                        }
                        map.Orientation.Add(orientation);
                        switch (orientation % 4)
                        {
                            case 0: label8.Text = "Orientation: North"; break;
                            case 1: label8.Text = "Orientation: East"; break;
                            case 2: label8.Text = "Orientation: South"; break;
                            case 3: label8.Text = "Orientation: West"; break;
                        }
                        label8.Update();

                        System.Threading.Thread.Sleep(200);
                        //MessageBox.Show(i.ToString());
                        label6.Text = "";
                        label6.Update();
                    }
                    g.FillRectangle(brushblue, map.Path[1].X * length + 52, map.Path[1].Y * length + 52, length - 3, length - 3);
                    label5.Text = "Location:  ( " + (map.Path[0].X + 1).ToString() + " , " + (map.Path[0].Y + 1).ToString() + " )";

                }

                else
                {
                    MessageBox.Show("Path does not exist!");
                }
            }

            if(map.startvalue==0&&map.endvalue==1)
            {
                MessageBox.Show("Please set the StartPoint!");
            }
            if (map.startvalue == 1 && map.endvalue == 0)
            {
                MessageBox.Show("Please set the EndPoint!");
            }
            if (map.startvalue == 0 && map.endvalue == 0)
            {
                MessageBox.Show("Please set the StartPoint and the EndPoint!");
            }
        }

        private void button5_Click(object sender, EventArgs e)//关闭界面
        {
            Close();
        }

        private void Form2_MouseClick(object sender, MouseEventArgs e)//鼠标点击界面
        {
            Graphics g = this.CreateGraphics();
                int x = e.Location.X;
                int y = e.Location.Y;
            if (x >= 50 && y >= 50 && x <= 50+length * Rows && y <= 50+length * Columns)
            {
                label1.Text = " ";
                //取起点坐标
                if (brushstate == 1 && map.startvalue == 0)
                {
                    map.startvalue = 1;
                    map.startx = (x - 50) / length;
                    map.starty = (y - 50) / length;
                    map.start = new Point(map.startx, map.starty);
                    map.start.H = 0;
                   // MessageBox.Show(x.ToString() + " " + y.ToString() + " " + map.startx.ToString() + " " + map.starty.ToString());
                    g.FillRectangle(brushgreen, 52 + length * (map.startx), 52 + length * (map.starty), length-3, length-3);
                    map.sign[map.startx, map.starty] = 5;
                    label5.Text = "Location: ( " + (map.startx + 1).ToString() + " , " + (map.starty + 1).ToString() + " )";
                }
                //取终点坐标
                if (brushstate == 2 && map.endvalue == 0)
                {
                    map.endvalue = 1;
                    map.endx = (x - 50) / length;
                    map.endy = (y - 50) / length;
                    map.end = new Point(map.endx, map.endy);
                    map.end.G = 0;
                    // MessageBox.Show(x.ToString() + " " + y.ToString() + " " + Map.endx.ToString() + " " + Map.endy.ToString());
                    g.FillRectangle(brushred, 52 + length * (map.endx), 52 + length * (map.endy), length-3, length-3);
                    map.sign[map.endx, map.endy] = 6;
                }
                if (brushstate == 3)
                {
                    int X, Y;
                   
                                X= (x - 50) / length;
                                Y= (y - 50) / length;
                        if (map.sign[(x - 50) / length, (y - 50) / length] == 0)
                        {
                            g.FillRectangle(brushblack, 52 + length * (X), 52 + length * (Y), length-3, length-3);
                            map.sign[X, Y] = 1;
                            barrier++;
                        label4.Text = "Barriers:" + barrier.ToString();
                        }
                    }

                if(brushstate==4)
                {
                    int X, Y;

                    X = (x - 50) / length;
                    Y = (y - 50) / length;
                    if(map.sign[X,Y]==1)
                    {
                        barrier--;
                    }
                    map.sign[X, Y] = 0;
                    g.FillRectangle(brushwhite, 52 + length * (X), 52 + length * (Y), length-3, length-3);
                    if(X==map.startx && Y==map.starty)
                    {
                        map.startvalue = 0;
                        label5.Text = "";
                    }
                    if (X == map.endx && Y == map.endy)
                    {
                        map.endvalue = 0;
                    }
                    label4.Text = "Barriers:" + barrier.ToString();
                }
            }
            else
            {
                label1.Text = "Please click in the form";
            }
        }

        protected override void OnPaint(PaintEventArgs e)//界面绘制
        {
                   
        Graphics g = e.Graphics;
            Pen frame = new Pen(Color.Black, 3);
            g.DrawLine(penblue, 460, 50,690, 50);
            g.DrawLine(penblue,690,50,690,250);
            g.DrawLine(penblue,460,250,690,250);
            g.DrawLine(penblue,460,50,460,250);
            int x, y;
            x = 50;
            y = 50;
            //绘制边框
            if (Columns == Rows)
            {
                //竖边框线
                for (int i = 0; i <= Rows; i++)
                {
                    g.DrawLine(frame, x+i*length, y, x+i*length, y + Columns*length);
                }
                //横边框线
                for (int i = 0; i <=Columns; i++)
                {
                    g.DrawLine(frame, x, y+i*length, x + Rows*length, y+i*length);
                }
            }
            //else
            {
                if (Columns > Rows)
                {
                    //横边框线
                    for(int i=0;i<=Columns;i++)
                    {
                        g.DrawLine(frame, x, y+i*length, x + length*Rows, y+i*length);
                    }
                    //竖边框线
                    for(int i=0;i<=Rows;i++)
                    {
                        g.DrawLine(frame, x+i*length, y, x + i*length, y+Columns*length);
                    }
                }
                else
                {
                    //横边框线
                    for (int i = 0; i <= Columns; i++)
                    {
                        g.DrawLine(frame, x, y + i * length, x + Rows*length, y + i * length);
                    }
                    //竖边框线
                    for (int i = 0; i <= Rows; i++)
                    {
                        g.DrawLine(frame, x + i * length, y, x + i * length, y + length*Columns);
                    }
                }   
            }
        }
    }
}

