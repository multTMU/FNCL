using System;
using System.Windows.Forms;
using GlobalHelpers;

namespace GuiWidgets.Source
{
    public partial class SourceSelection : UserControl
    {
        private Sources source;
        private ISourceSelectionGui sourceWidget;
        public event EventHandler LaunchFuelEditor;
        public event EventHandler SourceChanged;

        public SourceSelection()
        {
            InitializeComponent();
            this.sourceSelector1.SourceChanged += SelectedSourceChanged;
            sourceWidget = SourceSelectionGuiHelper.GetSourceSelectionForm(Sources.Point);
            this.inMaterial.DataIsInteger = true;
            this.inMaterial.SetReadonly();
            ReInitializeEvents();
        }

        public void SetActiveState(bool active)
        {
            this.pickPoliMiSource1.Enabled = !active;
        }

        public bool EnableMaterialViewer()
        {
            return sourceWidget.DisplayMaterialEditor();
        }

        private void SelectedSourceChanged(object sender, EventArgs e)
        {
            source = this.sourceSelector1.GetSource();
            sourceWidget = SourceSelectionGuiHelper.GetSourceSelectionForm(source);
            this.pSource.Controls.Clear();
            this.pSource.Controls.Add(sourceWidget as Control);
            ReInitializeEvents();
            HandleSourceChanged();
        }

        protected virtual void HandleSourceChanged()
        {
            this.inMaterial.Enabled = sourceWidget.DisplayMaterialEditor();
            EventHandler handler = this.SourceChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }

        public double GetHeightCylinder()
        {
            return sourceWidget.GetCylinderHeight();
        }

        private void ReInitializeEvents()
        {
            sourceWidget.LaunchFuelEditor += LaunchFuelEditor;
        }

        public void SetMaterial(int materialKey)
        {
            this.inMaterial.SetValueRaiseNoEvent(materialKey);
        }

        public string GetFuelFile()
        {
            return sourceWidget.GetFuelFile();
        }

        public double GetFuelHeightDisplacement()
        {
            return sourceWidget.GetFuelHeightDisplacement();
        }

        public double GetInnerRadius()
        {
            return this.sourceWidget.GetInnerRadius();
        }

        public double GetOuterRadius()
        {
            return this.sourceWidget.GetOuterRadius();
        }

        public GeometrySampling.Point3D GetCenter()
        {
            return this.sourceWidget.GetCenter();
        }

        public GeometrySampling.Point3D GetAxis()
        {
            return this.sourceWidget.GetAxis();
        }

        public double GetRadius()
        {
            return this.sourceWidget.GetRadius();
        }

        public int GetMaterial()
        {
            return (int)inMaterial.Value;
        }

        public PoliMiSource GetPoliMiSource()
        {
            return this.pickPoliMiSource1.GetSource();
        }

        public Sources GetSourceType()
        {
            return this.sourceWidget.GetSourceType();
        }
    }
}
