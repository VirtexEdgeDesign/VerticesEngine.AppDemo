
using Microsoft.Xna.Framework;
using VerticesEngine;

namespace VerticesEngine.AppDemo
{
    public class Rock : TechDemoItem
    {

        public Rock(vxGameplayScene3D scene, Vector3 StartPosition) :
            base(scene, VerticesTechDemoGame.Model_Items_Rock, StartPosition)
        {

        }
    }
}
