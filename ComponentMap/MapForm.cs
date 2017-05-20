﻿using System;
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
        private MapDialog md;
        private List<Point> Arr;
        private Graphics g;
        private Graphics f;
        private Bitmap bm;

        public MapForm(MapDialog md)
        {
            InitializeComponent();
            //bm = new Bitmap(Properties.Resources.Map);
            bm = new Bitmap(852, 560);
            //CtrlPanel.CreateGraphics().DrawImage(bm, 0, 0);
            g = Graphics.FromImage(bm);
            f = CtrlPanel.CreateGraphics();
            this.md = md;
        }

        private void MapForm_MouseMove(object sender, MouseEventArgs e)
        {
            //md.MouseMove(sender, e);
        }

        private void MapForm_MouseDown(object sender, MouseEventArgs e)
        {
            Arr.Add(new Point(e.X, e.Y));
        }

        private void MapForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            /* using (System.IO.StreamWriter sw = new System.IO.StreamWriter("coords.txt"))
             {
                 int C = Arr.Count;
                 for (int i = 0; i < C; i++)
                 {
                     sw.WriteLine(Arr[i].Item1 + " " + Arr[i].Item2);
                 }
                 sw.Close();
             }*/
        }

        private void Action()
        {
            Arr = new List<Point>();
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
            }
            g.FillPolygon(Brushes.Green, Arr.ToArray());
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            g.DrawImage(Properties.Resources.Map, 0, 0);
            Action();
            f.DrawImage(bm, 0, 0);
            base.OnPaint(e);
        }
    }
}
