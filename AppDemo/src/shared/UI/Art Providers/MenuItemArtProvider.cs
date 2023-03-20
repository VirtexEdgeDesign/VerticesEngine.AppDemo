using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using VerticesEngine;
using VerticesEngine.UI.Themes;
using VerticesEngine.UI.Controls;
using VerticesEngine.UI;
using VerticesEngine.Graphics;

namespace VerticesEngine.AppDemo.UI
{
    public class MenuItemArtProvider : vxMenuItemArtProvider
    {
        public MenuItemArtProvider() : base()
        {
            Theme = new vxUIControlTheme(new vxColourTheme(Color.DarkOrange, Color.DeepSkyBlue), new vxColourTheme(Color.White));
            
            Padding = new Vector2(15, 15) * vxLayout.Scale;
        }



        public override void Draw(object guiItem)
        {
            //First Cast the GUI Item to be a Menu Entry
            vxMenuEntry menuEntry = (vxMenuEntry)guiItem;

            Theme.SetState(menuEntry);

            // Set the font type
            SpriteFont font = vxUITheme.Fonts.Size16;

            // get the text size
            Vector2 Size = font.MeasureString(menuEntry.Text) * vxLayout.Scale;

            // calculate the bounds from the size
            menuEntry.Bounds = vxLayout.GetRect(0, menuEntry.Position.Y - Padding.Y / 2, MenuArtProvider.MenuWidth, Size.Y + Padding.Y);

            //Set Opacity from Parent Screen Transition Alpha
            menuEntry.Opacity = menuEntry.ParentScreen.TransitionAlpha;

            //Do a last second null check.
            if (menuEntry.Texture == null)
                menuEntry.Texture = DefaultTexture;

            // Draw the background
            vxGraphics.SpriteBatch.Draw(menuEntry.Texture, menuEntry.Bounds.GetBorder(-1), menuEntry.HasFocus ? Color.DarkOrange * menuEntry.Opacity : Color.Transparent);

            // draw the main text
            vxGraphics.SpriteBatch.DrawString(font, menuEntry.Text, menuEntry.Position.ToIntValue(), Theme.Text.Color * menuEntry.Opacity, 0, Vector2.Zero, Vector2.One,
            SpriteEffects.None,
            1);
        }
    }
}
