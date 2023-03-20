
using BEPUphysics.Entities.Prefabs;
using Microsoft.Xna.Framework;

using VerticesEngine;
using VerticesEngine.Graphics;

namespace VerticesEngine.AppDemo
{
    public class Teapot : TechDemoItem
    {
        vxLightEntity light;

        public Teapot(vxGameplayScene3D scene, Vector3 StartPosition) :
            base(scene, VerticesTechDemoGame.Model_Items_Teapot, StartPosition)
        {
            light = new vxLightEntity(scene, StartPosition, LightType.Point, Color.Orange, 2, 1);
        }

        //protected override void OnPhysicsColliderSetup()
        //{
        //    PhysicsCollider = new Box(Position, 2, 2, 2);

        //    base.OnPhysicsColliderSetup();
        //}

        protected override void Update()
        {
            base.Update();
            light.Position = Position;
        }
    }
}
