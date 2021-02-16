using System;
using System.Timers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxCounter
{
    public partial class Form1 : Form
    {
        public LandButton[,] arr;
        public Form1()
        {
            InitializeComponent();
            arr = new LandButton[yAxel, xAxel];
            for (int i = 0; i < yAxel; i++)
            {
                for (int j = 0; j < xAxel; j++)
                {
                    LandButton newButton = new LandButton();
                    newButton.Size = new Size(button_width, button_height);
                    newButton.Location = new Point(button_width * j, button_height * i);
                    arr[i, j] = newButton;
                    this.Controls.Add(newButton);
                }
            }
        }

        private int button_height = 50;
        private int button_width = 50;
        private int xAxel = 10;
        private int yAxel = 6;

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void sameColorAreas(int color, int i, int j)
        {
            try
            {
                if (checklist[i, j])
                {
                    return;

                } else if (arr[i,j].getColorNum() == color) {
                    checklist[i, j] = true;
                    sameColorAreas(color, i + 1, j);
                    sameColorAreas(color, i, j + 1);
                    sameColorAreas(color, i-1, j);
                    sameColorAreas(color, i, j - 1);
                }
                else {
                    return;
                }
            }

            catch (IndexOutOfRangeException)
            {
                return;
            }
        }
        private bool[,] generateCheckList()
        {
            bool[,] tempArr = new bool[yAxel, xAxel];
            for (int i = 0; i< yAxel; i++)
            {
                for (int j = 0; j< xAxel; j++)
                {
                    tempArr[i, j] = false;
                }       
            }
            return tempArr;
        }
        private void checkAreas()
        {
            int count = 0;
            checklist = generateCheckList();
            for (int i = 0; i < yAxel; i++)
            {
                for (int j = 0; j < xAxel; j++)
                {
                    if (!checklist[i, j])
                    {
                        sameColorAreas(arr[i, j].getColorNum(), i, j);
                        count += 1;
                    } 
                }
            }
            CountLabel.Text = count.ToString();

        }

        private bool[,] checklist;

        private void button1_Click(object sender, EventArgs e)
        {
            checkAreas();
        }
    }
}
