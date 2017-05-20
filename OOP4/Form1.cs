using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP4
{
    public partial class Form1 : Form
    {
        private Graphics _canvas;
        private Bitmap _tb;
        public Form1()
        {
            InitializeComponent();
            _canvas = CreateGraphics();
            _tb = new Bitmap(ClientSize.Width, ClientSize.Height);
            using (Graphics g = Graphics.FromImage(_tb))
            {
                g.Clear(Color.Black);
                g.DrawLine(Pens.White, 0, 0, 100, 100);
                _canvas.DrawImage(_tb, ClientRectangle);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            mapDialog1.ShowDialog();
        }
    }
}
