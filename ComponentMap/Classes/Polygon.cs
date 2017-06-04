using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ComponentMap
{
    class Polygon
    {
        protected List<Point> _coords;
        protected bool _selected;
        public virtual bool Selected
        {
            get
            {
                return _selected;
            }
            protected set
            {
                _selected = value;
                if (value)
                {
                    DrawEvent(_coords);
                    TextChanger(Name + "\n\n" + _data);
                    
                }
            }
        }
        public event Action<List<Point>> DrawEvent;
        private event Action<string> TextChanger;
        protected string _data;
        public string Name { get; set; }

        public Action<bool> Selection
        {
            get
            {
                return (bool Select) => { Selected = Select; };
            }
        }

        protected Polygon(Action<string> Changer, Action<string> LabelText)
        {
            TextChanger += Changer;
            TextChanger += LabelText;
        }

        public Polygon(List<Point> Coords, Action<List<Point>> Del, Action<string> Changer, string[] Arr, Action<string> LabelText)
        {
            Name = Arr[0];
            _data = Arr[1];
            _coords = Coords;
            DrawEvent += Del;
            TextChanger += Changer;
            TextChanger += LabelText;
        }

        protected void Temp(string Inp)
        {
            TextChanger(Inp);
        }

        public virtual void MouseFocus(int X, int Y)
        {
            bool isInside = false;
            int C = _coords.Count;
            for (int i = 0, j = C - 1; i < C; j = i++)
                if (((_coords[i].Y > Y) != (_coords[j].Y > Y)) &&
                (X < (_coords[j].X - _coords[i].X) * (Y - _coords[i].Y) / (_coords[j].Y - _coords[i].Y) + _coords[i].X))
                    isInside = !isInside;
            Selected = isInside;
        }

        public virtual void Draw()
        {
            if (Selected)
            {
                //DrawEvent(_coords);
                TextChanger(Name + "\n\n" + _data);
            }
        }

        public void DrawWithoutText()
        {
            if (Selected)
            {
                DrawEvent(_coords);
            }
        }
    }
}
