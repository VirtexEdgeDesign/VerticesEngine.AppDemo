using BEPUphysics;
using BEPUphysics.BroadPhaseEntries.MobileCollidables;
using BEPUphysics.Entities.Prefabs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using VerticesEngine;
using VerticesEngine.ContentManagement;
using VerticesEngine.Controllers;
using VerticesEngine.Editor.Entities;
using VerticesEngine.Entities;
using VerticesEngine.Graphics;
using VerticesEngine.Input;

namespace VerticesEngine.AppDemo
{
    /// <summary>
    /// This is a basic sandbox test level which both shows how to set up a basic sandbox
    /// with a number of test entities.
    /// </summary>
    public class SponzaLightingTestLevel : vxGameplayScene3D
	{
		//MotorizedGrabSpring grabber;

		float grabDistance = 1;

        public SponzaLightingTestLevel():base(vxStartGameMode.Editor)
		{
			TransitionOnTime = TimeSpan.FromSeconds(1.5);
			TransitionOffTime = TimeSpan.FromSeconds(0.5);

		}



        protected override void InitialiseCameras()
        {
            base.InitialiseCameras();

            var Camera = (vxCamera3D)Cameras[0];

            Camera.CameraType = vxCameraType.Freeroam;

            //character = new CharacterControllerInput(PhyicsSimulation, Camera, Engine);

            ////Since this is the character playground, turn on the character by default.
            //character.Activate();


            //character.CharacterController.Body.Position = new Vector3(10, 0, 10);
            ////Having the character body visible would be a bit distracting.
            //character.CharacterController.Body.Tag = "noDisplayObject";


            SimulationStart();

            SimulationStop();

            //Grabbers
            //grabber = new MotorizedGrabSpring();
            //PhyicsSimulation.Add(grabber);
            //rayCastFilter = RayCastFilter;

                //Camera.Renderer.RenderingPasses.Insert(0, new BackgroundPostProcess(Camera.Renderer));

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public override void LoadContent()
		{
			base.LoadContent();


			// Set up Fog
            //Renderer.IsFogEnabled = false;
            //Renderer.FogNear = 20;
            //Renderer.FogFar = Camera.FarPlane / 10;
			SunEmitter.RotationX += 1.5f;


			Vector3 pos = new Vector3(15, 0, -2);


            Envrio envr = new Envrio(this,
                vxContentManager.Instance.Load<vxMesh>(AssetPaths.Models.COURTYARD_TD_COURTYARD_FBX),
                new Vector3(0, 0, 0));

			int size = 100;
			Box ground = new Box(new Vector3(0, -5.1f, 0), size, 10, size);
			PhyicsSimulation.Add(ground);

		}

		protected override void OnFirstUpdate()
		{
			base.OnFirstUpdate();

            vxSkyBox.Instance.IsVisible = true;
            //vxGizmo.Instance.IsEnabled = false;
            //vxGizmo.Instance.IsVisible = false;
            vxWorkingPlane.Instance.IsEnabled = false;
            this.SandBoxFile.Enviroment.SkyBox.SkyColourStrength1 = 1;
            this.SandBoxFile.Enviroment.SkyBox.SkyColourStrength2 = 1;
            this.SandBoxFile.Enviroment.SkyBox.SkyColourStrength3 = 1;
        }


		/// <summary>
		/// Updates Main Gameplay Loop code here, this is affected by whether or not the scene is paused.
		/// </summary>
		/// <param name="gameTime"></param>
		/// <param name="otherScreenHasFocus"></param>
		/// <param name="coveredByOtherScreen"></param>
		//public override void UpdateScene(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
		//{
		//          if (SandboxCurrentState == vxEnumSandboxStatus.Running)
		//          {
		//              // Update Character
		//              character.Update((float)gameTime.ElapsedGameTime.TotalSeconds, vxInput.PreviousKeyboardState,
		//      vxInput.KeyboardState, vxInput.GamePadState, vxInput.GamePadState);


		//              //Update grabber
		//              if (vxInput.MouseState.RightButton == ButtonState.Pressed && !grabber.IsGrabbing)
		//              {
		//                  //Find the earliest ray hit
		//                  RayCastResult raycastResult;
		//                  if (PhyicsSimulation.RayCast(new Ray(Cameras[0].Position, Cameras[0].WorldMatrix.Forward), 500, rayCastFilter, out raycastResult))
		//                  {
		//                      var entityCollision = raycastResult.HitObject as EntityCollidable;
		//                      //If there's a valid ray hit, then grab the connected object!
		//                      if (entityCollision != null && entityCollision.Entity.IsDynamic)
		//                      {
		//                          Console.WriteLine("GRABBING ITEM: {0}", entityCollision.Entity.GetType().ToString());
		//                          grabber.Setup(entityCollision.Entity, raycastResult.HitData.Location);
		//                          //grabberGraphic.IsDrawing = true;
		//                          grabDistance = raycastResult.HitData.T;
		//                      }
		//                  }
		//              }

		//              if (vxInput.MouseState.RightButton == ButtonState.Pressed && grabber.IsUpdating)
		//              {
		//                  if (grabDistance < 4)
		//                  {
		//                      grabDistance = 3;
		//                      grabber.GoalPosition = Cameras[0].Position + Cameras[0].WorldMatrix.Forward * grabDistance;
		//                  }
		//              }

		//              else if (vxInput.MouseState.RightButton == ButtonState.Released && grabber.IsUpdating)
		//              {
		//                  grabber.Release();
		//                  //grabberGraphic.IsDrawing = false;
		//              }
		//              vxConsole.WriteInGameDebug(this, "Update");
		//          }
		//	base.UpdateScene(gameTime, otherScreenHasFocus, coveredByOtherScreen);
		//}

		//public override void DrawGameplayScreen()
		//{
		//	base.DrawGameplayScreen();

		//          vxConsole.WriteToScreen(this, "Draw");
		//}
		//Testing
		public override void SimulationStart()
		{

            if (SandboxCurrentState == vxEnumSandboxStatus.EditMode)
			{
                SandboxCurrentState = vxEnumSandboxStatus.Running;

				// Set the Camera type to chase Camera
				//character.Activate();
				//Cameras[0].CameraType = CameraType.CharacterFPS;
			}
			base.SimulationStart();
		}



		public override void SimulationStop()
		{

            if (SandboxCurrentState == vxEnumSandboxStatus.Running)
			{
				//Set Working Plane in its original Position
				//workingPlane.Position = Vector3.Up * WrkngPln_HeightDelta;

                SandboxCurrentState = vxEnumSandboxStatus.EditMode;

				//character.Deactivate();

			}
			base.SimulationStop();
		}
	}
}
