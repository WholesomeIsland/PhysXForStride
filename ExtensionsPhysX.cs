using NVIDIA.PhysX;
using Vector3 = Stride.Core.Mathematics.Vector3;
namespace Stride.PhysX
{
    public static class ExtensionsPhysX
    {
        public static PxVec3 ToPhysXVector3(this Vector3 a)
        {
            return new PxVec3(a.X, a.Y, a.Z);
        }
       public static Vector3 ToStrideVec3(this PxVec3 a)
        {
            return new Vector3(a.x, a.y, a.z);
        }
    }
}
