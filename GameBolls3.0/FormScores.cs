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
    public partial class FormScores : Form
    {
       //public int length;
        public FormScores()
        {
            InitializeComponent();
        }

        static string result (int rightSteps, int currentSteps)
        {
            if (Convert.ToInt32(currentSteps) >  rightSteps) return "Mожно лучше";
            else
            {
                if (Convert.ToInt32(currentSteps) == rightSteps) return "Хороший результат";
                else return "Переиграл и уничтожил";
            }
        }
        private void FormScores_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("GameResults.txt");
            try
            {
                for (int i = 0; i < 20; i++)
                {
                    string[] temp = sr.ReadLine().Split('#');
                    string res = "";
                    int currentSteps = Convert.ToInt32(temp[2]);
                    switch (temp[0])
                    {
                        case "1": res = result(6, currentSteps); break;

                        case "2": res = result(9, currentSteps); break;

                        case "3": res = result(21, currentSteps); break;

                    }
                    ListViewItem item = new ListViewItem(new string[] { temp[0], temp[1], temp[2], res });
                    listViewScores.Items.Add(item);
                }
            }
            catch { sr.Close(); }
            sr.Close();
        }
    }
}
