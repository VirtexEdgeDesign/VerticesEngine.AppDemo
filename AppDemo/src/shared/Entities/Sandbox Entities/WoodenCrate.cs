
using Microsoft.Xna.Framework;
using VerticesEngine;

namespace VerticesEngine.AppDemo
{
    [vxRegisterAsSandboxEntity("Wooden Crate", SandboxCategories.RealWorldItems, SandboxSubCategories.ConstructionItems, "Models/items/crate wooden/model")]
    public class WoodenCrate : TechDemoItem
    {
        public WoodenCrate(vxGameplayScene3D scene, Vector3 StartPosition) :
            base(scene, null, StartPosition)
        {

        }
    }
}
