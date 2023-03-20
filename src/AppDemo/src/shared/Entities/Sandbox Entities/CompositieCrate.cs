
using Microsoft.Xna.Framework;


using VerticesEngine;

namespace VerticesEngine.AppDemo
{
    [vxRegisterAsSandboxEntity("Compositie Crate", SandboxCategories.RealWorldItems, SandboxSubCategories.ConstructionItems, "Models/items/crate composite/model")]
    public class CompositieCrate : TechDemoItem
    {

        public CompositieCrate(vxGameplayScene3D scene, Vector3 StartPosition) :
            base(scene, null, StartPosition)
        {

        }
    }
}
