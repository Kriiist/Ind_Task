using IZ_OOP_2020.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IZ_OOP_2020
{
    public partial class MainForm : Form
    {
        public ToolTip []ErrorTip = new ToolTip[10];
        public bool []ActiveErrors = new bool[10];
        LineSys[] LS = new LineSys[5];

        public MainForm()
        {
            InitializeComponent();
            
        }



        public PictureBox getPic(string picName)
        {
            var FR = Controls[picName];
            PictureBox PB = null;
            if (FR != null)
                PB = FR as PictureBox;
            return PB;
        }

        

        private void MainForm_Load(object sender, EventArgs e)
        {


            
            LS[0] = new route1();
            LS[1] = new route2();
            LS[2] = new route3();
            LS[3] = new route4();
            LS[4] = new route5();
            for (int i = 0; i < 5; i++)
            {
                LS[i].CreateRoute();
                LS[i].LinkRoute(this);
            }
            
            

            

        
        }

        

        private async void button6_Click(object sender, EventArgs e)
        {
            crashInfo CI = new crashInfo();
            while (true)
            {
                while (CI.TC == null)
                {
                    //один шаг на всех путях
                    for (int i = 0; i < LS.Length; i++)
                    {
                        CI = LS[i].MoveRoute();
                        if (CI.TC != null)
                            break;
                    }

                }
                LS[CI.route - 1].ShowCrash(CI.LP, CI.TC);
                CI.TC = LS[CI.route - 1].FixCrash(CI.route, CI.TC, logs);
                await Task.Delay(5000);


                LS[CI.route - 1].HideCrash(CI.LP);
                CI.TC = null;
            }
        }















        /*private void button1_Click(object sender, EventArgs e)
        {
            LineSys.line[4].linePart[5].Pic = pictureBox2;
            LineSys.line[4].linePart[5].ErrorTip.Show($"{LineSys.line[4].color} {LineSys.line[4].linePart[5].IDLinePart}", LineSys.line[4].linePart[5].Pic);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LineSys.line[4].linePart[5].ErrorTip.Hide(LineSys.line[4].linePart[5].Pic);
        }*/


    }
}
