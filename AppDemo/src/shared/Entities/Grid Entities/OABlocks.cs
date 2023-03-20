
using BEPUphysics.Entities.Prefabs;
using Microsoft.Xna.Framework;
using VerticesEngine;

namespace VerticesEngine.AppDemo
{
    [vxRegisterAsSandboxEntity("AOBlocks", SandboxCategories.GridItems, SandboxSubCategories.GridItems, "Models/stuff/intro")]
    public class AOBlocks : TechDemoItem
    {
        
        public AOBlocks(vxGameplayScene3D scene, Vector3 StartPosition) : base (scene, null, StartPosition)
        {

        }
        protected override void OnPhysicsColliderSetup()
        {
            // As a check, create the entity as a unit cube
            //PhysicsCollider = new Sphere(StartPosition, 0.5f, 1);
         
            base.OnPhysicsColliderSetup();
        }
    }
}
