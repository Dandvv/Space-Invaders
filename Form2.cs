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
    public partial class frmGetPlayerName : Form
    {
        public string playerName { get; set; }

        public frmGetPlayerName()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.playerName = txbPlayerName.Text;
            this.Close();
        }

        private void txbPlayerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.playerName = txbPlayerName.Text;
                this.Close();
            }
        }
    }
}
