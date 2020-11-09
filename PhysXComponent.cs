using Stride.Engine;
using NVIDIA.PhysX;
namespace Stride.PhysX
{
    class PhysXComponentBase : EntityComponent
    {
        
        internal PxShape internalShape;
        PxRigidDynamic rigidbody = null;
        public void AddShape(PxPhysics physics, Shapes type, PxMaterial material)
        {
            PxShape shape;
            bool cdn = type == Shapes.Box;
            if (rigidbody == null)
            {
                var t = Entity.Get<TransformComponent>().LocalMatrix;
                var Matrix = new PxMat44(new PxVec4(t.M11, t.M12, t.M13, t.M14), new PxVec4(t.M21, t.M22, t.M23, t.M24), new PxVec4(t.M31, t.M32, t.M33, t.M34), new PxVec4(t.M41, t.M42, t.M43, t.M44));
                rigidbody = physics.createRigidDynamic(new PxTransform(Matrix));
                if (cdn)
                {
                    shape = physics.createShape(new PxBoxGeometry(new PxVec3(1, 1, 1)), material, true);
                }
                else
                {
                    shape = physics.createShape(new PxCapsuleGeometry(1, 1), material, true);
                }
            }
            else
            {
                if (cdn)
                {
                    shape = physics.createShape(new PxBoxGeometry(new PxVec3(1, 1, 1)), material, true);
                }
                else
                {
                    shape = physics.createShape(new PxCapsuleGeometry(1, 1), material, true);
                }
            }
           
        }
        public void DeleteShape(PxShape shape)
        {
            rigidbody.detachShape(shape);
        }
    }
}
