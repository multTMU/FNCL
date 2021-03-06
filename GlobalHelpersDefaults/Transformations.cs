using GeometrySampling;

namespace GlobalHelpers
{
    public static class TransformationHelper
    {
        private const string TRANSLATE = "tr";
        private const string DEFAULT_DISPLACEMENT = " 0 0 0 ";

        public static string GetDisplacement(int label, MyPoint3D displacmentVector)
        {
            string dataLabel = GetDataLabel(label);

            return dataLabel + " " + displacmentVector.ToString();
        }

        public static string GetRotation(int label, MyPoint3D basisVector, MyPoint3D newVector)
        {
            return GetDataLabel(label) + " " + DEFAULT_DISPLACEMENT + GetRotation(basisVector, newVector);
        }

        public static string GetDisplacementAndRotation(int label, MyPoint3D displacmentVector, MyPoint3D basisVector,
            MyPoint3D newVector)
        {
            return GetDisplacement(label, displacmentVector) + " " + GetRotation(basisVector, newVector);
        }

        private static string GetRotation(MyPoint3D basisVector, MyPoint3D newVector)
        {
            basisVector = Point3DHelper.GetUnitVector(basisVector);
            newVector = Point3DHelper.GetUnitVector(newVector);
            Matrix3D rotation = Point3DHelper.GetRotationMatrix(basisVector, newVector);

            return rotation.ToString();
        }

        private static string GetDataLabel(in int label)
        {
            return TRANSLATE + label.ToString();
        }
    }
}
