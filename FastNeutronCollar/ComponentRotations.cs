using GeometrySampling;

namespace FastNeutronCollar
{
    public partial class FNCLcomponent
    {
        private class DetectorOne : DetectorTransform
        {
            public DetectorOne(PanelTransform Transform, Point3D DetectorCenter, Point3D DetectorExtents) : base(
                Transform, DetectorCenter, DetectorExtents)
            {
                comment = "One";
            }
        }

        private class DetectorTwo : DetectorTransform
        {
            public DetectorTwo(PanelTransform Transform, Point3D DetectorCenter, Point3D DetectorExtents) : base(
                Transform, DetectorCenter, DetectorExtents)
            {
                comment = "Two";
            }

            protected override Point3D GetCenter(Point3D center)
            {
                return Point3D.MirrorY(center);
            }
        }

        private class DetectorThree : DetectorTransform
        {
            public DetectorThree(PanelTransform Transform, Point3D DetectorCenter, Point3D DetectorExtents) : base(
                Transform, DetectorCenter, DetectorExtents)
            {
                comment = "Three";
            }

            protected override Point3D GetCenter(Point3D center)
            {
                return Point3D.MirrorZ(center);
            }

            protected override Point3D TransformAxis(Point3D axis)
            {
                return Point3D.MirrorZ(axis);
            }
        }

        private class DetectorFour : DetectorTransform
        {
            public DetectorFour(PanelTransform Transform, Point3D DetectorCenter, Point3D DetectorExtents) : base(
                Transform, DetectorCenter, DetectorExtents)
            {
                comment = "Four";
            }

            protected override Point3D GetCenter(Point3D center)
            {
                return Point3D.MirrorZ(Point3D.MirrorY(center));
            }

            protected override Point3D TransformAxis(Point3D axis)
            {
                return Point3D.MirrorZ(axis);
            }
        }

        private abstract class DetectorTransform
        {
            private readonly PanelTransform transform;
            protected readonly Point3D detectorCenter;
            private readonly Point3D detectorExtents;
            protected string comment;

            public DetectorTransform(PanelTransform Transform, Point3D DetectorCenter, Point3D DetectorExtents)
            {
                transform = Transform;
                detectorCenter = DetectorCenter;
                detectorExtents = transform.TransformExtents(DetectorExtents);
            }

            public Point3D GetDetectorCenter()
            {
                return TransformCenter(GetCenter());
            }

            private Point3D GetCenter()
            {
                return GetCenter(detectorCenter);
            }

            protected virtual Point3D GetCenter(Point3D center)
            {
                return center;
            }

            private Point3D TransformCenter(Point3D center)
            {
                return transform.GetPanelCenter() + transform.TransformPoint(center);
            }

            public Point3D GetDetectorExtents()
            {
                return transform.TransformExtents(detectorExtents);
            }

            public string GetComment()
            {
                return comment;
            }

            public Encased<Point3D> GetPmtCenter(Encased<Point3D> getPmtCenter)
            {
                var inner = TransformCenter(GetCenter(getPmtCenter.Inner));
                var outer = TransformCenter(GetCenter(getPmtCenter.Outer));
                return new Encased<Point3D>(inner, outer);
            }

            public Encased<CylinderExtent> GetPmtExtents(Encased<CylinderExtent> pmtExtents)
            {
                pmtExtents.Outer.Axis = TransformAxis(pmtExtents.Outer.Axis);
                pmtExtents.Inner.Axis = TransformAxis(pmtExtents.Inner.Axis);
                return pmtExtents;
            }

            protected virtual Point3D TransformAxis(Point3D axis)
            {
                return axis;
            }
        }

        private abstract class PanelTransform
        {
            private readonly Point3D center;
            private readonly Point3D panelCenter;

            public PanelTransform(Point3D Center, Point3D PanelCenter)
            {
                center = Center;
                panelCenter = PanelCenter;
            }

            public Point3D GetPanelCenter()
            {
                return center + TransformPoint(panelCenter);
            }

            public virtual string GetExtraComment()
            {
                return string.Empty;
            }

            public virtual Point3D TransformPoint(Point3D panelCenterPoint)
            {
                return panelCenterPoint;
            }

            public virtual Point3D TransformExtents(Point3D extents)
            {
                return extents;
            }

            public abstract int PanelIndexOffset();
        }

        private class PanelOneHelper : PanelTransform
        {
            public override string GetExtraComment()
            {
                return "One";
            }

            public override int PanelIndexOffset()
            {
                return 10;
            }

            public PanelOneHelper(Point3D Center, Point3D PanelCenter) : base(Center, PanelCenter)
            {
            }
        }

        private class PanelTwoHelper : PanelTransform
        {
            public override string GetExtraComment()
            {
                return "Two";
            }

            public override Point3D TransformPoint(Point3D point)
            {
                return Point3D.MirrorX(point);
            }

            public override int PanelIndexOffset()
            {
                return 20;
            }

            public PanelTwoHelper(Point3D Center, Point3D PanelCenter) : base(Center, PanelCenter)
            {
            }
        }

        private class PanelThreeHelper : PanelTransform
        {
            public override string GetExtraComment()
            {
                return "Three";
            }

            public override Point3D TransformPoint(Point3D point)
            {
                return Point3D.Swap_213(point);
            }

            public override Point3D TransformExtents(Point3D extents)
            {
                return Point3D.Swap_213(extents);
            }

            public override int PanelIndexOffset()
            {
                return 30;
            }

            public PanelThreeHelper(Point3D Center, Point3D PanelCenter) : base(Center, PanelCenter)
            {
            }
        }
    }
}
