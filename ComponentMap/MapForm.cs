using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComponentMap
{
    public partial class MapForm : Form
    {
        //private List<Point> Arr;
        private Drawer _drawer;
        
        public MapForm(MapDialog md, EventHandler MouseMove)
        {
            InitializeComponent();
            _drawer = new Drawer(CtrlPanel.CreateGraphics(), ChangeText, md.ChangeText);
            _drawer.Draw();
            //Arr = new List<Point>();
        }

        private void MapForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            /* using (System.IO.StreamWriter sw = new System.IO.StreamWriter("coords.txt"))
             {
                 int C = Arr.Count;
                 for (int i = 0; i < C; i++)
                 {
                     sw.WriteLine(Arr[i].X + " " + Arr[i].Y);
                 }
                 sw.Close();
             }*/
        }

        private void Action()
        {
            /*Arr = new List<Point>();
            using (System.IO.StreamReader sw = new System.IO.StreamReader("coords.txt"))
            {
                string Ass;
                string[] Temp;

                while (!sw.EndOfStream)
                {
                    Ass = sw.ReadLine();
                    Temp = Ass.Split(' ');
                    Arr.Add(new Point(int.Parse(Temp[0]), int.Parse(Temp[1])));
                }
            }*/
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            _drawer.Draw();
            base.OnPaint(e);
        }

        private void CtrlPanel_MouseMove(object sender, MouseEventArgs e)
        {
            _drawer.MouseFocus(e.X, e.Y);
            _drawer.Draw();
        }

        private void CtrlPanel_MouseDown(object sender, MouseEventArgs e)
        {
            //Arr.Add(new Point(e.X, e.Y));
        }

        private void ChangeText(string Text)
        {
            if (Text != null)
                CtrlTxB.Text = Text;
            else
                CtrlTxB.Text = "";
        }
    }
}
