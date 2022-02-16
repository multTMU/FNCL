using System;
using System.Windows.Forms;

namespace GuiWidgets.PulseShapeDisc
{
    public partial class DrawCurve : UserControl
    {
        public event EventHandler DrawCurveChanged;

        public event EventHandler ClearCurve;

        // public event EventHandler SavePsdToDictionary;
        public event EventHandler LoadCurve;

        public bool DrawCurveEnabled => this.cbDraw.Checked;

        //public string CurveFile => curveFile;

        //private string curveFile;

        public DrawCurve()
        {
            InitializeComponent();
        }

        private void cbDraw_CheckedChanged(object sender, EventArgs e)
        {
            OnDrawCurveChanged();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            OnClearCurve();
        }

        //private void bSaveFit_Click(object sender, EventArgs e)
        //{
        //    //curveFile = MultiplicityInterfaceHelper.GetFile("Save Current PSD As...", true);
        //    //if (!string.IsNullOrEmpty(curveFile))
        //    //{
        //        OnSaveToDictionary();
        //   // }
        //}

        protected virtual void OnDrawCurveChanged()
        {
            DrawCurveChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnClearCurve()
        {
            ClearCurve?.Invoke(this, EventArgs.Empty);
        }

        //protected virtual void OnSaveToDictionary()
        //{
        //    SavePsdToDictionary?.Invoke(this, EventArgs.Empty);
        //}

        private void bReLoad_Click(object sender, EventArgs e)
        {
            //curveFile = MultiplicityInterfaceHelper.GetFile("Load PSD Curve...", false);
            //if (!string.IsNullOrEmpty(curveFile))
            //{
            OnReloadCurve();
            //}
        }

        protected virtual void OnReloadCurve()
        {
            LoadCurve?.Invoke(this, EventArgs.Empty);
        }
    }
}
