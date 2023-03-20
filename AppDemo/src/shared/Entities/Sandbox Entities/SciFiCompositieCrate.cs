
using Microsoft.Xna.Framework;


using VerticesEngine;

namespace VerticesEngine.AppDemo
{
    [vxRegisterAsSandboxEntity("SciFi Composite Crate", SandboxCategories.RealWorldItems, SandboxSubCategories.ConstructionItems, "Models/items/crate scifi/model")]
    public class SciFiCompositieCrate : TechDemoItem
    {
        public SciFiCompositieCrate() : base()
        {

        }

        public SciFiCompositieCrate(vxGameplayScene3D scene, Vector3 StartPosition) :
            base(scene, null, StartPosition)
        {

        }

    }
}
