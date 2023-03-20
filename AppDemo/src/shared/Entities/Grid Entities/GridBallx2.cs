
using BEPUphysics.Entities.Prefabs;
using Microsoft.Xna.Framework;

using VerticesEngine;
using VerticesEngine.Physics;
using VerticesEngine.Physics.BEPUWrapper;

namespace VerticesEngine.AppDemo
{
    [vxRegisterAsSandboxEntity("Grid Ball x 2", SandboxCategories.GridItems, SandboxSubCategories.GridItems, "Models/items/gridballx2/model")]
    public class GridBallx2 : TechDemoItem
    {
        public GridBallx2()
        {

        }

        public GridBallx2(vxGameplayScene3D scene, Vector3 StartPosition) :
            base(scene, null, StartPosition)
        {

        }
        protected override void OnPhysicsColliderSetup()
        {
            collider = AddComponent<vxBEPUPhysicsSphereCollider>();
            collider.Mass = 10;
            collider.IsAffectedByGravity = false;
        }
    }
}
