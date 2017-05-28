using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ComponentMap
{
    class Polygon
    {
        protected List<Tuple<int, int>> _coords;
        public bool Selected { get; protected set; }
        public event Action<Graphics> DrawEvent;
        public Action<bool> Selection
        {
            get
            {
                return (bool Select) => { Selected = true; };
            }
        }
        protected Polygon()
        {

        }

        public Polygon(List<Tuple<int, int>> Coords, Action<Graphics> Del)
        {
            _coords = Coords;
            DrawEvent += Del;
        }

        public virtual void MouseFocus(int X, int Y)
        {
            bool isInside = false;
            int C = _coords.Count;
            for (int i = 0, j = C - 1; i < C; j = i++)
                if (((_coords[i].Item2 > Y) != (_coords[j].Item2 > Y)) &&
                (X < (_coords[j].Item1 - _coords[i].Item1) * (Y - _coords[i].Item2) / (_coords[j].Item2 - _coords[i].Item2) + _coords[i].Item1))
                    isInside = !isInside;
            Selected = isInside;
        }

        public virtual void Draw()
        {
            //DrawEvent();
        }
    }
}
