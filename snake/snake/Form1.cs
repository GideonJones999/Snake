using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    public partial class Form1 : Form
    {
        //Variables
        List<PictureBox> Snake = new List<PictureBox>();
        Random numb = new Random();
        int ySpeed = 30, xSpeed = 0;


        public Form1()
        {
            InitializeComponent();

            SnakeBody();
            Snake[0].Image = Properties.Resources.down;

        }

        private void SnakeBody()
        {
            PictureBox temp = new PictureBox();
            temp.Image = Properties.Resources.body;
            temp.SizeMode = PictureBoxSizeMode.StretchImage;
            temp.BackColor = Color.Transparent;
            temp.Width = temp.Height = 28;
            Snake.Add(temp);
            panel1.Controls.Add(temp);
        }

        private void gameTime_Tick(object sender, EventArgs e)
        {
            //Eat
            if (Snake[0].Bounds.IntersectsWith(food.Bounds))
                Eat();

            //Move Body
            for (int i = Snake.Count - 1; i > 0; i--)
            {
                Snake[i].Left = Snake[i - 1].Left;
                Snake[i].Top = Snake[i - 1].Top;
            }
            //Move Head
            Snake[0].Top += ySpeed;
            Snake[0].Left += xSpeed;

            //Fall off world
            if (!Snake[0].Bounds.IntersectsWith(panel1.Bounds))
                DEATH();

            //Cross Body
            for (int i = Snake.Count-1; i > 0; i--)
            {
                if (Snake[0].Bounds.IntersectsWith(Snake[i].Bounds))
                    DEATH();
            }

        }

        private void DEATH()
        {
            Score.Text += "\nPress ''Space'' to Play Again!";
            gameTime.Stop();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    xSpeed = 0;
                    ySpeed = -30;
                    Snake[0].Image = Properties.Resources.up;
                    break;
                case Keys.W:
                    xSpeed = 0;
                    ySpeed = -30;
                    Snake[0].Image = Properties.Resources.up;
                    break;
                case Keys.Left:
                    xSpeed = -30;
                    ySpeed = 0;
                    Snake[0].Image = Properties.Resources.left;
                    break;
                case Keys.A:
                    xSpeed = -30;
                    ySpeed = 0;
                    Snake[0].Image = Properties.Resources.left;
                    break;
                case Keys.Right:
                    xSpeed = 30;
                    ySpeed = 0;
                    Snake[0].Image = Properties.Resources.right;
                    break;
                case Keys.D:
                    xSpeed = 30;
                    ySpeed = 0;
                    Snake[0].Image = Properties.Resources.right;
                    break;
                case Keys.Down:
                    xSpeed = 0;
                    ySpeed = 30;
                    Snake[0].Image = Properties.Resources.down;
                    break;
                case Keys.S:
                    xSpeed = 0;
                    ySpeed = 30;
                    Snake[0].Image = Properties.Resources.down;
                    break;
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Space:
                    Application.Restart();
                    break;
                default:
                    break;
            }
        }

        private void Eat()
        {
            // Eat Kitten
            SnakeBody();

            //Move Kitten
            food.Left = numb.Next(30) * 30;
            food.Top = numb.Next(20) * 30;

            //Update Score
            Score.Text = "Score:   "+ Snake.Count;
        }
    }
}
