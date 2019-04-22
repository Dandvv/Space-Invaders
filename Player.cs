using System.Drawing;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;

namespace Space_Invaders
{
    class Player 
    {
        Graphics g;
        private PictureBox PcbGameScreen;
        private Bullet bullet;
        float x, y, width, height;
        static float PLAYERHEIGHT = 40;
        private readonly float playerSpeed = 1.5F;

        public int playerScore { get; set; }
        public string playerName { get; }


        public float X { get { return this.x; } }
        public float Y { get { return this.y; } }

        public Player(PictureBox GameScreen, string playerName)
        {
            PcbGameScreen = GameScreen;
            x = PcbGameScreen.Width / 2;
            y = PcbGameScreen.Height - PLAYERHEIGHT;
            width = 20;
            height = PLAYERHEIGHT;
            this.playerName = playerName;
        }

        public void Draw()
        {
            g = PcbGameScreen.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.DeepSkyBlue), this.x, this.y, width, height);
        }

        public void Move(float xdir)
        {
            this.x = this.x + (playerSpeed * xdir);
        }

        public Bullet Shoot()
        {
            bullet = new Bullet(PcbGameScreen, (this.x + 5), (this.y - 10));

            return bullet;
        }
    }
}
