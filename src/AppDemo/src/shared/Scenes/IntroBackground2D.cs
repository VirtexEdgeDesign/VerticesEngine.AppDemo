using System;


using VerticesEngine;

namespace VerticesEngine.AppDemo
{
    /// <summary>
    /// This is the main class for the game. It holds the instances of the sphere simulator,
    /// the arena, the bsp tree, renderer, GUI (Overlay) and player. It contains the main 
    /// game loop, and provides keyboard and mouse input.
    /// </summary>
    public class IntroBackground2D : vxGameplayScene2D
    {

        public IntroBackground2D():base(vxStartGameMode.GamePlay)
		{
			TransitionOnTime = TimeSpan.FromSeconds(1.5);
			TransitionOffTime = TimeSpan.FromSeconds(0.5);

        }
    }
}
