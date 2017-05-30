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
        public bool Selected { get; protected set; }
        public event Action<List<Point>> DrawEvent;

        public Action<bool> Selection
        {
            get
            {
                return (bool Select) => { Selected = Select; };
            }
        }

        protected Polygon()
        {

        }

        public Polygon(List<Point> Coords, Action<List<Point>> Del)
        {
            _coords = Coords;
            DrawEvent += Del;
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
                DrawEvent(_coords);
            }
        }
    }
}
