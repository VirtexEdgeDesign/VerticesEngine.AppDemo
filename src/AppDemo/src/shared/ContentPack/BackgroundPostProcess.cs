using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VerticesEngine;
using VerticesEngine.Graphics;

namespace VerticesEngine.AppDemo
{
    /// <summary>
    /// This is the diagram renderer of items.
    /// </summary>
    public class BackgroundPostProcess : vxRenderPass, vxIRenderPass
    {

        public override string RenderPass
        {
            get { return "Background"; }
        }
        public RenderTarget2D AlbedoPass;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:VerticesEngine.Graphics.vxSSAOPostProcess"/> class.
        /// </summary>
        /// <param name="Engine">Engine.</param>
        public BackgroundPostProcess() :base("Diagram Post Process", vxInternalAssets.Shaders.MainShader)
        {
            PresentationParameters pp = vxGraphics.GraphicsDevice.PresentationParameters;

            AlbedoPass = new RenderTarget2D(vxGraphics.GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight, false, pp.BackBufferFormat, pp.DepthStencilFormat);
        }

        public override void OnGraphicsRefresh()
        {
            base.OnGraphicsRefresh();
        }

        public void Prepare(vxCamera camera)
        {

        }

        public void Apply(vxCamera camera)
        {
            AlbedoPass = Renderer.GetNewTempTarget("Albedo Pass");

            vxGraphics.GraphicsDevice.SetRenderTarget(AlbedoPass);

            // draw the background first
            vxGraphics.SpriteBatch.Begin();



            vxGraphics.SpriteBatch.End();

        }
    }
}