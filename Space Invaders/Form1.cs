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
        Boolean drawInvaders, updatePlayer;
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

        public Form1()
        {
            InitializeComponent();

            gameEngine.Enabled = true;

            gameEngine.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(500, 500);

            drawInvaders = true;
            Refresh();
         
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

            checkPlayerShot();

            moveShot();

            updateBarriers();

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen drawPen = new Pen(Color.Green, 2);

            Rectangle rectangle1 = new Rectangle(xHero, yHero, 10, 10);

            Rectangle rectangle2 = new Rectangle(xShot, yShot, 5, 5);

            e.Graphics.DrawLine(drawPen, 2, this.Height - 50, this.Width - 2, this.Height - 50);
            
            e.Graphics.FillRectangle(Brushes.White, rectangle1);

            e.Graphics.FillRectangle(Brushes.White, rectangle2);


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

    }
}

