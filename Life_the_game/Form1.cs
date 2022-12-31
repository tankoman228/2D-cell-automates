using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Life_the_game
{
    public partial class Form1 : Form
    {

        int m = 100, n = 70, scale = 17;

        bool[,] map;

        Bitmap bmp;
        Graphics g;
        Random rand = new Random();
        Pen pen = new Pen(Color.White, 3);

        public Form1()
        {
            InitializeComponent();

            map = new bool[m, n];

            bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            g = Graphics.FromImage(bmp);
        }       

        void create_map()
        {

            m = int.Parse(textBox5.Text);
            n = int.Parse(textBox6.Text);

            map = new bool[m, n];

            for (int i = 0; i < m; i++)
            {
                map[i, 0] = false;
                map[i, n - 1] = false;
            }
            for (int j = 0; j < n; j++)
            {
                map[0, j] = false;
                map[m - 1, j] = false;
            }

            for (int i = 1; i < m - 1; i++)
            {
                for (int j = 1; j < n - 1; j++)
                {
                    if (rand.Next(0, int.Parse(textBox8.Text)) <= 1)
                    {
                        map[i, j] = true;
                    }
                    else
                    {
                        map[i, j] = false;
                    }
                }
            }
        }

        private void render_map()
        {

            scale = int.Parse(textBox7.Text);

            pen = new Pen(Color.White, scale/4);

            g = Graphics.FromImage(bmp);

            g.Clear(Color.Black);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (map[i, j])
                    {
                        g.DrawRectangle(pen, i * scale, j * scale, scale, scale);
                    }
                }
            }

            pictureBox1.Image = bmp;

        }

        private void step()
        {

            bool[,] next = new bool[m, n];
            int nei = 0;

            for (int i = 1; i < m - 1; i++)
            {
                for (int j = 1; j < n - 1; j++)
                {
                    nei = 0;

                    if (map[i, j + 1])
                    {
                        nei++;
                    }
                    if (map[i + 1, j + 1])
                    {
                        nei++;
                    }
                    if (map[i + 1, j])
                    {
                        nei++;
                    }
                    if (map[i + 1, j - 1])
                    {
                        nei++;
                    }
                    if (map[i, j - 1])
                    {
                        nei++;
                    }
                    if (map[i - 1, j - 1])
                    {
                        nei++;
                    }
                    if (map[i - 1, j])
                    {
                        nei++;
                    }
                    if (map[i - 1, j + 1])
                    {
                        nei++;
                    }

                    if (map[i, j])
                    {

                        if (nei >= int.Parse(textBox1.Text) && nei <= int.Parse(textBox2.Text))
                        {
                            next[i, j] = true;
                        }
                        else
                        {
                            next[i, j] = false;
                        }

                    }
                    else
                    {
                        if (nei >= int.Parse(textBox3.Text) && nei <= int.Parse(textBox4.Text))
                        {
                            next[i, j] = true;
                        }
                        else
                        {
                            next[i, j] = false;
                        }
                    }

                }
            }

            map = next;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    map[i, j] = false;
                }
            }
            render_map();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            map[m / 2, n / 2] = true;
            render_map();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            create_map();
            render_map();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            step();
            render_map();
        }
    }
}
