
using BEPUphysics.Entities.Prefabs;
using Microsoft.Xna.Framework;
using VerticesEngine;
using VerticesEngine.Physics;
using VerticesEngine.Physics.BEPUWrapper;

namespace VerticesEngine.AppDemo
{
    [vxRegisterAsSandboxEntity("Grid Ball x 1", SandboxCategories.GridItems, SandboxSubCategories.GridItems, "Models/items/gridballx1/model")]
    public class GridBallx1 : TechDemoItem
    {
        public GridBallx1()
        {

        }


        public GridBallx1(vxGameplayScene3D scene, Vector3 StartPosition) :
            base(scene, null, StartPosition)
        {

        }

        protected override void OnPhysicsColliderSetup()
        {
            collider = AddComponent<vxBEPUPhysicsSphereCollider>();
            collider.Mass = 10;
            collider.IsAffectedByGravity = false;
            ((vxBEPUPhysicsSphereCollider)collider).Radius = 0.5f;
        }
    }
}
