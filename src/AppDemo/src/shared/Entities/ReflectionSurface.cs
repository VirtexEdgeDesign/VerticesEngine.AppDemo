
//XNA/MONOGAME
using Microsoft.Xna.Framework;


using VerticesEngine;
using VerticesEngine.Graphics;

namespace VerticesEngine.AppDemo
{
    public class ReflectionSurface : vxEntity3D
    {
        /// <summary>
        /// Creates a New Instance of the Base Ship Class
        /// </summary>
        /// <param name="AssetPath"></param>
        public ReflectionSurface(vxGameplayScene3D scene, vxMesh entityModel, Vector3 StartPosition)
            : base(scene, entityModel, StartPosition)
        {
            
        }

        protected override void Update()
        {
            base.Update();

            //TextureUVOffset += new Vector2(0, 0.01f);
        }
    }
}
