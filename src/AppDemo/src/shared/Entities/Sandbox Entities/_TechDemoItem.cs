
using BEPUphysics.Entities.Prefabs;
using Microsoft.Xna.Framework;
using VerticesEngine;
using VerticesEngine.Graphics;
using VerticesEngine.Physics;

namespace VerticesEngine.AppDemo
{
    public class TechDemoItem : vxEntity3D
    {
        protected vxBEPUPhysicsBaseCollider collider;

        public TechDemoItem() : base()
        {
            OnPhysicsColliderSetup();

            editorTransform = this.Transform.ToCopy();
        }

        public TechDemoItem(vxMesh model, Vector3 StartPosition) :
            base(model, StartPosition)
        {
            OnPhysicsColliderSetup();

            editorTransform = this.Transform.ToCopy();
        }

        public TechDemoItem(vxGameplayScene3D scene, vxMesh model, Vector3 StartPosition) :
            base(scene, model, StartPosition)
        {
            OnPhysicsColliderSetup();

            editorTransform = this.Transform.ToCopy();
        }

        protected virtual void OnPhysicsColliderSetup() { }

        private vxTransform editorTransform;

        protected override void OnSandboxStatusChanged(bool IsRunning)
        {
            base.OnSandboxStatusChanged(IsRunning);

            if(IsRunning)
            {
                editorTransform = this.Transform.ToCopy();
            }
            else
            {
                this.Transform = editorTransform.ToCopy();
            }

            if(collider != null)
            {
                collider.Clear();

                collider.IsAffectedByGravity = IsRunning;
                collider.MovementType = IsRunning ? vxPhysicsColliderMovementType.Dynamic : vxPhysicsColliderMovementType.Kinamatic;
            }
        }
    }
}
