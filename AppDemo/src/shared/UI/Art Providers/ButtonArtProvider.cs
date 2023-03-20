using Microsoft.Xna.Framework;
using System;
using VerticesEngine;
using VerticesEngine.Graphics;
using VerticesEngine.UI;
using VerticesEngine.UI.Controls;
using VerticesEngine.UI.Themes;

namespace VerticesEngine.AppDemo.UI
{
    public class ButtonArtProvider : vxButtonArtProvider
    {
        public ButtonArtProvider() : base()
        {
            DefaultWidth = 150;
            DefaultHeight = 24;

            DoBorder = true;
            BorderWidth = 2;


            Theme = new vxUIControlTheme(
            new vxColourTheme(Color.DarkOrange, Color.DeepSkyBlue, Color.DeepSkyBlue * 1.25f),
                new vxColourTheme(Color.Black));
            Theme.Background.DisabledColour = Color.DarkGray;
            Theme.Text.DisabledColour = Color.Gray;
        }

        int growCount = 0;

        protected override void DrawUIControl(vxButtonControl button)
        {
            Theme.SetState(button);

            //Update Rectangle
            if (button.UseDefaultWidth)
            {
                //Set Width and Height
                button.Width = Math.Max(this.DefaultWidth, (int)(this.Font.MeasureString(button.Text).X + Padding.X * 2));
                button.Height = Math.Max(this.DefaultHeight, (int)(this.Font.MeasureString(button.Text).Y + Padding.Y * 2));

                button.Bounds = new Rectangle(
                    (int)(button.Position.X - Padding.X),
                    (int)(button.Position.Y - Padding.Y / 2),
                    button.Width, button.Height);
            }

            float GUIAlpha = 1;
            if (button.UIManager != null)
                GUIAlpha = button.UIManager.Alpha;

            float growSpeed = 1;// Math.Min(button.TransitionAlpha * (1 + button.GUIIndex), 1);

            if (button.ScreenState != ScreenState.TransitionOff)
            {
                growCount += Math.Max(1, button.GUIIndex * 2 / 3);
                growSpeed = MathHelper.Clamp((button.GUIIndex * -6 + growCount) / 10.0f, 0, 1);
            }

            if (button.ScreenState == ScreenState.TransitionOff)
            {
                growCount--;
                growSpeed = Math.Min(button.TransitionAlpha * (1 + button.GUIIndex), 1);
            }

            Rectangle background = new Rectangle(
                    (int)(button.Position.X - Padding.X + button.Width * (1 - growSpeed)),
                    (int)(button.Position.Y - Padding.Y / 2),
                    (int)(button.Width * growSpeed), button.Height);

            //Draw Button
            if (button.DoBorder && growSpeed > 0)
                vxGraphics.SpriteBatch.Draw(DefaultTexture, background.GetBorder(1),
                    button.BorderColour * Opacity * GUIAlpha * button.TransitionAlpha);


            vxGraphics.SpriteBatch.Draw(DefaultTexture, background,
                Theme.Background.Color * Opacity * GUIAlpha * button.TransitionAlpha);

            vxGraphics.SpriteBatch.DrawString(this.Font, button.Text,
                new Vector2(
                    button.Position.X + button.Width / 2 - this.Font.MeasureString(button.Text).X / 2 - Padding.X,
                    button.Position.Y + button.Height / 2 - this.Font.MeasureString(button.Text).Y / 2),
                                          Theme.Text.Color * Opacity * GUIAlpha * growSpeed * button.TransitionAlpha);
        }
    }
}

