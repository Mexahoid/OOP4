using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ComponentMap
{
    class ComplexPolygon : Polygon
    {
        private List<Polygon> _polygons;
        private int _count;
        private event Action<bool> _MassSelect;

        public ComplexPolygon(List<Tuple<int, int>> Coords, Action<Graphics> Del, List<int> Boundaries) : base()
        {
            _count = Boundaries.Count - 1;
            _polygons = new List<Polygon>();
            //Используется только тут
            _coords = new List<Tuple<int, int>>();
            int j = 0;
            for (int i = 0; i < _count; i++)
            {
                for (; j < Boundaries[i]; j++)
                {
                    _coords.Add(Coords[j]);
                }
                _polygons[i] = new Polygon(_coords, Del);
                _MassSelect += _polygons[i].Selection;
            }
            _coords = null;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void MouseFocus(int X, int Y)
        {
            for (int i = 0; i < _count; i++)
            {
                _polygons[i].MouseFocus(X, Y);
                if (_polygons[i].Selected)
                {
                    Selected = true;
                    break;
                }
            }
        }
    }
}
