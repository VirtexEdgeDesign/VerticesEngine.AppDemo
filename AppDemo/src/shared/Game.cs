#region Using Statements
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using VerticesEngine;
using VerticesEngine.AppDemo.UI;
using VerticesEngine.ContentManagement;
using VerticesEngine.Graphics;
using VerticesEngine.Input;
using VerticesEngine.Plugins;
using VerticesEngine.UI;
using VerticesEngine.UI.Themes;
#endregion

namespace VerticesEngine.AppDemo
{
    /// <summary>
    /// Sample showing how to manage different game states, with transitions
    /// between menu screens, a loading screen, the game itself, and a pause
    /// menu. This main game class is extremely simple: all the interesting
    /// stuff happens in the ScreenManager component.
    /// </summary>
    [vxGameConfigurations(GameName = "Vertics Engine Tech Demo",
        GameType = vxGameEnviromentType.Both,
        MainOrientation = vxOrientationType.Landscape,
        ConfigOptions = vxGameConfigFlags.IsCursorVisible | vxGameConfigFlags.GraphicsSettings | vxGameConfigFlags.PlayerProfileSupport

#if __MOBILE__
        | vxGameConfigFlags.PlayerProfileSupport
#endif        
        | vxGameConfigFlags.AudioSettings)]
    public class VerticesTechDemoGame : vxGame
    {
        #region -- Initialization --


        //public static vxMesh Model_Items_WoodenCrate { get; set; }
        public static vxMesh Model_Items_Rock { get; set; }
        public static vxMesh Model_Items_WaterCrate { get; set; }
        public static vxMesh Model_Items_Concrete { get; set; }
        public static vxMesh Model_Items_Teapot { get; set; }

        protected override string GetAppID()
        {
            return "1534150";
        }

        /// <summary>
        /// The main game constructor.
        /// </summary>
		public VerticesTechDemoGame() : base()
        {

        }
        
        protected override void OnGameStart()
        {
            base.OnGameStart(new IntroScene(), new MainvxMenuBaseScreen());
        }


        protected override vxIPlugin GetCoreGamePlugin()
        {
            return new BaseMetricGameContentPack();
        }
        
        #endregion

        #region -- Load Content --
        
        /// <summary>
        /// Loads graphics content.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();

            vxEngine.Game.IsMouseVisible = false;// vxEngine.PlatformType == vxPlatformHardwareType.Desktop;
            vxInput.IsCursorVisible = vxEngine.PlatformType == vxPlatformHardwareType.Desktop;
            // Let the Inpurt Manager Draw
            vxInput.IsCusorInitialised = true;
        }

        protected override void OnLoadUIAssets()
        {
            base.OnLoadUIAssets();
            
            vxUITheme.Fonts = new vxFontPack("Fonts", "en");
            vxUITheme.ArtProviderForMenuScreenItems = new MenuItemArtProvider();
            vxUITheme.ArtProviderForMenuScreen = new MenuArtProvider();
            vxUITheme.ArtProviderForButtons = new ButtonArtProvider();
        }

        protected override void OnRenderPipelineInitialised(vxRenderPipeline renderPipeline)
        {
            base.OnRenderPipelineInitialised(renderPipeline);
        }

        protected override IEnumerator LoadGlobalContent()
        {
            base.LoadGlobalContent();

            Model_Items_Concrete = vxContentManager.Instance.Load<vxMesh>("Models/items/concrete_cube/concrete_cube");
            Model_Items_Teapot = vxContentManager.Instance.Load<vxMesh>("Models/items/teapot/teapot");

            vxInput.CursorSprite = Content.Load<Texture2D>(AssetPaths.Textures.CURSOR_CURSOR_PNG);
            vxInput.CursorSpriteClicked = Content.Load<Texture2D>(AssetPaths.Textures.CURSOR_CURSOR_CLICKED_PNG);

            yield return null;
        }


#endregion

    }
}
