using BEPUphysics;
using BEPUphysics.BroadPhaseEntries.MobileCollidables;
using FarseerPhysics.Collision.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using VerticesEngine;
using VerticesEngine.ContentManagement;
using VerticesEngine.Controllers;
using VerticesEngine.Entities;
using VerticesEngine.Graphics;
using VerticesEngine.Input;

namespace VerticesEngine.AppDemo
{
    public enum SandboxCategories
    {
        GridItems,
        RealWorldItems
    }


    public enum SandboxSubCategories
    {
        GridItems,
        ConstructionItems,
        NaturalItems,
    }

    /// <summary>
    /// This is a basic sandbox test level which both shows how to set up a basic sandbox
    /// with a number of test entities.
    /// </summary>
    public class BasicSandboxTestLevel : vxGameplayScene3D
    {
        MotorizedGrabSpring grabber;

        float grabDistance = 1;

        DrivableVehicle vehicle;

        public BasicSandboxTestLevel()
            : base(vxStartGameMode.Editor)
        {
            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
        }

        bool spawnCharacter = false;

        protected override void InitialiseCameras()
        {
            base.InitialiseCameras();


            foreach (var Camera in Cameras)
            {
                //Camera.Renderer.RenderingPasses.Insert(0, new BackgroundPostProcess(Camera.Renderer));
                Camera.CameraType = vxCameraType.Freeroam;

                if (spawnCharacter)
                {
                    character = new CharacterControllerInput(PhyicsSimulation, (vxCamera3D)Camera, vxEngine.Instance);

                    //Since this is the character playground, turn on the character by default.
                    character.Activate();


                    character.CharacterController.Body.Position = new Vector3(-50, 50, 50);
                    // Camera.Position = new Vector3(100, 100, 100);
                    ((vxCamera3D)Camera).Yaw = -MathHelper.PiOver4;
                    ((vxCamera3D)Camera).Pitch = -MathHelper.PiOver4 * 2 / 3;

                    var ChaseCamera = Camera.GetComponent<vxCameraChaseController>();

                    // Set the camera offsets
                    float scale = 2 * Camera.FieldOfView / MathHelper.PiOver4;
                    ChaseCamera.DesiredPositionOffset = new Vector3(0.0f, 1.5f / 2, 4.5f / scale);
                    ChaseCamera.LookAtOffset = new Vector3(0.0f, 0.50f, 0.0f);
                    ChaseCamera.Stiffness = 877500; // 450000 * (2) * 0.975f;
                    ChaseCamera.Damping = 18716.5775f; //35000 / (2.2f * 0.85f);

                    //Having the character body visible would be a bit distracting.
                    character.CharacterController.Body.Tag = "noDisplayObject";
                }

                Camera.ReqYaw = 0.78f;
                Camera.ReqPitch = -0.48f;

                Camera.NearPlane = 0.1f;
                Camera.FarPlane = 5000;

                Camera.FieldOfView = vxCamera.DefaultFieldOfView * MathHelper.Pi / 180;
            }

            var csm = vxRenderPipeline.Instance.GetRenderingPass<vxCascadeShadowRenderPass>();
            csm.IsEnabled = true;

            //	//Grabbers
            grabber = new MotorizedGrabSpring();
            PhyicsSimulation.Add(grabber);
            rayCastFilter = SelectionRayCastFilter;

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public override void LoadContent()
        {
            Console.WriteLine("loading...");
            base.LoadContent();

            Console.WriteLine("inital");


            //SkyBox.SkyboxTextureCube = Engine.Game.Content.Load<TextureCube>("Textures/skyboxes/Terra/skybox");

            SunEmitter.RotationX += 1.5f;



            
            Vector3 pos = new Vector3(15, 0, -2);

            ArenaEntity arena = new ArenaEntity(
            this,
                vxContentManager.Instance.Load<vxMesh>("Models/arena/arena"),
                new Vector3(0, 0, 0));

            new ConcreteCube(this, new Vector3(5, 3, 0));

            new GridBallx1(this, new Vector3(10, 3, 0));

            new GridBallx2(this, new Vector3(7, 3, 0));

            new GridCubex2(this, new Vector3(12, 3, 5));

            new SciFiCompositieCrate(this, new Vector3(14, 5, 5));

            vehicle = new DrivableVehicle(this, new Vector3(0, 30, 0));
           var chaseCamController = vehicle.AddComponent<CarChaseCamera>();
            chaseCamController.ChaseCamera = Cameras[0].GetComponent<vxCameraChaseController>();

            Console.WriteLine("Loaded");
            vxInput.IsCursorVisible = true;
        }


        bool isInVehicleMode = false;

        protected override void OnFirstUpdate()
        {
            base.OnFirstUpdate();

            SimulationStart();
            SimulationStop();

            vxSkyBox.Instance.IsVisible = true;

            this.SandBoxFile.Enviroment.SkyBox.SkyColourStrength1 = 1;
            this.SandBoxFile.Enviroment.SkyBox.SkyColourStrength2 = 1;
            this.SandBoxFile.Enviroment.SkyBox.SkyColourStrength3 = 1;
        }

        public override void ShowPauseScreen()
        {
            base.ShowPauseScreen();
        }

        /// <summary>
        /// Updates Main Gameplay Loop code here, this is affected by whether or not the scene is paused.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="otherScreenHasFocus"></param>
        /// <param name="coveredByOtherScreen"></param>
        protected override void UpdateScene()
        {
            // Update Character
            if (character != null)
                character.Update(vxTime.DeltaTime, vxInput.PreviousKeyboardState, vxInput.KeyboardState, vxInput.GamePadState, vxInput.GamePadState);

            if (SandboxCurrentState == vxEnumSandboxStatus.Running)
            {
                // handle Vehicle Mode 
                if (vxInput.IsNewKeyPress(Keys.V))
                {
                    isInVehicleMode = !isInVehicleMode;

                    if (isInVehicleMode)
                    {
                        //character.Deactivate();
                        vehicle.Activate();

                    }
                    else
                    {
                        //character.Activate();
                        vehicle.Deactivate();
                        Cameras[0].CameraType = vxCameraType.Freeroam;
                    }
                }

                if (isInVehicleMode)
                {

                }
                else
                {
                    //if (vxInput.IsNewMouseButtonPress(MouseButtons.LeftButton))
                    //{
                    //    var ball = new GridBallx1(this, Camera.Position + Camera.WorldMatrix.Forward * 2);
                    //    ball.OnSandboxStatusChanged(true);
                    //    ball.PhysicsCollider.ApplyImpulse(Camera.Position,
                    //                             Camera.WorldMatrix.Forward * 100 * ball.PhysicsCollider.Mass);

                    //}


                    //Update grabber
                    if (vxInput.MouseState.RightButton == ButtonState.Pressed && !grabber.IsGrabbing)
                    {
                        //Find the earliest ray hit
                        RayCastResult raycastResult;
                        if (PhyicsSimulation.RayCast(new Ray(Cameras[0].Position, Cameras[0].WorldMatrix.Forward), 500, rayCastFilter, out raycastResult))
                        {
                            var entityCollision = raycastResult.HitObject as EntityCollidable;
                            //If there's a valid ray hit, then grab the connected object!
                            if (entityCollision != null && entityCollision.Entity.IsDynamic)
                            {
                                Console.WriteLine("GRABBING ITEM: {0}", entityCollision.Entity.GetType());
                                grabber.Setup(entityCollision.Entity, raycastResult.HitData.Location);
                                //grabberGraphic.IsDrawing = true;
                                grabDistance = raycastResult.HitData.T;
                            }
                        }
                    }

                    if (vxInput.MouseState.RightButton == ButtonState.Pressed && grabber.IsUpdating)
                    {
                        if (grabDistance < 4)
                        {
                            grabDistance = 3;
                            grabber.GoalPosition = Cameras[0].Position + Cameras[0].WorldMatrix.Forward * grabDistance;
                        }
                    }

                    else if (vxInput.MouseState.RightButton == ButtonState.Released && grabber.IsUpdating)
                    {
                        grabber.Release();
                        //grabberGraphic.IsDrawing = false;
                    }
                }
            }
            vxConsole.WriteToScreen(this, "Update");
            base.UpdateScene();
        }



        //public override void DrawHUD()
        //{
        //    base.DrawHUD();

        //    if (SandboxCurrentState == vxEnumSandboxStatus.Running)
        //    {
        //        int sq = 3;
        //        Rectangle rec = new Rectangle(
        //        Viewport.Width / 2 - sq / 2, Viewport.Height / 2 - sq / 2, sq, sq);
        //        SpriteBatch.Begin();
        //        SpriteBatch.Draw(DefaultTexture, rec.GetBorder(1), Color.Black);
        //        SpriteBatch.Draw(DefaultTexture, rec, vxInput.IsMouseButtonPressed(MouseButtons.RightButton) ? Color.DeepSkyBlue : Color.White);
        //        SpriteBatch.End();
        //    }
        //}

        //Testing
        public override void SimulationStart()
        {
            IsEncodedIndexNeeded = false;

            if (SandboxCurrentState == vxEnumSandboxStatus.EditMode)
            {
                SandboxCurrentState = vxEnumSandboxStatus.Running;

                // Set the Camera type to chase Camera
                //character.Activate();
                //Cameras[0].CameraType = CameraType.CharacterFPS;

            }

            foreach (vxCamera3D camera in Cameras)
                camera.CameraType = vxCameraType.ChaseCamera;

            base.SimulationStart();
        }



        public override void SimulationStop()
        {
            IsEncodedIndexNeeded = true;
            vxInput.IsCursorVisible = true;
            isInVehicleMode = false;
            if (SandboxCurrentState == vxEnumSandboxStatus.Running)
            {
                //Set Working Plane in its original Position
                //workingPlane.Position = Vector3.Up * WrkngPln_HeightDelta;

                SandboxCurrentState = vxEnumSandboxStatus.EditMode;

                Cameras[0].CameraType = vxCameraType.Freeroam;
                //character.Deactivate();
                //Camera.CameraType = CameraType.Freeroam;
            }
            base.SimulationStop();
        }
    }
}
