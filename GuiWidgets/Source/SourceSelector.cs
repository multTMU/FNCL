using System;
using System.Windows.Forms;
using GlobalHelpers;

namespace GuiWidgets
{
    public partial class SourceSelector : UserControl
    {
        public event EventHandler SourceChanged;
        private Sources source;

        public SourceSelector()
        {
            InitializeComponent();
        }

        public Sources GetSource()
        {
            return source;
        }

        private void rbPoint_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPoint.Checked)
            {
                source = Sources.Point;
                HandleChange();
            }
        }

        private void rbSphere_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSphere.Checked)
            {
                source = Sources.Sphere;
                HandleChange();
            }
        }

        private void rbUhollowCyl_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUhollowCyl.Checked)
            {
                source = Sources.HollowCylinder;
                HandleChange();
            }
        }

        private void rbCyl_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCyl.Checked)
            {
                source = Sources.Cylinder;
                HandleChange();
            }
        }

        private void rbFuel_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFuel.Checked)
            {
                source = Sources.Fuel;
                HandleChange();
            }
        }

        protected virtual void HandleChange()
        {
            EventHandler handler = this.SourceChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }

        private void rbNbl_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNbl.Checked)
            {
                source = Sources.NblStandard;
                HandleChange();
            }
        }

        private void rbPeSphere_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPeSphere.Checked)
            {
                source = Sources.PolySphere;
                HandleChange();
            }
        }

        private void rbSphereShell_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSphereShell.Checked)
            {
                source = Sources.PointSourceInSphericalShell;
                HandleChange();
            }
        }
    }
}
