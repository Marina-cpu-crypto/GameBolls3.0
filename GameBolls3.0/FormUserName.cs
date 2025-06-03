using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameBolls3._0
{
    public partial class FormUserName : Form
    {
        public string level;
        public int steps;
        public FormUserName()
        {
            InitializeComponent();
        }
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("GameResults.txt", true);
            string userName = textBoxUserName.Text;
            sw.WriteLine(level + "#" + userName + "#"+ steps);
            sw.Close();
            this.Close();
        }
    }
}
