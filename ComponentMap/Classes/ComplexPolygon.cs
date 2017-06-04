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
        private event Action _Clear;
        public override bool Selected {
            get
            {
                return _selected;
            }
            protected set
            {
                _selected = value;
                if (value)
                {
                    for (int i = 0; i < _count; i++)
                    {
                        _polygons[i].DrawWithoutText();
                    }
                    Temp(Name + "\n\n" + _data);
                }
            }
        }

        public ComplexPolygon(List<Point> Coords, Action<List<Point>> Del,
            List<int> Boundaries, Action Clear, string[] Data, Action<string> Changer, Action<string> LabelText) : base(Changer, LabelText)
        {
            _data = Data[1];
            Name = Data[0];
            _Clear += Clear;
            _count = Boundaries.Count;
            _polygons = new List<Polygon>();
            //Используется только тут
            _coords = new List<Point>();
            int j = 0;
            for (int i = 0; i < _count; i++)
            {
                for (; j < Boundaries[i]; j++)
                {
                    _coords.Add(Coords[j]);
                }
                _polygons.Add(new Polygon(_coords, Del, Changer, Data, LabelText));
                _MassSelect += _polygons[i].Selection;
                _coords = new List<Point>();
            }
        }

        public override void Draw()
        {
            for (int i = 0; i < _count; i++)
            {
                _polygons[i].DrawWithoutText();
            }
            Temp(Name + "\n\n" + _data);
        }

        public override void MouseFocus(int X, int Y)
        {
            for (int i = 0; i < _count; i++)
            {
                _polygons[i].MouseFocus(X, Y);
                if (_polygons[i].Selected)
                {
                    _MassSelect(true);
                    Selected = true;
                    break;
                }
            }
        }
    }
}
