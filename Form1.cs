using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace Space_Invaders
{
    public partial class FrmGameScreen : Form
    {
        private Game game; 

        public FrmGameScreen()
        {
            InitializeComponent();
            game = new Game(PcbGameScreen);
        }

        private void BtnGameStart_Click(object sender, EventArgs e)
        {
            Boolean GAMEOVER = false;
            
            while (!GAMEOVER)
            {
                game.Logic();
                game.UserInput();
                game.Draw();

                GAMEOVER = game.IsGameOver();
            }
        }
    }
}
