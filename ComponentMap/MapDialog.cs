using System.Threading;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Microsoft.Win32;
using System.Security;
using System.Security.Permissions;

namespace ComponentMap
{
    public partial class MapDialog : CommonDialog
    {
        public MapDialog()
        {
            InitializeComponent();
        }

        public MapDialog(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }

        protected override bool RunDialog(IntPtr hwndOwner)
        {
            using (MapForm f = new MapForm(this))
                return f.ShowDialog() == DialogResult.OK;
            
        }

        public void MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
