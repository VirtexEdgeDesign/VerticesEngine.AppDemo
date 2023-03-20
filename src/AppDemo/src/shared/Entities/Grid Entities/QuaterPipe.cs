

using BEPUphysics;
using BEPUphysics.BroadPhaseEntries;
using BEPUutilities;
using Microsoft.Xna.Framework;
using VerticesEngine;

namespace VerticesEngine.AppDemo
{
    //[vxRegisterAsSandboxEntityAttribute("Quater Pipe", SandboxCategories.GridItems, SandboxSubCategories.GridItems, "Models/grid/quaterpipe/model")]
    public class QuaterPipe : TechDemoItem
    {

        public QuaterPipe(vxGameplayScene3D scene, Vector3 StartPosition) :
            base(scene, null, StartPosition)
        {

            //Mass = 1000;

            //ModelDataExtractor.GetVerticesAndIndicesFromModel(Model.ModelMain, out MeshVertices, out MeshIndices);

            //PhysicsSkin = new StaticMesh(MeshVertices, MeshIndices,
            //    new AffineTransform(new Vector3(0.01f), Quaternion.CreateFromRotationMatrix(WorldTransform), new Vector3(0,4.5f, 0)));

            //Scene.PhyicsSimulation.Add(PhysicsSkin);
            //Scene.PhysicsDebugViewer.Add(PhysicsSkin);

            //base.OnPhysicsColliderSetup();
        }

        //StaticMesh PhysicsSkin;
        //protected override void OnPhysicsColliderSetup() { }

    }
}
