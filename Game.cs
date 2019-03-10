using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Space_Invaders
{
    class Game : Form
    {
        private static int enemiesperLine = 8;
        private static int enemiesperRow = 4;
        private Enemy[,] enemy = new Enemy[enemiesperLine,enemiesperRow];
        private Player player;
        private PictureBox PcbGameScreen;
        private Bullet bullet = null;
        bool endofScreen = false;
        bool isBullet = false;
        bool endofgame = false;

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool GetAsyncKeyState(Keys vKey);

        public Game(PictureBox GameScreen)
        {
            PcbGameScreen = GameScreen;
            float enemyX = 0, enemyY = 0, width = 20, height = 20;

            for (int i = 0; i <= enemiesperLine - 1; i++)
                for (int j = 0; j <= enemiesperRow - 1; j++)
                {
                    enemyX = i;
                    enemyY = j;
                    enemy[i, j] = new Enemy(GameScreen, enemyX*40 + 40, enemyY*40 + 40, width, height);
                }

            player = new Player(GameScreen);

        }

        public void UserInput()
        {
            float xdir;
            
            if (GetAsyncKeyState(Keys.Left) == true)
            {
                xdir = -0.5F;
                player.Move(xdir);
            }

            if (GetAsyncKeyState(Keys.Right) == true)
            {
                xdir = 0.5F;
                player.Move(xdir);
            }

            if (GetAsyncKeyState(Keys.Up) == true)
            {
                isBullet = true;
               
                if (!Bullet.OnScreen())
                {
                    bullet = player.Shoot();
                }
            }
        }

        public void Draw()
        {
            PcbGameScreen.Refresh();

            player.Draw();

            for (int i = 0; i <= enemiesperLine - 1; i++)
                for (int j = 0; j <= enemiesperRow - 1; j++)
                {
                    if (enemy[i,j].destroyed == false)
                    {
                        enemy[i, j].Draw();
                    }
                }

            /* check if the bullet exist before try to move it, to avoid an exception error.
             * if the obj is out of the screen set its property to false so it can be created 
             * again.
             */
            if (isBullet != false)
            {
                if (bullet.Y <= 10)
                {
                    bullet.SetCreated();
                }
                else
                {
                    //if (bullet.used == false)
                    //{
                        bullet.Draw();
                    //}
                }
            }
        }

        public void Logic()
        {
            // check if the enemy is on the edge of the screen.
            for (int i = 0; i <= enemiesperLine - 1; i++)
                for (int j = 0; j <= enemiesperRow - 1; j++)
                {
                    if ((enemy[i, j].X + enemy[i, j].Width) >= PcbGameScreen.Width || enemy[i, j].X <= 0)
                    {
                        endofScreen = true;
                    }
                }
            
            // if the endofscreen its true invert the direction and shift the enemies down.
            if (endofScreen)
            {
                for (int i = 0; i <= enemiesperLine - 1; i++)
                    for (int j = 0; j <= enemiesperRow - 1; j++)
                    {
                        enemy[i, j].Hitedge();
                    }
            }

            // move the enemies through the screen.
            for (int i = 0; i <= enemiesperLine - 1; i++)
                for (int j = 0; j <= enemiesperRow - 1; j++)
                {
                    enemy[i, j].Move();

                    if (enemy[i, j].destroyed == false)
                    {
                        PlayerColision(enemy[i, j]);
                    }
                }

            endofScreen = false;

            // check if the bullet exist before try to move it, to avoid an exception error.
            if (isBullet != false)
            {
                bullet.Move();

                if (bullet.used == false)
                {
                    for (int i = 0; i <= enemiesperLine - 1; i++)
                        for (int j = 0; j <= enemiesperRow - 1; j++)
                        {
                            if (enemy[i, j].destroyed == false)
                            {
                                ColisionDetection(enemy[i, j]);
                            }
                        }
                }
            }
        }

        public void ColisionDetection(Enemy enemy)
        {
            if (bullet.Y <= enemy.Y + 20 && bullet.Y >= enemy.Y &&
                bullet.X >= enemy.X && bullet.X <+ enemy.X + 20)
            {
                enemy.destroyed = true;
                isBullet = false;
            }
        }

        public void PlayerColision(Enemy enemy)
        {
            if (player.Y <= enemy.Y + 20 && player.Y >= enemy.Y &&
                    player.X >= enemy.X && player.X < +enemy.X + 20)
            {
                endofgame = true;
            }
        }

        public Boolean IsGameOver()
        {
            return endofgame;
        }
    }

}


