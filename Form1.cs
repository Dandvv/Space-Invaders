﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Space_Invaders
{
    public partial class FrmGameScreen : Form
    {
        private Game game;
        Boolean gameOver = false;
        frmGetPlayerName frmGetPlayerName = new frmGetPlayerName();
        public string playerName;

        public FrmGameScreen()
        {
            frmGetPlayerName.ShowDialog(this);
            playerName = frmGetPlayerName.playerName;

            InitializeComponent();
            game = new Game(PcbGameScreen, lblScore, playerName);
            BtnGameStart.FlatAppearance.MouseDownBackColor = Color.Black;
            BtnGameClose.FlatAppearance.MouseDownBackColor = Color.Black;

        }

        private void BtnGameStart_Click(object sender, EventArgs e)
        {
            pcbLogo.Visible = false;
            BtnGameClose.Visible = false;
            BtnGameStart.Visible = false;
            
            while (!gameOver)
            {
                game.UserInput();
                game.Logic();
                game.Draw();

                gameOver = game.IsGameOver();
            }

            BtnGameClose.Visible = true;
            BtnGameStart.Visible = true;

        }

        private void BtnGameClose_Click(object sender, EventArgs e)
        {
            this.Close();
            gameOver = true;
        }

    }
}
