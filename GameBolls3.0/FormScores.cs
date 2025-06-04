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

        static string result (int rightSteps, int currentSteps)//Сравнение шагов пользователя с заданными для каждого уровня
        {
            if (Convert.ToInt32(currentSteps) >  rightSteps) return "Mожно лучше";
            else
            {
                if (Convert.ToInt32(currentSteps) == rightSteps) return "Хороший результат";
                else return "Переиграл и уничтожил";
            }
        }
        private void FormScores_Load(object sender, EventArgs e)//Открытие таблицы результатов
        {
            StreamReader sr = new StreamReader("GameResults.txt");//Открытие файла с номером уровня и так далее
            try//Если там что-то вообще будет
            {
                for (int i = 0; i < 20; i++)
                {
                    string[] temp = sr.ReadLine().Split('#');//Считываем данные
                    string res = "";
                    int currentSteps = Convert.ToInt32(temp[2]);
                    switch (temp[0])//вынос вердикта
                    {
                        case "1": res = result(6, currentSteps); break;

                        case "2": res = result(9, currentSteps); break;

                        case "3": res = result(21, currentSteps); break;

                    }
                    ListViewItem item = new ListViewItem(new string[] { temp[0], temp[1], temp[2], res });//Запись всего этого в таблицу результатов
                    listViewScores.Items.Add(item);
                }
            }
            catch { sr.Close(); } // если нет, то закрываем
            sr.Close();
        }
    }
}
