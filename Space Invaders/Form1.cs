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
        bool invadersRight = true;
        bool invadersLeft = false;
        bool newLevel = false;
        bool shotLaunched = false;
        bool restart = false;
        bool ufoLaunched = false;
        bool ufoHit = false;
        bool newInvaderSpeed = false;

        //Intialize variables for player
        int playerSpeed = 3;
        int xHero;
        int yHero = 600;
        int heroWidth = 10;
        int heroHeight = 10;
        int score = 0;
        int killCounter = 0;
        int levelCounter = 0;

        //Intialize variables for shot
        int playerShotSpeed = 8;
        int shotWidth = 2;
        int shotHeight = 10;
        int xShot;
        int yShot;

        //Intialize variables for invaders
        int invaderX11 = 200;
        int invaderY11 = 100;

        int invaderX12 = 200;
        int invaderY12 = 120;

        int invaderX13 = 200;
        int invaderY13 = 140;

        int invaderX14 = 200;
        int invaderY14 = 160;

        int invaderX15 = 200;
        int invaderY15 = 180;

        int invaderSpeed = 1;
        int invaderWidth = 10;
        int invaderHeight = 10;
        int invaderDecrease = 10;
        int ufoX = 776;
        int ufoY = 50;
        int ufoWidth = 10;
        int ufoHeight = 10;
        int ufoSpeed = 1;
        int preUfoScore;
        int ufoScore = 0;
        int ufoDelay = 0;

        //Intialize variables for barriers
        int barrierWidth = 100;
        int barrierHeight = 10;

        int barrier1X = 100;
        int barrier1Y = 550;
        int barrier2X = 350;
        int barrier3X = 600;

        Random randGen = new Random();


        public Form1()
        {
            InitializeComponent();

            gameEngine.Enabled = true;

            gameEngine.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(766, 706);

            xHero = this.Width / 2;
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
            updateBarriers();

            randomUfoScore();

            ufoSpawn();

            checkPlayerShot();

            movePlayer();

            moveInvaders();

            ufoMovement();

            moveShot();

            invaderDown();

            updateScore();

            ufoDestruction();

            invaderRestart();

            levelTracker();

            speedUpdate();

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen drawPen = new Pen(Color.Green, 2);
            Font drawFont = new Font("Arial", 16, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Red);

            Rectangle barrier1 = new Rectangle(barrier1X, barrier1Y, barrierWidth, barrierHeight);

            Rectangle barrier2 = new Rectangle(barrier2X, barrier1Y, barrierWidth, barrierHeight);

            Rectangle barrier3 = new Rectangle(barrier3X, barrier1Y, barrierWidth, barrierHeight);

            Rectangle defender = new Rectangle(xHero, yHero, heroWidth, heroHeight);

            Rectangle playerShot = new Rectangle(xShot, yShot, shotWidth, shotHeight);

            Rectangle invader11 = new Rectangle(invaderX11, invaderY11, invaderWidth, invaderHeight);

            Rectangle invader12 = new Rectangle(invaderX12, invaderY12, invaderWidth, invaderHeight);

            Rectangle invader13 = new Rectangle(invaderX13, invaderY13, invaderWidth, invaderHeight);

            Rectangle invader14 = new Rectangle(invaderX14, invaderY14, invaderWidth, invaderHeight);

            Rectangle invader15 = new Rectangle(invaderX15, invaderY15, invaderWidth, invaderHeight);

            Rectangle ufo = new Rectangle(ufoX, ufoY, ufoWidth, ufoHeight);

            e.Graphics.DrawLine(drawPen, 2, this.Height - 50, this.Width - 2, this.Height - 50);

            e.Graphics.FillRectangle(Brushes.Green, barrier1);

            e.Graphics.FillRectangle(Brushes.Green, barrier2);

            e.Graphics.FillRectangle(Brushes.Green, barrier3);

            e.Graphics.FillRectangle(Brushes.White, defender);

            e.Graphics.FillRectangle(Brushes.White, playerShot);

            e.Graphics.FillRectangle(Brushes.White, invader11);

            e.Graphics.FillRectangle(Brushes.White, invader12);

            e.Graphics.FillRectangle(Brushes.White, invader13);

            e.Graphics.FillRectangle(Brushes.White, invader14);

            e.Graphics.FillRectangle(Brushes.White, invader15);

            e.Graphics.FillRectangle(Brushes.Red, ufo);

            // Create image.
            Image newImage = Image.FromFile("hero");

            // Create rectangle for displaying image.
            Rectangle heroImage = new Rectangle(xHero, yHero, heroWidth, heroHeight);
            // Draw image to screen.
            e.Graphics.DrawImage(newImage, heroImage);
        

        e.Graphics.DrawString(score + "", drawFont, drawBrush, 400, 40);

            e.Graphics.DrawString(killCounter + "", drawFont, drawBrush, 300, 40);

            e.Graphics.DrawString(levelCounter + "", drawFont, drawBrush, 200, 40);
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
            if (shotLaunched)
            {
                yShot = yShot - playerShotSpeed;
            }

            if (yShot == 0)
            {
                yShot = 1000;

                shotLaunched = false;
            }
        }

        public void updateBarriers()
        {
            Rectangle playerShot = new Rectangle(xShot, yShot, shotWidth, shotHeight);

            Rectangle barrier1 = new Rectangle(barrier1X, barrier1Y, barrierWidth, barrierHeight);

            Rectangle barrier2 = new Rectangle(barrier2X, barrier1Y, barrierWidth, barrierHeight);

            Rectangle barrier3 = new Rectangle(barrier3X, barrier1Y, barrierWidth, barrierHeight);

            if (playerShot.IntersectsWith(barrier1) || playerShot.IntersectsWith(barrier2) || playerShot.IntersectsWith(barrier3))
            {
                shotLaunched = false;

                yShot = 1000;
            }
        }

        public void moveInvaders()
        {
            if (invadersRight == true && restart == false)
            {
                invaderX11 = invaderX11 + invaderSpeed;

                invaderX12 = invaderX12 + invaderSpeed;

                invaderX13 = invaderX13 + invaderSpeed;

                invaderX14 = invaderX14 + invaderSpeed;

                invaderX15 = invaderX15 + invaderSpeed;
            }
            else if (invadersLeft == true && restart == false)
            {
                invaderX11 = invaderX11 - invaderSpeed;

                invaderX12 = invaderX12 - invaderSpeed;

                invaderX13 = invaderX13 - invaderSpeed;

                invaderX14 = invaderX14 - invaderSpeed;

                invaderX15 = invaderX15 - invaderSpeed;

            }

        }

        public void invaderDown()
        {
            if (invaderX11 >= this.Width - invaderWidth || invaderX12 >= this.Width - invaderWidth || invaderX13 >= this.Width - invaderWidth || invaderX14 >= this.Width - invaderWidth || invaderX15 >= this.Width - invaderWidth)
            {
                invadersRight = false;

                invadersLeft = true;

                invaderY11 += invaderHeight;
                invaderY12 += invaderHeight;
                invaderY13 += invaderHeight;
                invaderY14 += invaderHeight;
                invaderY15 += invaderHeight;
            }

            else if (invaderX11 <= 0 || invaderX12 <= 0 || invaderX13 <= 0 || invaderX14 <= 0 || invaderX15 <= 0)
            {
                invadersRight = true;

                invadersLeft = false;

                invaderY11 += invaderHeight;
                invaderY12 += invaderHeight;
                invaderY13 += invaderHeight;
                invaderY14 += invaderHeight;
                invaderY15 += invaderHeight;
            }

        }

        public void updateScore()
        {
            Rectangle playerShot = new Rectangle(xShot, yShot, shotWidth, shotHeight);

            Rectangle invader11 = new Rectangle(invaderX11, invaderY11, invaderWidth, invaderHeight);

            Rectangle invader12 = new Rectangle(invaderX12, invaderY12, invaderWidth, invaderHeight);

            Rectangle invader13 = new Rectangle(invaderX13, invaderY13, invaderWidth, invaderHeight);

            Rectangle invader14 = new Rectangle(invaderX14, invaderY14, invaderWidth, invaderHeight);

            Rectangle invader15 = new Rectangle(invaderX15, invaderY15, invaderWidth, invaderHeight);

            if (playerShot.IntersectsWith(invader11))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY11 = 2000;

                score += 40;
            }
            else if (playerShot.IntersectsWith(invader12))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY12 = 2000;

                score += 20;
            }
            else if (playerShot.IntersectsWith(invader13))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY13 = 2000;

                score += 20;
            }
            else if (playerShot.IntersectsWith(invader14))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY14 = 2000;

                score += 10;
            }
            else if (playerShot.IntersectsWith(invader15))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY15 = 2000;

                score += 10;
            }
        }

        public void levelTracker()
        {
            if (killCounter == 1 && newLevel == false)
            {
                newInvaderSpeed = true;
            }

            else if (killCounter == 2 && newLevel == false)
            {
                newInvaderSpeed = true;
            }
            else if (killCounter == 3 && newLevel == false)
            {
                newInvaderSpeed = true;
            }

            else if (killCounter == 4 && newLevel == false)
            {
                newInvaderSpeed = true;
            }

            else if (killCounter == 5 && newLevel == false)
            {
                levelCounter++;

                newLevel = true;

                restart = true;
            }

        }

        public void invaderRestart()
        {
            if (levelCounter == 1 && restart == true)
            {
                invaderX11 = this.Width / 2;
                invaderY11 = 120 + levelCounter * invaderDecrease;

                invaderX12 = this.Width / 2;
                invaderY12 = 140 + levelCounter * invaderDecrease;

                invaderX13 = this.Width / 2;
                invaderY13 = 160 + levelCounter * invaderDecrease;

                invaderX14 = this.Width / 2;
                invaderY14 = 180 + levelCounter * invaderDecrease;

                invaderX15 = this.Width / 2;
                invaderY15 = 200 + levelCounter * invaderDecrease;

                invadersLeft = false;

                invadersRight = true;

                restart = false;

                killCounter = 0;

                score += 1000;

                invaderSpeed = 1;
            }

            else if (levelCounter == 2 && restart == true)
            {
                invaderX11 = this.Width / 2;
                invaderY11 = 120 + levelCounter * invaderDecrease;

                invaderX12 = this.Width / 2;
                invaderY12 = 140 + levelCounter * invaderDecrease;

                invaderX13 = this.Width / 2;
                invaderY13 = 160 + levelCounter * invaderDecrease;

                invaderX14 = this.Width / 2;
                invaderY14 = 180 + levelCounter * invaderDecrease;

                invaderX15 = this.Width / 2;
                invaderY15 = 200 + levelCounter * invaderDecrease;

                invadersLeft = false;

                invadersRight = true;

                restart = false;

                killCounter = 0;

                score += 1000;

                invaderSpeed = 1;
            }
            else if (levelCounter == 3 && restart == true)
            {
                invaderX11 = this.Width / 2;
                invaderY11 = 120 + levelCounter * invaderDecrease;

                invaderX12 = this.Width / 2;
                invaderY12 = 140 + levelCounter * invaderDecrease;

                invaderX13 = this.Width / 2;
                invaderY13 = 160 + levelCounter * invaderDecrease;

                invaderX14 = this.Width / 2;
                invaderY14 = 180 + levelCounter * invaderDecrease;

                invaderX15 = this.Width / 2;
                invaderY15 = 200 + levelCounter * invaderDecrease;

                invadersLeft = false;

                invadersRight = true;

                restart = false;

                killCounter = 0;

                score += 1000;

                invaderSpeed = 1;
            }
            else if (levelCounter == 4 && restart == true)
            {
                invaderX11 = this.Width / 2;
                invaderY11 = 120 + levelCounter * invaderDecrease;

                invaderX12 = this.Width / 2;
                invaderY12 = 140 + levelCounter * invaderDecrease;

                invaderX13 = this.Width / 2;
                invaderY13 = 160 + levelCounter * invaderDecrease;

                invaderX14 = this.Width / 2;
                invaderY14 = 180 + levelCounter * invaderDecrease;

                invaderX15 = this.Width / 2;
                invaderY15 = 200 + levelCounter * invaderDecrease;

                invadersLeft = false;

                invadersRight = true;

                restart = false;

                killCounter = 0;

                score += 1000;

                invaderSpeed = 1;
            }

            else if (levelCounter == 5 && restart == true)
            {
                invaderX11 = this.Width / 2;
                invaderY11 = 120 + levelCounter * invaderDecrease;

                invaderX12 = this.Width / 2;
                invaderY12 = 140 + levelCounter * invaderDecrease;

                invaderX13 = this.Width / 2;
                invaderY13 = 160 + levelCounter * invaderDecrease;

                invaderX14 = this.Width / 2;
                invaderY14 = 180 + levelCounter * invaderDecrease;

                invaderX15 = this.Width / 2;
                invaderY15 = 200 + levelCounter * invaderDecrease;

                invadersLeft = false;

                invadersRight = true;

                restart = false;

                killCounter = 0;

                score += 1000;

                invaderSpeed = 1;
            }

            else if (levelCounter == 6 && restart == true)
            {
                invaderX11 = this.Width / 2;
                invaderY11 = 120 + levelCounter * invaderDecrease;

                invaderX12 = this.Width / 2;
                invaderY12 = 140 + levelCounter * invaderDecrease;

                invaderX13 = this.Width / 2;
                invaderY13 = 160 + levelCounter * invaderDecrease;

                invaderX14 = this.Width / 2;
                invaderY14 = 180 + levelCounter * invaderDecrease;

                invaderX15 = this.Width / 2;
                invaderY15 = 200 + levelCounter * invaderDecrease;

                invadersLeft = false;

                invadersRight = true;

                restart = false;

                killCounter = 0;

                score += 1000;

                invaderSpeed = 1;
            }

            else if (levelCounter == 7 && restart == true)
            {
                invaderX11 = this.Width / 2;
                invaderY11 = 120 + levelCounter * invaderDecrease;

                invaderX12 = this.Width / 2;
                invaderY12 = 140 + levelCounter * invaderDecrease;

                invaderX13 = this.Width / 2;
                invaderY13 = 160 + levelCounter * invaderDecrease;

                invaderX14 = this.Width / 2;
                invaderY14 = 180 + levelCounter * invaderDecrease;

                invaderX15 = this.Width / 2;
                invaderY15 = 200 + levelCounter * invaderDecrease;

                invadersLeft = false;

                invadersRight = true;

                restart = false;

                killCounter = 0;

                score += 1000;

                invaderSpeed = 1;
            }

            else if (levelCounter == 8 && restart == true)
            {
                invaderX11 = this.Width / 2;
                invaderY11 = 120 + levelCounter * invaderDecrease;

                invaderX12 = this.Width / 2;
                invaderY12 = 140 + levelCounter * invaderDecrease;

                invaderX13 = this.Width / 2;
                invaderY13 = 160 + levelCounter * invaderDecrease;

                invaderX14 = this.Width / 2;
                invaderY14 = 180 + levelCounter * invaderDecrease;

                invaderX15 = this.Width / 2;
                invaderY15 = 200 + levelCounter * invaderDecrease;

                invadersLeft = false;

                invadersRight = true;

                restart = false;

                killCounter = 0;

                score += 1000;

                invaderSpeed = 1;
            }
            else if (levelCounter == 9 && restart == true)
            {
                invaderX11 = this.Width / 2;
                invaderY11 = 120 + levelCounter * invaderDecrease;

                invaderX12 = this.Width / 2;
                invaderY12 = 140 + levelCounter * invaderDecrease;

                invaderX13 = this.Width / 2;
                invaderY13 = 160 + levelCounter * invaderDecrease;

                invaderX14 = this.Width / 2;
                invaderY14 = 180 + levelCounter * invaderDecrease;

                invaderX15 = this.Width / 2;
                invaderY15 = 200 + levelCounter * invaderDecrease;

                invadersLeft = false;

                invadersRight = true;

                restart = false;

                killCounter = 0;

                score += 1000;

                invaderSpeed = 1;
            }
            else if (levelCounter == 10 && restart == true)
            {
                invaderX11 = this.Width / 2;
                invaderY11 = 120 + levelCounter * invaderDecrease;

                invaderX12 = this.Width / 2;
                invaderY12 = 140 + levelCounter * invaderDecrease;

                invaderX13 = this.Width / 2;
                invaderY13 = 160 + levelCounter * invaderDecrease;

                invaderX14 = this.Width / 2;
                invaderY14 = 180 + levelCounter * invaderDecrease;

                invaderX15 = this.Width / 2;
                invaderY15 = 200 + levelCounter * invaderDecrease;

                invadersLeft = false;

                invadersRight = true;

                restart = false;

                killCounter = 0;

                score += 1000;

                invaderSpeed = 1;
            }
        }

        public void ufoSpawn()
        {
            ufoDelay++;

            if (ufoDelay == 600)
            {
                ufoLaunched = true;
            }
        }

        public void ufoMovement()
        {
            if (ufoLaunched)
            {
                ufoX = ufoX - ufoSpeed;

                if (ufoX == 0)
                {
                    ufoX = 776;

                    ufoDelay = 0;

                    ufoLaunched = false;
                }
            }
        }

        public void ufoDestruction()
        {
            Rectangle playerShot = new Rectangle(xShot, yShot, shotWidth, shotHeight);

            Rectangle ufo = new Rectangle(ufoX, ufoY, ufoWidth, ufoHeight);

            if (playerShot.IntersectsWith(ufo))
            {
                score = score + ufoScore;

                shotLaunched = false;

                ufoDelay = 0;

                ufoX = 776;

                yShot = 1000;

                ufoLaunched = false;
            }
        }

        public void randomUfoScore()
        {
            preUfoScore = randGen.Next(1, 7);

            if (preUfoScore == 1)
            {
                ufoScore = 50;
            }
            else if (preUfoScore == 2)
            {
                ufoScore = 100;
            }
            else if (preUfoScore == 3)
            {
                ufoScore = 150;
            }
            else if (preUfoScore == 4)
            {
                ufoScore = 200;
            }
            else if (preUfoScore == 5)
            {
                ufoScore = 250;
            }
            else if (preUfoScore == 6)
            {
                ufoScore = 300;
            }
        }

        public void speedUpdate()
        {
   
            /*        if (newInvaderSpeed)
            {
                newInvaderSpeed = false;

                invaderSpeed++;              
            }
            */
        }
    }
}




    


