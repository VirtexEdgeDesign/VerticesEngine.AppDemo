
using BEPUphysics.Entities.Prefabs;
using Microsoft.Xna.Framework;

using VerticesEngine;
using VerticesEngine.Physics;
using VerticesEngine.Physics.BEPUWrapper;

namespace VerticesEngine.AppDemo
{
    [vxRegisterAsSandboxEntity("Grid Cube x 2", SandboxCategories.GridItems, SandboxSubCategories.GridItems, "Models/items/gridcubex2/model")]
    public class GridCubex2 : TechDemoItem
    {
        public GridCubex2()
        {
            collider = AddComponent<vxBEPUPhysicsBoxCollider>();
            ((vxBEPUPhysicsBoxCollider)collider).Width = 2;
            ((vxBEPUPhysicsBoxCollider)collider).Height = 2;
            ((vxBEPUPhysicsBoxCollider)collider).Length = 2;
            collider.Mass = 10;
            collider.MovementType = vxPhysicsColliderMovementType.Kinamatic;
            collider.IsAffectedByGravity = false;
        }

        public GridCubex2(vxGameplayScene3D scene, Vector3 StartPosition) :
            base(scene, null, StartPosition)
        {
            collider = AddComponent<vxBEPUPhysicsBoxCollider>();
            ((vxBEPUPhysicsBoxCollider)collider).Width = 2;
            ((vxBEPUPhysicsBoxCollider)collider).Height = 2;
            ((vxBEPUPhysicsBoxCollider)collider).Length = 2;
            collider.Mass = 10;
            collider.MovementType = vxPhysicsColliderMovementType.Kinamatic;
            collider.IsAffectedByGravity = false;
        }
    }
}
