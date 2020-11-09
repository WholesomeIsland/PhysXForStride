using System.Collections.Generic;
using Stride.Engine;
using Scene = Stride.Engine.Scene;
using NVIDIA.PhysX;
using System.IO;
using System.Reflection;
using System.Text;

namespace Stride.PhysX
{
    public enum Shapes
    {
        Box,
        Capsule,
    }
    class ActorHandler
    {
        Scene CurrentScene;
        Game game;
        PxFoundation foundation;
        PxPhysics physics;
        PxAllocatorCallback pxAllocatorCallback = default;
        public ActorHandler(Game game)
        {
            foundation = PxFoundation.create(PxVersion.PX_PHYSICS_VERSION, pxAllocatorCallback, new ErrorPhysXHandler());
            physics = foundation.createPhysics(PxVersion.PX_PHYSICS_VERSION);
            this.game = game;
            CurrentScene = game.SceneSystem.SceneInstance.RootScene;
        }
        public void AddShapeToEntity(Shapes type, Entity entity, PxMaterial material)
        {
            entity.Get<PhysXComponentBase>().AddShape(physics, type, material);
        }
        public void DeleteShapeFromEntity(Shapes type, Entity entity, PxMaterial material)
        {
            entity.Get<PhysXComponentBase>().AddShape(physics, type, material);
        }
        public void Release()
        {
            physics.release();
            foundation.release();
        }
    }
    public class ErrorPhysXHandler : PxDefaultErrorCallback
    {
        FileStream fs = File.Create(@"c:\3030Temp\physLog.txt");
        public ErrorPhysXHandler() : base()
        {

        }
        public override void reportError(PxErrorCode errorCode, string message, string file, int lineNumber)
        {
            byte[] b = new UTF8Encoding(true).GetBytes(errorCode.ToString() + " : " + message);
            fs.Write(b, 0, b.Length);
        }
    }
}
