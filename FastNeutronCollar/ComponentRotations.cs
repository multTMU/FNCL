using GeometrySampling;

namespace FastNeutronCollar
{
    public partial class FNCLcomponent
    {
        private class DetectorOne : DetectorTransform
        {
            public DetectorOne(PanelTransform Transform, MyPoint3D DetectorCenter, MyPoint3D DetectorExtents) : base(
                Transform, DetectorCenter, DetectorExtents)
            {
                comment = "One";
            }
        }

        private class DetectorTwo : DetectorTransform
        {
            public DetectorTwo(PanelTransform Transform, MyPoint3D DetectorCenter, MyPoint3D DetectorExtents) : base(
                Transform, DetectorCenter, DetectorExtents)
            {
                comment = "Two";
            }

            protected override MyPoint3D GetCenter(MyPoint3D center)
            {
                return MyPoint3D.MirrorY(center);
            }
        }

        private class DetectorThree : DetectorTransform
        {
            public DetectorThree(PanelTransform Transform, MyPoint3D DetectorCenter, MyPoint3D DetectorExtents) : base(
                Transform, DetectorCenter, DetectorExtents)
            {
                comment = "Three";
            }

            protected override MyPoint3D GetCenter(MyPoint3D center)
            {
                return MyPoint3D.MirrorZ(center);
            }

            protected override MyPoint3D TransformAxis(MyPoint3D axis)
            {
                return MyPoint3D.MirrorZ(axis);
            }
        }

        private class DetectorFour : DetectorTransform
        {
            public DetectorFour(PanelTransform Transform, MyPoint3D DetectorCenter, MyPoint3D DetectorExtents) : base(
                Transform, DetectorCenter, DetectorExtents)
            {
                comment = "Four";
            }

            protected override MyPoint3D GetCenter(MyPoint3D center)
            {
                return MyPoint3D.MirrorZ(MyPoint3D.MirrorY(center));
            }

            protected override MyPoint3D TransformAxis(MyPoint3D axis)
            {
                return MyPoint3D.MirrorZ(axis);
            }
        }

        private abstract class DetectorTransform
        {
            private readonly PanelTransform transform;
            protected readonly MyPoint3D detectorCenter;
            private readonly MyPoint3D detectorExtents;
            protected string comment;

            public DetectorTransform(PanelTransform Transform, MyPoint3D DetectorCenter, MyPoint3D DetectorExtents)
            {
                transform = Transform;
                detectorCenter = DetectorCenter;
                detectorExtents = transform.TransformExtents(DetectorExtents);
            }

            public MyPoint3D GetDetectorCenter()
            {
                return TransformCenter(GetCenter());
            }

            private MyPoint3D GetCenter()
            {
                return GetCenter(detectorCenter);
            }

            protected virtual MyPoint3D GetCenter(MyPoint3D center)
            {
                return center;
            }

            private MyPoint3D TransformCenter(MyPoint3D center)
            {
                return transform.GetPanelCenter() + transform.TransformPoint(center);
            }

            public MyPoint3D GetDetectorExtents()
            {
                return transform.TransformExtents(detectorExtents);
            }

            public string GetComment()
            {
                return comment;
            }

            public Encased<MyPoint3D> GetPmtCenter(Encased<MyPoint3D> getPmtCenter)
            {
                var inner = TransformCenter(GetCenter(getPmtCenter.Inner));
                var outer = TransformCenter(GetCenter(getPmtCenter.Outer));
                return new Encased<MyPoint3D>(inner, outer);
            }

            public Encased<CylinderExtent> GetPmtExtents(Encased<CylinderExtent> pmtExtents)
            {
                pmtExtents.Outer.Axis = TransformAxis(pmtExtents.Outer.Axis);
                pmtExtents.Inner.Axis = TransformAxis(pmtExtents.Inner.Axis);
                return pmtExtents;
            }

            protected virtual MyPoint3D TransformAxis(MyPoint3D axis)
            {
                return axis;
            }
        }

        private abstract class PanelTransform
        {
            private readonly MyPoint3D center;
            private readonly MyPoint3D panelCenter;

            public PanelTransform(MyPoint3D Center, MyPoint3D PanelCenter)
            {
                center = Center;
                panelCenter = PanelCenter;
            }

            public MyPoint3D GetPanelCenter()
            {
                return center + TransformPoint(panelCenter);
            }

            public virtual string GetExtraComment()
            {
                return string.Empty;
            }

            public virtual MyPoint3D TransformPoint(MyPoint3D panelCenterPoint)
            {
                return panelCenterPoint;
            }

            public virtual MyPoint3D TransformExtents(MyPoint3D extents)
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

            public PanelOneHelper(MyPoint3D Center, MyPoint3D PanelCenter) : base(Center, PanelCenter)
            {
            }
        }

        private class PanelTwoHelper : PanelTransform
        {
            public override string GetExtraComment()
            {
                return "Two";
            }

            public override MyPoint3D TransformPoint(MyPoint3D point)
            {
                return MyPoint3D.MirrorX(point);
            }

            public override int PanelIndexOffset()
            {
                return 20;
            }

            public PanelTwoHelper(MyPoint3D Center, MyPoint3D PanelCenter) : base(Center, PanelCenter)
            {
            }
        }

        private class PanelThreeHelper : PanelTransform
        {
            public override string GetExtraComment()
            {
                return "Three";
            }

            public override MyPoint3D TransformPoint(MyPoint3D point)
            {
                return MyPoint3D.Swap_213(point);
            }

            public override MyPoint3D TransformExtents(MyPoint3D extents)
            {
                return MyPoint3D.Swap_213(extents);
            }

            public override int PanelIndexOffset()
            {
                return 30;
            }

            public PanelThreeHelper(MyPoint3D Center, MyPoint3D PanelCenter) : base(Center, PanelCenter)
            {
            }
        }
    }
}
