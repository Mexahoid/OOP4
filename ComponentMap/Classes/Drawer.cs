using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ComponentMap
{
    class Drawer
    {
        private Graphics _innerGraph;
        private Graphics _outerGraph;
        private Bitmap _btm;
        private List<Polygon> _polygons;
        private int _count;
        private Action<string> _changer;
        private  Action<string> _countryChange;

        public Drawer(Graphics CanvGraph, Action<string> ChangeText, Action<string> ChangeCountry)
        {
            _countryChange = ChangeCountry;
            _outerGraph = CanvGraph;
            _btm = new Bitmap(852, 560);
            _innerGraph = Graphics.FromImage(_btm);
            _polygons = new List<Polygon>();
            _changer = ChangeText;
            Parse();
        }

        public void Drawing(List<Point> Coords)
        {
            _innerGraph.FillPolygon(Brushes.LightBlue, Coords.ToArray());
        }

        public void MouseFocus(int X, int Y)
        {
            Clear();
            for (int i = 0; i < _count; i++)
            {
                _polygons[i].MouseFocus(X, Y);
            }
        }

        public void Clear()
        {
            _innerGraph.DrawImage(Properties.Resources.Map, 0, 0);
            _outerGraph.DrawImage(_btm, 0, 0);
        }

        public void Draw()
        {
            _outerGraph.DrawImage(_btm, 0, 0);
        }

        private void Parse()
        {
            string[] files = System.IO.Directory.GetFiles("Data", "*.txt");
            System.IO.StreamReader SR;
            List<Point> coords;
            string Ass;
            string[] Data = new string[2];
            string[] Seps, Temp;
            foreach (string textPath in files)
            {
                coords = new List<Point>();
                try
                {
                    SR = new System.IO.StreamReader(textPath, Encoding.Default);
                    Data[0] = SR.ReadLine();
                    Data[1] = SR.ReadLine();

                    Seps = SR.ReadLine().Split(',');
                    List<int> Bounds;
                    int C = Seps.Length;
                    Bounds = new List<int>();
                    for (int i = 0; i < C; i++)
                    {
                        Bounds.Add(int.Parse(Seps[i]));
                    }
                    while (!SR.EndOfStream)
                    {
                        Ass = SR.ReadLine();
                        Temp = Ass.Split(' ');
                        coords.Add(new Point(int.Parse(Temp[0]), int.Parse(Temp[1])));
                    }
                    SR.Close();
                    _count++;
                    if (C != 1)
                        _polygons.Add(new ComplexPolygon(coords, Drawing, Bounds, Clear, Data, _changer, _countryChange));
                    else
                        _polygons.Add(new Polygon(coords, Drawing, _changer, Data, _countryChange));
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
