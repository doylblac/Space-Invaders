//Created by Doyle Blacklock and Nathan Hood on January 25, 2017
//To play the classic arcade game space invaders
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace Space_Invaders
{
    public partial class Form1 : Form
    {
        #region Declare variables
        //Intialize boolean variables 
        Boolean leftArrowDown, rightArrowDown, spaceKeyDown;
        bool invadersRight = true;
        bool invadersLeft = false;
        bool newLevel = false;
        bool shotLaunched = false;
        bool restart = false;
        bool ufoLaunched = false;
        bool invaderShotFired = false;

        //Intialize variables for player
        int playerSpeed = 5;
        int xHero;
        int yHero = 600;
        int heroWidth = 60;
        int heroHeight = 20;
        int score = 0;
        int killCounter = 0;
        int levelCounter = 8;
        int lives = 3;
        int screenTracker = 0;

        //Intialize variables for shot
        int playerShotSpeed = 8;
        int shotWidth = 2;
        int shotHeight = 10;
        int xShot;
        int yShot;

        //Intialize lists for invader shots
        List<int> activeInvaders = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 });
        List<int> activeInvadersBackup = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 });

        //Intializes variables for invader positions
        int invaderX11 = 200;
        int invaderY11 = 100;
        int invaderX12 = 200;
        int invaderY12 = 140;
        int invaderX13 = 200;
        int invaderY13 = 180;
        int invaderX14 = 200;
        int invaderY14 = 220;
        int invaderX15 = 200;
        int invaderY15 = 260;
        int invaderX21 = 250;
        int invaderY21 = 100;
        int invaderX22 = 250;
        int invaderY22 = 140;
        int invaderX23 = 250;
        int invaderY23 = 180;
        int invaderX24 = 250;
        int invaderY24 = 220;
        int invaderX25 = 250;
        int invaderY25 = 260;
        int invaderX31 = 300;
        int invaderY31 = 100;
        int invaderX32 = 300;
        int invaderY32 = 140;
        int invaderX33 = 300;
        int invaderY33 = 180;
        int invaderX34 = 300;
        int invaderY34 = 220;
        int invaderX35 = 300;
        int invaderY35 = 260;
        int invaderX41 = 350;
        int invaderY41 = 100;
        int invaderX42 = 350;
        int invaderY42 = 140;
        int invaderX43 = 350;
        int invaderY43 = 180;
        int invaderX44 = 350;
        int invaderY44 = 220;
        int invaderX45 = 350;
        int invaderY45 = 260;
        int invaderX51 = 400;
        int invaderY51 = 100;
        int invaderX52 = 400;
        int invaderY52 = 140;
        int invaderX53 = 400;
        int invaderY53 = 180;
        int invaderX54 = 400;
        int invaderY54 = 220;
        int invaderX55 = 400;
        int invaderY55 = 260;
        int invaderX61 = 450;
        int invaderY61 = 100;
        int invaderX62 = 450;
        int invaderY62 = 140;
        int invaderX63 = 450;
        int invaderY63 = 180;
        int invaderX64 = 450;
        int invaderY64 = 220;
        int invaderX65 = 450;
        int invaderY65 = 260;

        //Intialize variables for invader size,speed and level change
        int invaderSpeed = 1;
        int invaderWidth = 25;
        int invaderHeight = 25;
        int invaderDecrease = 25;

        //Intialize variables for invader shots
        int invaderShotY = 3000;
        int invaderShotX = 3000;
        int invaderShotSpeed = 5;
        int nextInvadershot = 0;
        int shotTime = 120;

        //Intialize variables for ufo
        int ufoX = 776;
        int ufoY = 50;
        int ufoWidth = 40;
        int ufoHeight = 20;
        int ufoSpeed = 2;
        int preUfoScore;
        int ufoScore = 0;
        int ufoDelay = 0;

        //Intialize variables for barriers
        int barrierWidth = 100;
        int barrierHeight = 10;
        int barrier1X = 100;
        int barrier1Y = 550;
        int barrier2Y = 550;
        int barrier2X = 350;
        int barrier3Y = 550;
        int barrier3X = 600;
        int barrier1Hit = 0;
        int barrier2Hit = 0;
        int barrier3Hit = 0;

        //Intialize random for use in code
        Random randGen = new Random();

        //Intialize list for high scores
        List<int> highScores = new List<int>();

        //Intialize sound players
        SoundPlayer themeSong = new SoundPlayer(Properties.Resources.spaceinvaders1);
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Add highscores
            highScores.Add(25870);
            highScores.Add(24930);
            highScores.Add(24870);
            highScores.Add(23650);
            highScores.Add(22560);
            highScores.Add(20070);

            //Place hero at center of screen
            xHero = this.Width / 2;

            //Play space invaders theme song
            themeSong.PlayLooping();
        }

        private void playGameButton_Click(object sender, EventArgs e)
        {
            //Create graphics object and clear screen
            Graphics g = this.CreateGraphics();
            g.Clear(Color.Black);

            //Makes play game buttton invisible
            playGameButton.Visible = false;

            //Makes high score button invisible
            highScoreButton.Visible = false;

            //Enables the game engine
            gameEngine.Enabled = true;

            //Starts the game engine
            gameEngine.Start();

            //Puts focus on key presses
            KeyPreview = true;

            //Puts focus on the form
            this.Focus();

            //Enables double buffering
            DoubleBuffered = true;

            //Gets rid of backgorund image
            this.BackgroundImage = null;

            //Stops playing theme song
            themeSong.Stop();

            //Switches to game screen, calls paint
            screenTracker = 3;
            Refresh();
        }

        private void highScoreButton_Click(object sender, EventArgs e)
        {
            //Switches to high score screen
            screenTracker = 2;
            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            #region move character and shoot
            //Moves character and allows shooting
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
            //Allows character to stay still and stop shooting
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
            invaderShotGeneration();//Generates invader shots

            drawBarriers();//Updates barriers based on collision

            randomUfoScore();//Generates a random ufo score

            ufoSpawn();//Spawns the ufo

            checkPlayerShot();//Launches shot when spacebar is pressed

            movePlayer();//Moves player based on input

            moveInvaders();//Moves invaders

            invaderShotMovement();//Moves invader shot

            ufoMovement();//Moves ufo

            moveShot();//Moves player shot

            invaderDown();//Moves invaders down when they hit a wall

            updateScore();//Updates score based on kills

            ufoDestruction();//Destroys ufo based on rectangle intersection

            invaderRestart();//Restarts when all invaders are killed

            levelTracker();//Tracks the level that the user is on

            updateBarriers();//Destroys barriers when they are shot 25 times

            invaderShotCollision();//Tracks invader shots

            gameEnd();//Ends game if lives = 0

            Refresh();//Calls paint
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (screenTracker == 2)//Draws high score screen
            {
                Graphics g = this.CreateGraphics();
                Font bigFont = new Font("Consolas", 20, FontStyle.Bold); //create a font for graphics
                Font smallFont = new Font("Consolas", 13, FontStyle.Bold); //create a font for graphics
                SolidBrush greenBrush = new SolidBrush(Color.LimeGreen); //create a brush for graphics
                SolidBrush whiteBrush = new SolidBrush(Color.White); //create a brush for graphics

                this.BackgroundImage = null;//Gets rid of background image

                g.Clear(Color.Black);//Clears graphics

                highScoreButton.Visible = false;//Makes high score button invisible

                highScores.Add(score);//Adds score to highscore list of bigger than other scores
                highScores.Sort();//Sorts high score list
                highScores.Reverse();//Arranges high score list properly

                int y = 80;//Creates variables and sets value to 80

                for (int i = 0; i < 5; i++)//Draws high score list
                {
                    g.DrawString("HIGH SCORES", bigFont, greenBrush, 150, 50);
                    g.DrawString("" + highScores[i], smallFont, whiteBrush, 150, y);
                    y = y + 20;
                }
            }
            if (screenTracker == 3)//Draws game when being played
            {
                //Declares font size and type
                Font normalFont = new Font("Arial", 16, FontStyle.Bold);

                //Declares 3 rectangles for the barriers
                Rectangle barrier1 = new Rectangle(barrier1X, barrier1Y, barrierWidth, barrierHeight);
                Rectangle barrier2 = new Rectangle(barrier2X, barrier2Y, barrierWidth, barrierHeight);
                Rectangle barrier3 = new Rectangle(barrier3X, barrier3Y, barrierWidth, barrierHeight);

                //Declares rectangle for the hero
                Rectangle defender = new Rectangle(xHero, yHero, heroWidth, heroHeight);

                //Declares rectangle for the player's shot
                Rectangle playerShot = new Rectangle(xShot, yShot, shotWidth, shotHeight);

                //Declares variable for onvader shot
                Rectangle invaderShot = new Rectangle(invaderShotX, invaderShotY, shotWidth, shotHeight);

                //Declares rectangles for invaders
                Rectangle invader11 = new Rectangle(invaderX11, invaderY11, invaderWidth, invaderHeight);
                Rectangle invader12 = new Rectangle(invaderX12, invaderY12, invaderWidth, invaderHeight);
                Rectangle invader13 = new Rectangle(invaderX13, invaderY13, invaderWidth, invaderHeight);
                Rectangle invader14 = new Rectangle(invaderX14, invaderY14, invaderWidth, invaderHeight);
                Rectangle invader15 = new Rectangle(invaderX15, invaderY15, invaderWidth, invaderHeight);
                Rectangle invader21 = new Rectangle(invaderX21, invaderY21, invaderWidth, invaderHeight);
                Rectangle invader22 = new Rectangle(invaderX22, invaderY22, invaderWidth, invaderHeight);
                Rectangle invader23 = new Rectangle(invaderX23, invaderY23, invaderWidth, invaderHeight);
                Rectangle invader24 = new Rectangle(invaderX24, invaderY24, invaderWidth, invaderHeight);
                Rectangle invader25 = new Rectangle(invaderX25, invaderY25, invaderWidth, invaderHeight);
                Rectangle invader31 = new Rectangle(invaderX31, invaderY31, invaderWidth, invaderHeight);
                Rectangle invader32 = new Rectangle(invaderX32, invaderY32, invaderWidth, invaderHeight);
                Rectangle invader33 = new Rectangle(invaderX33, invaderY33, invaderWidth, invaderHeight);
                Rectangle invader34 = new Rectangle(invaderX34, invaderY34, invaderWidth, invaderHeight);
                Rectangle invader35 = new Rectangle(invaderX35, invaderY35, invaderWidth, invaderHeight);
                Rectangle invader41 = new Rectangle(invaderX41, invaderY41, invaderWidth, invaderHeight);
                Rectangle invader42 = new Rectangle(invaderX42, invaderY42, invaderWidth, invaderHeight);
                Rectangle invader43 = new Rectangle(invaderX43, invaderY43, invaderWidth, invaderHeight);
                Rectangle invader44 = new Rectangle(invaderX44, invaderY44, invaderWidth, invaderHeight);
                Rectangle invader45 = new Rectangle(invaderX45, invaderY45, invaderWidth, invaderHeight);
                Rectangle invader51 = new Rectangle(invaderX51, invaderY51, invaderWidth, invaderHeight);
                Rectangle invader52 = new Rectangle(invaderX52, invaderY52, invaderWidth, invaderHeight);
                Rectangle invader53 = new Rectangle(invaderX53, invaderY53, invaderWidth, invaderHeight);
                Rectangle invader54 = new Rectangle(invaderX54, invaderY54, invaderWidth, invaderHeight);
                Rectangle invader55 = new Rectangle(invaderX55, invaderY55, invaderWidth, invaderHeight);
                Rectangle invader61 = new Rectangle(invaderX61, invaderY61, invaderWidth, invaderHeight);
                Rectangle invader62 = new Rectangle(invaderX62, invaderY62, invaderWidth, invaderHeight);
                Rectangle invader63 = new Rectangle(invaderX63, invaderY63, invaderWidth, invaderHeight);
                Rectangle invader64 = new Rectangle(invaderX64, invaderY64, invaderWidth, invaderHeight);
                Rectangle invader65 = new Rectangle(invaderX65, invaderY65, invaderWidth, invaderHeight);

                //Declares rectangle for ufo
                Rectangle ufo = new Rectangle(ufoX, ufoY, ufoWidth, ufoHeight);

                //Draws line beneath hero
                e.Graphics.DrawLine(Pens.Green, 2, this.Height - 50, this.Width - 2, this.Height - 50);

                //Draws barriers
                e.Graphics.FillRectangle(Brushes.Green, barrier1);
                e.Graphics.FillRectangle(Brushes.Green, barrier2);
                e.Graphics.FillRectangle(Brushes.Green, barrier3);

                //Draws defender
                e.Graphics.FillRectangle(Brushes.Green, defender);

                //Draws player shot
                e.Graphics.FillRectangle(Brushes.White, playerShot);

                //draws invader shot
                e.Graphics.FillRectangle(Brushes.White, invaderShot);

                //Draws invaders
                e.Graphics.FillRectangle(Brushes.Green, invader11);
                e.Graphics.FillRectangle(Brushes.Blue, invader12);
                e.Graphics.FillRectangle(Brushes.Blue, invader13);
                e.Graphics.FillRectangle(Brushes.White, invader14);
                e.Graphics.FillRectangle(Brushes.White, invader15);
                e.Graphics.FillRectangle(Brushes.Green, invader21);
                e.Graphics.FillRectangle(Brushes.Blue, invader22);
                e.Graphics.FillRectangle(Brushes.Blue, invader23);
                e.Graphics.FillRectangle(Brushes.White, invader24);
                e.Graphics.FillRectangle(Brushes.White, invader25);
                e.Graphics.FillRectangle(Brushes.Green, invader31);
                e.Graphics.FillRectangle(Brushes.Blue, invader32);
                e.Graphics.FillRectangle(Brushes.Blue, invader33);
                e.Graphics.FillRectangle(Brushes.White, invader34);
                e.Graphics.FillRectangle(Brushes.White, invader35);
                e.Graphics.FillRectangle(Brushes.Green, invader41);
                e.Graphics.FillRectangle(Brushes.Blue, invader42);
                e.Graphics.FillRectangle(Brushes.Blue, invader43);
                e.Graphics.FillRectangle(Brushes.White, invader44);
                e.Graphics.FillRectangle(Brushes.White, invader45);
                e.Graphics.FillRectangle(Brushes.Green, invader51);
                e.Graphics.FillRectangle(Brushes.Blue, invader52);
                e.Graphics.FillRectangle(Brushes.Blue, invader53);
                e.Graphics.FillRectangle(Brushes.White, invader54);
                e.Graphics.FillRectangle(Brushes.White, invader55);
                e.Graphics.FillRectangle(Brushes.Green, invader61);
                e.Graphics.FillRectangle(Brushes.Blue, invader62);
                e.Graphics.FillRectangle(Brushes.Blue, invader63);
                e.Graphics.FillRectangle(Brushes.White, invader64);
                e.Graphics.FillRectangle(Brushes.White, invader65);

                //Draws ufo
                e.Graphics.FillRectangle(Brushes.Red, ufo);

                //Draws score and lives remaining
                e.Graphics.DrawString("Score: " + score, normalFont, Brushes.Green, this.Width - 200, 50);
                e.Graphics.DrawString("Lives: " + lives, normalFont, Brushes.Green, 100, 50);
            }

            if (screenTracker == 4)//draws end game situation
            {
                //Declares graphics obgects
                Font normalFont = new Font("Arial", 16, FontStyle.Bold);

                //Tells user that game is over
                e.Graphics.DrawString("Game Over", normalFont, Brushes.Red, this.Width / 2, this.Height / 2);

                //Displays score
                e.Graphics.DrawString("Score: " + score, normalFont, Brushes.Red, this.Width / 2, (this.Height / 2) + 100);
            }
        }

        public void movePlayer()
        {
            //Moves player left 
            if (leftArrowDown == true)
            {
                if (xHero > 0)
                {
                    xHero = xHero - playerSpeed;
                }
                //Stops player from going off screen
                else if (xHero <= 0)
                {
                    xHero = 0;
                }
            }

            //Moves player right
            if (rightArrowDown == true)
            {
                if (xHero < this.Width - 10)
                {
                    xHero = xHero + playerSpeed;
                }
                //Stops player from going off screen
                else if (xHero >= this.Width - 10)
                {
                    xHero = this.Width - 10;
                }
            }
        }

        public void checkPlayerShot()
        {
            //Launches a shot if spacebar is pressed
            if (spaceKeyDown == true && shotLaunched == false)
            {
                shotLaunched = true;

                xShot = xHero + heroWidth / 2;
                yShot = yHero;
            }
        }

        public void moveShot()
        {
            //Moves player shot
            if (shotLaunched == true)
            {
                yShot = yShot - playerShotSpeed;
            }

            //Resets shot if it goes off screen
            if (yShot <= 0)
            {
                yShot = 1000;

                shotLaunched = false;
            }
        }

        public void drawBarriers()
        {
            //Declaresd rectangles so they exist in this context
            Rectangle playerShot = new Rectangle(xShot, yShot, shotWidth, shotHeight);
            Rectangle invaderShot = new Rectangle(invaderShotX, invaderShotY, shotWidth, shotHeight);
            Rectangle barrier1 = new Rectangle(barrier1X, barrier1Y, barrierWidth, barrierHeight);
            Rectangle barrier2 = new Rectangle(barrier2X, barrier2Y, barrierWidth, barrierHeight);
            Rectangle barrier3 = new Rectangle(barrier3X, barrier3Y, barrierWidth, barrierHeight);

            //Tracks player shot hitting barrier and takes away barrier health
            if (playerShot.IntersectsWith(barrier1))
            {
                barrier1Hit++;

                shotLaunched = false;

                yShot = 1000;
            }

            else if (playerShot.IntersectsWith(barrier2))
            {
                shotLaunched = false;

                yShot = 1000;

                barrier2Hit++;
            }
            else if (playerShot.IntersectsWith(barrier3))
            {
                shotLaunched = false;

                yShot = 1000;

                barrier3Hit++;
            }
        }

        public void moveInvaders()
        {
            #region Moves Invaders Right
            //Move invaders right
            if (invadersRight == true && restart == false)
            {
                invaderX11 = invaderX11 + invaderSpeed;

                invaderX12 = invaderX12 + invaderSpeed;

                invaderX13 = invaderX13 + invaderSpeed;

                invaderX14 = invaderX14 + invaderSpeed;

                invaderX15 = invaderX15 + invaderSpeed;

                invaderX21 = invaderX21 + invaderSpeed;

                invaderX22 = invaderX22 + invaderSpeed;

                invaderX23 = invaderX23 + invaderSpeed;

                invaderX24 = invaderX24 + invaderSpeed;

                invaderX25 = invaderX25 + invaderSpeed;

                invaderX31 = invaderX31 + invaderSpeed;

                invaderX32 = invaderX32 + invaderSpeed;

                invaderX33 = invaderX33 + invaderSpeed;

                invaderX34 = invaderX34 + invaderSpeed;

                invaderX35 = invaderX35 + invaderSpeed;

                invaderX41 = invaderX41 + invaderSpeed;

                invaderX42 = invaderX42 + invaderSpeed;

                invaderX43 = invaderX43 + invaderSpeed;

                invaderX44 = invaderX44 + invaderSpeed;

                invaderX45 = invaderX45 + invaderSpeed;

                invaderX51 = invaderX51 + invaderSpeed;

                invaderX52 = invaderX52 + invaderSpeed;

                invaderX53 = invaderX53 + invaderSpeed;

                invaderX54 = invaderX54 + invaderSpeed;

                invaderX55 = invaderX55 + invaderSpeed;

                invaderX61 = invaderX61 + invaderSpeed;

                invaderX62 = invaderX62 + invaderSpeed;

                invaderX63 = invaderX63 + invaderSpeed;

                invaderX64 = invaderX64 + invaderSpeed;

                invaderX65 = invaderX65 + invaderSpeed;
            }
            #endregion

            #region move invaders left
            //Moves invaders left
            else if (invadersLeft == true && restart == false)
            {
                invaderX11 = invaderX11 - invaderSpeed;

                invaderX12 = invaderX12 - invaderSpeed;

                invaderX13 = invaderX13 - invaderSpeed;

                invaderX14 = invaderX14 - invaderSpeed;

                invaderX15 = invaderX15 - invaderSpeed;

                invaderX21 = invaderX21 - invaderSpeed;

                invaderX22 = invaderX22 - invaderSpeed;

                invaderX23 = invaderX23 - invaderSpeed;

                invaderX24 = invaderX24 - invaderSpeed;

                invaderX25 = invaderX25 - invaderSpeed;

                invaderX31 = invaderX31 - invaderSpeed;

                invaderX32 = invaderX32 - invaderSpeed;

                invaderX33 = invaderX33 - invaderSpeed;

                invaderX34 = invaderX34 - invaderSpeed;

                invaderX35 = invaderX35 - invaderSpeed;

                invaderX41 = invaderX41 - invaderSpeed;

                invaderX42 = invaderX42 - invaderSpeed;

                invaderX43 = invaderX43 - invaderSpeed;

                invaderX44 = invaderX44 - invaderSpeed;

                invaderX45 = invaderX45 - invaderSpeed;

                invaderX51 = invaderX51 - invaderSpeed;

                invaderX52 = invaderX52 - invaderSpeed;

                invaderX53 = invaderX53 - invaderSpeed;

                invaderX54 = invaderX54 - invaderSpeed;

                invaderX55 = invaderX55 - invaderSpeed;

                invaderX61 = invaderX61 - invaderSpeed;

                invaderX62 = invaderX62 - invaderSpeed;

                invaderX63 = invaderX63 - invaderSpeed;

                invaderX64 = invaderX64 - invaderSpeed;

                invaderX65 = invaderX65 - invaderSpeed;
            }
            #endregion
        }

        public void invaderDown()
        {
            #region Move Invaders down right side
            //Moves invaders down if they meet right side
            if (invaderX11 == this.Width - invaderWidth || invaderX12 == this.Width - invaderWidth || invaderX13 == this.Width - invaderWidth || invaderX14 == this.Width - invaderWidth || invaderX15 == this.Width - invaderWidth || invaderX21 == this.Width - invaderWidth || invaderX22 == this.Width - invaderWidth || invaderX23 == this.Width - invaderWidth || invaderX24 == this.Width - invaderWidth || invaderX25 == this.Width - invaderWidth || invaderX31 == this.Width - invaderWidth || invaderX32 == this.Width - invaderWidth || invaderX33 == this.Width - invaderWidth || invaderX34 == this.Width - invaderWidth || invaderX35 == this.Width - invaderWidth || invaderX41 == this.Width - invaderWidth || invaderX42 == this.Width - invaderWidth || invaderX43 == this.Width - invaderWidth || invaderX44 == this.Width - invaderWidth || invaderX45 == this.Width - invaderWidth || invaderX51 == this.Width - invaderWidth || invaderX52 == this.Width - invaderWidth || invaderX53 == this.Width - invaderWidth || invaderX54 == this.Width - invaderWidth || invaderX55 == this.Width - invaderWidth || invaderX61 == this.Width - invaderWidth || invaderX62 == this.Width - invaderWidth || invaderX63 == this.Width - invaderWidth || invaderX64 == this.Width - invaderWidth || invaderX65 == this.Width - invaderWidth)
            {
                //Moves invaders left
                invadersRight = false;
                invadersLeft = true;

                invaderY11 += invaderHeight;
                invaderY12 += invaderHeight;
                invaderY13 += invaderHeight;
                invaderY14 += invaderHeight;
                invaderY15 += invaderHeight;

                invaderY21 += invaderHeight;
                invaderY22 += invaderHeight;
                invaderY23 += invaderHeight;
                invaderY24 += invaderHeight;
                invaderY25 += invaderHeight;

                invaderY31 += invaderHeight;
                invaderY32 += invaderHeight;
                invaderY33 += invaderHeight;
                invaderY34 += invaderHeight;
                invaderY35 += invaderHeight;

                invaderY41 += invaderHeight;
                invaderY42 += invaderHeight;
                invaderY43 += invaderHeight;
                invaderY44 += invaderHeight;
                invaderY45 += invaderHeight;

                invaderY51 += invaderHeight;
                invaderY52 += invaderHeight;
                invaderY53 += invaderHeight;
                invaderY54 += invaderHeight;
                invaderY55 += invaderHeight;

                invaderY61 += invaderHeight;
                invaderY62 += invaderHeight;
                invaderY63 += invaderHeight;
                invaderY64 += invaderHeight;
                invaderY65 += invaderHeight;
            }
            #endregion

            #region Move Invaders down left side
            //Move invaders down if they meet left side
            else if (invaderX11 == 0 || invaderX12 == 0 || invaderX13 == 0 || invaderX14 == 0 || invaderX15 == 0 || invaderX21 == 0 || invaderX22 == 0 || invaderX23 == 0 || invaderX24 == 0 || invaderX25 == 0 || invaderX31 == 0 || invaderX32 == 0 || invaderX33 == 0 || invaderX34 == 0 || invaderX35 == 0 || invaderX41 == 0 || invaderX42 == 0 || invaderX43 == 0 || invaderX44 == 0 || invaderX45 == 0 || invaderX51 == 0 || invaderX52 == 0 || invaderX53 == 0 || invaderX54 <= 0 || invaderX55 == 0 || invaderX61 == 0 || invaderX62 == 0 || invaderX63 == 0 || invaderX64 == 0 || invaderX65 == 0)
            {
                //Moves invaders right
                invadersRight = true;
                invadersLeft = false;

                invaderY11 += invaderHeight;
                invaderY12 += invaderHeight;
                invaderY13 += invaderHeight;
                invaderY14 += invaderHeight;
                invaderY15 += invaderHeight;

                invaderY21 += invaderHeight;
                invaderY22 += invaderHeight;
                invaderY23 += invaderHeight;
                invaderY24 += invaderHeight;
                invaderY25 += invaderHeight;

                invaderY31 += invaderHeight;
                invaderY32 += invaderHeight;
                invaderY33 += invaderHeight;
                invaderY34 += invaderHeight;
                invaderY35 += invaderHeight;

                invaderY41 += invaderHeight;
                invaderY42 += invaderHeight;
                invaderY43 += invaderHeight;
                invaderY44 += invaderHeight;
                invaderY45 += invaderHeight;

                invaderY51 += invaderHeight;
                invaderY52 += invaderHeight;
                invaderY53 += invaderHeight;
                invaderY54 += invaderHeight;
                invaderY55 += invaderHeight;

                invaderY61 += invaderHeight;
                invaderY62 += invaderHeight;
                invaderY63 += invaderHeight;
                invaderY64 += invaderHeight;
                invaderY65 += invaderHeight;
            }
            #endregion
        }

        public void updateScore()
        {
            //Declares rectangles so they exist in this context
            Rectangle playerShot = new Rectangle(xShot, yShot, shotWidth, shotHeight);
            Rectangle invader11 = new Rectangle(invaderX11, invaderY11, invaderWidth, invaderHeight);
            Rectangle invader12 = new Rectangle(invaderX12, invaderY12, invaderWidth, invaderHeight);
            Rectangle invader13 = new Rectangle(invaderX13, invaderY13, invaderWidth, invaderHeight);
            Rectangle invader14 = new Rectangle(invaderX14, invaderY14, invaderWidth, invaderHeight);
            Rectangle invader15 = new Rectangle(invaderX15, invaderY15, invaderWidth, invaderHeight);
            Rectangle invader21 = new Rectangle(invaderX21, invaderY21, invaderWidth, invaderHeight);
            Rectangle invader22 = new Rectangle(invaderX22, invaderY22, invaderWidth, invaderHeight);
            Rectangle invader23 = new Rectangle(invaderX23, invaderY23, invaderWidth, invaderHeight);
            Rectangle invader24 = new Rectangle(invaderX24, invaderY24, invaderWidth, invaderHeight);
            Rectangle invader25 = new Rectangle(invaderX25, invaderY25, invaderWidth, invaderHeight);
            Rectangle invader31 = new Rectangle(invaderX31, invaderY31, invaderWidth, invaderHeight);
            Rectangle invader32 = new Rectangle(invaderX32, invaderY32, invaderWidth, invaderHeight);
            Rectangle invader33 = new Rectangle(invaderX33, invaderY33, invaderWidth, invaderHeight);
            Rectangle invader34 = new Rectangle(invaderX34, invaderY34, invaderWidth, invaderHeight);
            Rectangle invader35 = new Rectangle(invaderX35, invaderY35, invaderWidth, invaderHeight);
            Rectangle invader41 = new Rectangle(invaderX41, invaderY41, invaderWidth, invaderHeight);
            Rectangle invader42 = new Rectangle(invaderX42, invaderY42, invaderWidth, invaderHeight);
            Rectangle invader43 = new Rectangle(invaderX43, invaderY43, invaderWidth, invaderHeight);
            Rectangle invader44 = new Rectangle(invaderX44, invaderY44, invaderWidth, invaderHeight);
            Rectangle invader45 = new Rectangle(invaderX45, invaderY45, invaderWidth, invaderHeight);
            Rectangle invader51 = new Rectangle(invaderX51, invaderY51, invaderWidth, invaderHeight);
            Rectangle invader52 = new Rectangle(invaderX52, invaderY52, invaderWidth, invaderHeight);
            Rectangle invader53 = new Rectangle(invaderX53, invaderY53, invaderWidth, invaderHeight);
            Rectangle invader54 = new Rectangle(invaderX54, invaderY54, invaderWidth, invaderHeight);
            Rectangle invader55 = new Rectangle(invaderX55, invaderY55, invaderWidth, invaderHeight);
            Rectangle invader61 = new Rectangle(invaderX61, invaderY61, invaderWidth, invaderHeight);
            Rectangle invader62 = new Rectangle(invaderX62, invaderY62, invaderWidth, invaderHeight);
            Rectangle invader63 = new Rectangle(invaderX63, invaderY63, invaderWidth, invaderHeight);
            Rectangle invader64 = new Rectangle(invaderX64, invaderY64, invaderWidth, invaderHeight);
            Rectangle invader65 = new Rectangle(invaderX65, invaderY65, invaderWidth, invaderHeight);

            #region Invader Hits
            //Tracks kills and score increase
            if (playerShot.IntersectsWith(invader11))
            {
                killCounter++;//Adds one to kills

                shotLaunched = false;//Resets shot
                yShot = 1000;

                newLevel = false;//Ensures new level isn't called

                //Moves invader off screen 
                invaderY11 = 2000;
                invaderX11 = 2000;

                //Adds to score
                score += 40;

                //Removes invader from list
                activeInvaders.Remove(1);
            }
            else if (playerShot.IntersectsWith(invader12))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY12 = 2000;

                invaderX12 = 2000;

                score += 20;

                activeInvaders.Remove(2);
            }
            else if (playerShot.IntersectsWith(invader13))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY13 = 2000;

                invaderX13 = 2000;

                score += 20;

                activeInvaders.Remove(2);
            }
            else if (playerShot.IntersectsWith(invader14))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY14 = 2000;

                invaderX14 = 2000;

                score += 10;

                activeInvaders.Remove(3);
            }
            else if (playerShot.IntersectsWith(invader15))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY15 = 2000;

                invaderX15 = 2000;

                score += 10;

                activeInvaders.Remove(4);
            }

            else if (playerShot.IntersectsWith(invader21))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY21 = 2000;

                invaderX21 = 2000;

                score += 40;

                activeInvaders.Remove(5);
            }
            else if (playerShot.IntersectsWith(invader22))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY22 = 2000;

                invaderX22 = 2000;

                score += 20;

                activeInvaders.Remove(6);
            }
            else if (playerShot.IntersectsWith(invader23))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY23 = 2000;

                invaderX23 = 2000;

                score += 20;

                activeInvaders.Remove(7);
            }
            else if (playerShot.IntersectsWith(invader24))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY24 = 2000;

                invaderX24 = 2000;

                score += 10;

                activeInvaders.Remove(8);
            }
            else if (playerShot.IntersectsWith(invader25))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY25 = 2000;

                invaderX25 = 2000;

                score += 10;

                activeInvaders.Remove(10);
            }

            else if (playerShot.IntersectsWith(invader31))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY31 = 2000;

                invaderX31 = 2000;

                score += 40;

                activeInvaders.Remove(11);
            }
            else if (playerShot.IntersectsWith(invader32))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY32 = 2000;

                invaderX32 = 2000;

                score += 20;

                activeInvaders.Remove(12);
            }
            else if (playerShot.IntersectsWith(invader33))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY33 = 2000;

                invaderX33 = 2000;

                score += 20;

                activeInvaders.Remove(13);
            }
            else if (playerShot.IntersectsWith(invader34))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY34 = 2000;

                invaderX34 = 2000;

                score += 10;

                activeInvaders.Remove(14);
            }
            else if (playerShot.IntersectsWith(invader35))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY35 = 2000;

                invaderX35 = 2000;

                score += 10;

                activeInvaders.Remove(15);
            }

            else if (playerShot.IntersectsWith(invader41))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY41 = 2000;

                invaderX41 = 2000;

                score += 40;

                activeInvaders.Remove(16);
            }
            else if (playerShot.IntersectsWith(invader42))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY42 = 2000;

                invaderX42 = 2000;

                score += 20;

                activeInvaders.Remove(17);
            }
            else if (playerShot.IntersectsWith(invader43))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY43 = 2000;

                invaderX43 = 2000;

                score += 20;

                activeInvaders.Remove(18);
            }
            else if (playerShot.IntersectsWith(invader44))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY44 = 2000;

                invaderX44 = 2000;

                score += 10;

                activeInvaders.Remove(19);
            }
            else if (playerShot.IntersectsWith(invader45))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY45 = 2000;

                invaderX45 = 2000;

                score += 10;

                activeInvaders.Remove(20);
            }
            else if (playerShot.IntersectsWith(invader51))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY51 = 2000;

                invaderX51 = 2000;

                score += 40;

                activeInvaders.Remove(21);
            }
            else if (playerShot.IntersectsWith(invader52))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY52 = 2000;

                invaderX52 = 2000;

                score += 20;

                activeInvaders.Remove(22);
            }
            else if (playerShot.IntersectsWith(invader53))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY53 = 2000;

                invaderX53 = 2000;

                score += 20;

                activeInvaders.Remove(23);
            }
            else if (playerShot.IntersectsWith(invader54))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY54 = 2000;

                invaderX54 = 2000;

                score += 10;

                activeInvaders.Remove(24);
            }
            else if (playerShot.IntersectsWith(invader55))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY55 = 2000;

                invaderX55 = 2000;

                score += 10;

                activeInvaders.Remove(25);
            }
            else if (playerShot.IntersectsWith(invader61))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY61 = 2000;

                invaderX61 = 2000;

                score += 40;

                activeInvaders.Remove(26);
            }
            else if (playerShot.IntersectsWith(invader62))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY62 = 2000;

                invaderX62 = 2000;

                score += 20;

                activeInvaders.Remove(27);
            }
            else if (playerShot.IntersectsWith(invader63))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY63 = 2000;

                invaderX63 = 2000;

                score += 20;

                activeInvaders.Remove(28);
            }
            else if (playerShot.IntersectsWith(invader64))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY64 = 2000;

                invaderX64 = 2000;

                score += 10;

                activeInvaders.Remove(29);
            }
            else if (playerShot.IntersectsWith(invader65))
            {
                killCounter++;

                shotLaunched = false;

                newLevel = false;

                yShot = 1000;

                invaderY65 = 2000;

                invaderX65 = 2000;

                score += 10;

                activeInvaders.Remove(30);
            }
            #endregion
        }

        public void levelTracker()
        {
            //Increases level and make level more difficult as time goes on
            if (killCounter == 10 && newLevel == false)
            {
                invaderShotSpeed = 7;
            }

            else if (killCounter == 15 && newLevel == false)
            {
                invaderShotSpeed = 9;
            }

            else if (killCounter == 20 && newLevel == false)
            {
                invaderShotSpeed = 11;
            }

            else if (killCounter == 25 && newLevel == false)
            {
                invaderShotSpeed = 13;
            }
            else if (killCounter == 30 && newLevel == false)
            {
                levelCounter++;

                newLevel = true;

                restart = true;
            }

        }

        public void invaderRestart()
        {
            //Resets invader values each new level
            if (levelCounter == 1 && restart == true)
            {
                //Puts invaders back to original spots
                invaderX11 = 200;
                invaderY11 = 100 + levelCounter * invaderDecrease;
                invaderX12 = 200;
                invaderY12 = 140 + levelCounter * invaderDecrease;
                invaderX13 = 200;
                invaderY13 = 180 + levelCounter * invaderDecrease;
                invaderX14 = 200;
                invaderY14 = 220 + levelCounter * invaderDecrease;
                invaderX15 = 200;
                invaderY15 = 260 + levelCounter * invaderDecrease;
                invaderX21 = 250;
                invaderY21 = 100 + levelCounter * invaderDecrease;
                invaderX22 = 250;
                invaderY22 = 140 + levelCounter * invaderDecrease;
                invaderX23 = 250;
                invaderY23 = 180 + levelCounter * invaderDecrease;
                invaderX24 = 250;
                invaderY24 = 220 + levelCounter * invaderDecrease;
                invaderX25 = 250;
                invaderY25 = 260 + levelCounter * invaderDecrease;
                invaderX31 = 300;
                invaderY31 = 100 + levelCounter * invaderDecrease;
                invaderX32 = 300;
                invaderY32 = 140 + levelCounter * invaderDecrease;
                invaderX33 = 300;
                invaderY33 = 180 + levelCounter * invaderDecrease;
                invaderX34 = 300;
                invaderY34 = 220 + levelCounter * invaderDecrease;
                invaderX35 = 300;
                invaderY35 = 260 + levelCounter * invaderDecrease;
                invaderX41 = 350;
                invaderY41 = 100 + levelCounter * invaderDecrease;
                invaderX42 = 350;
                invaderY42 = 140 + levelCounter * invaderDecrease;
                invaderX43 = 350;
                invaderY43 = 180 + levelCounter * invaderDecrease;
                invaderX44 = 350;
                invaderY44 = 220 + levelCounter * invaderDecrease;
                invaderX45 = 350;
                invaderY45 = 260 + levelCounter * invaderDecrease;
                invaderX51 = 400;
                invaderY51 = 100 + levelCounter * invaderDecrease;
                invaderX52 = 400;
                invaderY52 = 140 + levelCounter * invaderDecrease;
                invaderX53 = 400;
                invaderY53 = 180 + levelCounter * invaderDecrease;
                invaderX54 = 400;
                invaderY54 = 220 + levelCounter * invaderDecrease;
                invaderX55 = 400;
                invaderY55 = 260 + levelCounter * invaderDecrease;
                invaderX61 = 450;
                invaderY61 = 100 + levelCounter * invaderDecrease;
                invaderX62 = 450;
                invaderY62 = 140 + levelCounter * invaderDecrease;
                invaderX63 = 450;
                invaderY63 = 180 + levelCounter * invaderDecrease;
                invaderX64 = 450;
                invaderY64 = 220 + levelCounter * invaderDecrease;
                invaderX65 = 450;
                invaderY65 = 260 + levelCounter * invaderDecrease;

                invadersLeft = false;//Makes invaders move right on restart
                invadersRight = true;

                //Resets booleans for new level
                restart = false;
                ufoLaunched = false;
                newLevel = false;

                //Puts kill counter to 0
                killCounter = 0;

                //Increases score
                score += 1000;

                //Resets ufo
                ufoX = 776;
                ufoDelay = 0;

                //Resets invader shot values
                shotTime = 120;
                invaderShotSpeed = 5;
                activeInvaders.AddRange(activeInvadersBackup);

                //Gives extra life
                lives++;
            }
            else if (levelCounter == 2 && restart == true)
            {
                //Puts invaders back to original spots
                invaderX11 = 200;
                invaderY11 = 100 + levelCounter * invaderDecrease;
                invaderX12 = 200;
                invaderY12 = 140 + levelCounter * invaderDecrease;
                invaderX13 = 200;
                invaderY13 = 180 + levelCounter * invaderDecrease;
                invaderX14 = 200;
                invaderY14 = 220 + levelCounter * invaderDecrease;
                invaderX15 = 200;
                invaderY15 = 260 + levelCounter * invaderDecrease;
                invaderX21 = 250;
                invaderY21 = 100 + levelCounter * invaderDecrease;
                invaderX22 = 250;
                invaderY22 = 140 + levelCounter * invaderDecrease;
                invaderX23 = 250;
                invaderY23 = 180 + levelCounter * invaderDecrease;
                invaderX24 = 250;
                invaderY24 = 220 + levelCounter * invaderDecrease;
                invaderX25 = 250;
                invaderY25 = 260 + levelCounter * invaderDecrease;
                invaderX31 = 300;
                invaderY31 = 100 + levelCounter * invaderDecrease;
                invaderX32 = 300;
                invaderY32 = 140 + levelCounter * invaderDecrease;
                invaderX33 = 300;
                invaderY33 = 180 + levelCounter * invaderDecrease;
                invaderX34 = 300;
                invaderY34 = 220 + levelCounter * invaderDecrease;
                invaderX35 = 300;
                invaderY35 = 260 + levelCounter * invaderDecrease;
                invaderX41 = 350;
                invaderY41 = 100 + levelCounter * invaderDecrease;
                invaderX42 = 350;
                invaderY42 = 140 + levelCounter * invaderDecrease;
                invaderX43 = 350;
                invaderY43 = 180 + levelCounter * invaderDecrease;
                invaderX44 = 350;
                invaderY44 = 220 + levelCounter * invaderDecrease;
                invaderX45 = 350;
                invaderY45 = 260 + levelCounter * invaderDecrease;
                invaderX51 = 400;
                invaderY51 = 100 + levelCounter * invaderDecrease;
                invaderX52 = 400;
                invaderY52 = 140 + levelCounter * invaderDecrease;
                invaderX53 = 400;
                invaderY53 = 180 + levelCounter * invaderDecrease;
                invaderX54 = 400;
                invaderY54 = 220 + levelCounter * invaderDecrease;
                invaderX55 = 400;
                invaderY55 = 260 + levelCounter * invaderDecrease;
                invaderX61 = 450;
                invaderY61 = 100 + levelCounter * invaderDecrease;
                invaderX62 = 450;
                invaderY62 = 140 + levelCounter * invaderDecrease;
                invaderX63 = 450;
                invaderY63 = 180 + levelCounter * invaderDecrease;
                invaderX64 = 450;
                invaderY64 = 220 + levelCounter * invaderDecrease;
                invaderX65 = 450;
                invaderY65 = 260 + levelCounter * invaderDecrease;

                invadersLeft = false;//Makes invaders move right on restart
                invadersRight = true;

                //Resets booleans for new level
                restart = false;
                ufoLaunched = false;
                newLevel = false;

                //Puts kill counter to 0
                killCounter = 0;

                //Increases score
                score += 1000;

                //Resets ufo
                ufoX = 776;
                ufoDelay = 0;

                //Resets invader shot values
                shotTime = 120;
                invaderShotSpeed = 5;
                activeInvaders.AddRange(activeInvadersBackup);

                //Gives extra life
                lives++;
            }
            else if (levelCounter == 3 && restart == true)
            {
                //Puts invaders back to original spots
                invaderX11 = 200;
                invaderY11 = 100 + levelCounter * invaderDecrease;
                invaderX12 = 200;
                invaderY12 = 140 + levelCounter * invaderDecrease;
                invaderX13 = 200;
                invaderY13 = 180 + levelCounter * invaderDecrease;
                invaderX14 = 200;
                invaderY14 = 220 + levelCounter * invaderDecrease;
                invaderX15 = 200;
                invaderY15 = 260 + levelCounter * invaderDecrease;
                invaderX21 = 250;
                invaderY21 = 100 + levelCounter * invaderDecrease;
                invaderX22 = 250;
                invaderY22 = 140 + levelCounter * invaderDecrease;
                invaderX23 = 250;
                invaderY23 = 180 + levelCounter * invaderDecrease;
                invaderX24 = 250;
                invaderY24 = 220 + levelCounter * invaderDecrease;
                invaderX25 = 250;
                invaderY25 = 260 + levelCounter * invaderDecrease;
                invaderX31 = 300;
                invaderY31 = 100 + levelCounter * invaderDecrease;
                invaderX32 = 300;
                invaderY32 = 140 + levelCounter * invaderDecrease;
                invaderX33 = 300;
                invaderY33 = 180 + levelCounter * invaderDecrease;
                invaderX34 = 300;
                invaderY34 = 220 + levelCounter * invaderDecrease;
                invaderX35 = 300;
                invaderY35 = 260 + levelCounter * invaderDecrease;
                invaderX41 = 350;
                invaderY41 = 100 + levelCounter * invaderDecrease;
                invaderX42 = 350;
                invaderY42 = 140 + levelCounter * invaderDecrease;
                invaderX43 = 350;
                invaderY43 = 180 + levelCounter * invaderDecrease;
                invaderX44 = 350;
                invaderY44 = 220 + levelCounter * invaderDecrease;
                invaderX45 = 350;
                invaderY45 = 260 + levelCounter * invaderDecrease;
                invaderX51 = 400;
                invaderY51 = 100 + levelCounter * invaderDecrease;
                invaderX52 = 400;
                invaderY52 = 140 + levelCounter * invaderDecrease;
                invaderX53 = 400;
                invaderY53 = 180 + levelCounter * invaderDecrease;
                invaderX54 = 400;
                invaderY54 = 220 + levelCounter * invaderDecrease;
                invaderX55 = 400;
                invaderY55 = 260 + levelCounter * invaderDecrease;
                invaderX61 = 450;
                invaderY61 = 100 + levelCounter * invaderDecrease;
                invaderX62 = 450;
                invaderY62 = 140 + levelCounter * invaderDecrease;
                invaderX63 = 450;
                invaderY63 = 180 + levelCounter * invaderDecrease;
                invaderX64 = 450;
                invaderY64 = 220 + levelCounter * invaderDecrease;
                invaderX65 = 450;
                invaderY65 = 260 + levelCounter * invaderDecrease;

                invadersLeft = false;//Makes invaders move right on restart
                invadersRight = true;

                //Resets booleans for new level
                restart = false;
                ufoLaunched = false;
                newLevel = false;

                //Puts kill counter to 0
                killCounter = 0;

                //Increases score
                score += 1000;

                //Resets ufo
                ufoX = 776;
                ufoDelay = 0;

                //Resets invader shot values
                shotTime = 120;
                invaderShotSpeed = 5;
                activeInvaders.AddRange(activeInvadersBackup);

                //Gives extra life
                lives++;
            }
            else if (levelCounter == 4 && restart == true)
            {
                //Puts invaders back to original spots
                invaderX11 = 200;
                invaderY11 = 100 + levelCounter * invaderDecrease;
                invaderX12 = 200;
                invaderY12 = 140 + levelCounter * invaderDecrease;
                invaderX13 = 200;
                invaderY13 = 180 + levelCounter * invaderDecrease;
                invaderX14 = 200;
                invaderY14 = 220 + levelCounter * invaderDecrease;
                invaderX15 = 200;
                invaderY15 = 260 + levelCounter * invaderDecrease;
                invaderX21 = 250;
                invaderY21 = 100 + levelCounter * invaderDecrease;
                invaderX22 = 250;
                invaderY22 = 140 + levelCounter * invaderDecrease;
                invaderX23 = 250;
                invaderY23 = 180 + levelCounter * invaderDecrease;
                invaderX24 = 250;
                invaderY24 = 220 + levelCounter * invaderDecrease;
                invaderX25 = 250;
                invaderY25 = 260 + levelCounter * invaderDecrease;
                invaderX31 = 300;
                invaderY31 = 100 + levelCounter * invaderDecrease;
                invaderX32 = 300;
                invaderY32 = 140 + levelCounter * invaderDecrease;
                invaderX33 = 300;
                invaderY33 = 180 + levelCounter * invaderDecrease;
                invaderX34 = 300;
                invaderY34 = 220 + levelCounter * invaderDecrease;
                invaderX35 = 300;
                invaderY35 = 260 + levelCounter * invaderDecrease;
                invaderX41 = 350;
                invaderY41 = 100 + levelCounter * invaderDecrease;
                invaderX42 = 350;
                invaderY42 = 140 + levelCounter * invaderDecrease;
                invaderX43 = 350;
                invaderY43 = 180 + levelCounter * invaderDecrease;
                invaderX44 = 350;
                invaderY44 = 220 + levelCounter * invaderDecrease;
                invaderX45 = 350;
                invaderY45 = 260 + levelCounter * invaderDecrease;
                invaderX51 = 400;
                invaderY51 = 100 + levelCounter * invaderDecrease;
                invaderX52 = 400;
                invaderY52 = 140 + levelCounter * invaderDecrease;
                invaderX53 = 400;
                invaderY53 = 180 + levelCounter * invaderDecrease;
                invaderX54 = 400;
                invaderY54 = 220 + levelCounter * invaderDecrease;
                invaderX55 = 400;
                invaderY55 = 260 + levelCounter * invaderDecrease;
                invaderX61 = 450;
                invaderY61 = 100 + levelCounter * invaderDecrease;
                invaderX62 = 450;
                invaderY62 = 140 + levelCounter * invaderDecrease;
                invaderX63 = 450;
                invaderY63 = 180 + levelCounter * invaderDecrease;
                invaderX64 = 450;
                invaderY64 = 220 + levelCounter * invaderDecrease;
                invaderX65 = 450;
                invaderY65 = 260 + levelCounter * invaderDecrease;

                invadersLeft = false;//Makes invaders move right on restart
                invadersRight = true;

                //Resets booleans for new level
                restart = false;
                ufoLaunched = false;
                newLevel = false;

                //Puts kill counter to 0
                killCounter = 0;

                //Increases score
                score += 1000;

                //Resets ufo
                ufoX = 776;
                ufoDelay = 0;

                //Resets invader shot values
                shotTime = 120;
                invaderShotSpeed = 5;
                activeInvaders.AddRange(activeInvadersBackup);

                //Gives extra life
                lives++;
            }

            else if (levelCounter == 5 && restart == true)
            {
                //Puts invaders back to original spots
                invaderX11 = 200;
                invaderY11 = 100 + levelCounter * invaderDecrease;
                invaderX12 = 200;
                invaderY12 = 140 + levelCounter * invaderDecrease;
                invaderX13 = 200;
                invaderY13 = 180 + levelCounter * invaderDecrease;
                invaderX14 = 200;
                invaderY14 = 220 + levelCounter * invaderDecrease;
                invaderX15 = 200;
                invaderY15 = 260 + levelCounter * invaderDecrease;
                invaderX21 = 250;
                invaderY21 = 100 + levelCounter * invaderDecrease;
                invaderX22 = 250;
                invaderY22 = 140 + levelCounter * invaderDecrease;
                invaderX23 = 250;
                invaderY23 = 180 + levelCounter * invaderDecrease;
                invaderX24 = 250;
                invaderY24 = 220 + levelCounter * invaderDecrease;
                invaderX25 = 250;
                invaderY25 = 260 + levelCounter * invaderDecrease;
                invaderX31 = 300;
                invaderY31 = 100 + levelCounter * invaderDecrease;
                invaderX32 = 300;
                invaderY32 = 140 + levelCounter * invaderDecrease;
                invaderX33 = 300;
                invaderY33 = 180 + levelCounter * invaderDecrease;
                invaderX34 = 300;
                invaderY34 = 220 + levelCounter * invaderDecrease;
                invaderX35 = 300;
                invaderY35 = 260 + levelCounter * invaderDecrease;
                invaderX41 = 350;
                invaderY41 = 100 + levelCounter * invaderDecrease;
                invaderX42 = 350;
                invaderY42 = 140 + levelCounter * invaderDecrease;
                invaderX43 = 350;
                invaderY43 = 180 + levelCounter * invaderDecrease;
                invaderX44 = 350;
                invaderY44 = 220 + levelCounter * invaderDecrease;
                invaderX45 = 350;
                invaderY45 = 260 + levelCounter * invaderDecrease;
                invaderX51 = 400;
                invaderY51 = 100 + levelCounter * invaderDecrease;
                invaderX52 = 400;
                invaderY52 = 140 + levelCounter * invaderDecrease;
                invaderX53 = 400;
                invaderY53 = 180 + levelCounter * invaderDecrease;
                invaderX54 = 400;
                invaderY54 = 220 + levelCounter * invaderDecrease;
                invaderX55 = 400;
                invaderY55 = 260 + levelCounter * invaderDecrease;
                invaderX61 = 450;
                invaderY61 = 100 + levelCounter * invaderDecrease;
                invaderX62 = 450;
                invaderY62 = 140 + levelCounter * invaderDecrease;
                invaderX63 = 450;
                invaderY63 = 180 + levelCounter * invaderDecrease;
                invaderX64 = 450;
                invaderY64 = 220 + levelCounter * invaderDecrease;
                invaderX65 = 450;
                invaderY65 = 260 + levelCounter * invaderDecrease;

                invadersLeft = false;//Makes invaders move right on restart
                invadersRight = true;

                //Resets booleans for new level
                restart = false;
                ufoLaunched = false;
                newLevel = false;

                //Puts kill counter to 0
                killCounter = 0;

                //Increases score
                score += 1000;

                //Resets ufo
                ufoX = 776;
                ufoDelay = 0;

                //Resets invader shot values
                shotTime = 120;
                invaderShotSpeed = 5;
                activeInvaders.AddRange(activeInvadersBackup);

                //Gives extra life
                lives++;
            }

            else if (levelCounter == 6 && restart == true)
            {
                //Puts invaders back to original spots
                invaderX11 = 200;
                invaderY11 = 100 + levelCounter * invaderDecrease;
                invaderX12 = 200;
                invaderY12 = 140 + levelCounter * invaderDecrease;
                invaderX13 = 200;
                invaderY13 = 180 + levelCounter * invaderDecrease;
                invaderX14 = 200;
                invaderY14 = 220 + levelCounter * invaderDecrease;
                invaderX15 = 200;
                invaderY15 = 260 + levelCounter * invaderDecrease;
                invaderX21 = 250;
                invaderY21 = 100 + levelCounter * invaderDecrease;
                invaderX22 = 250;
                invaderY22 = 140 + levelCounter * invaderDecrease;
                invaderX23 = 250;
                invaderY23 = 180 + levelCounter * invaderDecrease;
                invaderX24 = 250;
                invaderY24 = 220 + levelCounter * invaderDecrease;
                invaderX25 = 250;
                invaderY25 = 260 + levelCounter * invaderDecrease;
                invaderX31 = 300;
                invaderY31 = 100 + levelCounter * invaderDecrease;
                invaderX32 = 300;
                invaderY32 = 140 + levelCounter * invaderDecrease;
                invaderX33 = 300;
                invaderY33 = 180 + levelCounter * invaderDecrease;
                invaderX34 = 300;
                invaderY34 = 220 + levelCounter * invaderDecrease;
                invaderX35 = 300;
                invaderY35 = 260 + levelCounter * invaderDecrease;
                invaderX41 = 350;
                invaderY41 = 100 + levelCounter * invaderDecrease;
                invaderX42 = 350;
                invaderY42 = 140 + levelCounter * invaderDecrease;
                invaderX43 = 350;
                invaderY43 = 180 + levelCounter * invaderDecrease;
                invaderX44 = 350;
                invaderY44 = 220 + levelCounter * invaderDecrease;
                invaderX45 = 350;
                invaderY45 = 260 + levelCounter * invaderDecrease;
                invaderX51 = 400;
                invaderY51 = 100 + levelCounter * invaderDecrease;
                invaderX52 = 400;
                invaderY52 = 140 + levelCounter * invaderDecrease;
                invaderX53 = 400;
                invaderY53 = 180 + levelCounter * invaderDecrease;
                invaderX54 = 400;
                invaderY54 = 220 + levelCounter * invaderDecrease;
                invaderX55 = 400;
                invaderY55 = 260 + levelCounter * invaderDecrease;
                invaderX61 = 450;
                invaderY61 = 100 + levelCounter * invaderDecrease;
                invaderX62 = 450;
                invaderY62 = 140 + levelCounter * invaderDecrease;
                invaderX63 = 450;
                invaderY63 = 180 + levelCounter * invaderDecrease;
                invaderX64 = 450;
                invaderY64 = 220 + levelCounter * invaderDecrease;
                invaderX65 = 450;
                invaderY65 = 260 + levelCounter * invaderDecrease;

                invadersLeft = false;//Makes invaders move right on restart
                invadersRight = true;

                //Resets booleans for new level
                restart = false;
                ufoLaunched = false;
                newLevel = false;

                //Puts kill counter to 0
                killCounter = 0;

                //Increases score
                score += 1000;

                //Resets ufo
                ufoX = 776;
                ufoDelay = 0;

                //Resets invader shot values
                shotTime = 120;
                invaderShotSpeed = 5;
                activeInvaders.AddRange(activeInvadersBackup);

                //Gives extra life
                lives++;
            }

            else if (levelCounter == 7 && restart == true)
            {
                //Puts invaders back to original spots
                invaderX11 = 200;
                invaderY11 = 100 + levelCounter * invaderDecrease;
                invaderX12 = 200;
                invaderY12 = 140 + levelCounter * invaderDecrease;
                invaderX13 = 200;
                invaderY13 = 180 + levelCounter * invaderDecrease;
                invaderX14 = 200;
                invaderY14 = 220 + levelCounter * invaderDecrease;
                invaderX15 = 200;
                invaderY15 = 260 + levelCounter * invaderDecrease;
                invaderX21 = 250;
                invaderY21 = 100 + levelCounter * invaderDecrease;
                invaderX22 = 250;
                invaderY22 = 140 + levelCounter * invaderDecrease;
                invaderX23 = 250;
                invaderY23 = 180 + levelCounter * invaderDecrease;
                invaderX24 = 250;
                invaderY24 = 220 + levelCounter * invaderDecrease;
                invaderX25 = 250;
                invaderY25 = 260 + levelCounter * invaderDecrease;
                invaderX31 = 300;
                invaderY31 = 100 + levelCounter * invaderDecrease;
                invaderX32 = 300;
                invaderY32 = 140 + levelCounter * invaderDecrease;
                invaderX33 = 300;
                invaderY33 = 180 + levelCounter * invaderDecrease;
                invaderX34 = 300;
                invaderY34 = 220 + levelCounter * invaderDecrease;
                invaderX35 = 300;
                invaderY35 = 260 + levelCounter * invaderDecrease;
                invaderX41 = 350;
                invaderY41 = 100 + levelCounter * invaderDecrease;
                invaderX42 = 350;
                invaderY42 = 140 + levelCounter * invaderDecrease;
                invaderX43 = 350;
                invaderY43 = 180 + levelCounter * invaderDecrease;
                invaderX44 = 350;
                invaderY44 = 220 + levelCounter * invaderDecrease;
                invaderX45 = 350;
                invaderY45 = 260 + levelCounter * invaderDecrease;
                invaderX51 = 400;
                invaderY51 = 100 + levelCounter * invaderDecrease;
                invaderX52 = 400;
                invaderY52 = 140 + levelCounter * invaderDecrease;
                invaderX53 = 400;
                invaderY53 = 180 + levelCounter * invaderDecrease;
                invaderX54 = 400;
                invaderY54 = 220 + levelCounter * invaderDecrease;
                invaderX55 = 400;
                invaderY55 = 260 + levelCounter * invaderDecrease;
                invaderX61 = 450;
                invaderY61 = 100 + levelCounter * invaderDecrease;
                invaderX62 = 450;
                invaderY62 = 140 + levelCounter * invaderDecrease;
                invaderX63 = 450;
                invaderY63 = 180 + levelCounter * invaderDecrease;
                invaderX64 = 450;
                invaderY64 = 220 + levelCounter * invaderDecrease;
                invaderX65 = 450;
                invaderY65 = 260 + levelCounter * invaderDecrease;

                invadersLeft = false;//Makes invaders move right on restart
                invadersRight = true;

                //Resets booleans for new level
                restart = false;
                ufoLaunched = false;
                newLevel = false;

                //Puts kill counter to 0
                killCounter = 0;

                //Increases score
                score += 1000;

                //Resets ufo
                ufoX = 776;
                ufoDelay = 0;

                //Resets invader shot values
                shotTime = 120;
                invaderShotSpeed = 5;
                activeInvaders.AddRange(activeInvadersBackup);

                //Gives extra life
                lives++;
            }

            else if (levelCounter == 8 && restart == true)
            {
                //Puts invaders back to original spots
                invaderX11 = 200;
                invaderY11 = 100 + levelCounter * invaderDecrease;
                invaderX12 = 200;
                invaderY12 = 140 + levelCounter * invaderDecrease;
                invaderX13 = 200;
                invaderY13 = 180 + levelCounter * invaderDecrease;
                invaderX14 = 200;
                invaderY14 = 220 + levelCounter * invaderDecrease;
                invaderX15 = 200;
                invaderY15 = 260 + levelCounter * invaderDecrease;
                invaderX21 = 250;
                invaderY21 = 100 + levelCounter * invaderDecrease;
                invaderX22 = 250;
                invaderY22 = 140 + levelCounter * invaderDecrease;
                invaderX23 = 250;
                invaderY23 = 180 + levelCounter * invaderDecrease;
                invaderX24 = 250;
                invaderY24 = 220 + levelCounter * invaderDecrease;
                invaderX25 = 250;
                invaderY25 = 260 + levelCounter * invaderDecrease;
                invaderX31 = 300;
                invaderY31 = 100 + levelCounter * invaderDecrease;
                invaderX32 = 300;
                invaderY32 = 140 + levelCounter * invaderDecrease;
                invaderX33 = 300;
                invaderY33 = 180 + levelCounter * invaderDecrease;
                invaderX34 = 300;
                invaderY34 = 220 + levelCounter * invaderDecrease;
                invaderX35 = 300;
                invaderY35 = 260 + levelCounter * invaderDecrease;
                invaderX41 = 350;
                invaderY41 = 100 + levelCounter * invaderDecrease;
                invaderX42 = 350;
                invaderY42 = 140 + levelCounter * invaderDecrease;
                invaderX43 = 350;
                invaderY43 = 180 + levelCounter * invaderDecrease;
                invaderX44 = 350;
                invaderY44 = 220 + levelCounter * invaderDecrease;
                invaderX45 = 350;
                invaderY45 = 260 + levelCounter * invaderDecrease;
                invaderX51 = 400;
                invaderY51 = 100 + levelCounter * invaderDecrease;
                invaderX52 = 400;
                invaderY52 = 140 + levelCounter * invaderDecrease;
                invaderX53 = 400;
                invaderY53 = 180 + levelCounter * invaderDecrease;
                invaderX54 = 400;
                invaderY54 = 220 + levelCounter * invaderDecrease;
                invaderX55 = 400;
                invaderY55 = 260 + levelCounter * invaderDecrease;
                invaderX61 = 450;
                invaderY61 = 100 + levelCounter * invaderDecrease;
                invaderX62 = 450;
                invaderY62 = 140 + levelCounter * invaderDecrease;
                invaderX63 = 450;
                invaderY63 = 180 + levelCounter * invaderDecrease;
                invaderX64 = 450;
                invaderY64 = 220 + levelCounter * invaderDecrease;
                invaderX65 = 450;
                invaderY65 = 260 + levelCounter * invaderDecrease;

                invadersLeft = false;//Makes invaders move right on restart
                invadersRight = true;

                //Resets booleans for new level
                restart = false;
                ufoLaunched = false;
                newLevel = false;

                //Puts kill counter to 0
                killCounter = 0;

                //Increases score
                score += 1000;

                //Resets ufo
                ufoX = 776;
                ufoDelay = 0;

                //Resets invader shot values
                shotTime = 120;
                invaderShotSpeed = 5;
                activeInvaders.AddRange(activeInvadersBackup);

                //Gives extra life
                lives++;

            }
            else if (levelCounter == 9 && restart == true)
            {
                //Puts invaders back to original spots
                invaderX11 = 200;
                invaderY11 = 100 + levelCounter * invaderDecrease;
                invaderX12 = 200;
                invaderY12 = 140 + levelCounter * invaderDecrease;
                invaderX13 = 200;
                invaderY13 = 180 + levelCounter * invaderDecrease;
                invaderX14 = 200;
                invaderY14 = 220 + levelCounter * invaderDecrease;
                invaderX15 = 200;
                invaderY15 = 260 + levelCounter * invaderDecrease;
                invaderX21 = 250;
                invaderY21 = 100 + levelCounter * invaderDecrease;
                invaderX22 = 250;
                invaderY22 = 140 + levelCounter * invaderDecrease;
                invaderX23 = 250;
                invaderY23 = 180 + levelCounter * invaderDecrease;
                invaderX24 = 250;
                invaderY24 = 220 + levelCounter * invaderDecrease;
                invaderX25 = 250;
                invaderY25 = 260 + levelCounter * invaderDecrease;
                invaderX31 = 300;
                invaderY31 = 100 + levelCounter * invaderDecrease;
                invaderX32 = 300;
                invaderY32 = 140 + levelCounter * invaderDecrease;
                invaderX33 = 300;
                invaderY33 = 180 + levelCounter * invaderDecrease;
                invaderX34 = 300;
                invaderY34 = 220 + levelCounter * invaderDecrease;
                invaderX35 = 300;
                invaderY35 = 260 + levelCounter * invaderDecrease;
                invaderX41 = 350;
                invaderY41 = 100 + levelCounter * invaderDecrease;
                invaderX42 = 350;
                invaderY42 = 140 + levelCounter * invaderDecrease;
                invaderX43 = 350;
                invaderY43 = 180 + levelCounter * invaderDecrease;
                invaderX44 = 350;
                invaderY44 = 220 + levelCounter * invaderDecrease;
                invaderX45 = 350;
                invaderY45 = 260 + levelCounter * invaderDecrease;
                invaderX51 = 400;
                invaderY51 = 100 + levelCounter * invaderDecrease;
                invaderX52 = 400;
                invaderY52 = 140 + levelCounter * invaderDecrease;
                invaderX53 = 400;
                invaderY53 = 180 + levelCounter * invaderDecrease;
                invaderX54 = 400;
                invaderY54 = 220 + levelCounter * invaderDecrease;
                invaderX55 = 400;
                invaderY55 = 260 + levelCounter * invaderDecrease;
                invaderX61 = 450;
                invaderY61 = 100 + levelCounter * invaderDecrease;
                invaderX62 = 450;
                invaderY62 = 140 + levelCounter * invaderDecrease;
                invaderX63 = 450;
                invaderY63 = 180 + levelCounter * invaderDecrease;
                invaderX64 = 450;
                invaderY64 = 220 + levelCounter * invaderDecrease;
                invaderX65 = 450;
                invaderY65 = 260 + levelCounter * invaderDecrease;

                invadersLeft = false;//Makes invaders move right on restart
                invadersRight = true;

                //Resets booleans for new level
                restart = false;
                ufoLaunched = false;
                newLevel = false;

                //Puts kill counter to 0
                killCounter = 0;

                //Increases score
                score += 1000;

                //Resets ufo
                ufoX = 776;
                ufoDelay = 0;

                //Resets invader shot values
                shotTime = 120;
                invaderShotSpeed = 5;
                activeInvaders.AddRange(activeInvadersBackup);

                //Gives extra life
                lives++;
            }
            else if (levelCounter == 10 && restart == true)
            {
                lives = 0;//Ends game 
            }
        }

        public void ufoSpawn()
        {
            ufoDelay++;//Adds to ufoDelay

            if (ufoDelay == 600)//Spawns ufo every 600 cycles
            {
                ufoLaunched = true;//Launches ufo
            }
        }

        public void ufoMovement()
        {
            //Moves ufo
            if (ufoLaunched)
            {
                ufoX = ufoX - ufoSpeed;

                if (ufoX == 0 - ufoWidth)//Restes ufo when it touches the left side
                {
                    ufoX = 776;

                    ufoDelay = 0;

                    ufoLaunched = false;
                }
            }
        }

        public void ufoDestruction()
        {
            //Declares rectangles so they exist in this context
            Rectangle playerShot = new Rectangle(xShot, yShot, shotWidth, shotHeight);
            Rectangle ufo = new Rectangle(ufoX, ufoY, ufoWidth, ufoHeight);

            if (playerShot.IntersectsWith(ufo))//Allows ufo to be destroyed
            {
                score = score + ufoScore;

                //Resets ufo
                ufoLaunched = false;
                ufoDelay = 0;
                ufoX = 776;

                yShot = 1000;//Resets player shot
                shotLaunched = false;
            }
        }

        public void randomUfoScore()
        {
            preUfoScore = randGen.Next(1, 7);//Generates a random number

            //Generates a random score for the ufo
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

        public void updateBarriers()
        {
            //Destroys barriers if hit enough times
            if (barrier1Hit == 25)
            {
                barrier1Y = 1000;
            }
            else if (barrier2Hit == 25)
            {
                barrier2Y = 1000;
            }
            else if (barrier3Hit == 25)
            {
                barrier3Y = 1000;
            }
        }

        public void invaderShotGeneration()
        {
            nextInvadershot++;//Adds to delay on ufo shot

            if (nextInvadershot == shotTime)//launches shot if enough time has passed
            {
                nextInvadershot = 0;//Resets delay 

                int temp = randGen.Next(0, activeInvaders.Count());//Gets next random value from list
                int temp2 = activeInvaders[temp];//Adds random value to new list

                //Decides where to shoot 
                if (temp2 == 1)
                {
                    invaderShotX = invaderX11 - invaderWidth / 2;//Shoots from middle of invader

                    invaderShotY = invaderY11;//Puts shot in correct position

                    invaderShotFired = true;//Launches shot
                }
                else if (temp2 == 2)
                {
                    invaderShotX = invaderX12 - invaderWidth / 2;

                    invaderShotY = invaderY12;

                    invaderShotFired = true;
                }
                else if (temp2 == 3)
                {
                    invaderShotX = invaderX13 - invaderWidth / 2;

                    invaderShotY = invaderY13;

                    invaderShotFired = true;
                }
                else if (temp2 == 4)
                {
                    invaderShotX = invaderX14 - invaderWidth / 2;

                    invaderShotY = invaderY14;

                    invaderShotFired = true;
                }
                else if (temp2 == 5)
                {
                    invaderShotX = invaderX15 - invaderWidth / 2;

                    invaderShotY = invaderY15;

                    invaderShotFired = true;
                }
                else if (temp2 == 6)
                {
                    invaderShotX = invaderX21 - invaderWidth / 2;

                    invaderShotY = invaderY21;

                    invaderShotFired = true;
                }
                else if (temp2 == 7)
                {
                    invaderShotX = invaderX22 - invaderWidth / 2;

                    invaderShotY = invaderY22;

                    invaderShotFired = true;
                }
                else if (temp2 == 8)
                {
                    invaderShotX = invaderX23 - invaderWidth / 2;

                    invaderShotY = invaderY23;

                    invaderShotFired = true;
                }
                else if (temp2 == 9)
                {
                    invaderShotX = invaderX24 - invaderWidth / 2;

                    invaderShotY = invaderY24;

                    invaderShotFired = true;
                }
                else if (temp2 == 10)
                {
                    invaderShotX = invaderX25 - invaderWidth / 2;

                    invaderShotY = invaderY25;

                    invaderShotFired = true;
                }
                else if (temp2 == 11)
                {
                    invaderShotX = invaderX31 - invaderWidth / 2;

                    invaderShotY = invaderY31;

                    invaderShotFired = true;
                }
                else if (temp2 == 12)
                {
                    invaderShotX = invaderX32 - invaderWidth / 2;

                    invaderShotY = invaderY32;

                    invaderShotFired = true;
                }
                else if (temp2 == 13)
                {
                    invaderShotX = invaderX33 - invaderWidth / 2;

                    invaderShotY = invaderY33;

                    invaderShotFired = true;
                }
                else if (temp2 == 14)
                {
                    invaderShotX = invaderX34 - invaderWidth / 2;

                    invaderShotY = invaderY34;

                    invaderShotFired = true;
                }
                else if (temp2 == 15)
                {
                    invaderShotX = invaderX35 - invaderWidth / 2;

                    invaderShotY = invaderY35;

                    invaderShotFired = true;
                }
                else if (temp2 == 16)
                {
                    invaderShotX = invaderX41 - invaderWidth / 2;

                    invaderShotY = invaderY41;

                    invaderShotFired = true;
                }
                else if (temp2 == 17)
                {
                    invaderShotX = invaderX42 - invaderWidth / 2;

                    invaderShotY = invaderY42;

                    invaderShotFired = true;
                }
                else if (temp2 == 18)
                {
                    invaderShotX = invaderX43 - invaderWidth / 2;

                    invaderShotY = invaderY43;

                    invaderShotFired = true;
                }
                else if (temp2 == 19)
                {
                    invaderShotX = invaderX44 - invaderWidth / 2;

                    invaderShotY = invaderY44;

                    invaderShotFired = true;
                }
                else if (temp2 == 20)
                {
                    invaderShotX = invaderX45 - invaderWidth / 2;

                    invaderShotY = invaderY45;

                    invaderShotFired = true;
                }
                else if (temp2 == 21)
                {
                    invaderShotX = invaderX51 - invaderWidth / 2;

                    invaderShotY = invaderY51;

                    invaderShotFired = true;
                }
                else if (temp2 == 22)
                {
                    invaderShotX = invaderX52 - invaderWidth / 2;

                    invaderShotY = invaderY52;

                    invaderShotFired = true;
                }
                else if (temp2 == 23)
                {
                    invaderShotX = invaderX53 - invaderWidth / 2;

                    invaderShotY = invaderY53;

                    invaderShotFired = true;
                }
                else if (temp2 == 24)
                {
                    invaderShotX = invaderX54 - invaderWidth / 2;

                    invaderShotY = invaderY54;

                    invaderShotFired = true;
                }
                else if (temp2 == 25)
                {
                    invaderShotX = invaderX55 - invaderWidth / 2;

                    invaderShotY = invaderY55;

                    invaderShotFired = true;
                }
                else if (temp2 == 26)
                {
                    invaderShotX = invaderX61 - invaderWidth / 2;

                    invaderShotY = invaderY61;

                    invaderShotFired = true;
                }
                else if (temp2 == 27)
                {
                    invaderShotX = invaderX62 - invaderWidth / 2;

                    invaderShotY = invaderY62;

                    invaderShotFired = true;
                }
                else if (temp2 == 28)
                {
                    invaderShotX = invaderX63 - invaderWidth / 2;

                    invaderShotY = invaderY63;

                    invaderShotFired = true;
                }
                else if (temp2 == 29)
                {
                    invaderShotX = invaderX64 - invaderWidth / 2;

                    invaderShotY = invaderY64;

                    invaderShotFired = true;
                }
                else if (temp2 == 30)
                {
                    invaderShotX = invaderX65 - invaderWidth / 2;

                    invaderShotY = invaderY65;

                    invaderShotFired = true;
                }
            }
        }

        public void invaderShotMovement()
        {
            //Moves invader shot
            if (invaderShotFired)
            {
                invaderShotY = invaderShotY + invaderShotSpeed;
            }
        }

        public void invaderShotCollision()
        {
            //Declares rectangles so they exist in this context
            Rectangle invaderShot = new Rectangle(invaderShotX, invaderShotY, shotWidth, shotHeight);
            Rectangle barrier1 = new Rectangle(barrier1X, barrier1Y, barrierWidth, barrierHeight);
            Rectangle barrier2 = new Rectangle(barrier2X, barrier2Y, barrierWidth, barrierHeight);
            Rectangle barrier3 = new Rectangle(barrier3X, barrier3Y, barrierWidth, barrierHeight);
            Rectangle defender = new Rectangle(xHero, yHero, heroWidth, heroHeight);

            if (invaderShot.IntersectsWith(barrier1))//Tracks invader collisions with barrier
            {
                barrier1Hit++;//Takes away health of barrier

                invaderShotFired = false;//Resets invader shot
                invaderShotY = 1000;
            }

            else if (invaderShot.IntersectsWith(barrier2))//Tracks invader collisions with barrier
            {
                invaderShotFired = false;

                invaderShotFired = false;//Resets invader shot
                invaderShotY = 1000;
            }
            else if (invaderShot.IntersectsWith(barrier3))//Tracks invader collisions with barrier
            {
                invaderShotFired = false;

                invaderShotFired = false;//Resets invader shot
                invaderShotY = 1000;
            }
            else if (invaderShot.IntersectsWith(defender))//Tracks invader collisions with player
            {
                invaderShotFired = false;//Resets invader shot
                invaderShotY = 1000;

                lives--;//Player loses life
            }
            else if (invaderShotY == this.Height - 50)
            {
                invaderShotFired = false;//Resets invader shot
                invaderShotY = 1000;
            }
        }

        public void gameEnd()
        {

            if (lives == 0)//Ends game if player runs out if lives
            {
                screenTracker = 4;

                gameEngine.Stop();

                gameEngine.Enabled = false;
            }
        }

    }
}





    


