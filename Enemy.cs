using System.Drawing;
using System.Windows.Forms;

namespace Space_Invaders
{
    class Enemy
    {
        Graphics g;
        private PictureBox PcbGameScreen;
        float x, y, width, height;
        float xdir = 1F;
        public bool destroyed = false;

        public float Xdir
        {
            get { return this.xdir; }
            set { this.xdir = value; }
        }

        public float X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public float Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public float Width
        {
            get { return this.width; }
            set { this.width = value; }
        }
        
        public float Height
        {
            get { return this.height; }
            set { this.height = value; }
        }
        
        public Enemy(PictureBox GameScreen, float posX, float posY, float width, float height)
        {
            PcbGameScreen = GameScreen;
            x = posX;
            y = posY;
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            g = PcbGameScreen.CreateGraphics();
            g.FillRectangle(new SolidBrush(Color.DarkRed), x, y, width, height);
        }

        public void Move()
        {
            this.x = this.x + this.xdir;
        }

        public void Hitedge()
        {
            this.xdir = this.xdir *(-1);
            this.y = this.y + 5*height;
        }

    }
}
