using System;
using VerticesEngine;
using VerticesEngine.UI.Themes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VerticesEngine.UI.Menus;
using VerticesEngine.UI.Controls;
using VerticesEngine.UI;
using VerticesEngine.Graphics;

namespace VerticesEngine.AppDemo.UI
{
    public class MenuArtProvider : vxMenuScreenArtProvider
    {
        public static int MenuWidth = vxScreen.Width / 4;

        public MenuArtProvider()
        {
            TitleSpriteSheetRegion = new Rectangle(312, 0, 458, 122);

            IsTitleTextShadowVisible = true;
            TitleShadowAlpha = 0.75f;
            IsTitleTextShadowVisible = false;
            TitleColor = Color.White;

        }

        protected override SpriteFont GetTitleFont()
        {
            return vxUITheme.Fonts.Size20;
        }



        protected override void UpdateMenuEntryLocations(vxMenuBaseScreen MenuScreen)
        {
            // Get Total Height of Menu Items and set the Height based on that.
            int MenuHeight = 0;

            foreach (vxMenuEntry item in MenuScreen.MenuEntries)
                MenuHeight += item.Height + (int)Margin.Y;



            MenuStartPosition = new Vector2(24, TitleBoundingRectangle.Bottom + 16);

            IsTitleBackgroundVisible = false;

            // Make the menu slide into place during transitions, using a
            // power curve to make things look more interesting (this makes
            // the movement slow down as it nears the end).
            float transitionOffset = (float)Math.Pow(MenuScreen.TransitionPosition, 2);
            TextJustification = vxEnumTextHorizontalJustification.Left;
            //Set the Top Menu Start Position
            var position = MenuStartPosition;

            // update each menu entry's location in turn
            for (int i = 0; i < MenuScreen.MenuEntries.Count; i++)
            {
                // get menu entry offset
                vxMenuEntry menuEntry = MenuScreen.MenuEntries[i];
                NextMenuItemOffset = new Vector2(0, menuEntry.Height + Margin.Y);

                //Set Menu Item Location
                //if (TextJustification == vxEnumTextHorizontalJustification.Left)
                position.X = MenuStartPosition.X;


                if (MenuScreen.ScreenState == ScreenState.TransitionOn)
                    position.X -= transitionOffset * 128;
                else
                    position.X -= transitionOffset * 128;

                // set the entry's position
                menuEntry.Position = position;

                // move down for the next entry the size of this entry
                position += NextMenuItemOffset;

                //this.vxInput.ShowCursor = true;
            }
        }



        public override void SetTitlePosition(VerticesEngine.UI.Menus.vxMenuBaseScreen MenuScreen)
        {
            TitlePosition = new Vector2(24, 24);

            //TitlePadding = new Vector2(100, 40) * vxLayout.Scale;
        }

        public override void Draw(object guiItem)
        {
            vxMenuBaseScreen MenuScreen = (vxMenuBaseScreen)guiItem;

            // draw background back panel
            Rectangle menuBackground = new Rectangle(0, 0, MenuWidth, vxScreen.Height);

            var BlurredScene = vxRenderPipeline.Instance.BlurredScene;
            vxGraphics.SpriteBatch.Draw(BlurredScene, menuBackground, menuBackground, Color.White * MenuScreen.TransitionAlpha);
            vxGraphics.SpriteBatch.Draw(DefaultTexture, menuBackground, Color.Black * 0.5f * MenuScreen.TransitionAlpha);

            // Draw Version Information
            float scale = 1.0f;

            var versionText = "v. " + vxEngine.Game.Version;
            var versionFont = vxUITheme.Fonts.Size10;
            Vector2 TextSize = versionFont.MeasureString(versionText) * scale;
            var versionTextPos = new Vector2(10, vxGraphics.GraphicsDevice.Viewport.Height - versionFont.LineSpacing * scale - 10);
            Vector2 Padding = new Vector2(10, 6);


            // Draws Version Number
            vxGraphics.SpriteBatch.DrawString(versionFont, versionText, versionTextPos.ToIntValue(),
                                          Color.White * 0.5f * MenuScreen.TransitionAlpha, 0, Vector2.Zero, scale, SpriteEffects.None, 1);

            base.Draw(guiItem);
        }
    }
}



