using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Invaders
{
    public partial class Form1 : Form
    {
        //Intialize boolean variables 
        Boolean leftArrowDown, rightArrowDown, spaceKeyDown;
        bool invadersRight = false;
        bool invadersLeft = true;

        bool shotLaunched = false;

        //Intialize variables for player
        int playerSpeed = 3;
        int xHero = 250;
        int yHero = 400;
        int score = 0;

        //Intialize variables for shot
        int playerShotSpeed = 5;
        int xShot;
        int yShot;

        //Intialize variables for invaders
        int invaderX = 250;
        int invaderY = 100;
        int invaderSpeed = 1;



        public Form1()
        {
            InitializeComponent();

            gameEngine.Enabled = true;

            gameEngine.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(500, 500);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            #region move character and shoot
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Space:
                    spaceKeyDown = true;
                    break;
            }
            #endregion 
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            #region Stay still and stop shooting
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Space:
                    spaceKeyDown = false;
                    break;
            }
            #endregion
        }

        private void gameEngine_Tick(object sender, EventArgs e)
        {
            movePlayer();

            moveShot();

            checkPlayerShot();

            invaderDown();

            moveInvaders();

            updateBarriers();

            updateScore();

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen drawPen = new Pen(Color.Green, 2);
            Font drawFont = new Font("Arial", 16, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Red);


            Rectangle defender = new Rectangle(xHero, yHero, 10, 10);

            Rectangle playerShot = new Rectangle(xShot, yShot, 2, 8);

            Rectangle invader1 = new Rectangle(invaderX, invaderY, 30, 30);

            e.Graphics.DrawLine(drawPen, 2, this.Height - 50, this.Width - 2, this.Height - 50);

            e.Graphics.FillRectangle(Brushes.White, defender);

            e.Graphics.FillRectangle(Brushes.White, playerShot);

            e.Graphics.FillRectangle(Brushes.White, invader1);

            e.Graphics.DrawString(score + "", drawFont, drawBrush, 400, 40);


        }
        public void movePlayer()
        {
            if (leftArrowDown == true)
            {
                if (xHero > 0)
                {
                    xHero = xHero - playerSpeed;
                }
                else if (xHero <= 0)
                {
                    xHero = 0;
                }
            }

            if (rightArrowDown == true)
            {
                if (xHero < this.Width - 10)
                {
                    xHero = xHero + playerSpeed;
                }
                else if (xHero >= this.Width - 10)
                {
                    xHero = this.Width - 10;
                }
            }
        }

        public void checkPlayerShot()
        {
            if (spaceKeyDown == true && shotLaunched == false)
            {
                shotLaunched = true;

                xShot = xHero + 5;
                yShot = yHero;

            }
        }

        public void moveShot()
        {
            yShot = yShot - playerShotSpeed;

            if (yShot < 0)
            {
                shotLaunched = false;
            }
        }

        public void updateBarriers()
        {

        }

        public void moveInvaders()
        {
            if (invadersRight)
            {
                invaderX = invaderX + invaderSpeed;
            }
            else if (invadersLeft)
            {
                invaderX = invaderX - invaderSpeed;
            }
        }

        public void invaderDown()
        {
            if (invaderX >= this.Width - 10)
            {
                invadersRight = false;

                invadersLeft = true;

                invaderY += 30;
            }

            else if (invaderX <= 0)
            {
                invadersRight = true;

                invadersLeft = false;

                invaderY += 30;
            }

        }

        public void updateScore()
        {
            Rectangle playerShot = new Rectangle(xShot, yShot, 2, 8);

            Rectangle invader1 = new Rectangle(invaderX, invaderY, 10, 10);

            if (playerShot.IntersectsWith(invader1))
            {
                score += 100;
            }
        } 
    }

}


    


