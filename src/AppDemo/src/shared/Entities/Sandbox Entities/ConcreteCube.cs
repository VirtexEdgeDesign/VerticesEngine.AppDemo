using BEPUphysics.Entities.Prefabs;
using Microsoft.Xna.Framework;
using VerticesEngine;
using VerticesEngine.Physics;
using VerticesEngine.Physics.BEPUWrapper;

namespace VerticesEngine.AppDemo
{
    [vxRegisterAsSandboxEntity("Concrete Cube", SandboxCategories.RealWorldItems, SandboxSubCategories.ConstructionItems, AssetPaths.Models.ITEMS_CONCRETE_CUBE_CONCRETE_CUBE_FBX)]
    public class ConcreteCube : TechDemoItem
    {
        public ConcreteCube() : base(VerticesTechDemoGame.Model_Items_Concrete, Vector3.Zero)
        {
            collider = AddComponent<vxBEPUPhysicsBoxCollider>();
            ((vxBEPUPhysicsBoxCollider)collider).Width = 2;
            ((vxBEPUPhysicsBoxCollider)collider).Height = 2;
            ((vxBEPUPhysicsBoxCollider)collider).Length = 2;
            collider.Mass = 10;
            collider.MovementType = vxPhysicsColliderMovementType.Kinamatic;
            collider.IsAffectedByGravity = false;
        }

        public ConcreteCube(vxGameplayScene3D scene, Vector3 StartPosition) :
        base(scene, VerticesTechDemoGame.Model_Items_Concrete, StartPosition)
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