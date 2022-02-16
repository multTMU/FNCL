using System;
using GeometrySampling;
using GlobalHelpers;

namespace GuiWidgets.Source
{
    public interface ISourceSelectionGui
    {
        Sources GetSourceType();
        event EventHandler LaunchFuelEditor;
        bool DisplayMaterialEditor();
        string GetFuelFile();
        double GetInnerRadius();
        double GetOuterRadius();
        Point3D GetCenter();
        Point3D GetAxis();

        double GetRadius();

        //int GetMaterial();
        //PoliMiSource GetPoliMiSource();
        double GetFuelHeightDisplacement();
        double GetCylinderHeight();
    }

    public static class SourceSelectionGuiHelper
    {
        public static ISourceSelectionGui GetSourceSelectionForm(Sources newSource)
        {
            switch (newSource)
            {
                case Sources.Point:
                    return new PointSource();
                case Sources.Sphere:
                    return new SphereSource();
                case Sources.HollowCylinder:
                    return new HollowCylinder();
                case Sources.Cylinder:
                    return new Cylinder();
                case Sources.Fuel:
                    return new FuelSource();
                case Sources.NblStandard:
                    return new NblStandard();
                case Sources.PolySphere:
                    return new EmbededSphere(true);
                case Sources.PointSourceInSphericalShell:
                    return new EmbededSphere(false);
                default:
                    return new PointSource();
            }
        }
    }
}
