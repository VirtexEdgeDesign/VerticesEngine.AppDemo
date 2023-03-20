using Microsoft.Xna.Framework;
using System;
using VerticesEngine;
using VerticesEngine.ContentManagement;
using VerticesEngine.Editor.Entities;
using VerticesEngine.Entities;
using VerticesEngine.Graphics;

namespace VerticesEngine.AppDemo
{
    /// <summary>
    /// This is the main class for the game. It holds the instances of the sphere simulator,
    /// the arena, the bsp tree, renderer, GUI (Overlay) and player. It contains the main 
    /// game loop, and provides keyboard and mouse input.
    /// </summary>
    public class IntroScene : vxGameplayScene3D
    {

        public IntroScene() : base(vxStartGameMode.GamePlay)
        {
            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);

        }


        protected override void InitialiseCameras()
        {
            base.InitialiseCameras();


            foreach (var Camera in Cameras)
            {
                Camera.CameraType = vxCameraType.Orbit;
                Camera.OrbitTarget = new Vector3(0, 0, 0);
                Camera.OrbitZoom = 2000;
                Camera.MaxZoom = 8000;

                Camera.ReqYaw = -0.78f;
                Camera.ReqPitch = -0.48f;
                Camera.BackBufferColour = Color.White;
            }
        }
        vxEntity3D spitfire;
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public override void LoadContent()
        {
            base.LoadContent();

            IsPausable = false;
            IsStartBackground = true;
            IsGUIVisible = false;
            IsSceneDimmedOnCover = false;
            HideIfCovered = false;

            SunEmitter.RotationX += 1.5f;

            spitfire = new vxEntity3D(vxContentManager.Instance.Load<vxMesh>(AssetPaths.Models.SPITFIRE_SPITFIRE_FBX), new Vector3(0, 0, 0));
            spitfire.Transform.Position += Vector3.Up * 1;
            //spitfire.Transform.Rotate(0, 0, 45);
            //spitfire.Transform.Rotation = Quaternion.CreateFromAxisAngle(Vector3.Forward, MathHelper.PiOver4);
        }

        float angle = 0;

        int cnt = 0;

        protected override void OnFirstUpdate()
        {
            base.OnFirstUpdate();

            IsPausable = false;

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
        protected override void UpdateScene()
        {
            //spitfire.Position += Vector3.One * vxTime.DeltaTime;
            //spitfire.Transform.Rotation *= Quaternion.CreateFromYawPitchRoll(0, 0, vxTime.DeltaTime);
            //spitfire.Transform.Rotate(spitfire.Transform.Forward, vxTime.DeltaTime * 30);

            spitfire.Transform.Rotate(0, vxTime.DeltaTime * 30, 0);


            cnt++;
            if (cnt == 2)
            {
                //vxSceneManager.LoadScene(new BasicSandboxTestLevel());
                //vxSceneManager.LoadScene(new SponzaLightingTestLevel());
            }

            base.UpdateScene();
        }
    }
}
