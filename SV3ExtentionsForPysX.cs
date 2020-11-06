using PhysX;
using Vector3 = Stride.Core.Mathematics.Vector3;
namespace Stride.Physx
{
    public static class V3ExtentionsPhysics
    {
        public static System.Numerics.Vector3 ToNumericsVector3(this Vector3 a)
        {
            return new System.Numerics.Vector3(a.X, a.Y, a.Z);
        }
    }
}
