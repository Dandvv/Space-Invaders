using System.Drawing;
using System.Windows.Forms;
using System;
using System.ComponentModel;

namespace Space_Invaders 
{
    class Bullet : IDisposable
    {
        Graphics g;
        private PictureBox PcbGameScreen;
        private static bool created = false;
        public bool used = false;

        float x;
        float y;

        public float X { get { return this.x; } }
        public float Y { get { return this.y; } }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Bullet(PictureBox GameScreen, float initial_X, float initial_Y)
        {
            PcbGameScreen = GameScreen;
            x = initial_X;
            y = initial_Y;
        }

        public void Draw()
        {
            g = PcbGameScreen.CreateGraphics();
            g.FillEllipse(new SolidBrush(Color.Yellow), x, y, 5, 10);
            created = true;
        }

        public void Move()
        {
            this.y = this.y - 2;
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
            this.y = y;
        }

        public void SetBullet_X(float x)
        {
            this.x = x;
        }
    }
}
