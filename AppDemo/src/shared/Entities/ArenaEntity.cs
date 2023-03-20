using BEPUphysics;
using BEPUphysics.BroadPhaseEntries;
using BEPUutilities;
using Microsoft.Xna.Framework;
using VerticesEngine;
using VerticesEngine.Graphics;
using VerticesEngine.Physics.BEPUWrapper;

namespace VerticesEngine.AppDemo
{
    public class ArenaEntity : vxEntity3D
    {
        public ArenaEntity(vxGameplayScene3D scene, vxMesh entityModel, Vector3 StartPosition)
            : base(scene, entityModel, StartPosition)
        {

            AddComponent<vxBEPUPhysicsStaticMeshCollider>();
        }

        
    }
}
