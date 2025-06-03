using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameBolls3._0
{
    public partial class FormGame : System.Windows.Forms.Form
    {
        public FormGame()
        {
            InitializeComponent();
        }

        private void buttonLevel1_Click(object sender, EventArgs e)
        {
            FormLevels frm = new FormLevels();
            frm.claslevel = "1";
            frm.ShowDialog();
            
        }

        private void buttonLevel2_Click(object sender, EventArgs e)
        {
            FormLevels frm = new FormLevels();
            frm.claslevel = "2";
            frm.ShowDialog();
        }

        private void buttonLevel3_Click(object sender, EventArgs e)
        {
            FormLevels frm = new FormLevels();
            frm.claslevel = "3";
            frm.ShowDialog();
        }

        private void buttonShowScores_Click(object sender, EventArgs e)
        {
            FormScores frmS = new FormScores();
            frmS.ShowDialog();
        }
    }
}
