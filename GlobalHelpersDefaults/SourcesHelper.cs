using System.Collections.Generic;
using GeometrySampling;

namespace GlobalHelpers
{
    public struct SourceSpecification
    {
        public List<string> SourceDefinition;
        public PoliMiSource SourcePoliMi;

        public SourceSpecification(PoliMiSource sourcePoliMi, List<string> sourceDefinition)
        {
            SourcePoliMi = sourcePoliMi;
            SourceDefinition = sourceDefinition;
        }

        public SourceSpecification(PoliMiSource sourcePoliMi, string sourceDefinition) : this(sourcePoliMi,
            new List<string>() {sourceDefinition})
        {
        }
    }

    public enum Sources
    {
        Point,
        Sphere,
        HollowCylinder,
        Cylinder,
        Fuel,
        NblStandard,
        PolySphere,
        PointSourceInSphericalShell
    }

    public static class SourcesHelper
    {
        public static SourceSpecification NoSource = new SourceSpecification(PoliMiSource.None, new List<string>());

        private const string SOURCE = "sdef";
        private const string POS = "pos =";
        private const string CELL = "cell =";
        private const string X = "x =";
        private const string Y = "y =";
        private const string Z = "z =";
        private const string DX = "1";
        private const string DY = "2";
        private const string DZ = "3";
        private const string DCELL = "4";
        private const string DRAD = "5";
        private const string SEP = " ";
        private const string RAD = "rad =";
        private const string AXIS = "axs =";
        private const string EXTENT = "ext =";
        private const string DIST = "d";
        private const string DISCRETE = "si";
        private const string FREQUENCY = "sp";
        private const string ENERGY = "erg =";
        private const string HISTORGRAM = "h";
        private const string LINE = "L";
        private const string UNIFORM_RANGE = "0 1";

        public static List<string> GetPoliMiPointSourcePositions(IPoint3DCollection points)
        {
            return GetPositionStrings(points.GetPointCollection());
        }

        public static List<string> GetPoliMiPointSourcePositions(List<MyPoint3D> points)
        {
            return GetPositionStrings(points);
        }

        private static List<string> GetPositionStrings(List<MyPoint3D> points)
        {
            List<string> positions = new List<string>();

            foreach (MyPoint3D p in points)
            {
                positions.Add(GetPointSource(p));
            }

            return positions;
        }

        public static string GetPointSource(MyPoint3D point)
        {
            return SOURCE + SEP + POS + SEP + point.X + SEP + point.Y + SEP + point.Z;
        }

        public static List<string> GetUniformRangePointSource(MyPoint3D point, double LowEnergy, double HighEnergy,
            string distNumber = "1")
        {
            List<string> source = new List<string>();

            string pointSource = GetPointSource(point);
            pointSource += SEP + ENERGY + DIST + distNumber;
            source.Add(pointSource);

            string energy = DISCRETE + distNumber + SEP + HISTORGRAM + SEP + LowEnergy.ToString() + SEP +
                            HighEnergy.ToString();
            source.Add(energy);

            string frequency = FREQUENCY + distNumber + SEP + "0" + SEP + "1";
            source.Add(frequency);

            return source;
        }

        public static List<string> GetSphereSource(MyPoint3D center, double radius)
        {
            List<string> source = new List<string>();
            source.Add(GetPointSource(center) + SEP + RAD + DIST + DRAD);
            source.Add(DISCRETE + DRAD + SEP + radius);
            return source;
        }


        // A cylindrical volume distribution is specified with the keywords POS, AXS, RAD, and
        // EXT. The axis of the cylinder passes through the point POS in the direction AXS. The
        // position of the particles is sampled uniformly on a circle whose radius is the sampled
        // value of RAD, centered on the axis of the cylinder. The circle lies in a plane
        // perpendicular to AXS at a distance from POS which is the sampled value of EXT. A
        // useful degenerate case is EXT=0, which provides a source with circular symmetry on
        // a plane.

        public static List<string> GetCylinderSource(MyPoint3D Base, CylinderExtent cylinder)
        {
            return new List<string>()
            {
                GetPointSource(Base) + SEP + RAD + cylinder.Radius + SEP + AXIS + cylinder.Axis.ToString(SEP) +
                SEP + EXTENT + cylinder.Height
            };
        }

        public static double eVtoMeV(double eV)
        {
            return eV * (1e-6);
        }

        public static List<string> GetBoundSourceForManyCells(List<int> cells, SphereExtent sphere)
        {
            List<string> source = new List<string>();
            source.Add(GetPointSource(sphere.Center) + SEP + RAD + DIST + DRAD + SEP + CELL + DCELL);
            source.Add(DISCRETE + DRAD + SEP + sphere.Radius);
            source.Add(FREQUENCY + DRAD + SEP + "-21 2");
            source.Add(GetCellDistribution(cells));
            return source;
        }

        //c
        // SDEF POS=0 0 0 RAD=d1 CEL=8
        // SI1 0 20. $ radial sampling range: 0 to Rmax (=20cm)
        // SP1 -21 2 $ weighting for radial sampling: here r^2
        public static List<string> GetBoundSourceForManyCells(List<int> cells, MyPoint3D center, double radius)
        {
            return GetBoundSourceForManyCells(cells, new SphereExtent(center, radius));
        }

        //
        // SDEF X=d1 Y=d2 Z=d3 ERG=1.25 PAR=2 CEL=8
        // c NOTE: source parallelepiped is larger that cell 8, and hence
        // c source positions sampled outside cell 8 are rejected.
        // SI1 -12. 12. $ x-range limits for source volume
        // SP1 0 1 $ uniform probability over x-range
        // SI2 -11. 11. $ y-range limits for source volume
        // SP2 0 1 $ uniform probability over y-range
        // SI3 -13. 13. $ z-range limits for source volume
        // SP3 0 1 $ uniform probability over z-range
        public static List<string> GetBoundSourceForManyCells(List<int> cells, CuboidExtent cuboid)
        {
            List<string> source = new List<string>();

            source.Add(SOURCE + SEP + X + DIST + DX + SEP + Y + DIST + DY + SEP + Z + DIST + DZ + SEP + CELL + SEP +
                       DIST + DCELL);

            source.Add(DISCRETE + DX + SEP + cuboid.Lower.X + SEP + cuboid.Upper.X);
            source.Add(FREQUENCY + DX + SEP + UNIFORM_RANGE);

            source.Add(DISCRETE + DY + SEP + cuboid.Lower.Y + SEP + cuboid.Upper.Y);
            source.Add(FREQUENCY + DY + SEP + UNIFORM_RANGE);

            source.Add(DISCRETE + DZ + SEP + cuboid.Lower.Z + SEP + cuboid.Upper.Z);
            source.Add(FREQUENCY + DZ + SEP + UNIFORM_RANGE);

            source.Add(GetCellDistribution(cells));

            return source;
        }

        public static List<string> GetBoundSourceForManyCells(List<int> cells, MyPoint3D lower, MyPoint3D upper)
        {
            return GetBoundSourceForManyCells(cells, new CuboidExtent(lower, upper));
        }

        private static string GetCellDistribution(List<int> cells)
        {
            return DISCRETE + DCELL + SEP + LINE + SEP + ChangeListToString(cells);
        }

        private static string ChangeListToString(List<int> cells)
        {
            string cellString = string.Empty;
            foreach (var c in cells)
            {
                cellString += c + SEP;
            }

            return cellString;
        }
    }
}
