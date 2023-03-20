
//XNA/MONOGAME
using Microsoft.Xna.Framework;


using VerticesEngine;
using VerticesEngine.Graphics;

namespace VerticesEngine.AppDemo
{
    public class Envrio : vxEntity3D
    {
        /// <summary>
        /// Creates a New Instance of the Base Ship Class
        /// </summary>
        /// <param name="AssetPath"></param>
        public Envrio(vxGameplayScene3D scene, vxMesh entityModel, Vector3 StartPosition)
            : base(scene, entityModel, StartPosition)
        {
            
        }
    }
}
