

using BEPUphysics;
using BEPUphysics.Entities.Prefabs;
using BEPUutilities;
using Microsoft.Xna.Framework;
using VerticesEngine;
using VerticesEngine.Physics;

namespace VerticesEngine.AppDemo
{
    [vxRegisterAsSandboxEntity("Grid Ramp1", SandboxCategories.GridItems, SandboxSubCategories.GridItems, "Models/grid/ramp1/model")]
    public class GridRamp1 : TechDemoItem
    {
        public GridRamp1()
        {

        }

        public GridRamp1(vxGameplayScene3D scene, Vector3 StartPosition) :
            base(scene, null, StartPosition)
        {

            //Mass = 1000;

        }

        protected override void OnPhysicsColliderSetup()
        {
            //foreach (ModelMesh mesh in Model.ModelMain.Meshes)
            //    mesh.ParentBone.Transform = Matrix.CreateScale(100);
            
            //ModelDataExtractor.GetVerticesAndIndicesFromModel(Model.ModelMain, out MeshVertices, out MeshIndices);

            //var transform = new AffineTransform(new Vector3(0.01f), Quaternion.Identity, StartPosition);

            //PhysicsCollider = new MobileMesh(MeshVertices, MeshIndices,transform, 
            //                        BEPUphysics.CollisionShapes.MobileMeshSolidity.Counterclockwise);

            //base.OnPhysicsColliderSetup();
        }

    }
}
