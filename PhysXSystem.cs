using Stride.Core;
using Stride.Engine;
using Stride.Games;

namespace Stride.PhysX
{
    class PhysXSystem : IGameSystemBase
    {
        public string Name;

        public int ReferenceCount;
        private ActorHandler handler;

        string IComponent.Name => Name;

        int IReferencable.ReferenceCount => ReferenceCount;

        public int AddReference()
        {
            ++ReferenceCount;
            return ReferenceCount;
        }

        public void Initialize()
        {
            
        }

        public int Release()
        {
            handler.Release();
            return 0;
        }
    }
}
