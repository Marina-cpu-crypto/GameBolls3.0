using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameBolls3._0
{
    class ClassClick
    {
        /*public*/ Image ImgRedBall, ImgOrangeBall, ImgEmpty, ImgBlueBall;
        //public string level;
        public ClassClick()
        {
            ImgEmpty = Bitmap.FromFile("Images/Empty.png");
            ImgRedBall = Bitmap.FromFile("Images/RedBaloon_100.png");
            ImgOrangeBall = Bitmap.FromFile("Images/OrangeBaloon_100.png");
            ImgBlueBall = Bitmap.FromFile("Images/BlueBallon_100.png");
        }
        
        public bool IsColumnRight( int column, string level)
        {
            if (level == "1")
            {
                if (column == 2 || column == 6 || column == 10) return true;
                else return false;
            }
            else
            {
                if (column == 2 || column == 6 || column == 10 || column == 14) return true;
                else return false;
            }
        }
        public bool IsRowRight(int row, string level)
        {
            if (level == "3")
            {
                if (row == 2 || row == 3 || row == 4 || row == 1) return true;
                else return false;
            }
            else
            {
                if (row == 2 || row == 3 || row == 4) return true;
                else return false;
            }
        }
        public bool IsNoCurrentBall(string[,] gameField, string level)
        {
            int n = 8;//Номер столбца для хранения выбранного мяча в матрице уровней 2 и 3
            if (level == "1") n = 6;
            if (gameField[0, n] == "N") return true;
            else return false;
        }
        public bool IsPositionRight(string[,] gameField, string level, int row, int column)
        {
            int n = 2;
            if (level == "3") n = 1;
            if (gameField[row - 1, column] == "N" || row == n) return true;//Если над шариком пусто или шарик на самом верху колбы
            else return false;
        }
        public void CooseBall(string level, DataGridView grid, string[,] gameField, int row, int column)
        {
            int n = 8;
            if (level == "1") n = 6;
            string letter = gameField[row, column];//Переменная для хранения тыкнутой буквы
            gameField[0, n] = gameField[row, column];//Присваеваем эту букву на ячейку временного хранения
            gameField[row, column] = "N";//На месте этой буквы пустота
            switch (letter)//Отрисовка на поле на основе матрицы
            {
                case "R":
                    grid.Rows[row].Cells[column].Value = ImgEmpty;
                    grid.Rows[0].Cells[n].Value = ImgRedBall; break;
                case "O":
                    grid.Rows[row].Cells[column].Value = ImgEmpty;
                    grid.Rows[0].Cells[n].Value = ImgOrangeBall; break;
                case "B":
                    grid.Rows[row].Cells[column].Value = ImgEmpty;
                    grid.Rows[0].Cells[n].Value = ImgBlueBall; break;
            }
        }
        public bool PlaceBall(string level, DataGridView grid, string[,] gameField, int row, int column)
        {
            int n = 8;
            if (level == "1") n = 6;
            string letter = gameField[0, n];
            switch (letter)
            {
                case "O":
                    grid.Rows[row].Cells[column].Value = ImgOrangeBall;
                    grid.Rows[0].Cells[n].Value = ImgEmpty; break;
                case "R":
                    grid.Rows[row].Cells[column].Value = ImgRedBall;
                    grid.Rows[0].Cells[n].Value = ImgEmpty; break;
                case "B":
                    grid.Rows[row].Cells[column].Value = ImgBlueBall;
                    grid.Rows[0].Cells[n].Value = ImgEmpty; break;

            }
            gameField[row, column] = gameField[0, n];
            gameField[0, n] = "N";
            return true;
        }
        public bool IsFieldReady(string[,] GameField, string level)
        {
            bool ReadyColomnOne = GameField[2, 2] == GameField[3, 2] && GameField[2, 2] == GameField[4, 2] && GameField[3, 2] == GameField[4, 2] && GameField[3, 2] != "N";
            bool ReadyColomnTwo = GameField[2, 6] == GameField[3, 6] && GameField[2, 6] == GameField[4, 6] && GameField[3, 6] == GameField[4, 6] && GameField[3, 6] != "N";
            bool ReadyColomnThree = GameField[2, 10] == GameField[3, 10] && GameField[2, 10] == GameField[4, 10] && GameField[3, 10] == GameField[4, 10] && GameField[3, 10] != "N";
            if (level == "1")
            {
                if (ReadyColomnOne && ReadyColomnTwo || ReadyColomnOne && ReadyColomnThree || ReadyColomnThree && ReadyColomnTwo)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (level == "2")
                {
                    bool ReadyColomnFour = GameField[2, 14] == GameField[3, 14] && GameField[2, 14] == GameField[4, 14] && GameField[3, 14] == GameField[4, 14] && GameField[3, 14] != "N";
                    if (ReadyColomnOne && ReadyColomnTwo && ReadyColomnThree || ReadyColomnOne && ReadyColomnTwo && ReadyColomnFour
                        || ReadyColomnOne && ReadyColomnThree && ReadyColomnFour || ReadyColomnTwo && ReadyColomnThree && ReadyColomnFour)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    bool ReadyColomnOne3 = GameField[2, 2] == GameField[3, 2] && GameField[2, 2] == GameField[4, 2] && GameField[3, 2] == GameField[4, 2] && GameField[2, 2] == GameField[1, 2] && GameField[3, 2] == GameField[1, 2] && GameField[1, 2] == GameField[4, 2] && GameField[3, 2] != "N";
                    bool ReadyColomnTwo3 = GameField[2, 6] == GameField[3, 6] && GameField[2, 6] == GameField[4, 6] && GameField[3, 6] == GameField[4, 6] && GameField[2, 6] == GameField[1, 6] && GameField[3, 6] == GameField[1, 6] && GameField[1, 6] == GameField[4, 6] && GameField[3, 6] != "N";
                    bool ReadyColomnThree3 = GameField[2, 10] == GameField[3, 10] && GameField[2, 10] == GameField[4, 10] && GameField[3, 10] == GameField[4, 10] && GameField[2, 10] == GameField[1, 10] && GameField[3, 10] == GameField[1, 10] && GameField[1, 10] == GameField[4, 10] && GameField[3, 10] != "N";
                    bool ReadyColomnFour = GameField[2, 14] == GameField[3, 14] && GameField[2, 14] == GameField[4, 14] && GameField[3, 14] == GameField[4, 14] && GameField[2, 14] == GameField[1, 14] && GameField[3, 14] == GameField[1, 14] && GameField[1, 14] == GameField[4, 14] && GameField[3, 14] != "N";
                    if (ReadyColomnOne3 && ReadyColomnTwo3 && ReadyColomnThree3 || ReadyColomnOne3 && ReadyColomnTwo3 && ReadyColomnFour
                        || ReadyColomnOne3 && ReadyColomnThree3 && ReadyColomnFour || ReadyColomnTwo3 && ReadyColomnThree3 && ReadyColomnFour)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            
        }
    }
}
