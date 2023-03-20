
using BEPUphysics;
using BEPUphysics.Entities.Prefabs;
using BEPUutilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using VerticesEngine;

namespace VerticesEngine.AppDemo
{
    [vxRegisterAsSandboxEntity("Grid Tetra", SandboxCategories.GridItems, SandboxSubCategories.GridItems, "Models/items/gridtetrax2/model")]
    public class GridTetrax2 : TechDemoItem
    {
        public GridTetrax2()
        {

        }

        public GridTetrax2(vxGameplayScene3D scene, Vector3 StartPosition) :
            base(scene, null, StartPosition)
        {

            //Mass = 50;

        }


        //protected override void OnPhysicsColliderSetup()
        //{
        //    foreach (ModelMesh mesh in Model.ModelMain.Meshes)
        //        mesh.ParentBone.Transform = Matrix.CreateScale(100);
            
        //    ModelDataExtractor.GetVerticesAndIndicesFromModel(Model.ModelMain, out MeshVertices, out MeshIndices);

        //    var transform = new AffineTransform(new Vector3(0.01f), Quaternion.Identity, StartPosition);

        //    PhysicsCollider = new MobileMesh(MeshVertices, MeshIndices,transform, 
        //                            BEPUphysics.CollisionShapes.MobileMeshSolidity.Counterclockwise);

        //    base.OnPhysicsColliderSetup();
        //}
    }
}
