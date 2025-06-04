using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GameBolls3._0
{
    class CreateField
    {
        public Image ImgRedBall, ImgOrangeBall, ImgColumn, ImgBottom, ImgEmpty, ImgBlueBall;
        public void DrawColumn(int i, DataGridView grid, string level)
        {
            grid.Rows[2].Cells[i].Value = ImgColumn;
            grid.Rows[3].Cells[i].Value = ImgColumn;
            grid.Rows[4].Cells[i].Value = ImgColumn;
            grid.Rows[5].Cells[i].Value = ImgColumn;
            if (level == "3") grid.Rows[1].Cells[i].Value = ImgColumn; 
        }
        public void DrawBoll(int i, string[,] gameField, DataGridView grid, string level )
        {
            int min = 2;
            if (level == "3") min = 1;
            for (int j = min; j < 5; j++)
            {
                switch (gameField[j, i])
                {
                    case "N": grid.Rows[j].Cells[i].Value = ImgEmpty; break;
                    case "R": grid.Rows[j].Cells[i].Value = ImgRedBall; break;
                    case "O": grid.Rows[j].Cells[i].Value = ImgOrangeBall; break;
                    case "B": grid.Rows[j].Cells[i].Value = ImgBlueBall; break;
                }
            }
        }
        public void drawField(DataGridView grid, string[,] gameField, string level)
        {
            for (int j = 0; j < 6; j++)
            {
                for (int i=0;i<16;i++)
                {
                    grid.Rows[j].Cells[i].Value = ImgEmpty;
                }
            }
            int n = 16;
            if (level == "1") n = 12;
            for (int i = 0; i <n; i++)
            {
                switch (i)
                {
                    case 1: case 3: case 5: case 7: case 9: case 11: case 13: case 15: DrawColumn(i, grid, level); break;

                    case 2:
                        grid.Rows[5].Cells[i].Value = ImgBottom;
                        DrawBoll(i, gameField, grid, level); break;
                    case 6:
                        grid.Rows[5].Cells[i].Value = ImgBottom;
                        DrawBoll(i, gameField, grid, level); break;
                    case 10:
                        grid.Rows[5].Cells[i].Value = ImgBottom;
                        DrawBoll(i, gameField, grid, level); break;
                    case 14:
                        grid.Rows[5].Cells[i].Value = ImgBottom;
                        DrawBoll(i, gameField, grid, level); break;
                }
            }
        }
        public void BollColour(string[,] GameField, string level)
        {
            
            
            for (int i = 4; i > 0; i--) { for (int j = 2; j < 15; j += 4) { GameField[i, j] = "N"; } }//Для начала забиваем всю матрицу пустыми значениями
            Random rnd = new Random();
            if (level == "1")
            {
                List<string> list = new List<string> { "R", "R", "R", "O", "O", "O", "N", "N", "N" }; //Создаём список значений ячеек

                for (int i = 4; i > 1; i--)
                {
                    for (int j = 2; j < 11; j += 4)
                    {
                        int n = rnd.Next(list.Count);
                        GameField[i, j] = list[n];//Ставим в матрицу случайный эл-т из этого списка
                        list.RemoveAt(n);//Удаляем его
                        bool onecase = (GameField[i - 1, j] == "R" || GameField[i - 1, j] == "O") && GameField[i, j] == "N";//Первый случай - если текущая ячейка пуста, а над ней в ячейке есть шарик
                        bool twocase = i <= 3 && (GameField[i, j] == "R" || GameField[i, j] == "O") && GameField[i + 1, j] == "N";//Второй случай - если текущая ячейка заполнена, а под ней пуста
                        while (onecase || twocase) // В этих двух случаях опускаем шарик
                        {
                            if (onecase)
                            {
                                GameField[i, j] = GameField[i - 1, j];
                                GameField[i - 1, j] = "N";

                            }
                            if (twocase)
                            {
                                GameField[i + 1, j] = GameField[i, j];
                                GameField[i, j] = "N";
                            }
                            onecase = (GameField[i - 1, j] == "R" || GameField[i - 1, j] == "O") && GameField[i, j] == "N";
                            twocase = i <= 3 && (GameField[i, j] == "R" || GameField[i, j] == "O") && GameField[i + 1, j] == "N";
                        }
                    }
                }
                //Костыльное исправление ошибки, когда один шарик наверху, а внизу две ячейки пусты, то он опускается только на одну позицию и не доходит до дна
                for (int j = 2; j < 11; j += 4)//Опускаем его на дно в таком случае
                {
                    int i = 3;
                    if ((GameField[i, j] == "R" || GameField[i, j] == "O") && GameField[i + 1, j] == "N" && GameField[i - 1, j] == "N")
                    {
                        GameField[i+1, j] = GameField[i, j];
                        GameField[i, j] = "N";
                    }
                }
                GameField[0,6]="N";
            }
            else
            {
                if (level == "2")
                {
                    List<string> list = new List<string> { "R", "R", "R", "O", "O", "O", "N", "N", "N", "B", "B", "B" };
                    for (int i = 4; i > 1; i--)
                    {
                        for (int j = 2; j < 15; j += 4)
                        {
                            int n = rnd.Next(list.Count);
                            GameField[i, j] = list[n];
                            list.RemoveAt(n);
                            bool onecase = (GameField[i - 1, j] == "R" || GameField[i - 1, j] == "O" || GameField[i - 1, j] == "B") && GameField[i, j] == "N";
                            bool twocase = i <= 3 && (GameField[i, j] == "B"|| GameField[i, j] == "R" || GameField[i, j] == "O") && GameField[i + 1, j] == "N";
                            while (onecase || twocase)
                            {
                                if (onecase)
                                {
                                    GameField[i, j] = GameField[i - 1, j];
                                    GameField[i - 1, j] = "N";
                                }
                                if (twocase)
                                {
                                    GameField[i + 1, j] = GameField[i, j];
                                    GameField[i, j] = "N";
                                }
                                onecase = (GameField[i - 1, j] == "R" || GameField[i - 1, j] == "O" || GameField[i - 1, j] == "B") && GameField[i, j] == "N";
                                twocase = i <= 3 && (GameField[i, j] == "B" || GameField[i, j] == "R" || GameField[i, j] == "O") && GameField[i + 1, j] == "N";
                            }
                        }
                    }
                    for (int j = 2; j < 15; j += 4)
                    {
                        int i = 3;
                        if ((GameField[i, j] == "B" || GameField[i, j] == "R" || GameField[i, j] == "O") && GameField[i + 1, j] == "N" && GameField[i - 1, j] == "N")
                        {
                            GameField[i + 1, j] = GameField[i, j];
                            GameField[i, j] = "N";
                        }
                    }
                    GameField[0, 8] = "N";
                }
                else
                {
                    List<string> list = new List<string> { "R", "R", "R", "R", "O", "O", "O", "O", "N", "N", "N", "N", "B", "B", "B", "B" };
                    for (int i = 4; i > 0; i--)
                    {
                        for (int j = 2; j < 15; j += 4)
                        {
                            int n = rnd.Next(list.Count);
                            GameField[i, j] = list[n];
                            list.RemoveAt(n);
                            bool onecase = (GameField[i - 1, j] == "R" || GameField[i - 1, j] == "O" || GameField[i - 1, j] == "B") && GameField[i, j] == "N";
                            bool twocase = i <= 3 && (GameField[i, j] == "B" || GameField[i, j] == "R" || GameField[i, j] == "O") && GameField[i + 1, j] == "N";
                            while (onecase || twocase)
                            {
                                if (onecase)
                                {
                                    GameField[i, j] = GameField[i - 1, j];
                                    GameField[i - 1, j] = "N";
                                }
                                if (twocase)
                                {
                                    GameField[i + 1, j] = GameField[i, j];
                                    GameField[i, j] = "N";
                                }
                                onecase = (GameField[i - 1, j] == "R" || GameField[i - 1, j] == "O" || GameField[i - 1, j] == "B") && GameField[i, j] == "N";
                                twocase = i <= 3 && (GameField[i, j] == "B" || GameField[i, j] == "R" || GameField[i, j] == "O") && GameField[i + 1, j] == "N";
                            }
                        }
                    }
                    for (int j = 2; j < 15; j += 4)
                    {
                        for (int i=2; i < 4;i++)
                        {
                            if ((GameField[i, j] == "B" || GameField[i, j] == "R" || GameField[i, j] == "O") && GameField[i + 1, j] == "N" && GameField[i - 1, j] == "N")
                            {
                                GameField[i + 1, j] = GameField[i, j];
                                GameField[i, j] = "N";
                            }
                        }
                    }
                    GameField[0, 8] = "N";
                }
            }
        }
    }
}
