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
        bool newLevel = false;
        bool shotLaunched = false;
        bool restart = false;
        bool ufoLaunched = false;
        bool ufoHit = false;

        //Intialize variables for player
        int playerSpeed = 3;
        int xHero = 250;
        int yHero = 400;
        int heroWidth = 10;
        int heroHeight = 10;
        int score = 0;
        int killCounter = 0;
        int levelCounter = 0;

        //Intialize variables for shot
        int playerShotSpeed = 5;
        int shotWidth = 2;
        int shotHeight = 10;
        int xShot;
        int yShot;

        //Intialize variables for invaders
        int invaderX = 250;
        int invaderY = 100;
        int invaderSpeed = 1;
        int invaderWidth = 30;
        int invaderHeight = 30;
        int invaderDecrease = 30;
        int invaderStart = 100;
        int ufoX = 510;
        int ufoY = 50;
        int ufoWidth = 15;
        int ufoHeight = 15;
        int ufoSpeed = 1;
        int preUfoScore;
        int ufoScore = 0;
        int ufoChance;

        Random randGen = new Random();


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

            drawBarriers();

            updateScore();

            levelTracker();

            invaderRestart();

            ufoSpawn();

            ufoMovement();

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen drawPen = new Pen(Color.Green, 2);
            Font drawFont = new Font("Arial", 16, FontStyle.Bold);
            SolidBrush drawBrush = new SolidBrush(Color.Red);

            Rectangle defender = new Rectangle(xHero, yHero, heroWidth, heroHeight);

            Rectangle playerShot = new Rectangle(xShot, yShot, shotWidth, shotHeight);

            Rectangle invader1 = new Rectangle(invaderX, invaderY, invaderWidth, invaderHeight);

            Rectangle ufo = new Rectangle(ufoX, ufoY, ufoWidth, ufoHeight);

            e.Graphics.DrawLine(drawPen, 2, this.Height - 50, this.Width - 2, this.Height - 50);

            e.Graphics.FillRectangle(Brushes.White, defender);

            e.Graphics.FillRectangle(Brushes.White, playerShot);

            e.Graphics.FillRectangle(Brushes.White, invader1);

            e.Graphics.FillRectangle(Brushes.White, ufo);


            e.Graphics.DrawString(score + "", drawFont, drawBrush, 400, 40);

            e.Graphics.DrawString(killCounter + "", drawFont, drawBrush, 300, 40);

            e.Graphics.DrawString(levelCounter + "", drawFont, drawBrush, 200, 40);

            if (ufoHit)
            {
                ufoLaunched = false;

                ufoX = 510;

                e.Graphics.DrawString(levelCounter + "", drawFont, drawBrush, ufoX, ufoY);
            }


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

        public void drawBarriers()
        {

        }

        public void moveInvaders()
        {
            if (invadersRight == true && restart == false)
            {
                invaderX = invaderX + invaderSpeed;
            }
            else if (invadersLeft && restart == false)
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

                invaderY += 50;
            }

            else if (invaderX <= 0)
            {
                invadersRight = true;

                invadersLeft = false;

                invaderY += 50;
            }

        }

        public void updateScore()
        {
            Rectangle playerShot = new Rectangle(xShot, yShot, 2, 8);

            Rectangle invader1 = new Rectangle(invaderX, invaderY, 30, 30);

            if (playerShot.IntersectsWith(invader1))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                score += 100;
            }
        }

        public void levelTracker()
        {
            if (killCounter == 20 && newLevel == false)
            {
                score += 1000;

                levelCounter++;

                newLevel = true;

                restart = true;
            }

            else if (killCounter == 40 && newLevel == false)
            {
                score += 1000;

                levelCounter++;

                newLevel = true;

                restart = true;
            }
            else if (killCounter == 60 && newLevel == false)
            {
                score += 1000;

                levelCounter++;

                newLevel = true;

                restart = true;
            }

            else if (killCounter == 80 && newLevel == false)
            {
                score += 1000;

                levelCounter++;

                newLevel = true;

                restart = true;
            }
            else if (killCounter == 100 && newLevel == false)
            {
                score += 1000;

                levelCounter++;

                newLevel = true;

                restart = true;
            }
            else if (killCounter == 120 && newLevel == false)
            {
                score += 1000;

                levelCounter++;

                newLevel = true;

                restart = true;
            }
            else if (killCounter == 140 && newLevel == false)
            {
                score += 1000;

                levelCounter++;

                newLevel = true;

                restart = true;
            }
            else if (killCounter == 160 && newLevel == false)
            {
                score += 1000;

                levelCounter++;

                newLevel = true;

                restart = true;
            }

        }
        
        public void invaderRestart()
        {
            if (levelCounter == 1 && restart == true)
            {
                invaderX = this.Width / 2;
                invaderY = invaderStart + levelCounter * invaderDecrease;

                restart = false;
            }

            else if (levelCounter == 2 && restart == true)
            {
                invaderX = this.Width / 2;
                invaderY = invaderStart + levelCounter * invaderDecrease;

                restart = false;
            }
            else if (levelCounter == 3 && restart == true)
            {
                invaderX = this.Width / 2;
                invaderY = invaderStart + levelCounter * invaderDecrease;

                restart = false;
            }
            else if (levelCounter == 4 && restart == true)
            {
                invaderX = this.Width / 2;
                invaderY = invaderStart + levelCounter * invaderDecrease;

                restart = false;
            }

            else if (levelCounter == 5 && restart == true)
            {
                invaderX = this.Width / 2;
                invaderY = invaderStart + levelCounter * invaderDecrease;

                restart = false;
            }

            else if (levelCounter == 6 && restart == true)
            {
                invaderX = this.Width / 2;
                invaderY = invaderStart + levelCounter * invaderDecrease;

                restart = false;
            }

            else if (levelCounter == 7 && restart == true)
            {
                invaderX = this.Width / 2;
                invaderY = invaderStart + levelCounter * invaderDecrease;

                restart = false;
            }

            else if (levelCounter == 8 && restart == true)
            {
                invaderX = this.Width / 2;
                invaderY = invaderStart + levelCounter * invaderDecrease;

                restart = false;
            }


        }

        public void ufoSpawn()
        {
            preUfoScore = randGen.Next(1, 7);

            if (ufoLaunched == false)
            {
                ufoChance = randGen.Next(1, 6);
            }

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

            if (ufoChance == 1)
            {
                ufoLaunched = false;
            }
           else if (ufoChance == 2)
            {
                ufoLaunched = false;
            }
           else if (ufoChance == 3)
            {
                ufoLaunched = false;
            }
           else if (ufoChance == 4)
            {
                ufoLaunched = false;
            }
           else if (ufoChance == 5)
            {
                ufoLaunched = true;
            }
        }

        public void ufoMovement()
        {
            Rectangle playerShot = new Rectangle(xShot, yShot, shotWidth, shotHeight);

            Rectangle ufo = new Rectangle(ufoX, ufoY, ufoWidth, ufoHeight);

            if (playerShot.IntersectsWith(ufo))
            {
                score = score + ufoScore;

                ufoHit = true;
            }

            if (ufoLaunched)
            {
                ufoX = ufoX - ufoSpeed;
            }


        }
    }

}




    


