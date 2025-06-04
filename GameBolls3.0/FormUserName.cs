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
        private void buttonEnter_Click(object sender, EventArgs e)//Кнопка подтверждения имени
        {
            //открываем файл, записываем в него 
            StreamWriter sw = new StreamWriter("GameResults.txt", true);
            string userName = textBoxUserName.Text;
            sw.WriteLine(level + "#" + userName + "#"+ steps);// Уровень, имя и шаги
            sw.Close();// закрываем файл
            this.Close();//закрываем форму
        }
    }
}
