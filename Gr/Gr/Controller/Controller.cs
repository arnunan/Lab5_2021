using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gr.Controllers
{
    public static class Controller
    {
        public const int sizeOfMap = 8; // размер поля
        public const int sizeOfCell = 50; // размер клетки
        public static int[,] map = new int[sizeOfMap, sizeOfMap]; // само поле
        public static Button[,] buttons = new Button[sizeOfMap, sizeOfMap]; // кнопки на поле
        public static Image image; // картина - ПЕРЕИМЕНОВАТЬ
        private static bool isTheFirstStep; // первый ли шаг делает игрок
        public static Point first; // координаты первой нажатой кнопки
        public static Form form;

        public static void ConfigureSizeOfMap(Form form) // задать размеры форме
        {
            form.Width = sizeOfMap * sizeOfCell + 20;
            form.Height = (sizeOfMap + 1) * sizeOfCell;
        }

        public static void Init(Form form) //инициализация формы
        {
            Controller.form = form;
            isTheFirstStep = true;
            image = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).
                                            Parent.Parent.FullName.ToString(), "Sprites\\tiles1.png"));
            ConfigureSizeOfMap(form);
            MapInit();
            InitButtons(form);
        }

        private static void MapInit() // инициализация поля
        {
            for (int i = 0; i < sizeOfMap; i++)
                for (int j = 0; j < sizeOfMap; j++)
                    map[i, j] = 0;
        }

        private static void InitButtons(Form form) // задать кнопки
        {
            for (int i = 0; i < sizeOfMap; i++)
            {
                for (int j = 0; j < sizeOfMap; j++)
                {
                    Button button = new Button();
                    button.Location = new Point(j * sizeOfCell, i * sizeOfCell);
                    button.Size = new Size(sizeOfCell, sizeOfCell);
                    button.Image = FindImage(0, 0);
                    button.MouseUp += new MouseEventHandler(DoOnPressedMouse);
                    form.Controls.Add(button);
                    buttons[i, j] = button;
                }
            }
        }

        private static void DoOnPressedMouse(object sender, MouseEventArgs e) //событие после нажатия (1 часть)
        {
            Button pressedButton = sender as Button;
            if (e.Button.ToString() == "Left")
                DoOnPressedButton(pressedButton);
        }

        private static void DoOnPressedButton(Button pressedButton) //событие после нажатия (2 часть)
        {
            pressedButton.Enabled = false;
            int i = pressedButton.Location.Y / sizeOfCell;
            int j = pressedButton.Location.X / sizeOfCell;
            if (isTheFirstStep)
            {
                first = new Point(j, i);
                SpreadSheeps();
                SpreadDog();
                CellsAroundMagic();
                isTheFirstStep = false;
            }
            OpenCells(i, j);
            if (map[i, j] == -1)
            {
                ShowDogAndSheeps(i, j);
                MessageBox.Show("Поражение!");
                form.Controls.Clear();
                Init(form);
            }
            if (map[i, j] == 2)
            {
                ShowDogAndSheeps(i, j);
                MessageBox.Show("Победа!");
                form.Controls.Clear();
                Init(form);
            }
        }

        private static void ShowDogAndSheeps(int iAnimal, int jAnimal) // показать животных после нажатия на овцу или собаку
        {
            for (int i = 0; i < sizeOfMap; i++)
            {
                for (int j = 0; j < sizeOfMap; j++)
                {
                    if (i == iAnimal && j == jAnimal)
                        continue;
                    if (map[i, j] == -1)
                    {
                        buttons[i, j].Image = FindImage(3, 0);
                    }
                    if (map[i, j] == 2)
                        buttons[i, j].Image = FindImage(1, 0);
                }
            }
        }

        public static Image FindImage(int x, int y) // вырезать картинку
        {
            Image image = new Bitmap(sizeOfCell, sizeOfCell);
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(Controller.image, new Rectangle(new Point(0, 0), new Size(sizeOfCell, sizeOfCell)), 
                        0 + 32 * x, 0 + 32 * y, 33, 33, GraphicsUnit.Pixel);
            return image;
        }

        private static void SpreadSheeps() // распределить овец по полю
        {
            Random random = new Random();
            int number = random.Next(7, 15);
            for (int i = 0; i < number; i++)
            {
                int iSheep = random.Next(0, sizeOfMap - 1);
                int jSheep = random.Next(0, sizeOfMap - 1);
                while (map[iSheep, jSheep] == -1 || (Math.Abs(iSheep - first.Y) <= 1 && Math.Abs(jSheep - first.X) <= 1))
                {
                    iSheep = random.Next(0, sizeOfMap - 1);
                    jSheep = random.Next(0, sizeOfMap - 1);
                }
                map[iSheep, jSheep] = -1;
            }
        }

        private static void SpreadDog() //закинуть собаку на поле
        {
            Random random = new Random();
            int number = random.Next(7, 15);
            int iDog = random.Next(0, sizeOfMap - 1);
            int jDog = random.Next(0, sizeOfMap - 1);
            iDog = random.Next(0, sizeOfMap - 1);
            jDog = random.Next(0, sizeOfMap - 1);
            map[iDog, jDog] = 2;
        }

        private static void CellsAroundMagic() // выбрать котов
        {
            for (int i = 0; i < sizeOfMap; i++)
            {
                for (int j = 0; j < sizeOfMap; j++)
                {
                    if (map[i, j] == -1 || map[i, j] == 2)
                    {
                        for (int k = i - 1; k < i + 2; k++)
                        {
                            for (int l = j - 1; l < j + 2; l++)
                            {
                                if (!IsInBorder(k, l) || map[k, l] == -1 || map[k, l] == 2)
                                    continue;
                                map[k, l] = 1;
                            }
                        }
                    }
                }
            }
        }

        private static void Groom(int i, int j) //вывести изображение с животным
        {
            buttons[i, j].Enabled = false;
            if (map[i, j] == -1)
                buttons[i, j].Image = FindImage(3, 0);
            else if (map[i, j] == 0)
                buttons[i, j].Image = FindImage(0, 0);
            else if (map[i, j] == 2)
                buttons[i, j].Image = FindImage(1, 0);
            else
                buttons[i, j].Image = FindImage(2, 0);
        }

        private static void OpenCells(int i, int j) // "подстричь"
        {
            Groom(i, j);
            if (map[i, j] > 0 && map[i, j] < 2)
                return;
            for (int k = i - 1; k < i + 2; k++)
            {
                for (int l = j - 1; l < j + 2; l++)
                {
                    if (!IsInBorder(k, l))
                        continue;
                    if (!buttons[k, l].Enabled)
                        continue;
                    if (map[k, l] == 0)
                    {
                        map[k, l] = 1;
                        OpenCells(k, l);
                    }
                    else if (map[k, l] == 1)
                        Groom(k, l);
                }
            }
        }

        private static bool IsInBorder(int i, int j) //проверить, находится ли координата в пределах поля
        {
            if (i < 0 || j < 0 || j > sizeOfMap - 1 || i > sizeOfMap - 1)
                return false;
            return true;
        }
    }
}