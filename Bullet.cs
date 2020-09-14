using System.Drawing;
using System.Windows.Forms;
using System;
//using System.ComponentModel;

namespace Space_Invaders 
{
    class Bullet 
    {
        Graphics g;
        private PictureBox PcbGameScreen;
        private static bool created = false;
        public bool used = false;

        public float X { get; private set; }
        public float Y { get; private set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Bullet(PictureBox GameScreen, float initial_X, float initial_Y)
        {
            PcbGameScreen = GameScreen;
            X = initial_X;
            Y = initial_Y;
        }

        public void Draw()
        {
            g = PcbGameScreen.CreateGraphics();
            g.FillEllipse(new SolidBrush(Color.Yellow), this.X, this.Y, 5, 10);
            created = true;
        }

        public void Move()
        {
            this.Y = this.Y - 3;
        }

        public static bool OnScreen()
        {
            if (created)
            {
                return true;
            }
            return false;    
        }

        public void SetCreated()
        {
            created = false;
        }

        public void SetBullet_Y(float y)
        {
            this.Y = y;
        }

        public void SetBullet_X(float x)
        {
            this.X = x;
        }
    }
}
