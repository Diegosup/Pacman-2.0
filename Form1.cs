using System;
using System.Drawing;
using System.Windows.Forms;


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        byte[,] level = Class1.map0;
        byte[,] NewLevel1 = Class1.N0;//Guardar mapas para que no se borren 
        //byte[,] NewLevel2 = Class1.N1;
        //byte[,] NewLevel3 = Class1.N2;
        int pills = 0;
        int xpos, ypos, count;
        bool goright, goleft, goup, godown;
        bool firstTime;



        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(250, 250);
            PCT_CANVAS.Image = bmp;
            firstTime = true;
            DrawMap(level);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (goleft == true)
            {
                Move(xpos, ypos, xpos - 1, ypos);
            }
            if (goright == true)
            {
                Move(xpos, ypos, xpos + 1, ypos);
            }
            if (goup == true)
            {
                Move(xpos, ypos, xpos, ypos - 1);
            }
            if (godown == true)
            {
                Move(xpos, ypos, xpos, ypos + 1);
            }
        }

        //Resetear mapas
        private void restart(byte[,] currentMap, byte[,] newMap)
        {
            for (int x = 0; x < currentMap.GetLength(1); x++)
            {
                for (int y = 0; y < currentMap.GetLength(1); y++)
                {
                    currentMap[y, x] = newMap[y, x];
                }
            }
            //Resetear SCORE y dibujar de nuevo el mapa
            count = 0;
            Score.Text = count.ToString();
            PCT_CANVAS.Image = bmp;
            firstTime = true;
            DrawMap(currentMap);

        }
        private void Level1_Click(object sender, EventArgs e)
        {
            pills = 0;
            restart(level, Class1.N0);

        }

        private void Level2_Click(object sender, EventArgs e)
        {
            pills = 0;
            restart(level, Class1.N1);

        }

        private void Level3_Click(object sender, EventArgs e)
        {
            pills = 0;
            restart(level, Class1.N2);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    goleft = true;
                    goright = false;
                    godown = false;
                    goup = false;
                    break;
                case Keys.Right:
                    goright = true;
                    goleft = false;
                    godown = false;
                    goup = false;

                    break;
                case Keys.Up:
                    goup = true;
                    goleft = false;
                    godown = false;
                    goright = false;
                    break;
                case Keys.Down:
                    godown = true;
                    goleft = false;
                    goright = false;
                    goup = false;
                    break;
                case Keys.Space:
                    break;
            }
        }

        private void DrawMap(byte[,] map)
        {

            g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {

                    if (map[y, x] == 3)
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 128)), x * 10, y * 10, 10, 10);
                        g.DrawImage(Resource1.PG, x * 10, y * 10, 10, 10);
                    }
                    if (map[y, x] == 4)
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 128)), x * 10, y * 10, 10, 10);
                        g.DrawImage(Resource1.RG, x * 10, y * 10, 10, 10);
                    }
                    if (map[y, x] == 5)
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 128)), x * 10, y * 10, 10, 10);
                        g.DrawImage(Resource1.YG, x * 10, y * 10, 10, 10);
                    }
                    if (map[y, x] == 6)
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 128)), x * 10, y * 10, 10, 10);
                        g.DrawImage(Resource1.BG, x * 10, y * 10, 10, 10);
                    }
                    if (map[y, x] == 0)
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 128)), x * 10, y * 10, 10, 10);
                    }
                    if (map[y, x] == 8)
                    {
                        g.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 128)), x * 10, y * 10, 10, 10);
                        g.DrawImage(Resource1.YDOT, x * 10, y * 10, 10, 10);

                    }
                    if (map[y, x] == 2)
                    {
                        if (firstTime == true)
                        {
                            g.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 128)), x * 10, y * 10, 10, 10);
                            g.DrawImage(Resource2.pacmanright, x * 10, y * 10, 10, 10);
                            firstTime = false;
                        }


                        if (goright == true)
                            g.DrawImage(Resource2.pacmanright, x * 10, y * 10, 10, 10);

                        if (goleft == true)
                            g.DrawImage(Resource2.pacmanleft, x * 10, y * 10, 10, 10);

                        if (godown == true)
                            g.DrawImage(Resource2.pacmandown, x * 10, y * 10, 10, 10);

                        if (goup == true)
                            g.DrawImage(Resource2.pacmanup, x * 10, y * 10, 10, 10);

                        xpos = x;
                        ypos = y;
                    }
                    else
                        g.DrawRectangle(Pens.Gray, x * 10, y * 10, 10, 10);
                }
            }
            PCT_CANVAS.Invalidate();

        }

        private void Move(int oldx, int oldy, int newx, int newy)
        {
            int limy, limx, nextPos;
            limy = level.GetLength(1) - 1;
            limx = level.GetLength(0) - 1;
            if (newy > limy)
            {
                level[0, newx] = 2;
                level[oldy, oldx] = 0;
            }
            else
            {
                if (newy < 0)
                {
                    level[limy, newx] = 2;
                    level[oldy, oldx] = 0;
                }
                else
                {
                    if (newx > limx)
                    {
                        level[newy, 0] = 2;
                        level[oldy, oldx] = 0;
                    }
                    else
                    {
                        if (newx < 0)
                        {
                            level[newy, limx] = 2;
                            level[oldy, oldx] = 0;
                        }
                        else
                        {
                            if (level[newy, newx] != 1)
                            {
                                //Contar Monedas
                                if (level[newy, newx] == 8)
                                {
                                    count = int.Parse(Score.Text);
                                    count++;
                                    Score.Text = count.ToString();
                                    //llega a comer 10 pildoras
                                    if (count == 10)
                                    {
                                        timer1.Enabled = false;
                                        MessageBox.Show("YOU WON");
                                    }
                                }
                                //Detectar colision con fantasma
                                if (level[newy, newx] >= 3 && level[newy, newx] <= 6)
                                {
                                    timer1.Enabled = false;
                                    DialogResult dr = MessageBox.Show(" CONTINUE?", "GAME OVER", MessageBoxButtons.YesNo);
                                    switch (dr)
                                    {
                                        case DialogResult.Yes:
                                            Application.Restart();
                                            break;
                                        case DialogResult.No:
                                            Application.Exit();
                                            break;
                                    }


                                }
                                level[oldy, oldx] = 0;
                                level[newy, newx] = 2;
                            }

                        }

                    }
                }
            }


            DrawMap(level);
        }

        public void UpdateMap()
        {
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            for (int x = 0; x < level.GetLength(0); x++)
            {
                for (int y = 0; y < level.GetLength(1); y++)
                {
                    if (level[y, x] == 2)
                    {
                        g.DrawImage(Resource1.pacman, x * 10, y * 10, 10, 10);

                    }
                }
            }
        }
    }
}