//using BEPUphysics;
//using BEPUphysics.BroadPhaseEntries.MobileCollidables;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Input;
//using System;
//using VerticesEngine;
//using VerticesEngine.Input;

//namespace VerticesDemo
//{
//    /// <summary>
//    /// This is the main class for the game. It holds the instances of the sphere simulator,
//    /// the arena, the bsp tree, renderer, GUI (Overlay) and player. It contains the main 
//    /// game loop, and provides keyboard and mouse input.
//    /// </summary>
//    public class TechDemoTerrainSampleLevel : vxGameplayScene3D
//    {
		
//        public TechDemoTerrainSampleLevel():base(vxStartGameMode.GamePlay)
//        {
//            TransitionOnTime = TimeSpan.FromSeconds(1.5);
//            TransitionOffTime = TimeSpan.FromSeconds(0.5);

//        }
//        //vxLightEntity light;
//        MotorizedGrabSpring grabber;


//        public override void InitialiseCameras()
//        {
//            base.InitialiseCameras();


//            //foreach (var Camera in Cameras)
//            //{
//            //    Camera.Renderer.RenderingPasses.Insert(0, new BackgroundPostProcess(Camera.Renderer));
//            //}
//        }
//        /// <summary>
//        /// LoadContent will be called once per game and is the place to load
//        /// all of your content.
//        /// </summary>
//        public override void LoadContent()
//        {
//            base.LoadContent();


//            // Reset the Renderer
//            //Renderer = new vxRenderer3D(this)
//            //{
//            //    ShadowMapSize = 1024,
//            //    ShadowBoundingBoxSize = 256
//            //};
//            //Renderer.LoadContent();


//            // Initialise Camera Code
//            #region Set Up Camera

//            //Camera.CameraType = CameraType.CharacterFPS;
//            //Camera.FarPlane *= 5;

//            //character = new CharacterControllerInput(PhyicsSimulation, Camera, Engine);

//            //Since this is the character playground, turn on the character by default.
//            character.Activate();


//            character.CharacterController.Body.Position = new Vector3(0, 0, 10);
//            //Having the character body visible would be a bit distracting.
//            character.CharacterController.Body.Tag = "noDisplayObject";

//            SimulationStart();
//            SimulationStop();

//            //
//            //Grabbers
//            //
//            grabber = new MotorizedGrabSpring();
//            PhyicsSimulation.Add(grabber);
//            rayCastFilter = RayCastFilter;


//            #endregion

//            // Set up Fog
//            //DoFog = true;
//			//Renderer.FogNear = 20;
//            //Renderer.FogFar = Camera.FarPlane / 20;
//            SunEmitter.RotationX += 1.5f;

//            //vxTerrainEntity terrain = new vxTerrainEntity(this, 
//            //    vxInternalAssets.LoadInternalTexture2D("Textures/terrain/HeightMap"), Vector3.Zero);

//            //new vxTerrainEntity(Engine,
//            //Engine.InternalContentManager.Load<Texture2D>("Textures/terrain/HeightMap"), new Vector3(128 * 3, 0, 0));

//            //new vxTerrainEntity(Engine,
//            //    Engine.InternalContentManager.Load<Texture2D>("Textures/terrain/HeightMap"), new Vector3(0, 0, 128 * 3));
//            //new vxTerrainEntity(Engine,
//            //    Engine.InternalContentManager.Load<Texture2D>("Textures/terrain/HeightMap"), new Vector3(128 * 3, 0, 128 * 3));


//   //         vxTabPageControl ItemsTabPage = new vxTabPageControl(Engine, "Items");
//   //         NewSandboxItemDialog.TabControl.Add(ItemsTabPage);

//   //         vxScrollPanel ScrollPanel_GeneralItemsPage = new vxScrollPanel(Engine, new Vector2(0, 0),
//   //             Engine.GraphicsDevice.Viewport.Width - 150, Engine.GraphicsDevice.Viewport.Height - 75);

//   //         //Cubes
//   //         ScrollPanel_GeneralItemsPage.AddItem(new vxScrollPanelSpliter(Engine, "Items"));
//   //         ScrollPanel_GeneralItemsPage.AddItem(RegisterNewSandboxItem(WoodenCrate.EntityDescription));
//			//ScrollPanel_GeneralItemsPage.AddItem(RegisterNewSandboxItem(ConcreteCube.EntityDescription));
//			//ScrollPanel_GeneralItemsPage.AddItem(RegisterNewSandboxItem(Teapot.EntityDescription));
//   //         ScrollPanel_GeneralItemsPage.AddItem(RegisterNewSandboxItem(Rock.EntityDescription));
            

//   //         //Add the scrollpanel to the slider tab page.
//   //         ItemsTabPage.Add(ScrollPanel_GeneralItemsPage);


//            rand = new Random();
//        }

//        Random rand;
//        float grabDistance;
//        /// <summary>
//        /// Updates Main Gameplay Loop code here, this is affected by whether or not the scene is paused.
//        /// </summary>
//        /// <param name="gameTime"></param>
//        /// <param name="otherScreenHasFocus"></param>
//        /// <param name="coveredByOtherScreen"></param>
//        public override void UpdateScene()
//        {
//            // Update Character
//            character.Update(vxTime.DeltaTime, vxInput.PreviousKeyboardState,
//    vxInput.KeyboardState, vxInput.GamePadState, vxInput.GamePadState);

//            //foreach(Vector4 vec in Engine.Renderer.ShadowSplitTileBounds)
//            //    vxConsole.WriteToInGameDebug("Split Bounds: "+ vec);

//            //Update grabber
//            if (vxInput.MouseState.RightButton == ButtonState.Pressed && !grabber.IsGrabbing)
//            {
//                //Find the earliest ray hit
//                RayCastResult raycastResult;
//                if (PhyicsSimulation.RayCast(new Ray(Cameras[0].Position, Cameras[0].WorldMatrix.Forward), 500, rayCastFilter, out raycastResult))
//                {
//                    var entityCollision = raycastResult.HitObject as EntityCollidable;
//                    //If there's a valid ray hit, then grab the connected object!
//                    if (entityCollision != null && entityCollision.Entity.IsDynamic)
//                    {
//                        Console.WriteLine("GRABBING ITEM: {0}", entityCollision.Entity.GetType().ToString());
//                        grabber.Setup(entityCollision.Entity, raycastResult.HitData.Location);
//                        //grabberGraphic.IsDrawing = true;
//                        grabDistance = raycastResult.HitData.T;
//                    }
//                }
//            }

//            if (vxInput.MouseState.RightButton == ButtonState.Pressed && grabber.IsUpdating)
//            {
//                if (grabDistance < 4)
//                {
//                    grabDistance = 3;
//                    grabber.GoalPosition = Cameras[0].Position + Cameras[0].WorldMatrix.Forward * grabDistance;
//                }
//            }

//            else if (vxInput.MouseState.RightButton == ButtonState.Released && grabber.IsUpdating)
//            {
//                grabber.Release();
//                //grabberGraphic.IsDrawing = false;
//            }
//            vxConsole.WriteToScreen (this, "Update");
//            base.UpdateScene();
//        }

//		//public override void DrawGameplayScreen ()
//		//{
//		//	base.DrawGameplayScreen ();

//  //          vxConsole.WriteToScreen (this, "Draw");
//		//}
//        //Testing
//        public override void SimulationStart()
//        {

//            if (SandboxCurrentState == vxEnumSandboxStatus.EditMode)
//            {
//                SandboxCurrentState = vxEnumSandboxStatus.Running;

//                // Set the Camera type to chase Camera
//                character.Activate();
//                Cameras[0].CameraType = vxCameraType.CharacterFPS;
//            }
//            base.SimulationStart();
//        }
        


//        public override void SimulationStop()
//        {
//            if (SandboxCurrentState == vxEnumSandboxStatus.Running)
//            {
//                //Set Working Plane in its original Position
//                //workingPlane.Position = Vector3.Up * WrkngPln_HeightDelta;

//                SandboxCurrentState = vxEnumSandboxStatus.EditMode;

//                character.Deactivate();
//                //Camera.CameraType = CameraType.Freeroam;
//            }
//            base.SimulationStop();
//        }
//    }
//}
