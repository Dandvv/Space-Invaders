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
        Boolean gameOver = false;

        public FrmGameScreen()
        {
            InitializeComponent();
            game = new Game(PcbGameScreen);
            BtnGameStart.FlatAppearance.MouseDownBackColor = Color.Black;
            BtnGameClose.FlatAppearance.MouseDownBackColor = Color.Black;
        }

        private void BtnGameStart_Click(object sender, EventArgs e)
        {
            //Boolean GAMEOVER = false;
            
            while (!gameOver)
            {
                game.Logic();
                game.UserInput();
                game.Draw();

                gameOver = game.IsGameOver();
            }
        }

        private void BtnGameClose_Click(object sender, EventArgs e)
        {
            this.Close();
            gameOver = true;
        }

    }
}
